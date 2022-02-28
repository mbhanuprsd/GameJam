using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GameJam
{
    public partial class Snake : Form
    {
        public event Action<int> SnakeGameStatus;

        private int cols = 50, rows = 25, score = 0,
            dx = 0, dy = 0, front = 0, back = 0;
        int scale = 20;
        int fps = 50;
        Piece[] snake = new Piece[1250];
        List<int> available = new List<int>();
        bool[,] visit;

        Random rand = new Random();
        Timer timer = new Timer();

        public Snake()
        {
            InitializeComponent();
            StartGame();
        }

        private void LaunchTimer()
        {
            timer.Interval = fps;
            timer.Tick += MoveSnake;
            timer.Start();
        }

        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            dx = dy = 0;
            switch(e.KeyCode)
            {
                case Keys.Right:
                    dx = scale;
                    break;
                case Keys.Left:
                    dx = -scale;
                    break;
                case Keys.Up:
                    dy = -scale;
                    break;
                case Keys.Down:
                    dy = scale;
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SnakeGameStatus?.Invoke(score);
            base.OnClosing(e);
        }

        private void MoveSnake(object sender, EventArgs e)
        {
            int x = snake[front].Location.X, y = snake[front].Location.Y;
            if (dx == 0 && dy == 0) return;
            if (GameOver(x + dx, y + dy))
            {
                StopGame("Game Over!");
                return;
            }
            if(CollisionFood(x + dx, y+ dy))
            {
                score += 1;
                lblScore.Text = "Score: " + score;
                if (Hits((y + dy) / scale, (x + dx) / scale)) return;
                Piece head = new Piece(x + dx, y + dy, scale);
                front = (front - 1 + 1250) % 1250;
                snake[front] = head;
                visit[head.Location.Y / scale, head.Location.X / scale] = true;
                Controls.Add(head);
                RandomFood();
            }
            else
            {
                if (Hits((y + dy) / scale, (x + dx) / scale)) return;
                visit[snake[back].Location.Y / scale, snake[back].Location.X / scale] = false;
                front = (front - 1 + 1250) % 1250;
                snake[front] = snake[back];
                snake[front].Location = new Point(x + dx, y + dy);
                back = (back - 1 + 1250) % 1250;
                visit[(y + dy) / scale, (x + dx) / scale] = true;
            }
        }

        private void StopGame(string message)
        {
            timer.Tick -= MoveSnake;
            timer.Stop();
            DialogResult result = MessageBox.Show("Closing the game.", message, MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void RandomFood()
        {
            available.Clear();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!visit[i, j]) available.Add(i * cols + j);
                }
            }
            int idx = rand.Next(available.Count) % available.Count;
            lblFood.Left = (available[idx] * scale) % Width;
            lblFood.Top = (available[idx] * scale) / Width * scale;
        }

        private bool Hits(int x, int y)
        {
           if (visit[x, y])
            {
                timer.Stop();
                StopGame("Snake hit its body");
                return true;
            }
            return false;
        }

        private bool CollisionFood(int x, int y)
        {
            return x == lblFood.Location.X && y == lblFood.Location.Y;
        }

        private bool GameOver(int x, int y)
        {
            return x < 0 || y < 0 || x > cols*scale - scale || y > rows*scale- scale;
        }

        private void StartGame()
        {
            available.Clear();
            snake = new Piece[1250];

            dx = dy = score = front = back = 0;
            visit = new bool[rows, cols];

            Piece head
                = new Piece((rand.Next() % cols) * scale,
                (rand.Next() % rows) * scale, scale);
            lblFood.Location
                = new Point((rand.Next() % cols) * scale,
                (rand.Next() % rows) * scale);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    visit[i, j] = false;
                    available.Add(i * cols + j);
                }
            }
            visit[head.Location.Y / scale, head.Location.X / scale] = true;
            available.Remove(head.Location.Y / scale * cols + head.Location.X / scale);
            Controls.Add(head);
            snake[front] = head;

            LaunchTimer();
        }
    }
}
