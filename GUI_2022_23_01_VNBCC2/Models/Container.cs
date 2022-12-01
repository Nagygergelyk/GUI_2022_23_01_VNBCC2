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
        bool stored = false;
        public Item StoredItem
        {
            get
            {
                if (stored)
                {
                    stored = false;
                    return storedItem;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (!stored)
                {
                    storedItem = value;
                    stored = true;
                }
            }
        }
    }
}
