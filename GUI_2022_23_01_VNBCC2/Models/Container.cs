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
        Item storedItem;
        public Item StoredItem
        {
            get
            {
                if (storedItem != null)
                {
                    return storedItem;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (storedItem == null)
                {
                    storedItem = value;
                }
            }
        }
    }
}
