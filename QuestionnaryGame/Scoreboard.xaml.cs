using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ScoreboardLibrary;

namespace QuestionnaryGame
{
    public partial class ScoreboardWindow : Window
    {
        private ScoreBoard scoreboard;

        public ScoreboardWindow(ScoreBoard scoreboard)
        {
            InitializeComponent();
            this.scoreboard = scoreboard;

            UpdateScoreboard();
        }

        private void UpdateScoreboard()
        {
            // Clear the listbox
            ScoreboardList.Items.Clear();

            // Add each player score to the listbox
            foreach (PlayerScore playerScore in scoreboard.ScoreList)
            {
                ScoreboardList.Items.Add(playerScore.ToString());
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ResetGame();
            mainWindow.Show();
            this.Close();
        }
    }
}
