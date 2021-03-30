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

        public Genres(int _id, string _genreType)
        {
            id_g = _id;
            genreType = _genreType;
        }

        public override string ToString()
        {

            string toReturn =id_g + " | " + genreType;
            return toReturn;
        }


    }
}
