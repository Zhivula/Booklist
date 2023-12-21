using Booklist.Data;
using Booklist.DataBase;
using Booklist.Model;
using Booklist.Resourses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private bool flagBookTitles;
        private bool flagAuthors;
        private bool flagMarks;
        private bool flagPages;
        private bool flagDate;

        private ObservableCollection<BookFilter> books;
        public ObservableCollection<BookFilter> Books
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
        private ObservableCollection<BookFilter> GetListBookFilter()
        {
            var filterList = new ObservableCollection<BookFilter>();
            foreach (var i in new MainPageModel().ListMainPage)
            {
                filterList.Add(new BookFilter() {
                    Id = i.Id,
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
        
        public ICommand SortBookTitles => new DelegateCommand(o =>
        {
            if (flagBookTitles)
            {
                Books = new ObservableCollection<BookFilter>(Books.OrderByDescending(x => x.Name));
                flagBookTitles = false;
            }
            else
            {
                Books = new ObservableCollection<BookFilter>(Books.OrderBy(x => x.Name));
                flagBookTitles = true;
            }
        });
        public ICommand SortAuthors => new DelegateCommand(o =>
        {
            if (flagAuthors)
            {
                Books = new ObservableCollection<BookFilter>(Books.OrderByDescending(x => x.Author));
                flagAuthors = false;
            }
            else
            {
                Books = new ObservableCollection<BookFilter>(Books.OrderBy(x => x.Author));
                flagAuthors = true;
            }
        });
        public ICommand SortMarks => new DelegateCommand(o =>
        {
            if (flagMarks)
            {
                Books = new ObservableCollection<BookFilter>(Books.OrderByDescending(x => x.Mark));
                flagMarks = false;
            }
            else
            {
                Books = new ObservableCollection<BookFilter>(Books.OrderBy(x => x.Mark));
                flagMarks = true;
            }
        });
        public ICommand SortDate => new DelegateCommand(o =>
        {
            if (flagDate)
            {
                Books = new ObservableCollection<BookFilter>(Books.OrderByDescending(x => x.Date));
                flagDate = false;
            }
            else
            {
                Books = new ObservableCollection<BookFilter>(Books.OrderBy(x => x.Date));
                flagDate = true;
            }
        });
        public ICommand SortPages => new DelegateCommand(o =>
        {
            if (flagPages)
            {
                Books = new ObservableCollection<BookFilter>(Books.OrderByDescending(x => x.Pages));
                flagPages = false;
            }
            else
            {
                Books = new ObservableCollection<BookFilter>(Books.OrderBy(x => x.Pages));
                flagPages = true;
            }
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
