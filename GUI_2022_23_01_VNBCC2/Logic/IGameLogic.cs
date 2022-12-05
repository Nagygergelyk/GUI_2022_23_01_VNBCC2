using GUI_2022_23_01_VNBCC2.Models;
using System.Collections.Generic;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public interface IGameLogic
    {
        Player[] ActualPlayers { get; set; }
        Item[,] GameMatrix { get; set; }
        List</*Foods*/string> Ingredients { get; set; }

        void Action(GameLogic.Actions action);
        void Move(GameLogic.Directions directions);
        public Item Hand { get; set; }
        List<string> ActualOutput { get; set; }
    }
}