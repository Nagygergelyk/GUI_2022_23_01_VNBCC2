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
            table, floor, grill, deepfryer, output, start, cuttingboard, trash, plate, bread, meat, cheese, salad, bacon, onion, sauce, tomato, cucumber, oil, potato, glasses, drink
        }

        public enum Actions { up, down, left, right, space, esc }
        public Item[,] GameMatrix { get; set; }
        private Queue<string> levels;
        public Player[] ActualPlayers { get; set; }


        public GameLogic()
        {
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
            GameMatrix = new Item[12, 9];
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
                case 'T': return new Container() { item = Items.table, Image = "table.jpg"};
                case 'G': return new Container() { item = Items.grill, Image = "table.jpg" };
                case 'D': return new Container() { item = Items.deepfryer, Image = "deepfryer.jpg" };
                case 'O': return new Container() { item = Items.output, Image = "output.jpg" };
                case 'S': return new Container() { item = Items.start, Image = "start.jpg" };
                case 'C': return new Container() { item = Items.cuttingboard, Image = "cuttingboard.jpg" };
                case 'X': return new Container() { item = Items.trash, Image = "trash.jpg" };
                case 'P': return new Container() { item = Items.plate, Image = "plate.png" };
                case '1': return new Container() { item = Items.bread, Image = "bread.png" };
                case '2': return new Container() { item = Items.meat, Image = "meat.png" };
                case '3': return new Container() { item = Items.cheese, Image = "cheese.png" };
                case '4': return new Container() { item = Items.salad, Image = "salad.png" };
                case '5': return new Container() { item = Items.bacon, Image = "Bacon.png" };
                case '6': return new Container() { item = Items.onion, Image = "onion.png" };
                case '7': return new Container() { item = Items.sauce, Image = "sauce.png" };
                case '8': return new Container() { item = Items.tomato, Image = "tomato.png" };
                case '9': return new Container() { item = Items.cucumber, Image = "cucumber.png" };
                case 'A': return new Container() { item = Items.oil, Image = "oil.png" };
                case 'B': return new Container() { item = Items.potato, Image = "potato.png" };
                case 'E': return new Container() { item = Items.glasses, Image = "glasses.png" };
                case 'H': return new Container() { item = Items.drink, Image = "drink.png" };
                default:
                    return new Item() { item = Items.floor, Image = "floor.jpg" };
            }
        }
        public void Move(Actions action)
        {
            switch (action)
            {
                case Actions.up:
                    break;
                case Actions.down:
                    break;
                case Actions.left:
                    break;
                case Actions.right:
                    break;
                case Actions.space:
                    break;
                case Actions.esc:
                    break;
                default:
                    break;
            }
        }

        int[] WhereAmI()
        {
            return default;
        }
    }
}
