using NapierBank.Commands;
using NapierBank.Database;
using NapierBank.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NapierBank.ViewModels
{
    public class ViewMessageViewModel : BaseViewModel
    {
        public ObservableCollection<Sms> smsMessages { get; set; } // Get and set information hald in JSON files

        public string ClearDataButtonText { get; private set; } // Var declaration to set text for button
        public ICommand ClearButtonCommand { get; private set; } // Link button to relaycommand

        //Constructor loads sms JSON file 
        public ViewMessageViewModel()
        {

            LoadFromFile load = new LoadFromFile();

           
            
            if (!load.FromJsonSMS())
            {
                smsMessages = new ObservableCollection<Sms>();
            }
            else
            {
                smsMessages = new ObservableCollection<Sms>(load.SmsMessages);
            }

            ClearDataButtonText = "Clear Data"; // Text to be displayed on button
            ClearButtonCommand = new RelayCommand(ClearDataButtonClick); // When clicked button will call send method


        }

        // Clear data files
        private void ClearDataButtonClick()
        {
            System.IO.File.WriteAllText("Data/sms.json", string.Empty);
            MessageBox.Show("DATA CLEARED");
        }






    }
}
