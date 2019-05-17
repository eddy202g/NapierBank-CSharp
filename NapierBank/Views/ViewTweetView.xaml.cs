using NapierBank.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ViewTweetView.xaml
    /// </summary>
    public partial class ViewTweetView : UserControl
    {
        public ViewTweetView()
        {
            InitializeComponent();

            this.DataContext = new ViewTweetViewModel();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox.Text = ComboBox.SelectedItem.ToString();

        }
    }
}
