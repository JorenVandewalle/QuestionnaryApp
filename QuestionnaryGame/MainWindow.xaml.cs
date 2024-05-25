using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuestionnaryWpf;
using TriviaApiLibrary;
using QuestionnaryLibrary;
using ScoreboardLibrary;

namespace QuestionnaryGame
{
    public partial class MainWindow : Window, IQuestionHandler
    {
        private TriviaMultipleChoiceQuestion currentQuestion; // Stores the current question
        private List<Button> answerButtons; // List of answer buttons
        private List<Answer> answers; // List of answers

        private ScoreBoard scoreboard;
        private int questionCounter;
        private int answerCorrect;
        private string username;

        public MainWindow()
        {
            InitializeComponent();

            answerButtons = new List<Button> { FirstAnswerText, SecondAnswerText, ThirdAnswerText, FourthAnswerText };
            scoreboard = new ScoreBoard();

            questionCounter = 0;
            answerCorrect = 0;
        }

        private async void GetQuestion()
        {
            if (questionCounter < 10)
            {
                // Call the API to get a new question
                await TriviaApiRequester.RequestRandomQuestion(this);
                questionCounter++;
            }
            else
            {
                scoreboard.AddPlayer(username, answerCorrect);
                ScoreboardWindow scoreboardWindow = new ScoreboardWindow(scoreboard);
                scoreboardWindow.Show();
                this.Hide();
            }
        }

        public void ProcessQuestion(TriviaMultipleChoiceQuestion question)
        {
            currentQuestion = question;
            answers = new List<Answer>();

            // Adding the answers
            answers.Add(new Answer(question.CorrectAnswer, true));
            foreach (var incorrect in question.IncorrectAnswers)
            {
                answers.Add(new Answer(incorrect, false));
            }

            // Shuffle the answers
            Random rng = new Random();
            answers = answers.OrderBy(a => rng.Next()).ToList();

            QuestionText.Text = question.Question.Text;
            for (int i = 0; i < answerButtons.Count; i++)
            {
                if (i < answers.Count)
                {
                    answerButtons[i].Content = answers[i].Text;
                }
            }
        }

        private void CheckAnswer(int index)
        {
            if (answers[index].IsCorrect)
            {
                answerCorrect++;
            }
            else
            {
            }

            ScoreCounter.Text = $"Score: {answerCorrect.ToString()}/{questionCounter}";

            // New question after answering
            GetQuestion();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutPage aboutWindow = new AboutPage();
            this.Close();
            aboutWindow.Show();
        }

        private void Scoreboard_Click(object sender, RoutedEventArgs e)
        {
            ScoreboardWindow scoreboardWindow = new ScoreboardWindow(scoreboard);
            scoreboardWindow.Show();
        }

        private void First_Answer(object sender, RoutedEventArgs e) 
        { 
            CheckAnswer(0); 
        }
        private void Second_Answer(object sender, RoutedEventArgs e)
        {
            CheckAnswer(1);
        }
        private void Third_Answer(object sender, RoutedEventArgs e)
        {
            CheckAnswer(2);
        }
        private void Fourth_Answer(object sender, RoutedEventArgs e)
        {
            CheckAnswer(3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            username = userName.Text;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }
            firstPage.Visibility = Visibility.Hidden;
            questionaryGame.Visibility = Visibility.Visible;
            GetQuestion();
        }

        public void ResetGame()
        {
            questionCounter = 0;
            answerCorrect = 0;
            ScoreCounter.Text = $"Score: {answerCorrect.ToString()}/{questionCounter}";
            firstPage.Visibility = Visibility.Visible;
            questionaryGame.Visibility = Visibility.Hidden;
            userName.Text = "";
        }
    }
}
