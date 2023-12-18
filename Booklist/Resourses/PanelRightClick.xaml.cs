using Booklist.Data;
using Booklist.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Booklist.Resourses
{
    /// <summary>
    /// Логика взаимодействия для PanelRightClick.xaml
    /// </summary>
    public partial class PanelRightClick : UserControl
    {
        public PanelRightClick(int id, double x, double y)
        {
            InitializeComponent();
            DataContext = new PanelRightClickViewModel(id, x, y);
        }
    }
}
