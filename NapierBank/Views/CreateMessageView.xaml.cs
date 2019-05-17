using NapierBank.ViewModels;
using System.Windows.Controls;

namespace NapierBank.Views
{
    /// <summary>
    /// Interaction logic for CreateMessageView.xaml
    /// </summary>
    public partial class CreateMessageView : UserControl
    {
        public CreateMessageView()
        {
            InitializeComponent();

            this.DataContext = new CreateMessageViewModel();
            
        }

      
       
    }


}
