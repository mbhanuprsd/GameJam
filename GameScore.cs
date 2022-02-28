using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    class GameScore
    {
        private int score;
        private string timeStamp;
        private string gameTag;

        public GameScore(string gameTag, int score, string timeStamp)
        {
            this.score = score;
            this.timeStamp = timeStamp;
            this.gameTag = gameTag;
        }

        public int Score { get => score; }
        public string TimeStamp { get => timeStamp; }
        public string GameTag { get => gameTag; }
    }
}
