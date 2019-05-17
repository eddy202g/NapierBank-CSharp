using NapierBank.Commands;
using NapierBank.Database;
using NapierBank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NapierBank.ViewModels
{
    public class CreateTweetViewModel : BaseViewModel
    {
        #region textboxes
        public string HeaderTextBox { get; set; } // Var declaration to set Header
        public string SenderTextBox { get; set; } // Var declaration to set Sender
        public string BodyTextBox { get; set; } // Var declaration to set BodyText
        #endregion

        #region Get ID
        public string ID { get; set; } // Set up getters and setters for ID string
        #endregion

        #region String Declarations
        public string newMessage = ""; // Set up and initialise string
        #endregion

        #region Boolean Setup
        public bool saveRegular = false; // Set boolean to false
        public bool saveTrend = false; // Set boolean to false
        #endregion

        #region Add Button Content/Command
        public string SendButtonText { get; private set; } // Var declaration to set text for button
        public ICommand SendButtonCommand { get; private set; } // Link button to relaycommand

        public string ClearButtonText { get; private set; } // Var declaration to set text for button
        public ICommand ClearButtonCommand { get; private set; } // Link button to relaycommand
        #endregion

        #region Constructor
        // This Constructor sets up the content displayed in each of the components of
        // the UI, setting most of the components to empty, but calling the GenerateID method
        // to create a random Unique ID to be displayed in the header. It also sets up the buttons 
        // to call the methods that allow them to function
        public CreateTweetViewModel()
        {
            ID = "T";  // Identifier to be concatenated with random ID

            HeaderTextBox = ID + GenerateID();
            BodyTextBox = string.Empty;
            SenderTextBox = string.Empty;

            SendButtonText = "Send";
            ClearButtonText = "Clear";

            SendButtonCommand = new RelayCommand(SendButtonClick);
            ClearButtonCommand = new RelayCommand(ClearButtonClick);
        }
        #endregion


        #region Send Button Functionality
        // This method contains the functionality to be executed when button is pressed. 
        // It ensures all fileds are filled before sending, creates and saves an tweet object, 
        // and provides expanded form of any abbreviations. It also takes mentions and hashtags
        // from body and saves them to trends file
        private void SendButtonClick()
        {
            List<string> CsvLines = new List<String>(); // list to hold information to be sent to trends file

            Textspeak(); // Call Textspeak method

            // If statement prompts user to fill in all fields before message can be sent, by checking if the 
            // component is empty
            if (string.IsNullOrWhiteSpace(HeaderTextBox) || string.IsNullOrWhiteSpace(SenderTextBox) || string.IsNullOrWhiteSpace(BodyTextBox))
            {
                MessageBox.Show("Please Enter All Values");
                return;
            }

            // Split body text and save strings that begin with an '@' or '#' to trnds file
            var links = BodyTextBox.Split("\t\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(s => s.StartsWith("@") || s.StartsWith("#"));
            foreach (string s in links)
            {
                CsvLines.Add(s);
                File.AppendAllLines("Data/trends.csv", CsvLines);

            }

            // If statement checks if body contains textspeak abbreviation, if true creates new object and adds
            // textspeak, then saves to json file 
            if (saveRegular == true)
            {
                Tweet tweetMessage = new Tweet()
                {
                    Header = HeaderTextBox,
                    Sender = SenderTextBox,      
                    Body = newMessage
                };

                SaveToFile save = new SaveToFile();

                // If cannot be saved display error message, otherwise save file
                if (!save.ToJsonTweet(tweetMessage))
                {
                    MessageBox.Show("Error While Saving\n" + save.ErrorCode);
                }
                else
                {
                    MessageBox.Show("Order Saved");
                    save = null;
                }
            }

            // If statement checks if body contains textspeak abbreviation, if false creates new object and saves standard body, 
            // then saves to json file 
            if (saveRegular == false)
            {

                Tweet tweetMessage = new Tweet()
                {
                    Header = HeaderTextBox,
                    Sender = SenderTextBox,         
                    Body = BodyTextBox
                };

                SaveToFile save = new SaveToFile();

                // If cannot be saved display error message, otherwise save file
                if (!save.ToJsonTweet(tweetMessage))
                {
                    MessageBox.Show("Error While Saving\n" + save.ErrorCode);
                }
                else
                {
                    MessageBox.Show("Order Saved");
                    save = null;
                }
            }

        }
        #endregion

        #region Clear Button Functionality
        // Method to clear textboxes on button click
        private void ClearButtonClick()
        {
            SenderTextBox = string.Empty;
            BodyTextBox = string.Empty;

            OnChanged(nameof(SenderTextBox));
            OnChanged(nameof(BodyTextBox));
        }
        #endregion

        #region Text speak 
        // Method to add textspeak meaning. Searches textword csv file, and returns expanded abbreviation
        private string Textspeak()
        {
            var rows = File.ReadAllLines("Data/textwords.csv").Select(l => l.Split(',').ToArray()).ToArray(); // Split csv file by delimiter and add to string array

            // Loop iterates through string array, and checks if the textbox contains abbreviation contained
            // in the array. If it does, adds abbreviation and its meaning to string variable
            for (int i = 0; i < rows.GetLength(0); i++)
            {
                if (BodyTextBox.Contains(rows[i][0]))
                {
                    newMessage = BodyTextBox.Replace(rows[i][0].ToString(), rows[i][0].ToString() + "<" + rows[i][1].ToString() + ">"); // Add abbreviation and meaning to string
                    saveRegular = true;
                }

            }

            return newMessage; // return string
        }
        #endregion

        #region ID Generator
        // This function generates random ID and returns the ID
        private string GenerateID()
        {
            Random random = new Random(); // New instance of random class
            string r = ""; // Initialise string
            int i; // Initialise counter

            // loop and create 9-digit random number
            for (i = 1; i < 10; i++)
            {
                r += random.Next(0, 8).ToString(); // Add random number to string
            }

            return r; // Return string
        }
        #endregion
    }
}
