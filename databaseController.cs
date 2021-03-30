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
        #region BooksGenres
        public void SaveBooksGenres(Book_Genres Book_GenresToSave)
        {
            // List<string> listOfLocations = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "INSERT INTO book_genres (book_id, genre_id) VALUES((SELECT id_b FROM books WHERE id_b='" + Book_GenresToSave.book_id + "'), (SELECT id_g FROM genres WHERE id_g='" + Book_GenresToSave.genre_id + "'));";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeleteBooksGenres(Book_Genres Book_GenresToDelete)
        {
            //List<string> listOfLocations = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "DELETE FROM book_genres WHERE(book_id='" + Book_GenresToDelete.book_id + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdateBooksGenres(Book_Genres Book_GenresToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "UPDATE book_genres SET genre_id='" + Book_GenresToUpdate.genre_id + "'WHERE book_id='" + Book_GenresToUpdate.book_id + "';";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }
        #endregion

        #region BooksAuthors
        public void SaveBooksAuthors(Book_Authors Book_AuthorsToSave)
        {
            // List<string> listOfLocations = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "INSERT INTO book_authors (book_id, author_id) VALUES((SELECT id_b FROM books WHERE id_b='" + Book_AuthorsToSave.book_id + "'), (SELECT id_a FROM authors WHERE id_a='" + Book_AuthorsToSave.author_id + "'));";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeleteBooksAuthors(Book_Authors Book_AuthorsToDelete)
        {
            //List<string> listOfLocations = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "DELETE FROM book_authors WHERE(book_id='" + Book_AuthorsToDelete.book_id + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdateBooksAuthors(Book_Authors Book_AuthorsToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "UPDATE book_authors SET author_id='" + Book_AuthorsToUpdate.author_id + "' WHERE book_id='" + Book_AuthorsToUpdate.book_id + "';";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        #endregion


        #region Books
        public List<string> ReadBooks()
        {
            List<string> listOfBooks = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "SELECT * FROM books";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    int total_pages = reader.GetInt32(2);
                    int rating = reader.GetInt32(3);
                    string publish_date =Convert.ToString(reader.GetDate(4));
                    string summary = reader.GetString(5);
                    int publisher_id = reader.GetInt32(6);
                    int location_id = reader.GetInt32(7);

                    listOfBooks.Add(id + " | " + title + " | " + total_pages + " | " +rating + " | " +publish_date + " | " + summary + " | " +publisher_id + " | " +location_id);
                }
                con.Close();
                return listOfBooks;
            }
        }
       

        public void SaveBooks(Books BooksToSave)
        {
            List<string> listOfBooks = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "INSERT INTO books (title, summary, year, lost, genre_id) VALUES('" + BooksToSave.title + "', '" + BooksToSave.summary + "', '" + BooksToSave.year + "', '" + BooksToSave.lost + "', '" + BooksToSave.genre_id;
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void DeleteBooks(Books BooksToDelete)
        {
            //List<string> listOfLocations = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "DELETE FROM books WHERE(id_b='" + BooksToDelete.id_b + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }
        public void UpdateBooks(Books BooksToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "UPDATE books SET title='" + BooksToUpdate.title + "', summary='" + BooksToUpdate.summary + "', year='" + BooksToUpdate.year + "', lost='" + BooksToUpdate.summary + "', genre_id=(SELECT id_g FROM genres WHERE id_g='" + BooksToUpdate.genre_id + "') WHERE id_b='" + BooksToUpdate.id_b + "';";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
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
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "SELECT * FROM locations";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = com.ExecuteReader();
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
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "INSERT INTO locations (name, postalcode) VALUES('"+LocationsToSave.name+"', '"+LocationsToSave.postalcode+"');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeleteLocations(Locations LocationsToDelete)
        {
            //List<string> listOfLocations = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "DELETE FROM locations WHERE(id_l='" + LocationsToDelete.id_l  + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdateLocations(Locations LocationsToUpdate)
        {
            //List<string> listOfLocations = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "UPDATE locations SET name='" + LocationsToUpdate.name + "', postalcode='" + LocationsToUpdate.postalcode + "' WHERE(id_l='" + LocationsToUpdate.id_l + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }
        #endregion

        #region Publishers
        public List<string> ReadPublishers()
        {
            List<string> listOfPublishers = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "SELECT * FROM publishers";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string description = reader.GetString(2);
                    listOfPublishers.Add(id + " | " + name + " | " + description);
                }
                con.Close();
                return listOfPublishers;
            }
        }

        public void SavePublishers(Publishers PublishersToSave)
        {
            
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "INSERT INTO publishers (name, description) VALUES('" + PublishersToSave.name + "', '" + PublishersToSave.description + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeletePublishers(Publishers PublishersToDelete)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "DELETE FROM publishers WHERE(id_p='" + PublishersToDelete.id_p + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdatePublishers(Publishers PublishersToUpdate)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "UPDATE publishers SET name='" + PublishersToUpdate.name + "', description='" + PublishersToUpdate.description + "' WHERE(id_p='" + PublishersToUpdate.id_p + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
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
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "SELECT * FROM authors";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    string middlename = reader.GetString(3);
                    listOfAuthors.Add(id + " | " + name + " | " + surname + " | " + middlename);
                }
                con.Close();
                return listOfAuthors;
            }
        }

        public void SaveAuthors(Authors AuthorsToSave)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "INSERT INTO authors (name, surname) VALUES('" + AuthorsToSave.name + "', '" + AuthorsToSave.surname + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeleteAuthors(Authors AuthorsToDelete)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "DELETE FROM authors WHERE(id_a='" + AuthorsToDelete.id_a + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdateAuthors(Authors AuthorsToUpdate)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "UPDATE authors SET name='" + AuthorsToUpdate.name + "', surname='" + AuthorsToUpdate.surname + "' WHERE(id_a='" + AuthorsToUpdate.id_a + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
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
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "SELECT * FROM genres";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string description = reader.GetString(2);
                    listOfPublishers.Add(id + " | " + name + " | " + description);
                }
                con.Close();
                return listOfPublishers;
            }
        }

        public void SaveGenres(Genres GenresToSave)
        {

            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "INSERT INTO genres (genre_type) VALUES('" + GenresToSave.genreType + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        public void DeleteGenres(Genres GenresToDelete)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "DELETE FROM genres WHERE(id_g='" + GenresToDelete.id_g + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();
            }
        }

        public void UpdateGenres(Genres GenresToUpdate)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "UPDATE genres SET genre_type='" + GenresToUpdate.genreType + "' WHERE(id_p='" + GenresToUpdate.id_g + "');";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteNonQuery();
                com.Dispose();
                con.Close();

            }
        }

        #endregion



    }
}
