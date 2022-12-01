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
        private Player[] actualPlayers;
        private List<Player> players;

        public MenuLogic()
        {
            actualPlayers = new Player[2];
        }

        public MenuLogic(INewGameWindowService newGameWindowService)
        {
            this.newGameWindowService = newGameWindowService;
        }

        public void Setup(IList<Player> players)
        {

        }

        public void NewGame()
        {
            NewGameWindow ngw = new NewGameWindow(actualPlayers);
            if (ngw.ShowDialog() == true)
            {
                GameWindow gw = new GameWindow();
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
    }
}
