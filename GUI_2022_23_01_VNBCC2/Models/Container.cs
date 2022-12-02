using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GUI_2022_23_01_VNBCC2.Logic.GameLogic;

namespace GUI_2022_23_01_VNBCC2.Models
{
    public class Container : Item
    {
        private Item storedItem;
        public Item StoredItem
        {
            get { return storedItem; }
            set { storedItem = value; }
        }
    }
}
