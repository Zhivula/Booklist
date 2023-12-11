using Booklist.Data;
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
        private List<BookFilter> books;
        public List<BookFilter> Books
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
            Books = GetListBookFilter();
        }
        private List<BookFilter> GetListBookFilter()
        {
            var filterList = new List<BookFilter>();
            foreach (var i in new MainPageModel().ListMainPage)
            {
                filterList.Add(new BookFilter() {
                    Author = i.Author,
                    Pages = i.Pages,
                    Name = i.Name,
                    Mark = i.Mark,
                    Date = i.Date.ToShortDateString(),
                    PathPhoto = i.PathPhoto
                });
            }
            return filterList;
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
