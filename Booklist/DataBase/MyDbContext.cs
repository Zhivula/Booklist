using System.Data.Entity;

namespace Booklist.DataBase
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}