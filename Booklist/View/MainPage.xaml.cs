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
            if(sender != null)
            {
                var grid = sender as Grid;
                var element = grid.DataContext as BookFilter;
                var window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

                var point = Mouse.GetPosition(grid);
                var x = point.X;
                var y = point.Y;
                if (grid.Children.Count > 0)
                {
                    for (int i = grid.Children.Count - 1; i >= 0; --i)
                    {
                        var childTypeName = grid.Children[i].GetType().Name;
                        if (childTypeName == nameof(PanelRightClick))
                        {
                            grid.Children.RemoveAt(i);
                        }
                    }
                }
                grid.Children.Add(new PanelRightClick(element.Id, x, y));
            }
        }
    }
}