using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaryLibrary
{
    public class Question
    {
        private List<Answer> possibleAnswer;
        public string Text { get; set; }
        public string ImageUrl { get; set; }


        public Question(string text)
        {
            Text = text;
            possibleAnswer = new List<Answer>();
        }

        public void Add(Answer answer)
        {
            possibleAnswer.Add(answer);
        }

        public Answer GetAnswer(int index)
        {
            return possibleAnswer[index];
        }

        // Return the list
        public List<Answer> Answers
        {
            get { return new List<Answer>(possibleAnswer); }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
