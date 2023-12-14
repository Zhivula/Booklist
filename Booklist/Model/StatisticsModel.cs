using Booklist.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist.Model
{
    class StatisticsModel : INotifyPropertyChanged
    {
        private string countBooks;
        private string countPages;
        private string countAuthors;
        private string theMostPopularAuthor;

        public string CountBooks
        {
            get => countBooks;
            set
            {
                countBooks = value;
                OnPropertyChanged(nameof(CountBooks));
            }
        }
        public string CountPages
        {
            get => countPages;
            set
            {
                countPages = value;
                OnPropertyChanged(nameof(CountPages));
            }
        }
        public string CountAuthors
        {
            get => countAuthors;
            set
            {
                countAuthors = value;
                OnPropertyChanged(nameof(CountAuthors));
            }
        }
        public string TheMostPopularAuthor
        {
            get => theMostPopularAuthor;
            set
            {
                theMostPopularAuthor = value;
                OnPropertyChanged(nameof(TheMostPopularAuthor));
            }
        }
        public StatisticsModel()
        {
            using (var context = new MyDbContext())
            {
                CountBooks = GetCountBooks();
                CountPages = GetCountPages();
                CountAuthors = GetCountAuthors();
            }
        }
        private string GetCountBooks()
        {
            using (var context = new MyDbContext())
            {
                if (context.Books != null) return context.Books.Count().ToString();
                else return "0";
            }
        }
        private string GetCountPages()
        {
            using (var context = new MyDbContext())
            {
                if (context.Books != null) return context.Books.Select(x => x.Pages).Sum().ToString();
                else return "0";
            }
        }
        private string GetCountAuthors()
        {
            using (var context = new MyDbContext())
            {
                if (context.Books != null) return context.Books.Select(x => x.Author).Distinct().Count().ToString();
                else return "0";
            }
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
