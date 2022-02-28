using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameJam
{
    public partial class GameJam : Form
    {
        Dictionary<string, GameScore> ScoreDict = new Dictionary<string, GameScore>();
        const string SNAKE_GAME = "Snake";
        const string TICTACTOE_GAME = "TicTacToe";
        Snake snakeGame;

        public GameJam()
        {
            InitializeComponent();
            SetupScoreListView();
        }

        private void SetupScoreListView()
        {
            GameJamScoreList.View = View.Details;
            GameJamScoreList.Columns.Add("Game");
            GameJamScoreList.Columns.Add("Score");
            GameJamScoreList.Columns.Add("Completed On");
            GameJamScoreList.GridLines = true;
            GameJamScoreList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void UpdateSnakeGameScore(int score)
        {
            UpdateScores(score, SNAKE_GAME);
        }

        private void UpdateScores(int score, string gameTag)
        {
            string timeStamp = DateTime.UtcNow.ToString("dd-MMM-yyyy HH:mm:ss");
            GameScore gameScore = new GameScore(gameTag, score, timeStamp);
            if (ScoreDict.ContainsKey(timeStamp))
            {
                ScoreDict[timeStamp] = gameScore;
            }
            else
            {
                ScoreDict.Add(timeStamp, gameScore);
            }
            string[] row = { gameScore.GameTag, gameScore.Score.ToString(), gameScore.TimeStamp };
            GameJamScoreList.Items.Add(new ListViewItem(row));
        }

        private void btnSnakeGame_Click(object sender, EventArgs e)
        {
            snakeGame = new Snake();
            snakeGame.Show();
            snakeGame.SnakeGameStatus -= UpdateSnakeGameScore;
            snakeGame.SnakeGameStatus += UpdateSnakeGameScore;
        }
    }
}
