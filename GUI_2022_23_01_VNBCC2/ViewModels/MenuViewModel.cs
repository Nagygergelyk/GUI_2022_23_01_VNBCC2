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
using System.Windows.Input;

namespace GUI_2022_23_01_VNBCC2.ViewModels
{
    public class MenuViewModel : ObservableRecipient
    {
        MenuLogic logic;
        public BindingList<Player> Players { get; set; } //contains players
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
        public ICommand CreateNewGameCommand { get; set; }
        public ICommand LoadGameCommand { get; set; }
        public ICommand ControlsCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        //public ICommand ExitCommand { get; set; }

        public MenuViewModel(MenuLogic logic)
        {
            this.logic = logic;

            CreateNewGameCommand = new RelayCommand(() => {
                //this.MenuTitle = "Create new game";
                NewGameWindow ngw = new NewGameWindow();
                ngw.ShowDialog();
            });

            LoadGameCommand = new RelayCommand(() =>
            {
                this.MenuTitle = "Load game";
                
            });

            ControlsCommand = new RelayCommand(() =>
            {
                this.MenuTitle = "Controls";
            });

            SettingsCommand = new RelayCommand(() =>
            {
                this.MenuTitle = "Settings";
            });
        }

        public MenuViewModel() : this(new MenuLogic())
        {

        }
    }
}
