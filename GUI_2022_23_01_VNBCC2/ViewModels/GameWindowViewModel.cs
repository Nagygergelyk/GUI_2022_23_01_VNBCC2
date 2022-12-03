using GUI_2022_23_01_VNBCC2.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.ViewModels
{
    public class GameWindowViewModel
    {
        GameLogic logic;

        public GameWindowViewModel(GameLogic logic)
        {
            this.logic = logic;
        }
        //not sure this is good
        public List<string> Ingredients
        {
            get
            {
               /*for (int i = 0; i < logic.ingredients.Count; i++)
                {
                    return logic.ingredients[i];
                }
                foreach (var item in logic.ingredients)
                {
                    return item;
                }*/
                return logic.ingredients;
            }
        }
        public GameWindowViewModel() : this(new GameLogic(new MenuLogic()))
        {

        }
    }
}
