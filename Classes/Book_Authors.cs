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
        public int id_ba { get; set; }
        public int newid { get; set; }
        public Book_Authors(int _author_id, int _book_id)
        {
            book_id = _book_id;
            author_id = _author_id;
        }
        public Book_Authors(int _author_id, int _book_id, int _id_ba, int _newid)
        {
            author_id = _author_id; 
            book_id = _book_id;
            id_ba = _id_ba;
            newid = _newid;

            
        }
    }
}
