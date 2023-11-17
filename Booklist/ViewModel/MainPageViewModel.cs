using Booklist.DataBase;
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
    class MainPageViewModel : INotifyPropertyChanged
    {
        private List<Book> books;
        public List<Book> Books
        {
            get => books;
            set
            {
                books = value;
                OnPropertyChanged(nameof(Books));
            }
        }
        public MainPageViewModel()
        {
            var mainPageModel = new MainPageModel();
            Books = mainPageModel.ListMainPage;
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
