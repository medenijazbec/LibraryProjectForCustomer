using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theLibraryProject.Classes;
using Npgsql;

namespace theLibraryProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OutputLocations();
            OutputAuthors();
            OutputPublishers();
            OutputGenres();
            OutputBooks();

            //books page
            OutputGenresOnBooks();
            OutputLocationsOnBooks();
            OutputPublishersOnBooks();
            OutputAuthorsOnBooks();
            //SELECT b.title, b.total_pages, b.rating, b.publish_date, b.summary, a.name, a.surname, g.genre_type, g.description FROM authors a INNER JOIN book_authors q ON q.author_id=a.id_a INNER JOIN books b ON q.book_id=b.id_b INNER JOIN book_genres w ON w.book_id=b.id_b INNER JOIN genres g ON g.id_g=w.genre_id;  
        }

        #region LocationControlls

        databaseController db = new databaseController();
            public void OutputLocations()
            {
                foreach (string name in db.ReadLocations())
                {
                    locationslistBox.Items.Add(name);
                }
            }

        private void locationsUpdateButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedLocation = locationslistBox.SelectedItem.ToString();//exception needs to be handled
            selectedLocation = selectedLocation.Trim();
            string[] LocationID = selectedLocation.Split('|');
            selectedLocation = LocationID[1].Trim();
            string postalcode = LocationID[2].Trim();
            int id_l = Convert.ToInt32(LocationID[0].Trim());
            selectedLocation = locationsNameTextBox.Text;
            postalcode = postalLocationsTextBox.Text;
            MessageBox.Show(Convert.ToString(id_l));
            MessageBox.Show(selectedLocation);
            MessageBox.Show(postalcode);
            Locations loc = new Locations(id_l, selectedLocation, postalcode);
            dbc.UpdateLocations(loc);
            locationslistBox.Items.Clear();
            OutputLocations();
        }
    
        private void publishersCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void locationslistBox_DoubleClick(object sender, EventArgs e)
        {
            string selectedLocation = locationslistBox.SelectedItem.ToString();//exception needs to be handled
            selectedLocation = selectedLocation.Trim();
            string[] LocationID = selectedLocation.Split('|');
            selectedLocation = LocationID[1].Trim();
            string postalcode = LocationID[2].Trim();
            int id_l = Convert.ToInt32(LocationID[0].Trim());
            locationsNameTextBox.Text = selectedLocation.ToString();
            postalLocationsTextBox.Text = postalcode.ToString();
        }

        private void locationsDeleteButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedLocation = locationslistBox.SelectedItem.ToString();//exception needs to be handled
            selectedLocation = selectedLocation.Trim();
            string[] LocationID = selectedLocation.Split('|');
            selectedLocation = LocationID[1].Trim();
            string postalcode = LocationID[2].Trim();
            int id_l = Convert.ToInt32(LocationID[0].Trim());
            string name1 = locationsNameTextBox.Text;
            string postal = postalLocationsTextBox.Text;
            Locations loc = new Locations(id_l, name1, postal);
            dbc.DeleteLocations(loc);
            locationslistBox.Items.Clear();
            OutputLocations();
        }

        private void locationsAddButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            int id_l = 0;
            string name1 = locationsNameTextBox.Text;
            string postal = postalLocationsTextBox.Text;
            Locations loc = new Locations(id_l, name1, postal);
            dbc.SaveLocations(loc);
            locationslistBox.Items.Clear();
            OutputLocations();          
        }

        private void showLocationsButton_Click(object sender, EventArgs e)
        {
            OutputLocations();
        }


#endregion

#region PublisherControlls
        public void OutputPublishers()
        {
            foreach (string name in db.ReadPublishers())
            {
                publishersListBox.Items.Add(name);
            }
        }

        private void publishersShowAllButton_Click(object sender, EventArgs e)
        {
            OutputPublishers();
        }

        private void publishersAddButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            int id_p = 0;
            string name1 = publishersNameTextBox.Text;
            string description = publishersDescriptionRichTextBox.Text;

            Publishers pub = new Publishers(id_p, name1, description);
            dbc.SavePublishers(pub);

            publishersListBox.Items.Clear();
            OutputPublishers();
        }

        private void publishersUpdateButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedPublisher = publishersListBox.SelectedItem.ToString();//exception needs to be handled
            selectedPublisher = selectedPublisher.Trim();
            string[] PublisherID = selectedPublisher.Split('|');
            selectedPublisher = PublisherID[1].Trim();
            string description = PublisherID[2].Trim();
            int id_p = Convert.ToInt32(PublisherID[0].Trim());
            selectedPublisher = publishersNameTextBox.Text;
            description = publishersDescriptionRichTextBox.Text;
            MessageBox.Show(Convert.ToString(id_p));
            MessageBox.Show(selectedPublisher);
            MessageBox.Show(description);
            Publishers pub = new Publishers(id_p, selectedPublisher, description);
            dbc.UpdatePublishers(pub);
            publishersListBox.Items.Clear();
            OutputPublishers();
        }

        private void publishersDeleteButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedPublisher = publishersListBox.SelectedItem.ToString();//exception needs to be handled
            selectedPublisher = selectedPublisher.Trim();
            string[] PublisherID = selectedPublisher.Split('|');
            selectedPublisher = PublisherID[1].Trim();
            string description = PublisherID[2].Trim();
            int id_p = Convert.ToInt32(PublisherID[0].Trim());
            selectedPublisher = publishersNameTextBox.Text;
            description = publishersDescriptionRichTextBox.Text;
            Publishers pub = new Publishers(id_p, selectedPublisher, description);
            dbc.DeletePublishers(pub);
            publishersListBox.Items.Clear();
            OutputPublishers();
        }

        private void publishersListBox_DoubleClick(object sender, EventArgs e)
        {
            string selectedPublisher = publishersListBox.SelectedItem.ToString();//exception needs to be handled
            selectedPublisher = selectedPublisher.Trim();
            string[] PublisherID = selectedPublisher.Split('|');
            selectedPublisher = PublisherID[1].Trim();
            string description = PublisherID[2].Trim();
            int id_p = Convert.ToInt32(PublisherID[0].Trim());
            publishersNameTextBox.Text = selectedPublisher.ToString();
            publishersDescriptionRichTextBox.Text = description.ToString();
        }
#endregion


#region AuthorControlls
        public void OutputAuthors()
        {
            foreach (string name in db.ReadAuthors())
            {
                authorsListbox.Items.Add(name);
            }
        }

        private void authorsShowAllButton_Click(object sender, EventArgs e)
        {
            authorsListbox.Items.Clear();
            OutputAuthors();
        }

        private void authorsAddButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            int id_a = 0;
            string name = authorsNameTextBox.Text;
            string surname = authorsSurnameTextBox.Text;
            string middlename = authorsMiddlenameTextBox.Text;

            if (authorsMiddlenameTextBox.Text == "")
            {
                Authors auth = new Authors(id_a, name, surname);
                dbc.SaveAuthors(auth);
                authorsListbox.Items.Clear();
                OutputAuthors();

            }
            else
            {
                Authors aut = new Authors(id_a, name, surname);
                dbc.SaveAuthors(aut);
                authorsListbox.Items.Clear();
                OutputAuthors();
            }
        }

        private void authorsUpdateButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedAuthor = authorsListbox.SelectedItem.ToString();//exception needs to be handled
            selectedAuthor = selectedAuthor.Trim();
            string[] AuthorID = selectedAuthor.Split('|');
            selectedAuthor = AuthorID[1].Trim();
            string surname = AuthorID[2].Trim();
            string middlename = AuthorID[3].Trim();
            int id_a = Convert.ToInt32(AuthorID[0].Trim());
            selectedAuthor = authorsNameTextBox.Text;
            surname = authorsSurnameTextBox.Text;
            middlename = authorsMiddlenameTextBox.Text;
            MessageBox.Show(Convert.ToString(id_a));
            MessageBox.Show(selectedAuthor);
            MessageBox.Show(surname);
            MessageBox.Show(middlename);
            Authors aut = new Authors(id_a, selectedAuthor, surname);
            dbc.UpdateAuthors(aut);
            authorsListbox.Items.Clear();
            OutputAuthors();
        }

        private void authorsDeleteButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedAuthor = authorsListbox.SelectedItem.ToString();//exception needs to be handled
            selectedAuthor = selectedAuthor.Trim();
            string[] AuthorID = selectedAuthor.Split('|');
            selectedAuthor = AuthorID[1].Trim();
            string surname = AuthorID[2].Trim();
            string middlename = AuthorID[3].Trim();
            int id_a = Convert.ToInt32(AuthorID[0].Trim());
            selectedAuthor = authorsNameTextBox.Text;
            surname = authorsSurnameTextBox.Text;
            middlename = authorsMiddlenameTextBox.Text;
            MessageBox.Show(Convert.ToString(id_a));
            MessageBox.Show(selectedAuthor);
            MessageBox.Show(surname);
            MessageBox.Show(middlename);
            Authors aut = new Authors(id_a, selectedAuthor, surname);
            dbc.DeleteAuthors(aut);
            authorsListbox.Items.Clear();
            OutputAuthors();
        }

        private void authorsListbox_DoubleClick(object sender, EventArgs e)
        {
            string selectedAuthors = authorsListbox.SelectedItem.ToString();//exception needs to be handled
            selectedAuthors = selectedAuthors.Trim();
            string[] PublisherID = selectedAuthors.Split('|');
            selectedAuthors = PublisherID[1].Trim();
            string surname = PublisherID[2].Trim();
            string middlename = PublisherID[3].Trim();
            int id_a = Convert.ToInt32(PublisherID[0].Trim());
            authorsNameTextBox.Text = selectedAuthors.ToString();
            authorsSurnameTextBox.Text = surname.ToString();
            authorsMiddlenameTextBox.Text = surname.ToString();
        }
        #endregion

#region Genres

        public void OutputGenres()
        {
            foreach (string name in db.ReadGenres())
            {
                genreslistBox.Items.Add(name);
            }
        }


        private void genresShowallButton_Click(object sender, EventArgs e)
        {   
            genreslistBox.Items.Clear();
            OutputGenres();  
        }


      

        private void genresAddButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            int id_g = 0;
            string name = genresNametextBox.Text;
            string description = genresDescriptionrichTextBox.Text;

            Genres gen = new Genres(id_g, name);
            dbc.SaveGenres(gen);

            genreslistBox.Items.Clear();
            OutputGenres();
        }

        private void genresUpdateButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedGenre = genreslistBox.SelectedItem.ToString();//exception needs to be handled
            selectedGenre = selectedGenre.Trim();
            string[] GenreID = selectedGenre.Split('|');
            selectedGenre = GenreID[1].Trim();
            string description = GenreID[2].Trim();
            int id_g = Convert.ToInt32(GenreID[0].Trim());
            selectedGenre = genresNametextBox.Text;
            description = genresDescriptionrichTextBox.Text;
            Genres gen = new Genres(id_g, selectedGenre);
            dbc.UpdateGenres(gen);
            genreslistBox.Items.Clear();
            OutputGenres();
        }

        private void genresDeleteButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedGenre = genreslistBox.SelectedItem.ToString();//exception needs to be handled
            selectedGenre = selectedGenre.Trim();
            string[] GenreID = selectedGenre.Split('|');
            selectedGenre = GenreID[1].Trim();
            string description = GenreID[2].Trim();
            int id_g = Convert.ToInt32(GenreID[0].Trim());
            selectedGenre = genresNametextBox.Text;
            description = genresDescriptionrichTextBox.Text;
            Genres gen = new Genres(id_g, selectedGenre);
            dbc.DeleteGenres(gen);
            genreslistBox.Items.Clear();
            OutputGenres();
        }
       

        

        private void genreslistBox_DoubleClick(object sender, EventArgs e)
        {
            string selectedGenre = genreslistBox.SelectedItem.ToString();//exception needs to be handled
            selectedGenre = selectedGenre.Trim();
            string[] GenreID = selectedGenre.Split('|');
            selectedGenre = GenreID[1].Trim();
            string description = GenreID[2].Trim();
            int id_g = Convert.ToInt32(GenreID[0].Trim());
            genresNametextBox.Text = selectedGenre.ToString();
            genresDescriptionrichTextBox.Text = description.ToString();
        }
        #endregion

        #region Books
        #region FunctionsForBooks
        public void OutputLocationsOnBooks()
        {
            foreach (string name in db.ReadLocations())
            {
                locationBooksCombobox.Items.Add(name);
            }
        }

        public void OutputAuthorsOnBooks()
        {
            foreach (string name in db.ReadAuthors())
            {
                authorsBooksCombobox.Items.Add(name);
            }
        }

        public void OutputPublishersOnBooks()
        {
            foreach (string name in db.ReadPublishers())
            {
                publishersBooksCombobox.Items.Add(name);
            }
        }

        public void OutputGenresOnBooks()
        {
            foreach (string name in db.ReadGenres())
            {
                genreBooksCombobox.Items.Add(name);
            }
        }
        public void OutputBooks()
        {
            foreach (string name in db.ReadBooks())
            {
                bookslistBox.Items.Add(name);
            }
        }




        #endregion



        private void booksShowAllButton_Click(object sender, EventArgs e)
        {
            bookslistBox.Items.Clear();
            OutputBooks();
        }

        private void booksAddButton_Click(object sender, EventArgs e)
        {
            ratingNumeric.Minimum = 1;
            ratingNumeric.Maximum = 10;
            databaseController dbc = new databaseController();
           
            int id_b = 0;
            string title = titleTextBox.Text;
            int total_pages = Convert.ToInt32(numOfPages.Value);
            int rating = Convert.ToInt32(ratingNumeric.Value);
            string publish_date=Convert.ToString(DateTime.Now.Date.ToString("MM/dd/yyyy"));
            string summary = Convert.ToString(summaryTextBox.Text);

            //getting location id in bookstab
            #region location_id
            string selectedLocation = locationBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedLocation = selectedLocation.Trim();
            string[] LocationID = selectedLocation.Split('|');
            selectedLocation = LocationID[1].Trim();
            string postalcode = LocationID[2].Trim();
            int id_l = Convert.ToInt32(LocationID[0].Trim());
            #endregion

            //getting publisher id in books tab
            #region publisher_id
            string selectedPublisher = publishersBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedPublisher = selectedPublisher.Trim();
            string[] PublisherID = selectedPublisher.Split('|');
            selectedPublisher = PublisherID[1].Trim();
            string description = PublisherID[2].Trim();
            int id_p = Convert.ToInt32(PublisherID[0].Trim());
            selectedPublisher = publishersNameTextBox.Text;
            description = publishersDescriptionRichTextBox.Text;
            #endregion

            Books b = new Books(id_b, title, summary, year, lost, genre_id);
            dbc.SaveBooks(b);
            

            //getting genre id
            #region genre_id
            string selectedGenre = genreBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedGenre = selectedGenre.Trim();
            string[] GenreID = selectedGenre.Split('|');
            selectedGenre = GenreID[1].Trim();
            string g_description = GenreID[2].Trim();
            int id_g = Convert.ToInt32(GenreID[0].Trim());
            //selectedGenre = genresNametextBox.Text;
            //g_description = genresDescriptionrichTextBox.Text;
            #endregion

            //getting author id
            #region author_id
            string selectedAuthor = authorsBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedAuthor = selectedAuthor.Trim();
            string[] AuthorID = selectedAuthor.Split('|');
            selectedAuthor = AuthorID[1].Trim();
            string surname = AuthorID[2].Trim();
            string middlename = AuthorID[3].Trim();
            int id_a = Convert.ToInt32(AuthorID[0].Trim());
            #endregion

            //getting book_id
            #region book_id

            List<string> listOfBookss = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=hattie.db.elephantsql.com; User Id=oxbcwgvz;" + "Password=igpiilcYjHtSKKDcs3wuGd15RtjskDzP; Database=oxbcwgvz;"))
            {
                con.Open();
                string query = "SELECT id_b FROM books WHERE(title='" + title + "' AND total_pages='" + total_pages + "' AND rating='" +rating + "' AND publisher_id='" + id_p+ "' AND location_id='" + id_l + "')";
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id_bb = reader.GetInt32(0);
                    listOfBookss.Add(id_bb+""); 
                }
                con.Close(); 
            }
            string prvi = listOfBookss.ElementAt(0);
            int idbb = Convert.ToInt32(prvi);
            #endregion

            Book_Authors ba = new Book_Authors(idbb, id_a);
            dbc.SaveBooksAuthors(ba);
            Book_Genres bg = new Book_Genres(idbb, id_g);
            dbc.SaveBooksGenres(bg);
            bookslistBox.Items.Clear();
            OutputBooks();
           
        }

        private void booksUpdateButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedBook = bookslistBox.SelectedItem.ToString();//exception needs to be handled
            MessageBox.Show(selectedBook);
            selectedBook = selectedBook.Trim();
            string[] BookID = selectedBook.Split('|');
            selectedBook = BookID[1].Trim();
            
            int id_b = Convert.ToInt32(BookID[0].Trim());


            string title = titleTextBox.Text;
            int total_pages = Convert.ToInt32(numOfPages.Value);
            int rating = Convert.ToInt32(ratingNumeric.Value);
            string publish_date = Convert.ToString(DateTime.Now.Date.ToString("MM/dd/yyyy"));
            string summary = Convert.ToString(summaryTextBox.Text);


            //getting location id in bookstab
            #region location_id
            string selectedLocation = locationBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedLocation = selectedLocation.Trim();
            string[] LocationID = selectedLocation.Split('|');
            selectedLocation = LocationID[1].Trim();
            string postalcode = LocationID[2].Trim();
            int id_l = Convert.ToInt32(LocationID[0].Trim());
            #endregion

            //getting publisher id in books tab
            #region publisher_id
            string selectedPublisher = publishersBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedPublisher = selectedPublisher.Trim();
            string[] PublisherID = selectedPublisher.Split('|');
            selectedPublisher = PublisherID[1].Trim();
            string description = PublisherID[2].Trim();
            int id_p = Convert.ToInt32(PublisherID[0].Trim());
            selectedPublisher = publishersNameTextBox.Text;
            description = publishersDescriptionRichTextBox.Text;
            #endregion

            //getting genre id
            #region genre_id
            string selectedGenre = genreBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedGenre = selectedGenre.Trim();
            string[] GenreID = selectedGenre.Split('|');
            selectedGenre = GenreID[1].Trim();
            string description_genre = GenreID[2].Trim();
            int id_g = Convert.ToInt32(GenreID[0].Trim());
            int id_aa = 0;
            #endregion

            #region author_id
            string selectedAuthor = authorsBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedAuthor = selectedAuthor.Trim();
            string[] AuthorID = selectedAuthor.Split('|');
            selectedAuthor = AuthorID[1].Trim();
            string surname = AuthorID[2].Trim();
            string middlename = AuthorID[3].Trim();
            int id_a = Convert.ToInt32(AuthorID[0].Trim());
            #endregion

            Book_Authors ba = new Book_Authors(id_b, id_a);
            dbc.UpdateBooksAuthors(ba);

            Book_Genres bg = new Book_Genres(id_b, id_g);
            dbc.UpdateBooksGenres(bg);


            Books b = new Books(id_b, title, summary, year, lost, genre_id);
            dbc.UpdateBooks(b);
            bookslistBox.Items.Clear();
            OutputBooks();


        }

        private void booksDeleteButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedBook = bookslistBox.SelectedItem.ToString();//exception needs to be handled
            selectedBook = selectedBook.Trim();
            string[] BookID = selectedBook.Split('|');
            selectedBook = BookID[1].Trim();
            int total_pages = Convert.ToInt32(BookID[2].Trim());
            int id_b = Convert.ToInt32(BookID[0].Trim());
            string publish_date = BookID[4].Trim();
            int rating = Convert.ToInt32(BookID[3].Trim());
            string summary = BookID[5].Trim();

            int publisher_id = Convert.ToInt32(BookID[6].Trim());
            int location_id = Convert.ToInt32(BookID[7].Trim());


            int id_g = 0;
            
            Books b = new Books(id_b, selectedBook, summary, year, lost, genre_id);
            Book_Genres bg = new Book_Genres(id_b, id_g);
            dbc.DeleteBooksGenres(bg);

            Book_Authors ba = new Book_Authors(id_b, id_g);
            dbc.DeleteBooksAuthors(ba);

            dbc.DeleteBooks(b);
            bookslistBox.Items.Clear();
            OutputBooks();
        }
        #endregion

        private void bookslistBox_DoubleClick(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedBook = bookslistBox.SelectedItem.ToString();//exception needs to be handled
            selectedBook = selectedBook.Trim();
            string[] BookID = selectedBook.Split('|');
            selectedBook = BookID[1].Trim();
            int total_pages =Convert.ToInt32(BookID[2].Trim());
            int id_b = Convert.ToInt32(BookID[0].Trim());
            string publish_date = BookID[4].Trim();
            int rating = Convert.ToInt32(BookID[3].Trim());
            string summary = BookID[5].Trim();

            titleTextBox.Text = selectedBook.ToString();
            numOfPages.Value = total_pages;
            ratingNumeric.Value = rating;
            //publish_date

            summaryTextBox.Text = summary.ToString();


        }
    }
}
