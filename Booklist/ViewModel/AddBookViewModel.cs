using Booklist.Model;
using Booklist.View;
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
    class AddBookViewModel : INotifyPropertyChanged
    {
        private string author;
        private string bookTitle;
        private int numberOfPages;
        private int mark;
        private string date;
        private string pathPhoto;

        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }
        public string BookTitle
        {
            get => bookTitle;
            set
            {
                bookTitle = value;
                OnPropertyChanged(nameof(BookTitle));
            }
        }
        public int NumberOfPages
        {
            get => numberOfPages;
            set
            {
                numberOfPages = value;
                OnPropertyChanged(nameof(NumberOfPages));
            }
        }
        public int Mark
        {
            get => mark;
            set
            {
                mark = value;
                OnPropertyChanged(nameof(Mark));
            }
        }
        public string Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public string PathPhoto
        {
            get => pathPhoto;
            set
            {
                //TODO: здесь нужна нормальная проверка, чтобы pathPhoto не было null
                pathPhoto = value;
                OnPropertyChanged(nameof(PathPhoto));
            }
        }

        private readonly AddBookModel model = new AddBookModel();
        private readonly MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        public AddBookViewModel()
        {
            Date = DateTime.Now.ToShortDateString();
        }
        public ICommand ComeBack => new DelegateCommand(o =>
        {
            window.ChangedGrid.Children.Clear();
            window.ChangedGrid.Children.Add(new MainPage());    
        });
        public ICommand AddPhoto => new DelegateCommand(o =>
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                FileName = string.Empty,
                DefaultExt = ".jpg",

                Filter = "Файлы фотографий|*.jpg;*.png;*.ico"
            };

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                PathPhoto = dlg.FileName;
            }
        });
        private void ToMainPage()
        {
            window.ChangedGrid.Children.Clear();
            window.ChangedGrid.Children.Add(new MainPage());
        }
        public ICommand SaveBook => new DelegateCommand(o =>
        {
            if (!string.IsNullOrWhiteSpace(Author) || !string.IsNullOrWhiteSpace(BookTitle) || NumberOfPages > 0 || Mark > 0 || !string.IsNullOrWhiteSpace(Date))
            {
                model.AddBook(BookTitle, Author, DateTime.Parse(Date), Mark, NumberOfPages, PathPhoto);
                Author = BookTitle = string.Empty;
                NumberOfPages = Mark = 0;
                PathPhoto = string.Empty;
                MessageBox.Show("Успешно!");
                ToMainPage();
            }
            else MessageBox.Show("Некорректные данные.");
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
