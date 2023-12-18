using Booklist.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist.Model
{
    public class PanelRightClickModel
    {
        public PanelRightClickModel()
        {
            
        }
        public void DeleteBook(int id)
        {
            using (var context = new MyDbContext())
            {
                var book = context.Books.Where(x => x.Id == id).First();
                if(book != null) context.Books.Remove(book);
                context.SaveChanges();
            }
        }
    }
}
