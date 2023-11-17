using Booklist.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist.Model
{
    class MainPageModel
    {
        public List<Book> ListMainPage;
        public MainPageModel()
        {
            ListMainPage = new List<Book>();
            using (var context = new MyDbContext())
            {
                foreach (var item in context.Books)
                {
                    ListMainPage.Add(item);
                }
            }
        }
    }
}
