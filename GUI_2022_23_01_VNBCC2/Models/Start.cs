using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Models
{
    public class Start : Item
    {
        private Item hand;
        private bool isEmpty = true;
        public Item Hand
        {
            get
            {
                if (!isEmpty)
                {
                    isEmpty = true;
                    return hand;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (isEmpty && value != null)
                {
                    isEmpty = false;
                    hand = value;
                }
            }
        }
    }
}
