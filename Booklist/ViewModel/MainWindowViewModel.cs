using Booklist.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MessageBox.Show("afdadsfasfd");
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
