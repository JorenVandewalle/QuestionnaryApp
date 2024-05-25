namespace QuestionnaryLibrary
{
    public class Answer
    {
        public string Text { get;}
        public bool IsCorrect { get;}

        public Answer(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
