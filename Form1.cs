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
using System.Data.SQLite;
using System.Security.Cryptography;


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
            OutputUsers();
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
            

            Publishers pub = new Publishers(id_p, name1);
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
            
            int id_p = Convert.ToInt32(PublisherID[0].Trim());
            selectedPublisher = publishersNameTextBox.Text;
            
           
            Publishers pub = new Publishers(id_p, selectedPublisher);
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
            
            int id_p = Convert.ToInt32(PublisherID[0].Trim());
            selectedPublisher = publishersNameTextBox.Text;
           
            Publishers pub = new Publishers(id_p, selectedPublisher);
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
            
            int id_p = Convert.ToInt32(PublisherID[0].Trim());
            publishersNameTextBox.Text = selectedPublisher.ToString();
            
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
            

       
                Authors aut = new Authors(id_a, name, surname);
                dbc.SaveAuthors(aut);
                authorsListbox.Items.Clear();
                OutputAuthors();
            
        }

        private void authorsUpdateButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedAuthor = authorsListbox.SelectedItem.ToString();//exception needs to be handled
            selectedAuthor = selectedAuthor.Trim();
            string[] AuthorID = selectedAuthor.Split('|');
            selectedAuthor = AuthorID[1].Trim();
            string surname = AuthorID[2].Trim();
            
            int id_a = Convert.ToInt32(AuthorID[0].Trim());
            selectedAuthor = authorsNameTextBox.Text;
            surname = authorsSurnameTextBox.Text;
            
            
            
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
            
            int id_a = Convert.ToInt32(AuthorID[0].Trim());
            selectedAuthor = authorsNameTextBox.Text;
            surname = authorsSurnameTextBox.Text;
        
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
            int id_a = Convert.ToInt32(PublisherID[0].Trim());
            authorsNameTextBox.Text = selectedAuthors.ToString();
            authorsSurnameTextBox.Text = surname.ToString();
            
        }
        #endregion

        #region GenresControlls

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
            
            int id_g = Convert.ToInt32(GenreID[0].Trim());
            selectedGenre = genresNametextBox.Text;
            
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
            
            int id_g = Convert.ToInt32(GenreID[0].Trim());
            selectedGenre = genresNametextBox.Text;
            
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
            
            int id_g = Convert.ToInt32(GenreID[0].Trim());
            genresNametextBox.Text = selectedGenre.ToString();
            
        }
        #endregion

        #region UserControlls
        public void OutputUsers()
        {
            foreach (string name in db.ReadUsers())
            {
                userShowcomboBox.Items.Add(name);
            }
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


        static string Encrypt(string password)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte [] data = sha1.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);    
            }
        }

        private void booksShowAllButton_Click(object sender, EventArgs e)
        {
            bookslistBox.Items.Clear();
            OutputBooks();
        }

        private void booksAddButton_Click(object sender, EventArgs e)
        {
            
            databaseController dbc = new databaseController();
           
            int id_b = 0;
            string title = titleTextBox.Text;
            string summary = Convert.ToString(summaryTextBox.Text);
            string year = Convert.ToString(yearTextBox.Text);
            int lost = 0;
            string publish_date=Convert.ToString(DateTime.Now.Date.ToString("MM/dd/yyyy"));


            if (lostBookCheckBox.Checked)
               lost = 1;
            else
                lost = 0;



            
            #region genre_id
            string selectedGenre = genreBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedGenre = selectedGenre.Trim();
            string[] GenreID = selectedGenre.Split('|');
            selectedGenre = GenreID[1].Trim();
            
            int genre_id = Convert.ToInt32(GenreID[0].Trim());
            #endregion

            
            #region publisher_id
            string selectedPublisher = publishersBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedPublisher = selectedPublisher.Trim();
            string[] PublisherID = selectedPublisher.Split('|');
            selectedPublisher = PublisherID[1].Trim();
            
            int publisher_id = Convert.ToInt32(PublisherID[0].Trim());
            selectedPublisher = publishersNameTextBox.Text;
            
            #endregion

            Books b = new Books(id_b, title, summary, year, lost, genre_id, publisher_id);
            dbc.SaveBooks(b);
            

            //getting genre id
            #region genre_id
            string selectedGenre1 = genreBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedGenre = selectedGenre.Trim();
            string[] GenreID1 = selectedGenre.Split('|');
            selectedGenre = GenreID[1].Trim();
            
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
            int id_a = Convert.ToInt32(AuthorID[0].Trim());
            #endregion

            //getting book_id
            #region book_id

            List<string> listOfBookss = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection("data source=Knjiznica_projektt.db"))
            {
                con.Open();
                string query = "SELECT id_b FROM books WHERE(title='" + title + "' AND summary='" + summary + "' AND year='" + year + "' AND genre_id='" + id_g+ "' AND publisher_id='" + publisher_id + "')";
                SQLiteCommand com = new SQLiteCommand(query, con);
                SQLiteDataReader reader = com.ExecuteReader();
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

            Book_Authors ba = new Book_Authors(id_a, idbb);
            dbc.SaveBooksAuthors(ba);
            //Book_Genres bg = new Book_Genres(idbb, id_g);
            //dbc.SaveBooksGenres(bg);
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
            string year = yearTextBox.Text;
            int lost;

            if (lostBookCheckBox.Checked)
            {
                lost = 1;
            }
            else
            {
                lost = 0;
            }

            string title = titleTextBox.Text;
      
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
            
            int publisher_id = Convert.ToInt32(PublisherID[0].Trim());
            selectedPublisher = publishersNameTextBox.Text;
            
            #endregion

            //getting genre id
            #region genre_id
            
            string selectedGenre = genreBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedGenre = selectedGenre.Trim();
            string[] GenreID = selectedGenre.Split('|');
            selectedGenre = GenreID[1].Trim();
           
            int genre_id = Convert.ToInt32(GenreID[0].Trim());
            int id_aa = 0;
            #endregion

            #region author_id
            Book_Authors id = new Book_Authors(0, id_b);//g je sam zato k je
            dbc.ReadAuthorsID(id);
            int id_aaa = 0;
            foreach (int k in dbc.ReadAuthorsID(id))
            {
                id_aaa = k;
            }
            MessageBox.Show("star id"+Convert.ToString(id_aaa));
             string selectedAuthor = authorsBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedAuthor = selectedAuthor.Trim();
            string[] AuthorID = selectedAuthor.Split('|');
            selectedAuthor = AuthorID[1].Trim();
            string surname = AuthorID[2].Trim();
            
            int id_a = Convert.ToInt32(AuthorID[0].Trim());
            #endregion
            MessageBox.Show("nov id"+Convert.ToString(id_a));



            Book_Authors ba = new Book_Authors(id_a, id_b);
            dbc.UpdateBooksAuthors(ba);

            


            Books b = new Books(id_b, title, summary, year, lost, genre_id, publisher_id);
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
            int id_b = Convert.ToInt32(BookID[0].Trim());
            selectedBook = BookID[1].Trim();//title
            string summary = BookID[2].Trim();
            string year = BookID[3].Trim();
            int lost = Convert.ToInt32(BookID[4].Trim());
            int genre_id = Convert.ToInt32(BookID[5].Trim());
            int publisher_id = Convert.ToInt32(BookID[6].Trim());

            int id_g = 0;
            
            Books b = new Books(id_b, selectedBook, summary, year, lost, genre_id, publisher_id);

            #region author_id
            Book_Authors id = new Book_Authors(id_g, id_b);//g je sam zato k je
            dbc.ReadAuthorsID(id);
            int id_a=0;
            foreach (int k in dbc.ReadAuthorsID(id))
            {
                 id_a = k;
            }

            /*string selectedAuthor = authorsBooksCombobox.SelectedItem.ToString();//exception needs to be handled
            selectedAuthor = selectedAuthor.Trim();
            string[] AuthorID = selectedAuthor.Split('|');
            selectedAuthor = AuthorID[1].Trim();
            string surname = AuthorID[2].Trim();
            int id_a = Convert.ToInt32(AuthorID[0].Trim());*/
            #endregion

            Book_Authors ba = new Book_Authors(id_a, id_b);
            dbc.DeleteBooksAuthors(ba);

            dbc.DeleteBooks(b);
            bookslistBox.Items.Clear();
            OutputBooks();
        }
        

        private void bookslistBox_DoubleClick(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedBook = bookslistBox.SelectedItem.ToString();//exception needs to be handled
            selectedBook = selectedBook.Trim();
            string[] BookID = selectedBook.Split('|');
            int id_b = Convert.ToInt32(BookID[0].Trim());

            selectedBook = BookID[1].Trim();//title
            string summary = BookID[2].Trim();
        
            string year = BookID[3].Trim();
            int lost = Convert.ToInt32(BookID[4].Trim());

            //string genre_id = BookID[5].Trim();
            int genre_id = Convert.ToInt32(BookID[5].Trim());
            int publisher_id = Convert.ToInt32(BookID[6].Trim());

        





            titleTextBox.Text = selectedBook.ToString();
         
            //publish_date

            summaryTextBox.Text = summary.ToString();


        }
#endregion


        //register user button
        private void button14_Click(object sender, EventArgs e)
        {
            userRegistrationForm a = new userRegistrationForm();
            a.Close();
            a.Show();
  
            userShowcomboBox.Items.Clear();
            OutputUsers();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            string password = passwordChangeTextbox.Text;
            if (string.IsNullOrEmpty(passwordChangeTextbox.Text))
            {
                MessageBox.Show("Polje ne sme biti prazno!");
            }
            else
                password = Encrypt(passwordChangeTextbox.Text);
            
            string passwordV2 = passwordChangeTextboxV2.Text;
            if (string.IsNullOrEmpty(passwordChangeTextboxV2.Text))
            {
                MessageBox.Show("Polje ne sme biti prazno!");
            }
            else
                passwordV2 = Encrypt(passwordChangeTextboxV2.Text);

            if (password != passwordV2)
            {
                MessageBox.Show("Gesli se ne ujemata!");
            }
            else
            { 
            
            }
        }

        private void editUserButton_Click(object sender, EventArgs e)
        {
            
            userUpdateForm a = new userUpdateForm();
            
      

            databaseController dbc = new databaseController();
            string selectedUser = userShowcomboBox.SelectedItem.ToString();//exception needs to be handled
            selectedUser = selectedUser.Trim();
            string[] UserID = selectedUser.Split('|');
            int id_u = Convert.ToInt32(UserID[0].Trim());
            string name = UserID[1].Trim();//user's name
            string surname = UserID[2].Trim();
            string tel = UserID[3].Trim();
            string address = UserID[4].Trim();
            string email = UserID[5].Trim();
            string username = UserID[6].Trim();
            string password = UserID[7].Trim();
            string notes = UserID[8].Trim();
            int location_id = Convert.ToInt32(UserID[9].Trim());

            
            userUpdateForm ab = new userUpdateForm(id_u, name, surname, tel, address, email, username, password, notes, location_id);

            
            a.Show();
            userShowcomboBox.Items.Clear();
            OutputUsers();

        }

        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedUser = userShowcomboBox.SelectedItem.ToString();//exception needs to be handled
            selectedUser = selectedUser.Trim();
            string[] UserID = selectedUser.Split('|');
            int id_u = Convert.ToInt32(UserID[0].Trim());
            selectedUser = UserID[1].Trim();//user's name
            string surname = UserID[2].Trim();
            string tel = UserID[3].Trim();
            string address = UserID[4].Trim();
            string email = UserID[5].Trim();
            string username = UserID[6].Trim();
            string password = UserID[7].Trim();
            string notes = UserID[8].Trim();
            int location_id = Convert.ToInt32(UserID[9].Trim());

            Users u = new Users(id_u, selectedUser, surname, tel, address, email, username, password, notes);
            dbc.DeleteUsers(u);
            userShowcomboBox.Items.Clear();
            OutputUsers();
        }
    }
}
