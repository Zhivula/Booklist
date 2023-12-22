using Booklist.Model;
using Booklist.View;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Booklist.ViewModel
{
   public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {

        }
        public ICommand CloseWindow => new DelegateCommand(o =>
        {
            var window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            window.Close();
        });
        public ICommand AddBook => new DelegateCommand(o =>
        {
            var window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            window.ChangedGrid.Children.Add(new AddBookView());
        });
        public ICommand Statistics => new DelegateCommand(o =>
        {
            var window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            window.ChangedGrid.Children.Add(new StatisticsView());
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
