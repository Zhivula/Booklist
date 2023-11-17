using Booklist.Model;
using Booklist.View;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Booklist
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            ChangedGrid.Children.Add(new MainPage());
        }
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public ICommand CloseWindow => new DelegateCommand(o =>
        {
            this.Close();
        });
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
