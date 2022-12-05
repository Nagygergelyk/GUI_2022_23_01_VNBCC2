using GUI_2022_23_01_VNBCC2.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public class GameLogic : IGameModel, IGameControl, IGameLogic
    {
        IMessenger messenger;

        public enum Items
        {
            table, floor, grill, deepfryer, output, start, cuttingboard, trash, plate, bunContainer, pattyContainer, cheeseContainer, lettuceContainer, baconContainer, onionContainer, sauceContainer,
            tomatoContainer, cucumberContainer, oilContainer, potatoContainer, glassContainer, drinkTap
        }
        public enum Foods
        {
            Bun, Patty, Cheese, Lettuce, Bacon, Onion, Sauce, Tomato, Cucumber, Fries, Drink
        }
        public enum Directions { up, down, left, right }
        public enum Actions { space, esc }


        private IMenuLogic menuLogic;
        public Item[,] GameMatrix { get; set; }
        public List</*Foods*/string> Ingredients { get; set; }
        private Queue<string> levels;
        private Queue<string> recipes;
        public Player[] ActualPlayers { get; set; }
        public string inHand;
        private Item hand;
        public Item Hand { get; set; }
        public List<string> ActualOutput { get; set; }


        public GameLogic(IMenuLogic menuLogic, IMessenger messenger)
        {
            this.menuLogic = menuLogic;
            this.messenger = messenger;
            //this.ActualPlayers = players;
            this.ActualPlayers = menuLogic.ActualPlayers;

            levels = new Queue<string>();
            var lvls = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "*.txt");
            foreach (var item in lvls)
            {
                levels.Enqueue(item);

            }
            LoadNext(levels.Dequeue());


            recipes = new Queue<string>();
            var rcps = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Recipes"), "*.txt");
            foreach (var item in rcps)
            {
                recipes.Enqueue(item);
            }
            LoadNextRecipe(recipes.Dequeue().ToLower());

            ActualOutput = new List<string>();
        }

        private void LoadNextRecipe(string path)
        {

            string line = File.ReadAllText(path);
            Ingredients = new List<string>();
            string[] split = line.Split(';');

            foreach (var item in split)
            {
                Ingredients.Add(item);
            }

        }
        private void LoadNext(string path)
        {
            string[] lines = File.ReadAllLines(path);
            GameMatrix = new Item[9, 12];
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    GameMatrix[i, j] = ConvertToItem(lines[i][j]);
                }
            }

        }
        private Item ConvertToItem(char v)
        {
            switch (v)
            {
                case 'T': return new Item() { item = Items.table, Image = "table.jpg" };
                case 'G': return new Item() { item = Items.grill, Image = "grill.jpg" };
                case 'D': return new Item() { item = Items.deepfryer, Image = "deepfryer.jpg" };
                case 'O': return new ItemOutput() { item = Items.output, Image = "output.jpg" };
                case 'S': return new Start() { item = Items.start, Image = "player1.jpg" };
                case 'C': return new Item() { item = Items.cuttingboard, Image = "cuttingboard.jpg" };
                case 'X': return new Trash() { item = Items.trash, Image = "trash.jpg" };
                case 'P': return new Storage() { item = Items.plate, Image = "plateOnTable.jpg" };
                case '1': return new Container() { item = Items.bunContainer, Image = "bunContainer.jpg" };
                case '2': return new Container() { item = Items.pattyContainer, Image = "pattyContainer.jpg" };
                case '3': return new Container() { item = Items.cheeseContainer, Image = "cheeseContainer.jpg" };
                case '4': return new Container() { item = Items.lettuceContainer, Image = "lettuceContainer.jpg" };
                case '5': return new Container() { item = Items.baconContainer, Image = "baconContainer.jpg" };
                case '6': return new Container() { item = Items.onionContainer, Image = "onionContainer.jpg" };
                case '7': return new Container() { item = Items.sauceContainer, Image = "sauceContainer.jpg" };
                case '8': return new Container() { item = Items.tomatoContainer, Image = "tomatoContainer.jpg" };
                case '9': return new Container() { item = Items.cucumberContainer, Image = "cucumberContainer.jpg" };
                case 'A': return new Container() { item = Items.oilContainer, Image = "oilContainer.jpg" };
                case 'B': return new Container() { item = Items.potatoContainer, Image = "potatoContainer.jpg" };
                case 'E': return new Container() { item = Items.glassContainer, Image = "glassContainer.jpg" };
                case 'H': return new Item() { item = Items.drinkTap, Image = "drinkTap.jpg" };
                default:
                    return new Item() { item = Items.floor, Image = "floor.jpg" };
            }
        }
        public bool CompareOutput()
        {
            bool isEqual = Enumerable.SequenceEqual(Ingredients, ActualOutput);
            if (isEqual)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Action(Actions action)
        {

            switch (action)
            {
                case Actions.space:
                    var coordinates = WhereAmI();
                    for (int i = coordinates[0] - 1; i < coordinates[0] + 2; i++)
                    {
                        for (int j = coordinates[1] - 1; j < coordinates[1] + 2; j++)
                        {
                            if (GameMatrix[i, j] is Item && GameMatrix[i, j].item != Items.start)
                            {
                                if (GameMatrix[i, j] is Container)
                                {
                                    (GameMatrix[coordinates[0], coordinates[1]] as Start).Hand = new Item() { Image = (GameMatrix[i, j] as Container).StoredItem };
                                    this.Hand = new Item() { Image = (GameMatrix[i, j] as Container).StoredItem };
                                    inHand = (GameMatrix[i, j] as Container).StoredItem.ToString();
                                    //messenger.Send("Hand changed", "HandInfo");
                                }
                                else if (GameMatrix[i, j] is Storage)
                                {
                                    (GameMatrix[i, j] as Storage).StoredItem = (GameMatrix[coordinates[0], coordinates[1]] as Start).Hand;
                                }
                                else if (GameMatrix[i, j] is Trash)
                                {
                                    (GameMatrix[coordinates[0], coordinates[1]] as Start).Hand = null;
                                    this.Hand = null;
                                    //messenger.Send("Hand changed", "HandInfo");
                                }
                                else if (GameMatrix[i, j] is ItemOutput)
                                {
                                    //ActualOutput.Add((GameMatrix[coordinates[0], coordinates[1]] as Start).Hand.Image);
                                    ActualOutput.Add(inHand);
                                    CompareOutput();
                                    (GameMatrix[coordinates[0], coordinates[1]] as Start).Hand = null;
                                    this.Hand = null;
                                    //messenger.Send("Output changed", "OutInfo");
                                    //messenger.Send("Hand changed", "HandInfo");
                                }
                            }
                        }
                    }
                    break;
                case Actions.esc:
                    menuLogic.ExitGame();
                    break;
            }
        }

        public void Move(Directions directions)
        {
            var coordinates = WhereAmI();
            int i = coordinates[0];
            int j = coordinates[1];
            int iOld = coordinates[0];
            int jOld = coordinates[1];
            switch (directions)
            {
                case Directions.up:
                    if (i - 1 >= 0)
                    {
                        i--;
                    }
                    break;
                case Directions.down:
                    if (i + 1 < GameMatrix.GetLength(0))
                    {
                        i++;
                    }
                    break;
                case Directions.left:
                    if (j - 1 >= 0)
                    {
                        j--;
                    }
                    break;
                case Directions.right:
                    if (j + 1 < GameMatrix.GetLength(1))
                    {
                        j++;
                    }
                    break;
            }
            if (GameMatrix[i, j].item == Items.floor)
            {
                GameMatrix[iOld, jOld] = new Item() { item = Items.floor, Image = "floor.jpg" };
                GameMatrix[i, j] = new Start() { item = Items.start, Image = "player1.jpg" };
            }
            if (CompareOutput())
            {
                if (levels.Count > 0)
                {
                    LoadNext(levels.Dequeue());
                    LoadNextRecipe(recipes.Dequeue());
                }
            }
        }

        int[] WhereAmI()
        {
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    if (GameMatrix[i, j].item == Items.start)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
