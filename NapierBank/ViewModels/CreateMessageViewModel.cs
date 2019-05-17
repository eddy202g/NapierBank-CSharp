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
    public class CreateMessageViewModel : BaseViewModel
    {
        #region textboxes
        public string HeaderTextBox { get; set; } // Var declaration to set Header
        public string SenderTextBox { get; set; } // Var declaration to set Sender
        public string BodyTextBox { get; set; } // Var declaration to set BodyText
        #endregion

        #region Get ID
        public string ID { get; set; } // Var declaration to set unique ID for header
        #endregion

        #region Add Button Content/Command
        public string SendButtonText { get; private set; } // Var declaration to set text for button
        public ICommand SendButtonCommand { get; private set; } // Link button to relaycommand

        public string ClearButtonText { get; private set; } // Var declaration to set text for button
        public ICommand ClearButtonCommand { get; private set; } // Link button to relaycommand
        public object Page { get; }
        #endregion

        #region Boolean Setup
        public bool saveRegular = false; // Set boolean to false
        #endregion

        #region String Declarations
        public string newMessage = ""; // Set up and initialise string
        #endregion

        #region Constructor
        // This Constructor sets up the content displayed in each of the components of
        // the UI, setting most of the components to empty, but calling the GenerateID method
        // to create a random Unique ID to be displayed in the header. It also sets up the buttons 
        // to call the methods that allow them to function
        public CreateMessageViewModel()
        {
            string intCode = "+44 7";
            ID = "S"; // Identifier to be concatenated with random ID

            HeaderTextBox = ID + GenerateID(); // FIll Header with concatenated ID
            SenderTextBox = intCode + RandomPhoneNo(); // Clear textbox
            BodyTextBox = string.Empty; // Clear textbox

            SendButtonText = "Send"; // Text to be displayed on button
            ClearButtonText = "Clear"; // Text to be displayed on button

            SendButtonCommand = new RelayCommand(SendButtonClick); // When clicked button will call send method
            ClearButtonCommand = new RelayCommand(ClearButtonClick); // When clicked button will call clear method
        }
        #endregion

        #region Send Button Functionality
        // This method contains the functionality to be executed when button is pressed. 
        // It ensures all fileds are filled before sending, creates and saves an sms object, 
        // and provides meaning of any abbreviations
        private void SendButtonClick()
        {
            
            // If statement prompts user to fill in all fields before message can be sent, by checking if the 
            // component is empty
            if (string.IsNullOrWhiteSpace(HeaderTextBox) || string.IsNullOrWhiteSpace(SenderTextBox) || string.IsNullOrWhiteSpace(BodyTextBox))
            {
                MessageBox.Show("Please Enter All Values");
                return;
            }

            Textspeak(); // Call Textspeak method

            // If statement checks if body contains textspeak abbreviation, if true creates new object and adds
            // textspeak, then saves to json file 
            if (saveRegular == true)
            {           
                // Create object
                Sms smsMessage = new Sms()
                {
                    Header = HeaderTextBox, // Set header 
                    Sender = SenderTextBox, // Set sender
                    Body = newMessage // Set body to  textspeak
                };

                SaveToFile save = new SaveToFile(); // Create new instance of SaveToFIle class

                // If cannot be saved display error message, otherwise save file
                if (!save.ToJsonSms(smsMessage))
                {
                    MessageBox.Show("Error While Saving\n" + save.ErrorCode); // Display error code
                }
                else
                {
                    MessageBox.Show("Order Saved"); // Let user know file has been saved
                    save = null;
                }
            }

            // If statement checks if body contains textspeak abbreviation, if false creates new object and saves standard body, 
            // then saves to json file 
            if (saveRegular == false)
            {              
                Sms smsMessage = new Sms()
                {
                    Header = HeaderTextBox, // Set header 
                    Sender = SenderTextBox, // Set sender
                    Body = BodyTextBox // Set body to standard body text
                };

                SaveToFile save = new SaveToFile(); // Create new instance of SaveToFIle class

                // If cannot be saved display error message, otherwise save file
                if (!save.ToJsonSms(smsMessage))
                {
                    MessageBox.Show("Error While Saving\n" + save.ErrorCode); // Display error code
                }
                else
                {
                    MessageBox.Show("Order Saved"); // Let user know file has been saved
                    save = null;
                }
            }
        }
        #endregion

        #region Clear Button Functionality
        // Method to clear textboxes on button click
        private void ClearButtonClick()
        {          
            BodyTextBox = string.Empty; //  Set textbox to empty

            OnChanged(nameof(BodyTextBox)); // Acknowledge change has happened
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

        #region Random Tele Number
        // This function randomly generates a 9 digit number to make up
        // the telephone number in the sender box
        private string RandomPhoneNo()
        {
            Random random = new Random(); // New instance of random class
            string randomTele = ""; // Initialise string
            int i; // Initialise counter

            // loop and create 9-digit random number
            for (i = 1; i < 10; i++)
            {
                randomTele += random.Next(0,8).ToString(); // Add random number to string
            }

            return randomTele; // Return string
        }
        #endregion
    }


}
