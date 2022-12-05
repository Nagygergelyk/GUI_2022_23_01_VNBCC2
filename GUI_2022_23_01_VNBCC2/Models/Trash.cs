using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Models
{
    public class Trash : Item
    {
        Item storedItem;
        public Item StoredItem
        {
            get
            {
                return null;
            }
            set
            {
                storedItem = value;
            }
        }
    }
}
