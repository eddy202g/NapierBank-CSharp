using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using NapierBank.Commands;
using NapierBank.Views;


namespace NapierBank.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Button Content
        // Getters and setters for each button, to set display text and link buttons to 
        // relaycommand class
        public string CreateMessageButtonContent { get; private set; }
        public string CreateEmailButtonContent { get; private set; }
        public string CreateTweetButtonContent { get; private set; }

        public string ViewMessageButtonContent { get; private set; }
        public string ViewEmailButtonContent { get; private set; }
        public string ViewTweetButtonContent { get; private set; }

        public string ReportsButtonContent { get; private set; }

        public ICommand CreateMessageButtonCommand { get; private set; }
        public ICommand CreateEmailButtonCommand { get; private set; }
        public ICommand CreateTweetButtonCommand { get; private set; }


        public ICommand ViewMessageButtonCommand { get; private set; }
        public ICommand ViewEmailButtonCommand { get; private set; }
        public ICommand ViewTweetButtonCommand { get; private set; }

        public ICommand ReportsButtonCommand { get; private set; }
        #endregion

        #region Control control
        public UserControl ContentControlBinding { get; private set; } // Set control binding to alert to any changes
        #endregion

        #region Constructor
        // This constructor sets all of the text to be displayed on each button, and 
        // calls relaycommand to open user control hen a button is pushed
        public MainWindowViewModel()
        {
            CreateMessageButtonContent = "Send SMS";
            CreateEmailButtonContent = "Send Email";
            CreateTweetButtonContent = "Send Tweet";

            ViewMessageButtonContent = "View SMS";
            ViewEmailButtonContent = "View Email";
            ViewTweetButtonContent = "View Tweet";

            ReportsButtonContent = "View Reports";

            CreateMessageButtonCommand = new RelayCommand(CreateMessageButtonClick);
            CreateEmailButtonCommand = new RelayCommand(CreateEmailButtonClick);
            CreateTweetButtonCommand = new RelayCommand(CreateTweetButtonClick);

            ViewMessageButtonCommand = new RelayCommand(ViewMessageButtonClick);
            ViewEmailButtonCommand = new RelayCommand(ViewEmailButtonClick);
            ViewTweetButtonCommand = new RelayCommand(ViewTweetButtonClick);

            ReportsButtonCommand = new RelayCommand(ReportsButtonClick);

            ContentControlBinding = new DefaultView(); // set default view of Main Window
        }
        #endregion

        #region Private Click Helpers
        // Series of methods that are called when each biutton is clicked, opens
        // appropriate user control and alerts to changes
        private void CreateMessageButtonClick()
        {
            ContentControlBinding = new CreateMessageView();
            OnChanged(nameof(ContentControlBinding));
        }

        private void CreateEmailButtonClick()
        {
            ContentControlBinding = new CreateEmailView();
            OnChanged(nameof(ContentControlBinding));
        }

        private void CreateTweetButtonClick()
        {
            ContentControlBinding = new CreateTweetView();
            OnChanged(nameof(ContentControlBinding));
        }

        private void ViewMessageButtonClick()
        {
            ContentControlBinding = new ViewMessageView();
            OnChanged(nameof(ContentControlBinding));
        }

        private void ViewEmailButtonClick()
        {
            ContentControlBinding = new ViewEmailView();
            OnChanged(nameof(ContentControlBinding));
        }

        private void ViewTweetButtonClick()
        {
            ContentControlBinding = new ViewTweetView();
            OnChanged(nameof(ContentControlBinding));
        }

        private void ReportsButtonClick()
        {
            ContentControlBinding = new ReportsView();
            OnChanged(nameof(ContentControlBinding));
        }
        #endregion


    }
}
