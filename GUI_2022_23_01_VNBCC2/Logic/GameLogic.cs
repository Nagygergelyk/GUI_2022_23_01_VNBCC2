using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public class GameLogic //: IGameModel, IGameControl
    {
        public enum Items { }
        public enum Directions { up, down, left, right }

        public GameLogic()
        {

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
