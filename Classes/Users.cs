using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theLibraryProject.Classes
{
    public class Users
    {
        public int id_u { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string notes { get; set; }

        public int location_id { get; set; }

        public Users(int _id_u, string _name, string _surname, string _tel, string _address, string _email, string _username, string _password, string _notes)
        {
            id_u = _id_u;
            name = _name;
            surname = _surname;
            tel = _tel;
            address = _address;
            email = _email;
            username = _username;
            password = _password;
            notes = _notes;
        }

        public Users(int _id_u, string _name, string _surname, string _tel, string _address, string _email, string _username, string _password, string _notes, int _location_id)
        {
            id_u = _id_u;
            name = _name;
            surname = _surname;
            tel = _tel;
            address = _address;
            email = _email;
            username = _username;
            password = _password;
            notes = _notes;
            location_id = _location_id;
        }

        public override string ToString()
        {

            string toReturn = id_u + " | " + name + " | " + surname + " | " + tel + " | " + address + " | " + email + " | " + username + " | " + password + " | " + notes + " | " + location_id;
            return toReturn;
        }


    }

    

    
}
