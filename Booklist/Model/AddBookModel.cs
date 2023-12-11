using Booklist.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist.Model
{
    class AddBookModel
    {
        public AddBookModel()
        {

        }
        public void AddBook(string Name, string Author, DateTime Date, int Mark, int Pages, string PathPhoto)
        {
            using (var context = new MyDbContext())
            {
                context.Books.Add(new Book()
                {
                    Name = Name,
                    Author = Author,
                    Date = Date,
                    Mark = Mark,
                    Pages = Pages, 
                    PathPhoto = PathPhoto
                });
                context.SaveChanges();
            }
        }
    }
}
