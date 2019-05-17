using NapierBank.ViewModels;
using Newtonsoft.Json;
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
    /// Interaction logic for ViewMessageView.xaml
    /// </summary>
    public partial class ViewMessageView : UserControl
    {
        public ViewMessageView()
        {
            InitializeComponent();

            this.DataContext = new ViewMessageViewModel();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox.Text = ComboBox.SelectedItem.ToString();
        }
    }
}
