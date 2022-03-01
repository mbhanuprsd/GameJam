using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    interface IGameStats
    {
        event Action<string, string> GameOverEvent;
    }

    class GameScore
    {
        private string score;
        private string timeStamp;
        private string gameTag;

        public GameScore(string gameTag, string score, string timeStamp)
        {
            this.score = score;
            this.timeStamp = timeStamp;
            this.gameTag = gameTag;
        }

        public string Score { get => score; }
        public string TimeStamp { get => timeStamp; }
        public string GameTag { get => gameTag; }
    }
}
