using GUI_2022_23_01_VNBCC2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public class GameLogic : IGameModel, IGameControl
    {
        public enum Items
        {
            table, floor, grill, deepfryer, output, start, cuttingboard, trash, plate, bunContainer, pattyContainer, cheeseContainer, lettuceContainer, baconContainer, onionContainer, sauceContainer,
            tomatoContainer, cucumberContainer, oilContainer, potatoContainer, glassContainer, drinkTap
        }

        public enum Directions { up, down, left, right }
        public enum Actions { space, esc }
        private IMenuLogic menuLogic;
        public Item[,] GameMatrix { get; set; }
        private Queue<string> levels;
        public Player[] ActualPlayers { get; set; }


        public GameLogic(IMenuLogic menuLogic)
        {
            this.menuLogic = menuLogic;

            levels = new Queue<string>();
            var lvls = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "*.txt");
            foreach (var item in lvls)
            {
                levels.Enqueue(item);

            }
            LoadNext(levels.Dequeue());
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
                case 'T': return new Storage() { item = Items.table, Image = "table.jpg" };
                case 'G': return new ItemOutput() { item = Items.grill, Image = "grill.jpg" };
                case 'D': return new ItemOutput() { item = Items.deepfryer, Image = "deepfryer.jpg" };
                case 'O': return new Item() { item = Items.output, Image = "output.jpg" };
                case 'S': return new Item() { item = Items.start, Image = "player1.jpg" };
                case 'C': return new ItemOutput() { item = Items.cuttingboard, Image = "cuttingboard.jpg" };
                case 'X': return new Trash() { item = Items.trash, Image = "trash.jpg" };
                case 'P': return new Container() { item = Items.plate, Image = "plateOnTable.jpg" };
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
                case 'H': return new ItemOutput() { item = Items.drinkTap, Image = "drinkTap.jpg" };
                default:
                    return new Item() { item = Items.floor, Image = "floor.jpg" };
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
                                GameMatrix[i, j].Interact();
                                GameMatrix[i, j] = new Item() { item = Items.start, Image = "player2.jpg" };
                            }
                        }
                    }
                    break;
                case Actions.esc:
                    GamePauseWindow1 gpw = new GamePauseWindow1();
                    if (gpw.ShowDialog() == false)
                    {
                        gpw.Close();
                    }
                    else
                    {
                        gpw.Close();
                        menuLogic.ExitGame();
                    }
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
                GameMatrix[i, j] = new Item() { item = Items.start, Image = "player1.jpg" };
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
