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
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO book_authors (author_id, book_id) VALUES((SELECT id_a FROM authors WHERE id_a='" + Book_AuthorsToSave.author_id + "'), '" + Book_AuthorsToSave.book_id + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void DeleteBooksAuthors(Book_Authors Book_AuthorsToDelete)
        {
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
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE book_authors SET author_id='" + Book_AuthorsToUpdate.newid + "', book_id='" + Book_AuthorsToUpdate.book_id + "' WHERE id_ba='" + Book_AuthorsToUpdate.id_ba + "';";
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

        #region ReadIDs
        
        public List<int> idLocations(Locations ToReadIDs)
        {
            List<int> listOfIDs = new List<int>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT id_l FROM locations WHERE name='" + ToReadIDs.name + "'";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    listOfIDs.Add(id);
                }
                com.Dispose();
                con.Close();
                return listOfIDs;
            }
        }
        public List<int> idAuthors(Authors ToReadIDs)
        {
            List<int> listOfIDs = new List<int>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT id_a FROM authors WHERE name='" + ToReadIDs.name + "' AND surname='" + ToReadIDs.surname + "'";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    listOfIDs.Add(id);
                }
                com.Dispose();
                con.Close();
                return listOfIDs;
            }
        }
        public List<int> idPublishers(Publishers ToReadIDs)
        {
            List<int> listOfIDs = new List<int>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT id_p FROM publishers WHERE name='" + ToReadIDs.name + "'";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    listOfIDs.Add(id);
                }
                com.Dispose();
                con.Close();
                return listOfIDs;
            }
        }
        public List<int> idGenres(Genres ToReadIDs)
        {
            List<int> listOfIDs = new List<int>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT id_g FROM genre WHERE genretype='" + ToReadIDs.genreType + "'";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    listOfIDs.Add(id);
                }
                com.Dispose();
                con.Close();
                return listOfIDs;
            }
        }
        public List<int> idBookAuthors(Book_Authors ToReadIDs)
        {
            List<int> listOfIDs = new List<int>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT id_ba FROM book_authors WHERE (author_id=" + ToReadIDs.author_id + " AND book_id=" + ToReadIDs.book_id + ");";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    listOfIDs.Add(id);
                }
                com.Dispose();
                con.Close();
                return listOfIDs;
            }
        }

        public List<int> idBooks(Books ToReadIDs)
        {
            List<int> listOfIDs = new List<int>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT id_b FROM books WHERE title='" + ToReadIDs.title + "' AND year='" + ToReadIDs.year + "' AND lost='" + ToReadIDs.lost + "' AND genre_id='" + ToReadIDs.genre_id + "' AND publisher_id='" + ToReadIDs.publisher_id + "' AND book_location_id='" + ToReadIDs.location_id + "'";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    listOfIDs.Add(id);
                }
                com.Dispose();
                con.Close();
                return listOfIDs;
            }
        }

        public List<int> idUsers(Users ToReadIDs)
        {
            List<int> listOfIDs = new List<int>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT id_u FROM users WHERE name='" + ToReadIDs.name + "' AND surname='" + ToReadIDs.surname + "'";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    listOfIDs.Add(id);
                }
                com.Dispose();
                con.Close();
                return listOfIDs;
            }
        }

        public List<int> idRents(Rents ToReadIDs)
        {
            List<int> listOfIDs = new List<int>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT id_r FROM rents WHERE book_id='" + ToReadIDs.book_id + "'";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    listOfIDs.Add(id);
                }
                com.Dispose();
                con.Close();
                return listOfIDs;
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
                //string query = "SELECT b.title, b.year, b.lost, a.name, a.surname, g.genretype, p.publishers, l.name FROM books";
                string query = "SELECT b.id_b, b.title, a.name, a.surname, b.lost, b.year, l.name, p.name, g.genretype FROM books b INNER JOIN genre g ON g.id_g=b.genre_id INNER JOIN publishers p ON p.id_p=b.publisher_id INNER JOIN locations l ON l.id_l=b.book_location_id INNER JOIN book_authors s ON s.book_id=b.id_b INNER JOIN authors a ON a.id_a=s.author_id; ";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string author_name = reader.GetString(2);
                    string author_surname = reader.GetString(3);
                    int lost = reader.GetInt32(4);
                    string year = reader.GetString(5);
                    string location_name = reader.GetString(6);
                    string publisher_name = reader.GetString(7);
                    string genretype = reader.GetString(8);
                    //int genre_id = reader.GetInt32(5);
                    //int publisher_id = reader.GetInt32(6);




                    listOfBooks.Add(id + " | " + title + " | "+author_name + " | "+author_surname+ " | " + lost + " | " +year + " | " +location_name+ " | " +publisher_name + " | " +genretype);
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
                string query = "INSERT INTO books (title, summary, year, lost, genre_id, publisher_id, book_location_id) VALUES('" + BooksToSave.title + "','" + BooksToSave.summary + "','" + BooksToSave.year + "','" + BooksToSave.lost + "','" + BooksToSave.genre_id + "','" + BooksToSave.publisher_id + "','" + BooksToSave.location_id + "');";
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
                string query = "DELETE FROM books WHERE(id_b='" + BooksToDelete.id_b + "' AND title='" + BooksToDelete.title + "' AND year='" + BooksToDelete.year + "'AND lost='" + BooksToDelete.lost + "'AND genre_id='" + BooksToDelete.genre_id + "'AND publisher_id='" + BooksToDelete.publisher_id + "'AND book_location_id='" + BooksToDelete.location_id + "');";
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
                string query = "UPDATE books SET title='" + BooksToUpdate.title + "', summary='" + BooksToUpdate.summary + "', year='" + BooksToUpdate.year + "', lost='" + BooksToUpdate.lost + "', genre_id=(SELECT id_g FROM genre WHERE id_g='" + BooksToUpdate.genre_id + "'), publisher_id=(SELECT id_p FROM publishers WHERE id_p='" + BooksToUpdate.publisher_id + "'), book_location_id=(SELECT id_l FROM locations WHERE id_l='" + BooksToUpdate.location_id + "') WHERE id_b='" + BooksToUpdate.id_b + "';";
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
                string query = "UPDATE genre SET genretype='" + GenresToUpdate.genreType + "' WHERE(id_g='" + GenresToUpdate.id_g + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        #endregion

        #region Rents

        public void SaveBookRents(Rents BookToRentsSave)
        {
            List<string> listOfBooks = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO rents (state, date, book_id, user_id) VALUES('" + BookToRentsSave.state + "','" + BookToRentsSave.date + "','" + BookToRentsSave.book_id + "','" + BookToRentsSave.user_id + "');";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }



        public List<string> ReadUnlendedBooks()
        {
            List<string> listOfBooks = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                //string query = "SELECT b.title, b.year, b.lost, a.name, a.surname, g.genretype, p.publishers, l.name FROM books";
                string query = "SELECT b.id_b, b.title, a.name, a.surname, b.lost, b.year, l.name, p.name, g.genretype, r.state, r.date FROM authors a INNER JOIN book_authors ba ON ba.author_id=a.id_a INNER JOIN books b ON ba.book_id=b.id_b INNER JOIN genre g ON g.id_g=b.genre_id INNER JOIN publishers p ON p.id_p=b.publisher_id INNER JOIN rents r ON r.book_id=b.id_b INNER JOIN locations l ON l.id_l=book_location_id WHERE(r.state=0);";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string author_name = reader.GetString(2);
                    string author_surname = reader.GetString(3);
                    int lost = reader.GetInt32(4);
                    string year = reader.GetString(5);
                    string location_name = reader.GetString(6);
                    string publisher_name = reader.GetString(7);
                    string genretype = reader.GetString(8);
                    listOfBooks.Add(id + " | " + title + " | " + author_name + " | " + author_surname + " | " + lost + " | " + year + " | " + location_name + " | " + publisher_name + " | " + genretype);
                }
                com.Dispose();
                con.Close();
                return listOfBooks;
            }
        }



        public List<string> ReadLendedBooks(Rents toRead)
        {
            List<string> listOfBooks = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                //string query = "SELECT b.title, b.year, b.lost, a.name, a.surname, g.genretype, p.publishers, l.name FROM books";
                string query = "SELECT b.id_b, b.title, a.name, a.surname, b.lost, b.year, l.name, p.name, g.genretype, r.state, r.date FROM books b INNER JOIN genre g ON g.id_g=b.genre_id INNER JOIN publishers p ON p.id_p=b.publisher_id INNER JOIN rents r ON r.book_id=b.id_b INNER JOIN users u ON r.user_id=u.id_u INNER JOIN locations l ON u.location_id=l.id_l INNER JOIN book_authors s ON s.book_id=b.id_b INNER JOIN authors a ON a.id_a=s.author_id WHERE (r.user_id=" + toRead.user_id + " AND state=1);";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string author_name = reader.GetString(2);
                    string author_surname = reader.GetString(3);
                    int lost = reader.GetInt32(4);
                    string year = reader.GetString(5);
                    string location_name = reader.GetString(6);
                    string publisher_name = reader.GetString(7);
                    string genretype = reader.GetString(8);
                    string state = reader.GetString(8);
                    string date = reader.GetString(8);
                    listOfBooks.Add(id + " | " + title + " | " + author_name + " | " + author_surname + " | " + lost + " | " + year + " | " + location_name + " | " + publisher_name + " | " + genretype + " | " + state + " | " + date);
                }
                com.Dispose();
                con.Close();
                return listOfBooks;
            }
        }

        public void SaveRents(Rents RentsToSave)
        {
            List<string> listOfRents = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "INSERT INTO rents (state, date, book_id, user_id) VALUES('" + RentsToSave.state + "', '" + RentsToSave.date + "', " + RentsToSave.book_id + ", " + RentsToSave.user_id + ");";
                //string query = "UPDATE rents SET state='" + RentsToSave.state + "', date='" + RentsToSave.date + "', book_id=" + RentsToSave.book_id + ", user_id=" + RentsToSave.book_id + ";";
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
        public void UpdateRentsUnLend(Rents RentsToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE rents SET state=0, date='" + RentsToUpdate.date + "', user_id=" + 0 + " WHERE id_r=" + RentsToUpdate.id_r + ";";
                SQLiteCommand com = new SQLiteCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void UpdateRentsLend(Rents RentsToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "UPDATE rents SET state=1, date='" + RentsToUpdate.date + "', user_id=" + RentsToUpdate.user_id + " WHERE id_r=" + RentsToUpdate.id_r + ";";
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
                string query = "SELECT u.id_u, u.name, u.surname, u.tel, u.address, u.notes, l.name, l.postalcode FROM users u INNER JOIN locations l ON l.id_l=u.location_id;";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    string tel = reader.GetString(3);
                    string address = reader.GetString(4);
                    string notes = reader.GetString(5);
                    string location_name = reader.GetString(6);
                    string location_postalcode = reader.GetString(7);
                    listOfBooks.Add(id + " | " + name + " | " + surname + " | " + tel + " | " + address + " | " + notes + " | " +location_name + " | " +location_postalcode);
                }
                com.Dispose();
                con.Close();
                return listOfBooks;
            }
        }

        public List<string> ReadUsersForUpdate()
        {
            List<string> listOfBooks = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT u.id_u, u.name, u.surname, u.tel, u.address, u.email, u.username, u.notes FROM users u;";
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
                    //string password = reader.GetString();
                    string notes = reader.GetString(7);
                    listOfBooks.Add(id + " | " + name + " | " + surname + " | " + tel + " | " + address + " | "+email+ " | " +username + " | " + notes);
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
                string query = "UPDATE users SET name='" + UsersToUpdate.name + "', surname='" + UsersToUpdate.surname + "', tel='" + UsersToUpdate.tel + "', address='" + UsersToUpdate.address + "', email='" + UsersToUpdate.email + "', username='" + UsersToUpdate.username + "', password='" + UsersToUpdate.password + "', notes='" + UsersToUpdate.notes + "', location_id=(SELECT id_l FROM locations WHERE id_l='" + UsersToUpdate.location_id + "') WHERE id_u='" + UsersToUpdate.id_u + "';";
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
