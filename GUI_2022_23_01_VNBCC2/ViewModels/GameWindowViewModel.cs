using GUI_2022_23_01_VNBCC2.Logic;
using GUI_2022_23_01_VNBCC2.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.ViewModels
{
    public class GameWindowViewModel : ObservableRecipient
    {
        IGameLogic logic;
        public Player[] ActualPlayers { get; set; }
        private Player actualPlayer1;
        private Player actualPlayer2;
        public Player ActualPlayer1
        {
            get
            {
                if (actualPlayer1 != null)
                {
                    return actualPlayer1;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                actualPlayer1 = value;
                OnPropertyChanged();
            }
        }
        public Player ActualPlayer2 { get; set; }
        public List<string> ingredients { get; set; }
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
                return ingredients; ;
            }
            set
            {
                ingredients = value;
                OnPropertyChanged();
            }
        }

        public GameWindowViewModel()
        {
               
        }

        public void SetUp(IGameLogic logic)
        {
            this.logic = logic;

            this.ActualPlayer1 = logic.ActualPlayers[0];
            this.ActualPlayer2 = logic.ActualPlayers[1];

            Ingredients = logic.Ingredients;

        }
    }
}
