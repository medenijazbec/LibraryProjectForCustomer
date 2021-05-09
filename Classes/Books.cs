using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theLibraryProject
{
    public class Books
    {
        public int id_b { get; set; }
        public string title { get; set; }
        public string year { get; set; }
        public string summary { get; set; }
        public int lost { get; set; }
        public int publisher_id { get; set; }
        public int genre_id { get; set; }
        public int location_id { get; set; }
        public Books(int _id, string _title, string _summary, string _year, int _lost, int _genre_id, int _publisher_id, int _location_id)
        {
            id_b = _id;
            title = _title;
            year = _year;
            lost = _lost;
            summary = _summary;
            genre_id = _genre_id;
            publisher_id = _publisher_id;
            location_id = _location_id;
        }
        public override string ToString()
        {

            string toReturn = id_b + " | " + title + " | " + year + " | " + summary + " | " + genre_id;
            return toReturn;
        }
    }
}
