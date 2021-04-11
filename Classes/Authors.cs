using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theLibraryProject
{
    public class Authors
    {

        public int id_a { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public Authors(int _id, string _name, string _surname)
        {
            id_a = _id;
            name = _name;
            surname = _surname;
        }

        public override string ToString()
        {

            string toReturn =id_a + " | " + name + " | " + surname;
            return toReturn;
        }

    }
}
