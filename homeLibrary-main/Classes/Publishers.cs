using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theLibraryProject.Classes
{
   public class Publishers
    {
        public int id_p { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public Publishers(int _id, string _name)
        {
            id_p = _id;
            name = _name;
            description = "";
        }

        public Publishers(int _id, string _name, string _description)
        {
            id_p = _id;
            name = _name;
            description = _description;
        }

        public override string ToString()
        {

            string toReturn = id_p + " | " + name + " | " + description;
            return toReturn;
        }

    }
}
