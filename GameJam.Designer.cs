
namespace GameJam
{
    partial class GameJam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSnakeGame = new System.Windows.Forms.Button();
            this.GameJamScoreList = new System.Windows.Forms.ListView();
            this.lblGames = new System.Windows.Forms.Label();
            this.btnTicTacToe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSnakeGame
            // 
            this.btnSnakeGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnakeGame.Location = new System.Drawing.Point(55, 137);
            this.btnSnakeGame.Name = "btnSnakeGame";
            this.btnSnakeGame.Size = new System.Drawing.Size(140, 33);
            this.btnSnakeGame.TabIndex = 0;
            this.btnSnakeGame.Tag = "";
            this.btnSnakeGame.Text = "Snake";
            this.btnSnakeGame.UseVisualStyleBackColor = true;
            this.btnSnakeGame.Click += new System.EventHandler(this.BtnGame_Click);
            // 
            // GameJamScoreList
            // 
            this.GameJamScoreList.GridLines = true;
            this.GameJamScoreList.HideSelection = false;
            this.GameJamScoreList.Location = new System.Drawing.Point(517, 12);
            this.GameJamScoreList.Name = "GameJamScoreList";
            this.GameJamScoreList.Size = new System.Drawing.Size(735, 657);
            this.GameJamScoreList.TabIndex = 1;
            this.GameJamScoreList.UseCompatibleStateImageBehavior = false;
            // 
            // lblGames
            // 
            this.lblGames.AutoSize = true;
            this.lblGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGames.Location = new System.Drawing.Point(181, 37);
            this.lblGames.Name = "lblGames";
            this.lblGames.Size = new System.Drawing.Size(120, 37);
            this.lblGames.TabIndex = 2;
            this.lblGames.Text = "Games";
            // 
            // btnTicTacToe
            // 
            this.btnTicTacToe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicTacToe.Location = new System.Drawing.Point(280, 137);
            this.btnTicTacToe.Name = "btnTicTacToe";
            this.btnTicTacToe.Size = new System.Drawing.Size(140, 33);
            this.btnTicTacToe.TabIndex = 3;
            this.btnTicTacToe.Tag = "";
            this.btnTicTacToe.Text = "TicTacToe";
            this.btnTicTacToe.UseVisualStyleBackColor = true;
            this.btnTicTacToe.Click += new System.EventHandler(this.BtnGame_Click);
            // 
            // GameJam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnTicTacToe);
            this.Controls.Add(this.lblGames);
            this.Controls.Add(this.GameJamScoreList);
            this.Controls.Add(this.btnSnakeGame);
            this.Name = "GameJam";
            this.Text = "GameJam";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSnakeGame;
        private System.Windows.Forms.ListView GameJamScoreList;
        private System.Windows.Forms.Label lblGames;
        private System.Windows.Forms.Button btnTicTacToe;
    }
}