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
        public string middlename { get; set; }

        public Authors(int _id, string _name, string _surname)
        {
            id_a = _id;
            name = _name;
            surname = _surname;
            middlename = "";

        }

        public Authors(int _id_a, string _name, string _surname, string _middlename)
        {
            id_a = _id_a;
            name = _name;
            surname = _surname;
            middlename = _middlename;
        }

        public override string ToString()
        {

            string toReturn =id_a + " | " + name + " | " + surname + " | " + middlename;
            return toReturn;
        }

    }
}
