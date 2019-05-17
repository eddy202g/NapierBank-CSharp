using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using NapierBank.Commands;
using NapierBank.Database;
using NapierBank.Models;

namespace NapierBank.ViewModels
{
    public class CreateEmailViewModel : BaseViewModel
    {
        #region textboxes
        // Set up getters and setters for each of the textboxes
        public string HeaderTextBox { get; set; }
        public string SenderTextBox { get; set; }
        public string SubjectTextBox { get; set; }
        public string SortTextBox { get; set; }
        public string BodyTextBox { get; set; }
        #endregion

        #region Textblocks
        // Set up getters and setters for each of the Textblocks
        public string IncidentTextBlock { get; private set; }
        #endregion

        #region Comboboxes
        // Set up getters and setters for any comboboxes
        public string IncidentCombo { get; set; }
        #endregion

        #region Get ID
        // Set up getters and setters for ID string
        public string ID { get; set; }
        #endregion

        #region Boolean Setup
        // Set up boolean values
        public bool saveRegular = false;
        public bool Incident { get; set; }
        #endregion

        #region List Setup
        // Setup list tobe displayed in the combobox
        private readonly Email _incidentList;
        #endregion*     

        #region Add Button Content/Command
        // Set up getters and setters for button text and button commands
        public string SendButtonText { get; private set; }
        public ICommand SendButtonCommand { get; private set; }

        public string ClearButtonText { get; private set; }
        public ICommand ClearButtonCommand { get; private set; }
        #endregion

        #region Constructor
        // Constructor creates list to be pushed into combo, and sets up all of the components of the
        // UI. It also calls the GenerateID method to create a random Unique ID to be displayed in the header,
        // as well as setting up the buttons to call the methods that allow them to function
        public CreateEmailViewModel()
        {
           _incidentList = new Email(); // New list

            IncidentTextBlock = string.Empty; // Textblock to empty



            ID = "E"; // Identifier to be concatenated with random ID
            HeaderTextBox = ID + GenerateID(); // Fill Header with concatenated ID
            SenderTextBox = string.Empty; // Textbox to empty
            SubjectTextBox = string.Empty; // Textbox to empty
            SortTextBox = RandomSort() + "-" + RandomSort() + "-" + RandomSort(); // Textbox to empty
            IncidentCombo = string.Empty; // Textbox to empty
            BodyTextBox = string.Empty; // Textbox to empty

            Incident = false; // Set boolean to false

            SendButtonText = "Send"; // Text to be displayed on button
            ClearButtonText = "Clear"; // Text to be displayed on button
            IncidentTextBlock = "Incident Report?"; // Text to be displayed label for incident

            SendButtonCommand = new RelayCommand(SendButtonClick); // When clicked button will call send method
            ClearButtonCommand = new RelayCommand(ClearButtonClick); // When clicked button will call clear method
        }
        #endregion

        #region Send Button Functionality
        // This method contains the functionality to be executed when button is pressed. 
        // It ensures all fields are filled before sending, creates and saves an EMail object, 
        // Removes and quarantines URL's, and serialises information from certain textboxes
        private void SendButtonClick()
        {
            List<string> CsvLines = new List<String>(); // Create a list to hold SORT CODE 
            List<string> CsvLines2 = new List<String>(); // Create a list to hold combo box values 

            // If statement prompts user to fill in all fields before message can be sent, by checking if the 
            // component is empty
            if (string.IsNullOrWhiteSpace(HeaderTextBox) || string.IsNullOrWhiteSpace(SenderTextBox) || string.IsNullOrWhiteSpace(SubjectTextBox) ||
               string.IsNullOrWhiteSpace(SortTextBox) || string.IsNullOrWhiteSpace(BodyTextBox))
            {
                MessageBox.Show("Please Enter All Values");
                return;
            }

            // Split up the values held in the sortcode box
            var links = SortTextBox.Split("\t\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(s => s.StartsWith("0") || s.StartsWith("1") || s.StartsWith("2") || s.StartsWith("3")
            || s.StartsWith("4") || s.StartsWith("5") || s.StartsWith("6") || s.StartsWith("7") || s.StartsWith("8") || s.StartsWith("9"));
            
            // Feed sort code values into trends file
            foreach (string s in links)
            {
                CsvLines.Add(s);
                File.AppendAllLines("Data/trends.csv", CsvLines);
            }

            // Feed value fromincident box into trends list
            CsvLines2.Add(IncidentCombo);
            File.AppendAllLines("Data/trends.csv", CsvLines2);

            QuarantineURL(); // Call method which quarantines URL's

            // If statement checks if body contains textspeak abbreviation, if true creates new object and adds
            // textspeak, then saves to json file 
            if (saveRegular == true)
            {
                Email emailMessage = new Email()
                {
                    Header = HeaderTextBox,
                    Sender = SenderTextBox,
                    Subject = SubjectTextBox,
                    Incident = IncidentCombo,
                    SortCode = SortTextBox,
                    Body = QuarantineURL()
                };

                SaveToFile save = new SaveToFile();

                // If cannot be saved display error message, otherwise save file
                if (!save.ToJsonEMail(emailMessage))
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
                Email emailMessage = new Email()
                {
                    Header = HeaderTextBox,
                    Sender = SenderTextBox,
                    Subject = SubjectTextBox,
                    Incident = IncidentCombo,
                    Body = BodyTextBox
                };

                SaveToFile save = new SaveToFile();

                // If cannot be saved display error message, otherwise save file
                if (!save.ToJsonEMail(emailMessage))
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

        #region ID Generator
        private string GenerateID()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 10; i++)
            {
                r += random.Next(0, 8).ToString();
            }

            return r;
        }
        #endregion

        #region Random Sort Code
        // This function randomly generates a 2 digit number to make up
        // the Sort Code
        private string RandomSort()
        {
            Random random = new Random(); // New instance of random class
            string randomSortOne = ""; // Initialise string
            int i; // Initialise counter

            // loop and create 2-digit random number
            for (i = 1; i < 3; i++)
            {
                randomSortOne += random.Next(0, 8).ToString(); // Add random number to string

            }

            return randomSortOne; // Return string
        }
        #endregion

        // This method splits up the information held in the bodt textbox depending on wether it 
        // is a URL or not. If it finds a URL, it removes the URL and replaces it with a quarantined message
        #region Quarantine Method
        private string QuarantineURL()
        {

            string swap = "";

            var links = BodyTextBox.Split("\t\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(s => s.StartsWith("http://") || s.StartsWith("www.") || s.StartsWith("https://")
                        || s.StartsWith("HTTP://") || s.StartsWith("WWW.") || s.StartsWith("HTTPS://"));
            foreach (string s in links)
            {

                if (BodyTextBox.Contains(s))
                {
                    swap = BodyTextBox.Replace(s, "<URL Quarantined>");

                    saveRegular = true;
                }
            }
            //MessageBox.Show(swap);
            return swap;
        }
        #endregion

        // Create incident list for combobox
        #region Create Incident List     
        public ObservableCollection<string> IncidentList
        {
            get { return _incidentList.IncidentList; }
            set { _incidentList.IncidentList = value; }
        }
        #endregion

    }
}
