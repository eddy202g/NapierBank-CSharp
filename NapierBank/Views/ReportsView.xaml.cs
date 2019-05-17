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
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        public ReportsView()
        {
            InitializeComponent();

            this.DataContext = new ReportsViewModel();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = File.ReadLines("Data/trends.csv").ToList();

            list.RemoveAll(i => !i.Contains('@'));

            foreach (string t in list)
            {
                MentionsTxtB.Text = string.Join(Environment.NewLine, list);
                
            }
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = File.ReadLines("Data/trends.csv").ToList();

            list.RemoveAll(i => !i.Contains('#'));

            foreach (string t in list)
            {
                t.Remove(0);
                HashTxtB.Text = string.Join(Environment.NewLine, list);                
            }
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = File.ReadLines("Data/trends.csv").ToList();

            list.RemoveAll(i => i.Contains('@') || i.Contains('#'));

            foreach (string t in list)
            {
                SirTxtB.Text = string.Join(Environment.NewLine, list);
            }
        }
    }
}
