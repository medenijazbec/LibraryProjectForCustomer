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
        /*public int totalPages 
        {
            get
            {
                return totalPages;
            }
            set
            {
                if (value <= 1)
                    totalPages = 1;
                else
                    totalPages = value;
            }
        }*/
        public int totalPages { get; set; }

      /*  public int rating
        {
            get
            {
                return rating;
            }
            set
            {
                if (value < 0)
                    rating = 0;
                else
                    rating = value;
            }
        }*/

        public int rating { get; set; }
        public string publishDate { get; set; }
        public string summary { get; set; }

        public int publisher_id { get; set; }

        public int location_id { get; set; }
        public Books(int _id, string _title, int _totalPages, int _rating, string _publishDate, string _summary, int _publisher_id, int _location_id)
        {
            id_b = _id;
            title = _title;
            totalPages = _totalPages;
            rating = _rating;
            publishDate = _publishDate;
            summary = _summary;
            publisher_id = _publisher_id;
            location_id = _location_id;
        }

        public override string ToString()
        {

            string toReturn =id_b + " | " + title + " | " + totalPages + " | " + rating + " | " +publishDate + " | " +summary + " | "+publisher_id + " | "+location_id;
            return toReturn;
        }

    }
}
