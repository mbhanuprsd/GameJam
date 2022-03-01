using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameJam
{
    public partial class GameJam : Form
    {
        Dictionary<string, GameScore> ScoreDict = new Dictionary<string, GameScore>();
        IGameStats selectedGame;

        public GameJam()
        {
            InitializeComponent();
            SetupScoreListView();
        }

        private void SetupScoreListView()
        {
            GameJamScoreList.View = View.Details;
            GameJamScoreList.Columns.Add("Game").Width = 150;
            GameJamScoreList.Columns.Add("Score").Width = 150;
            GameJamScoreList.Columns.Add("Completed On").Width = 150;
            GameJamScoreList.GridLines = true;
        }

        private void UpdateScores(string gameTag, string score)
        {
            string timeStamp = DateTime.UtcNow.ToString("dd-MMM-yyyy HH:mm:ss");
            GameScore gameScore = new GameScore(gameTag, score, timeStamp);
            // Add to dictionary
            ScoreDict.Add(timeStamp, gameScore);
            // Add to list
            string[] row = { gameScore.GameTag, gameScore.Score, gameScore.TimeStamp };
            GameJamScoreList.Items.Add(new ListViewItem(row));
            // Add to save file

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
        }

        public object GetInstanceOf(string gameTag)
        {
            var obj = Activator.CreateInstance(Type.GetType("GameJam." + gameTag));
            if (obj == null) throw new InvalidOperationException("typeName is not supported");
            return obj;
        }
    }
}
