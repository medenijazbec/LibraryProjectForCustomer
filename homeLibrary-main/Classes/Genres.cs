using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theLibraryProject.Classes
{
    public class Genres
    {
        public int id_g { get; set; }
        public string genreType { get; set; }
        public string description { get; set; }

        public Genres(int _id, string _genreType)
        {
            id_g = _id;
            genreType = _genreType;
            description = "";
        }

        public Genres(int _id, string _genreType, string _description)
        {
            id_g = _id;
            genreType = _genreType;
            description = _description;
        }

        public override string ToString()
        {

            string toReturn =id_g + " | " + genreType + " | " + description;
            return toReturn;
        }


    }
}
