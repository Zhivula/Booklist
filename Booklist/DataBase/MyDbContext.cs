using Booklist.DataBase;
using System.Data.Entity;

namespace ZhiMoney.DataBase
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}