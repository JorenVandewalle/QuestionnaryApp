namespace ScoreboardLibrary
{
    public class PlayerScore
    {
        private string name;
        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public PlayerScore(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public override string ToString()
        {
            return $"{Name}: {Score}";
        }
    }
}
