using Booklist.DataBase;
using System;
using System.Windows;

namespace Booklist
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            using (var context = new MyDbContext())
            {
                context.Books.Add(new Book() {
                    Name = "Разумный инвестор",
                    Author = "Бенджамин Грэм",
                    Date = DateTime.Now,
                    Mark = 10,
                    Pages = 567
                });
                context.SaveChanges();
            }
        }
    }
}
