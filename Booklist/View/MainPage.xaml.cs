using Booklist.ViewModel;
using System.Windows.Controls;

namespace Booklist.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }
    }
}