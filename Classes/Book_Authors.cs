using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theLibraryProject.Classes
{
    public class Book_Authors
    {
        public int book_id { get; set; }
        public int author_id { get; set; }
        public int id_g { get; set; }

        public Book_Authors(int _book_id, int _author_id)
        {
            book_id = _book_id;
            author_id = _author_id;
        }

        public Book_Authors(int _book_id, int _author_id, int _id_g)
        {
            book_id = _book_id;
            author_id = _author_id;
            id_g = _id_g;
        }
    }
}
