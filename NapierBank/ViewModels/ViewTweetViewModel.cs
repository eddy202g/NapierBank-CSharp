using NapierBank.Commands;
using NapierBank.Database;
using NapierBank.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NapierBank.ViewModels
{
    class ViewTweetViewModel : BaseViewModel
    {
        public ObservableCollection<Tweet> tweetMessages { get; set; } // Get and set information hald in JSON files

        public string BodyTextBox { get; set; } // get and set body text

        public string ClearDataButtonText { get; private set; } // Var declaration to set text for button
        public ICommand ClearButtonCommand { get; private set; } // Link button to relaycommand

        #region Add Button Content/Command
        // Set up getters and setters for button text and button commands
        public string ViewTrendsText { get; private set; }
        public ICommand ViewTrendsCommand { get; private set; }
        #endregion

        // Contructor loads JSON files for tweets
        public ViewTweetViewModel()
        {

            LoadFromFile load = new LoadFromFile();

            ViewTrendsText = "View Trends";

            if (!load.FromJsonTWEET())
            {
                tweetMessages = new ObservableCollection<Tweet>();
            }
            else
            {
                tweetMessages = new ObservableCollection<Tweet>(load.TweetMessages);
            }

            BodyTextBox = string.Empty;

            ClearDataButtonText = "Clear Data"; // Text to be displayed on button
            ClearButtonCommand = new RelayCommand(ClearDataButtonClick); // When clicked button will call send method

        }

        // Clear data files
        private void ClearDataButtonClick()
        {
            System.IO.File.WriteAllText("Data/tweet.json", string.Empty);

            MessageBox.Show("DATA CLEARED");
        }


    }
}
