
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
            this.SuspendLayout();
            // 
            // btnSnakeGame
            // 
            this.btnSnakeGame.Location = new System.Drawing.Point(104, 102);
            this.btnSnakeGame.Name = "btnSnakeGame";
            this.btnSnakeGame.Size = new System.Drawing.Size(273, 29);
            this.btnSnakeGame.TabIndex = 0;
            this.btnSnakeGame.Text = "SnakeGame";
            this.btnSnakeGame.UseVisualStyleBackColor = true;
            this.btnSnakeGame.Click += new System.EventHandler(this.btnSnakeGame_Click);
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
            this.lblGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGames.Location = new System.Drawing.Point(181, 37);
            this.lblGames.Name = "lblGames";
            this.lblGames.Size = new System.Drawing.Size(120, 37);
            this.lblGames.TabIndex = 2;
            this.lblGames.Text = "Games";
            // 
            // GameJam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
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
    }
}