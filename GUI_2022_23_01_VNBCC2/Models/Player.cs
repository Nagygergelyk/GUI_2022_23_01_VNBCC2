using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }  //calculated from time, created food and reach level
        public DateTime Time { get; set; }  //??
        public int Level { get; set; }  //reached level

        public Player(string name)
        {
            this.Name = name;
        }
    }
}
