using NapierBank.Commands;
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
    public class ReportsViewModel : BaseViewModel
    {
        // Set upgetters and setters for the text insid textboxes
        public string MentionsTextBox { get; set; }
        public string SIRTextBox { get; set; }
        public string HashtagTextBox { get; set; }

        public string ClearDataButtonText { get; private set; } // Var declaration to set text for button
        public ICommand ClearButtonCommand { get; private set; } // Link button to relaycommand

        // Constructor to set all of the textboxes to empty
        public ReportsViewModel()
        {
            MentionsTextBox = string.Empty;
            SIRTextBox = string.Empty;
            HashtagTextBox = string.Empty;

            ClearDataButtonText = "Clear Data"; // Text to be displayed on button
            ClearButtonCommand = new RelayCommand(ClearDataButtonClick); // When clicked button will call send method
        }

        // Clear data files
        private void ClearDataButtonClick()
        {
            System.IO.File.WriteAllText("Data/trends.csv", string.Empty);
            MessageBox.Show("DATA CLEARED");
        }





    }


}
