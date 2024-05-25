using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardLibrary
{
    public class ScoreBoard
    {
        private List<PlayerScore> scoreList;

        public ScoreBoard()
        {
            scoreList = new List<PlayerScore>();
        }

        public void AddPlayer(string name,int score)
        {
            scoreList.Add(new PlayerScore(name,score));
        }

        public override string ToString()
        {
            string scoreboardString = "Scoreboard:\n";
            foreach (var playerScore in scoreList)
            {
                scoreboardString += playerScore.ToString() + "\n";
            }
            return scoreboardString;
        }

        public void SortScoreBoard()
        {
            scoreList.Sort();
        }

        public List<PlayerScore> ScoreList
        {
            get { return scoreList; }
        }
    }
}
