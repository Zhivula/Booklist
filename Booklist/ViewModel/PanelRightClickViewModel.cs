using Booklist.Data;
using Booklist.Model;
using Booklist.Resourses;
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
    class PanelRightClickViewModel : INotifyPropertyChanged
    {
        public PanelRightClickModel model;
        public int id;
        public MainWindow window;
        private double x;
        private double y;

        public double X
        {
            get => x;
            set
            {
                x = value;
                OnPropertyChanged(nameof(X));
            }
        } 
        public double Y
        {
            get => y;
            set
            {
                y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        public PanelRightClickViewModel(int id, double x, double y)
        {
            model = new PanelRightClickModel();
            window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            this.id = id;
            X = x;
            Y = y;
        }
        public ICommand DeleteBook => new DelegateCommand(o =>
        {
            model.DeleteBook(id);
            MessageBox.Show("Успешно!");
        });
        public ICommand EditBook => new DelegateCommand(o =>
        {
            window.ChangedGrid.Children.Add(new EditBookView(id));
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
