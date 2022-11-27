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
        public enum Actions { up, down, left, right, space }
        public Items[,] GameMatrix { get; set; }
        private Queue<string> levels;
        public Player[] ActualPlayers{ get; set; }


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
            GameMatrix = new Items[12, 9];
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    GameMatrix[i, j] = ConvertToEnum(lines[i][j]);
                }
            }

        }
        private Items ConvertToEnum(char v)
        {
            switch (v)
            {
                case 'T': return Items.table;
                case 'G': return Items.grill;
                case 'D': return Items.deepfryer;
                case 'O': return Items.output;
                case 'S': return Items.start;
                case 'C': return Items.cuttingboard;
                case 'X': return Items.trash;
                case 'P': return Items.plate;
                case '1': return Items.bread;
                case '2': return Items.meat;
                case '3': return Items.cheese;
                case '4': return Items.salad;
                case '5': return Items.bacon;
                case '6': return Items.onion;
                case '7': return Items.sauce;
                case '8': return Items.tomato;
                case '9': return Items.cucumber;
                case 'A': return Items.oil;
                case 'B': return Items.potato;
                case 'E': return Items.glasses;
                case 'H': return Items.drink;
                default:
                    return Items.floor;
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
