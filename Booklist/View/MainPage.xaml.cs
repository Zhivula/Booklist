using Booklist.Data;
using Booklist.Resourses;
using Booklist.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void ListBoxItemPageViewCommand(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var grid = sender as Grid;
            var element = grid.DataContext as BookFilter;
            var window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            var point = Mouse.GetPosition(grid);
            var x = point.X;
            var y = point.Y;

            window.ChangedGrid.Children.Add(new PanelRightClick(element.Id, x, y));
        }
    }
}