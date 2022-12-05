using GUI_2022_23_01_VNBCC2.Models;
using System.Collections.Generic;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public interface IMenuLogic
    {
        public Player[] ActualPlayers { get; }
        void NewGame();
        void ExitGame();
        void Setup(IList<Player> players);
        IList<Player> LoadScores();
        void WriteScores(IList<Player> scores);
    }
}