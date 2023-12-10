using Booklist.ViewModel;
using System.Windows.Controls;

namespace Booklist.View
{
    /// <summary>
    /// Логика взаимодействия для AddBookView.xaml
    /// </summary>
    public partial class AddBookView : UserControl
    {
        public AddBookView()
        {
            InitializeComponent();
            DataContext = new AddBookViewModel();
        }
    }
}
