using Booklist.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist.ViewModel
{
    class StatisticsViewModel : INotifyPropertyChanged
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
        public StatisticsViewModel()
        {
            var model = new StatisticsModel();

            CountBooks = model.CountBooks;
            CountPages = model.CountPages;
            CountAuthors = model.CountAuthors;

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
