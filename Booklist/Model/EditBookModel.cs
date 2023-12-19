using Booklist.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist.Model
{
    class EditBookModel
    {
        public EditBookModel()
        {

        }
        public void EditBook(int id, string Name, string Author, DateTime Date, int Mark, int Pages, string PathPhoto)
        {
            using (var context = new MyDbContext())
            {
                if (IsBook(id))
                {
                    var book = GetBook(id);

                    book.Name = Name;
                    book.Author = Author;
                    book.Date = Date;
                    book.Mark = Mark;
                    book.Pages = Pages;
                    book.PathPhoto = PathPhoto;

                    context.Entry(book).State = EntityState.Modified;

                    context.SaveChanges();
                }

            }
        }
        public Book GetBook(int id)
        {
            using (var context = new MyDbContext())
            {
                return context.Books.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        public bool IsBook(int id)
        {
            using (var context = new MyDbContext())
            {
                var book = context.Books.Where(x => x.Id == id).FirstOrDefault();
                if (book != null) return true;
                else return false;
            }
        }
    }
}
