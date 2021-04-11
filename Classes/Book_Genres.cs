using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theLibraryProject.Classes
{
    public class Book_Genres
    {
        public int book_id { get; set; }
        public int genre_id { get; set; }

        public int id_b { get; set; }
        public Book_Genres(int _book_id, int _genre_id)
        {
            book_id = _book_id;
            genre_id = _genre_id;
        }

        public Book_Genres(int _book_id, int _genre_id, int _id_b)
        {
            book_id = _book_id;
            genre_id = _genre_id;
            id_b = _id_b;
        }

    }
}
