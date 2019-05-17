using NapierBank.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NapierBank.Views
{
    /// <summary>
    /// Interaction logic for CreateEmailView.xaml
    /// </summary>
    public partial class CreateEmailView : UserControl
    {
        public CreateEmailView()
        {
            InitializeComponent();
            this.DataContext = new CreateEmailViewModel();
        }

        private void ChkBox_Checked(object sender, RoutedEventArgs e)
        {
            if(ChkBox.IsChecked == true)
            { 
                ComboBox.IsEnabled = true;
            }

            if(ChkBox.IsChecked == false)
            {
                ComboBox.IsEnabled = false;
            }
                
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmailTextBox.AcceptsReturn = true;
            EmailTextBox.TextWrapping = TextWrapping.Wrap;
        }
    }
}
