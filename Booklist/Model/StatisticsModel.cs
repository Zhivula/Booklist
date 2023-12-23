using Booklist.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string averageMark;
        private List<string> years;

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
        public string AverageMark
        {
            get => averageMark;
            set
            {
                averageMark = value;
                OnPropertyChanged(nameof(AverageMark));
            }
        }
        public List<string> Years
        {
            get => years;
            set
            {
                years = value;
                OnPropertyChanged(nameof(Years));
            }
        }

        public StatisticsModel()
        {
            using (var context = new MyDbContext())
            {
                CountBooks = GetCountBooks();
                CountPages = GetCountPages();
                CountAuthors = GetCountAuthors();
                TheMostPopularAuthor = GetTheMostPopularAuthor();
                AverageMark = GetAverageMark();
                Years = GetYears();
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
        private string GetAverageMark()
        {
            using (var context = new MyDbContext())
            {
                if (context.Books.Count() > 0)
                {
                    return ((double)context.Books.Select(x => x.Mark).Sum() / context.Books.Count()).ToString("#.##");
                }
                else return "-";
            }
        }
        private string GetTheMostPopularAuthor()
        {
            using (var context = new MyDbContext())
            {
                if (context.Books != null)
                {
                    var unique = context.Books.Select(x => x.Author).Distinct().ToList();
                    var full = context.Books.Select(x => x.Author).ToList();
                    var pages = context.Books.Select(x => x.Pages).ToList();
                    var points = new List<int>(unique.Count());
                    foreach (var i in unique) points.Add(0);
                    for(var i = 0; i < unique.Count(); i++)
                    {
                        for(var j = 0; j < full.Count(); j++)
                        {
                            if (unique[i].Equals(full[j])) points[i]++;
                        }
                    }
                    //теперь points хранит количество книг определенного автора
                    //нужно сформировать массив из авторов с наибольшим количеством книг, и выбрать по количеству страниц (в случае если несколько авторов совпадают по количеству книг)
                    var topAuthors = new List<string>();
                    for(var i = 0; i < points.Count(); i++)
                    {
                        if (points[i] == points.Max()) topAuthors.Add(unique[i]);// тут формируются самые топовые авторы или, если значение 1, то находится сразу самый топовый автор
                    }
                    if (topAuthors.Count() > 1)
                    {
                        var topPages = new List<int>(topAuthors.Count());
                        foreach (var i in topAuthors) topPages.Add(0);

                        for (var i = 0; i < topAuthors.Count(); i++)
                        {
                            for (var j = 0; j < full.Count(); j++)
                            {
                                if (topAuthors[i].Equals(full[j])) topPages[i] += pages[j];
                            }
                        }
                        return topAuthors[topPages.IndexOf(topPages.Max())];
                    }
                    else return topAuthors.First();
                }
                else return string.Empty;
            }
        }
        private List<string> GetYears()
        {
            using (var context = new MyDbContext())
            {
                if (context.Books.Count() > 0)
                {
                    return context.Books.Select(x => x.Date.Year.ToString()).Distinct().ToList();
                }
                else return null;
            }
        }
        public string GetCountBooks(string year)
        {
            using (var context = new MyDbContext())
            {
                if (context.Books != null) return context.Books.Where(x=> x.Date.Year.ToString() == year).Count().ToString();
                else return "0";
            }
        }
        public string GetCountPages(string year)
        {
            using (var context = new MyDbContext())
            {
                if (context.Books != null) return context.Books.Where(x => x.Date.Year.ToString() == year).Select(x => x.Pages).Sum().ToString();
                else return "0";
            }
        }
        public string GetCountAuthors(string year)
        {
            using (var context = new MyDbContext())
            {
                if (context.Books != null) return context.Books.Where(x => x.Date.Year.ToString() == year).Select(x => x.Author).Distinct().Count().ToString();
                else return "0";
            }
        }
        public string GetAverageMark(string year)
        {
            using (var context = new MyDbContext())
            {
                if (context.Books.Count() > 0)
                {
                    return ((double)context.Books.Where(x => x.Date.Year.ToString() == year).Select(x => x.Mark).Sum() / context.Books.Where(x => x.Date.Year.ToString() == year).Count()).ToString("#.##");
                }
                else return "-";
            }
        }
        public string GetTheMostPopularAuthor(string year)
        {
            using (var context = new MyDbContext())
            {
                if (context.Books != null)
                {
                    var unique = context.Books.Where(x => x.Date.Year.ToString() == year).Select(c => c.Author).Distinct().ToList();
                    var full = context.Books.Where(x => x.Date.Year.ToString() == year).Select(c => c.Author).ToList();
                    var pages = context.Books.Where(x => x.Date.Year.ToString() == year).Select(c => c.Pages).ToList();
                    var points = new List<int>(unique.Count());
                    foreach (var i in unique) points.Add(0);
                    for (var i = 0; i < unique.Count(); i++)
                    {
                        for (var j = 0; j < full.Count(); j++)
                        {
                            if (unique[i].Equals(full[j])) points[i]++;
                        }
                    }
                    //теперь points хранит количество книг определенного автора
                    //нужно сформировать массив из авторов с наибольшим количеством книг, и выбрать по количеству страниц (в случае если несколько авторов совпадают по количеству книг)
                    var topAuthors = new List<string>();
                    for (var i = 0; i < points.Count(); i++)
                    {
                        if (points[i] == points.Max()) topAuthors.Add(unique[i]);// тут формируются самые топовые авторы или, если значение 1, то находится сразу самый топовый автор
                    }
                    if (topAuthors.Count() > 1)
                    {
                        var topPages = new List<int>(topAuthors.Count());
                        foreach (var i in topAuthors) topPages.Add(0);

                        for (var i = 0; i < topAuthors.Count(); i++)
                        {
                            for (var j = 0; j < full.Count(); j++)
                            {
                                if (topAuthors[i].Equals(full[j])) topPages[i] += pages[j];
                            }
                        }
                        return topAuthors[topPages.IndexOf(topPages.Max())];
                    }
                    else return topAuthors.First();
                }
                else return string.Empty;
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
