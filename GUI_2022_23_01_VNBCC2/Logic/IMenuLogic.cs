using GUI_2022_23_01_VNBCC2.Models;
using System.Collections.Generic;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public interface IMenuLogic
    {
        void NewGame();
        IList<Player> Scoreoard();
        void Setup(IList<Player> players);
    }
}