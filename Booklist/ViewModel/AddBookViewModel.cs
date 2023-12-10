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
    class AddBookViewModel : INotifyPropertyChanged
    {
        private string pathPhoto;
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

        public AddBookViewModel()
        {

        }
        public ICommand ComeBack => new DelegateCommand(o =>
        {
            var window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            for (int i = window.ChangedGrid.Children.Count - 1; i >= 0; --i)
            {
                var childTypeName = window.ChangedGrid.Children[i].GetType().Name;
                if (childTypeName == "AddBookView")
                {
                    window.ChangedGrid.Children.RemoveAt(i);
                }
            }
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
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
