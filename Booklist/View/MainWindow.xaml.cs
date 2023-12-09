using Booklist.View;
using Booklist.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Booklist
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            ChangedGrid.Children.Add(new MainPage());
        }
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
