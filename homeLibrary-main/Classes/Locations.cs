using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theLibraryProject.Classes
{
    public class Locations
    {
        public int id_l { get; set; }
        public string name { get; set; }
        public string postalcode { get; set; }

        public Locations(int _id, string _name)
        {
            id_l = _id;
            name = _name;
            postalcode = "";
        }

        public Locations(int _id, string _name, string _postalcode)
        {
            id_l = _id;
            name = _name;
            postalcode = _postalcode;
        }

        public override string ToString()
        {

            string toReturn = id_l +" | "+ name + " | " + postalcode;
            return toReturn;
        }
    }
}
