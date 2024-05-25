using System;
using System.Collections.Generic;
using QuestionnaryLibrary;

namespace QuestionnaryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list for questions
            List<Question> questions = new List<Question>();

            // Question 1
            Question capitalBelgium = new Question("What is the capital of Belgium?");
            capitalBelgium.Add(new Answer("Brussels", true));
            capitalBelgium.Add(new Answer("London", false));
            capitalBelgium.Add(new Answer("Berlin", false));
            capitalBelgium.Add(new Answer("Madrid", false));
            questions.Add(capitalBelgium);

            // Question 2
            Question capitalFrance = new Question("What is the capital of France?");
            capitalFrance.Add(new Answer("Paris", true));
            capitalFrance.Add(new Answer("London", false));
            capitalFrance.Add(new Answer("Marseille", false));
            capitalFrance.Add(new Answer("Lille", false));
            questions.Add(capitalFrance);

            foreach (Question question in questions)
            {
                Console.WriteLine("Question: " + question.ToString());

                for (int i = 0; i < question.Answers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Answers[i].Text}");
                }

                // Get user input
                Console.Write("Your answer (enter the number): ");
                int userAnswer = int.Parse(Console.ReadLine());

                // Check if the answer is correct
                if (question.Answers[userAnswer - 1].IsCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect. The correct answer is {GetCorrectAnswer(question)}.\n");
                    Console.ResetColor();
                }
            }
        }

        // To find the correct answer
        static string GetCorrectAnswer(Question question)
        {
            foreach (var answer in question.Answers)
            {
                if (answer.IsCorrect)
                {
                    return answer.Text;
                }
            }
            return "No correct answer found";
        }
    }
}
