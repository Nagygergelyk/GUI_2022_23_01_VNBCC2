using GUI_2022_23_01_VNBCC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GUI_2022_23_01_VNBCC2.Logic.GameLogic;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public interface IGameModel
    {
        Item[,] GameMatrix { get; set; }
    }
}
