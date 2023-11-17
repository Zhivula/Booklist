using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist.DataBase
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
    }
}
