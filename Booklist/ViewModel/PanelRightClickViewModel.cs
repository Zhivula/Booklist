using Booklist.Data;
using Booklist.Model;
using Booklist.Resourses;
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

            for (int i = window.ChangedGrid.Children.Count - 1; i >= 0; --i)
            {
                var childTypeName = window.ChangedGrid.Children[i].GetType().Name;
                if (childTypeName == nameof(PanelRightClick))
                {
                    window.ChangedGrid.Children.RemoveAt(i);
                }
            }
        });
        public ICommand ChangeBook => new DelegateCommand(o =>
        {

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
