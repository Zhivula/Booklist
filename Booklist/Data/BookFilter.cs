using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist.Data
{
    class BookFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int Mark { get; set; }
        public string Date { get; set; }
        public string PathPhoto { get; set; }
    }
}
