using NapierBank.Commands;
using NapierBank.Database;
using NapierBank.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NapierBank.ViewModels
{
    public class ViewEmailViewModel : BaseViewModel
    {
        public ObservableCollection<Email> emailMessages { get; set; } // Get and set information hald in JSON files

        public string ClearDataButtonText { get; private set; } // Var declaration to set text for button
        public ICommand ClearButtonCommand { get; private set; } // Link button to relaycommand

        //Constructor loads email JSON file 
        public ViewEmailViewModel()
        {
            LoadFromFile load = new LoadFromFile();

            if (!load.FromJsonEMAIL())
            {
                emailMessages = new ObservableCollection<Email>();
            }
            else
            {
                emailMessages = new ObservableCollection<Email>(load.EmailMessages);
            }

            ClearDataButtonText = "Clear Data"; // Text to be displayed on button
            ClearButtonCommand = new RelayCommand(ClearDataButtonClick); // When clicked button will call send method

        }

        // Clear data files
        private void ClearDataButtonClick()
        {
            System.IO.File.WriteAllText("Data/email.json", string.Empty);
            MessageBox.Show("DATA CLEARED");
        }
    }
}
