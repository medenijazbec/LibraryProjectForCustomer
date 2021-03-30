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

        public Publishers(int _id, string _name)
        {
            id_p = _id;
            name = _name;
        }


        public override string ToString()
        {

            string toReturn = id_p + " | " + name;
            return toReturn;
        }

    }
}
