using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace GameJam
{
    public partial class TicTacToe : Form, IGameStats
    {
        const string statusX = "X", statusO = "O";

        string currentWinner = "";
        string player1Name = statusX, player2Name = statusO;
        bool isPlayer1Turn = true;
        int playCount = 0;

        List<List<int>> winConditions = new List<List<int>>();
        List<Button> tiles = new List<Button>();

        int player1WinCount = 0;
        int player2WinCount = 0;
        int tieCount = 0;

        public TicTacToe()
        {
            InitializeComponent();

            tiles = new List<Button>()
            { button1, button2, button3,
            button4, button5, button6,
            button7, button8, button9};

            // Win conditions
            winConditions.Add(new List<int>() { 0, 1, 2 });
            winConditions.Add(new List<int>() { 3, 4, 5 });
            winConditions.Add(new List<int>() { 6, 7, 8 });
            winConditions.Add(new List<int>() { 0, 3, 6 });
            winConditions.Add(new List<int>() { 1, 4, 7 });
            winConditions.Add(new List<int>() { 2, 5, 8 });
            winConditions.Add(new List<int>() { 0, 4, 8 });
            winConditions.Add(new List<int>() { 2, 4, 6 });
        }

        public event Action<string, string> GameOverEvent;

        protected override void OnClosing(CancelEventArgs e)
        {
            GameOverEvent?.Invoke(this.Name,
                player1Name + " : " + player1WinCount
                + ", " + player2Name + " : " + player2WinCount
                + ", Tie : " + tieCount);
            base.OnClosing(e);
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            int tileIndex = int.Parse((sender as Button).Name.Replace("button", "")) - 1;
            UpdateTileStatus(tileIndex);

            isPlayer1Turn = !isPlayer1Turn;
            lblTurn.Text = "Turn: " + (isPlayer1Turn ? player1Name : player2Name);
        }

        private void UpdateTileStatus(int tileIndex)
        {
            if (tiles[tileIndex].Text == "")
            {
                tiles[tileIndex].Text = isPlayer1Turn ? statusX : statusO;

                playCount++;
                CheckWinCondition();
            }
            else
            {
                MessageBox.Show("Already clicked!");
            }
        }

        private void CheckWinCondition()
        {
            Console.WriteLine("Play count: " + playCount);
            if (playCount == 9)
            {
                currentWinner = "";
                UpdateWins();
                return;
            }

            foreach (List<int> condition in winConditions)
            {
                if (tiles[condition[0]].Text == tiles[condition[1]].Text
                    && tiles[condition[1]].Text == tiles[condition[2]].Text
                    && tiles[condition[0]].Text != "")
                {
                    currentWinner = tiles[condition[0]].Text;
                    UpdateWins();
                }
            }
        }

        private void UpdateWins()
        {
            if (currentWinner == statusX) player1WinCount++;
            else if (currentWinner == statusO) player2WinCount++;
            else tieCount++;

            lblScore.Text = "Score:\n" + player1Name + " : " + player1WinCount
                + "\n" + player2Name + " : " + player2WinCount + "\nTies : " + tieCount;
            ToggleEnableGame(false);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (tbPlayer1.Enabled)
            {
                player1Name = (tbPlayer1.Text == "") ? statusX : tbPlayer1.Text;
                player2Name = (tbPlayer2.Text == "") ? statusO : tbPlayer2.Text;

                if (tbPlayer1.Text == "") tbPlayer1.Text = statusX;
                if (tbPlayer2.Text == "") tbPlayer2.Text = statusO;

                tbPlayer1.Enabled = false;
                tbPlayer2.Enabled = false;

                btnStart.Text = "Replay!";
            }

            ToggleEnableGame(true);
        }

        private void ToggleEnableGame(bool enableGame)
        {
            btnStart.Enabled = !enableGame;
            if (enableGame)
            {
                ResetGame();
            }
            else
            {
                for (int i = 0; i < tiles.Count; i++)
                {
                    tiles[i].Enabled = false;
                }
            }
        }

        private void ResetGame()
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].Text = "";
                tiles[i].Enabled = true;
            }

            isPlayer1Turn = true;
            currentWinner = "";
            playCount = 0;

            lblTurn.Text = "Turn: " + (isPlayer1Turn ? player1Name : player2Name);
        }
    }
}
