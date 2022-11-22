using static GUI_2022_23_01_VNBCC2.Logic.GameLogic;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public interface IGameModel
    {
        Items[,] GameMatrix { get; set; }
    }
}