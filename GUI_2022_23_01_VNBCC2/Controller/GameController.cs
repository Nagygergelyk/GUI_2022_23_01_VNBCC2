using GUI_2022_23_01_VNBCC2.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static GUI_2022_23_01_VNBCC2.Logic.GameLogic;

namespace GUI_2022_23_01_VNBCC2.Controller
{
    internal class GameController
    {
        IGameControl control;

        public GameController(IGameControl control)
        {
            this.control = control;
        }

        public void PressedKey(Key k)
        {
            switch (k)
            {
                case Key.Up:
                    control.Move(Directions.up);
                    break;
                case Key.Down:
                    control.Move(Directions.down);
                    break;
                case Key.Left:
                    control.Move(Directions.left);
                    break;
                case Key.Right:
                    control.Move(Directions.right);
                    break;
                case Key.Space:
                    control.Action(Actions.space);
                    break;
                case Key.Escape:
                    control.Action(Actions.esc);
                    break;
            }
        }
    }
}
