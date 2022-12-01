using GUI_2022_23_01_VNBCC2.Logic;
using GUI_2022_23_01_VNBCC2.Models;
using GUI_2022_23_01_VNBCC2.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace GUI_2022_23_01_VNBCC2.ViewModels
{
    public class MenuViewModel : ObservableRecipient
    {
        MenuLogic logic;
        public BindingList<Player> Players { get; set; } //contains players
        public BindingList<Player> Scoreboard { get; set; }
        string menuTitle = "Scoreboard";
        public string MenuTitle
        {
            get { return menuTitle; }
            set
            {
                this.menuTitle = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand ScoreCommand { get; set; }
        public ICommand CreateNewGameCommand { get; set; }
        public ICommand LoadGameCommand { get; set; }
        public ICommand ControlsCommand { get; set; }

        public MenuViewModel(MenuLogic logic)
        {
            this.logic = logic;

            this.Scoreboard = (logic.LoadScores() as BindingList<Player>);

            ScoreCommand = new RelayCommand(() =>
            {
                this.MenuTitle = "Scoreboard";
            });

            CreateNewGameCommand = new RelayCommand(() => {
                logic.NewGame();
            });

            LoadGameCommand = new RelayCommand(() =>
            {
                this.MenuTitle = "Load game";
                
            });

            ControlsCommand = new RelayCommand(() =>
            {
                this.MenuTitle = "Controls";
            });
        }

        public MenuViewModel() : this(new MenuLogic())
        {

        }
    }
}
