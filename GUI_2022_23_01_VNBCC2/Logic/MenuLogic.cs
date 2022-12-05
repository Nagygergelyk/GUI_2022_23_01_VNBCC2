using GUI_2022_23_01_VNBCC2.Models;
using GUI_2022_23_01_VNBCC2.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public class MenuLogic : IMenuLogic
    {
        private INewGameWindowService newGameWindowService;
        private Player[] actualPlayers = new Player[2];
        public Player[] ActualPlayers { get { return actualPlayers; } }
        private List<Player> players;
        private GameWindow gw;
        private GameLogic gameLogic;

        public MenuLogic()
        {
            //actualPlayers = new Player[2];
        }

        public MenuLogic(INewGameWindowService newGameWindowService)
        {
            this.newGameWindowService = newGameWindowService;
        }

        public void Setup(IList<Player> players)
        {
            this.players = (players as List<Player>);
        }

        public void NewGame()
        {
            NewGameWindow ngw = new NewGameWindow(ref actualPlayers);
            if (ngw.ShowDialog() == true)
            {
                gameLogic = new GameLogic(this);
                gw = new GameWindow(gameLogic);
                gw.ShowDialog();
            }
            ;
            //newGameWindowService.CreateGame(ref actualPlayers);
        }

        public IList<Player> LoadScores()
        {
            if (File.Exists("score.json"))
            {
                string scores = File.ReadAllText("score.json");
                return JsonConvert.DeserializeObject<IList<Player>>(scores);
            }
            else
            {
                return default;
            }
        }

        public void WriteScores(IList<Player> scores)
        {
            if (scores != null)
            {
                string jsonContent = JsonConvert.SerializeObject(scores);
                File.WriteAllText("score.json", jsonContent);
            }
            
        }

        public void ExitGame()
        {
            gw.Close();
        }
    }
}
