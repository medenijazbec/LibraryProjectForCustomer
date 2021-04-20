using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theLibraryProject.Classes
{
    public class Rents
    {
        public int id_r { get; set; }
        public int state { get; set; }
        public string date { get; set; }
        public int book_id { get; set; }
        public int user_id { get; set; }
        public Rents(int _id, int _state, string _date, int _book_id, int _user_id)
        {
            id_r = _id;
            state = _state;
            date = _date;
            book_id = _book_id;
            user_id = _user_id;
        }

        public override string ToString()
        {

            string toReturn = id_r + " | " + state + " | " + date + " | " + book_id + " | " + user_id;
            return toReturn;
        }


    }
}
