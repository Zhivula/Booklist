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
    class EditBookViewModel
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

        private EditBookModel model = new EditBookModel();
        private readonly int id;

        public EditBookViewModel(int id)
        {
            var book = model.GetBook(id);
            this.id = id;
            Author = book.Author;
            BookTitle = book.Name;
            NumberOfPages = book.Pages;
            Mark = book.Mark;
            Date = book.Date.ToShortDateString();
            PathPhoto = book.PathPhoto;
        }
        private void ToMainPage()
        {
            var window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            window.ChangedGrid.Children.Clear();
            window.ChangedGrid.Children.Add(new MainPage());
        }
        public ICommand ComeBack => new DelegateCommand(o =>
        {
            ToMainPage();
        });
        public ICommand EditPhoto => new DelegateCommand(o =>
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
        public ICommand EditBook => new DelegateCommand(o =>
        {
            if (!string.IsNullOrWhiteSpace(Author) || !string.IsNullOrWhiteSpace(BookTitle) || NumberOfPages > 0 || Mark > 0 || !string.IsNullOrWhiteSpace(Date))
            {
                model.EditBook(id, BookTitle, Author, DateTime.Parse(Date), Mark, NumberOfPages, PathPhoto);
                Author = BookTitle = string.Empty;
                NumberOfPages = Mark = 0;
                PathPhoto = string.Empty;
                WindowSuccessfullyViewModel.Successfully();
                ToMainPage();
            }
            else WindowSuccessfullyViewModel.NotSuccessfully();
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
