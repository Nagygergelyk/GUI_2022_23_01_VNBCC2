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
        public double Score    //calculated from time, created foods number and reach level
        {
            get
            {
                return  Math.Round(Time * Level, 0);
            }
        }  
        public double Time { get; set; }  // ?DateTime?
        public int Level { get; set; }  //reached level

        public Player(string name)
        {
            this.Name = name;
        }
    }
}
