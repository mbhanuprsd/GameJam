using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GameJam
{
    public partial class GameJam : Form
    {
        internal class GameStats
        {
            [JsonProperty("scoreList")]
            public List<GameScore> scoreList { get; set; }
        }

        GameStats gameStats;

        IGameStats selectedGame;
        const string GameJamFileName = "GameJamData";

        public GameJam()
        {
            InitializeComponent();
            SetupScoreListView();
        }

        private void SetupScoreListView()
        {
            GameJamScoreList.View = View.Details;
            GameJamScoreList.AllowColumnReorder = true;
            GameJamScoreList.Columns.Add("Game").Width = 200;
            GameJamScoreList.Columns.Add("Score").Width = 300;
            GameJamScoreList.Columns.Add("Completed On").Width = 200;
            GameJamScoreList.GridLines = true;

            gameStats = new GameStats();
            gameStats.scoreList = new List<GameScore>();

            LoadSavedData();
        }

        private void UpdateScores(string gameTag, string score)
        {
            this.Visible = true;
            string timeStamp = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
            GameScore gameScore = new GameScore(gameTag, score, timeStamp);
            // Add to dictionary
            gameStats.scoreList.Add(gameScore);
            // Add to list
            string[] row = { gameScore.GameTag, gameScore.Score, gameScore.TimeStamp };
            GameJamScoreList.Items.Add(new ListViewItem(row));
            // Add to save file
            SaveGameStatsToFile();
        }

        private void SaveGameStatsToFile()
        {
            try
            {
                string output = JsonConvert.SerializeObject(gameStats);
                TextWriter statsWriter = new StreamWriter(Directory.GetCurrentDirectory() + "/" + GameJamFileName + ".json");
                statsWriter.Write(output);
                statsWriter.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while saving game stats to file!");
            }
        }

        private void LoadSavedData()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + GameJamFileName + ".json")) return;
            try
            {
                using (StreamReader statsReader = new StreamReader(Directory.GetCurrentDirectory() + "/" + GameJamFileName + ".json"))
                {
                    string statsJson = statsReader.ReadToEnd();
                    statsReader.Close();
                    gameStats = JsonConvert.DeserializeObject<GameStats>(statsJson);
                    foreach (GameScore gameScore in gameStats.scoreList)
                    {
                        string[] row = { gameScore.GameTag, gameScore.Score, gameScore.TimeStamp };
                        GameJamScoreList.Items.Add(new ListViewItem(row));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while loading game stats from file!");
            }
        }

        private void BtnGame_Click(object sender, EventArgs e)
        {
            string gameTag = (sender as Button).Text;
            OpenGame(gameTag);
        }

        private void OpenGame(string gameTag)
        {
            selectedGame = GetInstanceOf(gameTag) as IGameStats;
            (selectedGame as Form).Show();
            selectedGame.GameOverEvent -= UpdateScores;
            selectedGame.GameOverEvent += UpdateScores;
            this.Visible = false;
        }

        public object GetInstanceOf(string gameTag)
        {
            var obj = Activator.CreateInstance(Type.GetType("GameJam." + gameTag));
            if (obj == null) throw new InvalidOperationException("typeName is not supported");
            return obj;
        }
    }
}
