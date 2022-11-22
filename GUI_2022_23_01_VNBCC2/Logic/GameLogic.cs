using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public class GameLogic //: IGameModel, IGameControl
    {
        public enum Items
        {
            table, floor, grill, deepfryer, output, start, cuttingboard, trash, plate, bread, meat, cheese, salad, bacon, onion, sauce, tomato, cucumber, oil, potato, glasses, drink
        }
        public enum Directions { up, down, left, right }
        public Items[,] GameMatrix { get; set; }
        private Queue<string> levels;
        public GameLogic()
        {
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
        public void Move(Directions direction)
        {
            switch (direction)
            {
                case Directions.up:
                    break;
                case Directions.down:
                    break;
                case Directions.left:
                    break;
                case Directions.right:
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
