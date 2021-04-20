using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using Npgsql;
using System.Diagnostics;
using theLibraryProject.Classes;

namespace theLibraryProject
{
    public class databaseController
    {
        #region BooksAuthors
        public void SaveBooksAuthors(Book_Authors Book_AuthorsToSave)
        {
            // List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO book_authors (author_id, book_id) VALUES((SELECT id_a FROM authors WHERE id_a='" + Book_AuthorsToSave.author_id + "'), (SELECT id_b FROM books WHERE id_b='" + Book_AuthorsToSave.book_id + "'));";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeleteBooksAuthors(Book_Authors Book_AuthorsToDelete)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "DELETE FROM book_authors WHERE(book_id='" + Book_AuthorsToDelete.book_id + "' AND author_id='" + Book_AuthorsToDelete.author_id + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdateBooksAuthors(Book_Authors Book_AuthorsToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE book_authors SET author_id='" + Book_AuthorsToUpdate.author_id + "', book_id='" + Book_AuthorsToUpdate.book_id + "' WHERE(SELECT id_b FROM books WHERE(id_b='" + Book_AuthorsToUpdate.book_id + "'));";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }
        public List<int> ReadAuthorsID(Book_Authors Book_AuthorsToGetID)
        {
            List<int> listOfAuthorsID = new List<int>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT author_id FROM book_authors WHERE book_id='" + Book_AuthorsToGetID.book_id + "';";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                  
                    listOfAuthorsID.Add(id);
                }
                con.Close();
                return listOfAuthorsID;
            }
        }


        #endregion

        #region Books
        public List<string> ReadBooks()
        {
            List<string> listOfBooks = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT * FROM books";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string summary = reader.GetString(2);
                    string year = reader.GetString(3);
                    int lost = reader.GetInt32(4);
                    int genre_id = reader.GetInt32(5);
                    int publisher_id = reader.GetInt32(6);

                    listOfBooks.Add(id + " | " + title + " | " + summary + " | " +year + " | " +lost+ " | " +genre_id + " | " +publisher_id);
                }
                com.Dispose();
                con.Close();
                return listOfBooks;
            }
        }
       

        public void SaveBooks(Books BooksToSave)
        {
            List<string> listOfBooks = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO books (title, summary, year, lost, genre_id, publisher_id) VALUES('" + BooksToSave.title + "','" + BooksToSave.summary + "','" + BooksToSave.year + "','" + BooksToSave.lost + "','" + BooksToSave.genre_id + "','" + BooksToSave.publisher_id + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void DeleteBooks(Books BooksToDelete)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "DELETE FROM books WHERE(id_b='" + BooksToDelete.id_b + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }
        public void UpdateBooks(Books BooksToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE books SET title='" + BooksToUpdate.title + "', summary='" + BooksToUpdate.summary + "', year='" + BooksToUpdate.year + "', lost='" + BooksToUpdate.lost + "', genre_id=(SELECT id_g FROM genre WHERE id_g='" + BooksToUpdate.genre_id + "') WHERE id_b='" + BooksToUpdate.id_b + "';";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        #endregion

        #region Locations
        public List<string> ReadLocations()
        {
            List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT * FROM locations";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string postalcode = reader.GetString(2);
                    listOfLocations.Add(id + " | " + name + " | "+ postalcode);
                }
                con.Close();
                return listOfLocations;
            }
        }

        public void SaveLocations(Locations LocationsToSave)
        {
           // List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO locations (name, postalcode) VALUES('"+LocationsToSave.name+"', '"+LocationsToSave.postalcode+"');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeleteLocations(Locations LocationsToDelete)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "DELETE FROM locations WHERE(id_l='" + LocationsToDelete.id_l  + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdateLocations(Locations LocationsToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE locations SET name='" + LocationsToUpdate.name + "', postalcode='" + LocationsToUpdate.postalcode + "' WHERE(id_l='" + LocationsToUpdate.id_l + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public List<string> ReadLocationsID(Locations LocationsToReadID)
        {
            List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT * FROM locations WHERE id_l='" + LocationsToReadID.id_l + "'";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string postalcode = reader.GetString(2);
                    listOfLocations.Add(id + " | " + name + " | " + postalcode);
                }
                con.Close();
                return listOfLocations;
            }
        }



        #endregion

        #region Publishers
        public List<string> ReadPublishers()
        {
            List<string> listOfPublishers = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT * FROM publishers";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    
                    listOfPublishers.Add(id + " | " + name);
                }
                con.Close();
                return listOfPublishers;
            }
        }

        public void SavePublishers(Publishers PublishersToSave)
        {
            
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO publishers (name) VALUES('" + PublishersToSave.name + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeletePublishers(Publishers PublishersToDelete)
        {
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "DELETE FROM publishers WHERE(id_p='" + PublishersToDelete.id_p + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdatePublishers(Publishers PublishersToUpdate)
        {
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE publishers SET name='" + PublishersToUpdate.name + "' WHERE(id_p='" + PublishersToUpdate.id_p + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }
        #endregion

        #region Authors
        public List<string> ReadAuthors()
        {
            List<string> listOfAuthors = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT * FROM authors";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    
                    listOfAuthors.Add(id + " | " + name + " | " + surname);
                }
                con.Close();
                return listOfAuthors;
            }
        }

        public void SaveAuthors(Authors AuthorsToSave)
        {
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO authors (name, surname) VALUES('" + AuthorsToSave.name + "', '" + AuthorsToSave.surname + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeleteAuthors(Authors AuthorsToDelete)
        {
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "DELETE FROM authors WHERE(id_a='" + AuthorsToDelete.id_a + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdateAuthors(Authors AuthorsToUpdate)
        {
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE authors SET name='" + AuthorsToUpdate.name + "', surname='" + AuthorsToUpdate.surname + "' WHERE(id_a='" + AuthorsToUpdate.id_a + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }
        #endregion

        #region Genres

        public List<string> ReadGenres()
        {
            List<string> listOfPublishers = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT * FROM genre";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string genretype = reader.GetString(1);
                    listOfPublishers.Add(id + " | " + genretype);
                }
                con.Close();
                return listOfPublishers;
            }
        }

        public void SaveGenres(Genres GenresToSave)
        {

            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO genre (genretype) VALUES('" + GenresToSave.genreType + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeleteGenres(Genres GenresToDelete)
        {
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "DELETE FROM genre WHERE(id_g='" + GenresToDelete.id_g + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdateGenres(Genres GenresToUpdate)
        {
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE genre SET genretype='" + GenresToUpdate.genreType + "' WHERE(id_p='" + GenresToUpdate.id_g + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        #endregion

        #region Rents

        public List<string> ReadRents()
        {
            List<string> listOfRents = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT * FROM books";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int state = reader.GetInt32(1); 
                    string date = reader.GetString(2);
                    int book_id = reader.GetInt32(3);
                    int user_id = reader.GetInt32(4);

                    listOfRents.Add(id + " | " + state + " | " + date + " | " + book_id + " | " + user_id);
                }
                con.Close();
                return listOfRents;
            }
        }


        public void SaveRents(Rents RentsToSave)
        {
            List<string> listOfRents = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO rents (state, date, book_id, user_id) VALUES('" + RentsToSave.state + "', '" + RentsToSave.date + "', '" + RentsToSave.book_id + "', '" + RentsToSave.user_id;
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void DeleteRents(Rents RentsToDelete)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "DELETE FROM rents WHERE(id_r='" + RentsToDelete.id_r + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }
        public void UpdateRents(Rents RentsToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE rents SET state='" + RentsToUpdate.state + "', date='" + RentsToUpdate.date + "', book_id=(SELECT id_b FROM books WHERE id_b='" + RentsToUpdate.book_id + "'), user_id=(SELECT id_u FROM users WHERE id_u='" + RentsToUpdate.user_id + "')  WHERE id_r='" + RentsToUpdate.id_r + "';";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }




        #endregion

        #region Users
        public List<string> ReadUsers()
        {
            List<string> listOfBooks = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT * FROM users";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    string tel = reader.GetString(3);
                    string address = reader.GetString(4);
                    string email = reader.GetString(5);
                    string username = reader.GetString(6);
                    string password = reader.GetString(7);
                    string notes = reader.GetString(8);
                    int location_id = reader.GetInt32(9);

                    listOfBooks.Add(id + " | " + name + " | " + surname + " | " + tel + " | " + address + " | " + email + " | " + username + " | " + password + " | " + notes + " | " + location_id);
                }
                com.Dispose();
                con.Close();
                return listOfBooks;
            }
        }


        public void SaveUsers(Users UsersToSave)
        {
            List<string> listOfBooks = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO users (name, surname, tel, address, email, username, password, notes, location_id) VALUES('" + UsersToSave.name + "','" + UsersToSave.surname + "','" + UsersToSave.tel + "','" + UsersToSave.address + "','" + UsersToSave.email + "','" + UsersToSave.username + "','" + UsersToSave.password + "','" + UsersToSave.notes + "','" + UsersToSave.location_id + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void DeleteUsers(Users UsersToDelete)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "DELETE FROM users WHERE(id_u='" + UsersToDelete.id_u + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }
        public void UpdateUsers(Users UsersToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE books SET name='" + UsersToUpdate.name + "', surname='" + UsersToUpdate.surname + "', tel='" + UsersToUpdate.tel + "', address='" + UsersToUpdate.address + "', email='" + UsersToUpdate.email + "', usrname='" + UsersToUpdate.username + "', password='" + UsersToUpdate.password + "', notes='" + UsersToUpdate.notes + "', location_id=(SELECT id_l FROM locations WHERE id_l='" + UsersToUpdate.location_id + "') WHERE id_u='" + UsersToUpdate.id_u + "';";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }


        public List<string> ReadUserLogin(Users UsersToReadLogin)
        {
            List<string> listOfUsers = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT password FROM users WHERE(username='" + UsersToReadLogin.username + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {   
                    string password = reader.GetString(0);
                    listOfUsers.Add(password);
                }
                com.Dispose();
                con.Close();
                return listOfUsers;
            }
        }

        #endregion
    }
}
