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
            OutputBooksOnRents_UnLended();

        }
        
        static string Encrypt(string password)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = sha1.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }

        #region StaticFieldsForEditUser
        public static int user_id_u = 0;
        public static string name = "";
        public static string surname = "";
        public static string tel = "";
        public static string address = "";
        public static string email = "";
        public static string username = "";
        public static string passwordV1 = "";
        public static string passwordV2 = "";
        public static string notes = "";
        public static string location_name = "";
        public static string location_postalcode = "";
        public static int user_location_id=0;
        #endregion

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
        {        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {        }
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
        /*   public void OutputBooksOnRents_Lended()
           {
               foreach (string name in db.ReadRents())
               {
                   userLendedBookslistBox.Items.Add(name);
               }
           }*/
        public void OutputBooksOnRents_UnLended()
        {
            foreach (string name in db.ReadUnlendedBooks())
            {
                userUnLendedBookslistBox.Items.Add(name);
            }
        }

        #endregion

        #region Books



        private void booksShowAllButton_Click(object sender, EventArgs e)
        {
            bookslistBox.Items.Clear();
            OutputBooks();
        }
        private void booksAddButton_Click(object sender, EventArgs e)
        {
            if (titleTextBox.Text == "" || yearTextBox.Text == "" || authorsBooksCombobox.SelectedItem == null || publishersBooksCombobox.SelectedItem == null || genreBooksCombobox.SelectedItem == null || locationBooksCombobox.SelectedItem == null)
            {
                MessageBox.Show("Preverite vnos. Eno izmed polij ni napolnjeno.");
            }
            else
            {
                databaseController dbc = new databaseController();
                int id_b = 0;
                string title = titleTextBox.Text;
                string summary = Convert.ToString(summaryTextBox.Text);
                string year = Convert.ToString(yearTextBox.Text);
                int lost = 0;
                string publish_date = Convert.ToString(DateTime.Now.Date.ToString("MM/dd/yyyy"));
                if (lostBookCheckBox.Checked)
                    lost = 1;
                else
                    lost = 0;
                #region genre_id
                string selectedGenre1 = genreBooksCombobox.SelectedItem.ToString();//exception needs to be handled
                selectedGenre1 = selectedGenre1.Trim();
                string[] GenreID1 = selectedGenre1.Split('|');
                selectedGenre1 = GenreID1[1].Trim();

                int genre_id = Convert.ToInt32(GenreID1[0].Trim());
                #endregion
                #region publisher_id
                string selectedPublisher = publishersBooksCombobox.SelectedItem.ToString();//exception needs to be handled
                selectedPublisher = selectedPublisher.Trim();
                string[] PublisherID = selectedPublisher.Split('|');
                selectedPublisher = PublisherID[1].Trim();

                int publisher_id = Convert.ToInt32(PublisherID[0].Trim());
                selectedPublisher = publishersNameTextBox.Text;
                MessageBox.Show(Convert.ToString(publisher_id));
                #endregion
                #region location_id
                string selectedLocation = locationBooksCombobox.SelectedItem.ToString();//exception needs to be handled
                selectedLocation = selectedLocation.Trim();
                string[] LocationID = selectedLocation.Split('|');
                selectedLocation = LocationID[1].Trim();
                string postalcode = LocationID[2].Trim();
                int location_idd = Convert.ToInt32(LocationID[0].Trim());
                MessageBox.Show("locationid" + Convert.ToString(location_idd) + selectedLocation + postalcode);
                #endregion
                Books b = new Books(id_b, title, summary, year, lost, genre_id, publisher_id, location_idd);
                dbc.SaveBooks(b);

                dbc.idBooks(b);
                int book_id = 0;
                foreach (int k in dbc.idBooks(b))
                {
                    book_id = k;
                }
                //getting genre id
                #region genre_id
                string selectedGenre = genreBooksCombobox.SelectedItem.ToString();//exception needs to be handled
                selectedGenre = selectedGenre.Trim();
                string[] GenreID = selectedGenre.Split('|');
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

                Book_Authors ba = new Book_Authors(id_a, book_id);
                dbc.SaveBooksAuthors(ba);
                DateTime currentDateTime = DateTime.Now;
                Rents rentss = new Rents(0, 0, Convert.ToString(currentDateTime), book_id, 0);
                dbc.SaveBookRents(rentss);
                bookslistBox.Items.Clear();
                OutputBooks();
                userUnLendedBookslistBox.Items.Clear();
                userLendedBookslistBox.Items.Clear();
                //OutputBooksOnRents_Lended();
                OutputBooksOnRents_UnLended();
            }

            
        }

        private void booksUpdateButton_Click(object sender, EventArgs e)
        {
            if (titleTextBox.Text == "" || yearTextBox.Text == "" || authorsBooksCombobox.SelectedItem == null || publishersBooksCombobox.SelectedItem == null || genreBooksCombobox.SelectedItem == null || locationBooksCombobox.SelectedItem == null)
            {
                MessageBox.Show("Preverite vnos. Eno izmed polij ni napolnjeno.");
            }
            else
            {
                databaseController dbc = new databaseController();
                string selectedBook = bookslistBox.SelectedItem.ToString();//exception needs to be handled
                selectedBook = selectedBook.Trim();
                string[] BookID = selectedBook.Split('|');
                int id_b = Convert.ToInt32(BookID[0].Trim());
                selectedBook = BookID[1].Trim();//title
                string author_name = BookID[2].Trim();
                string author_surname = BookID[3].Trim();
                int lost = Convert.ToInt32(BookID[4].Trim());
                string year = BookID[5].Trim();
                string location_name = BookID[6].Trim();
                string publisher_name = BookID[7].Trim();
                string genre_genretype = BookID[8].Trim();
                int id_g = 0;
                string summary = summaryTextBox.Text;

                #region genre_id
                string selectedGenre1 = genreBooksCombobox.SelectedItem.ToString();//exception needs to be handled
                selectedGenre1 = selectedGenre1.Trim();
                string[] GenreID1 = selectedGenre1.Split('|');
                selectedGenre1 = GenreID1[1].Trim();
                int genre_id = Convert.ToInt32(GenreID1[0].Trim());
                #endregion

                #region publisher_id
                string selectedPublisher = publishersBooksCombobox.SelectedItem.ToString();//exception needs to be handled
                selectedPublisher = selectedPublisher.Trim();
                string[] PublisherID = selectedPublisher.Split('|');
                selectedPublisher = PublisherID[1].Trim();
                int publisher_id = Convert.ToInt32(PublisherID[0].Trim());

                #endregion

                #region location_id
                string selectedLocation = locationBooksCombobox.SelectedItem.ToString();//exception needs to be handled
                selectedLocation = selectedLocation.Trim();
                string[] LocationID = selectedLocation.Split('|');
                int location_id = Convert.ToInt32(LocationID[0].Trim());
                #endregion

                #region author_id
                string selectedAuthor = authorsBooksCombobox.SelectedItem.ToString();//exception needs to be handled
                selectedAuthor = selectedAuthor.Trim();
                string[] AuthorID = selectedAuthor.Split('|');
                int author_id_waiting = Convert.ToInt32(AuthorID[0].Trim());//nov id
                #endregion

                Authors aid = new Authors(0, author_name, author_surname);//tastar id
                dbc.idAuthors(aid);
                int author_id = 0;
                foreach (int k in dbc.idAuthors(aid))
                {
                    author_id = k;
                }

                Book_Authors baid = new Book_Authors(author_id, id_b);//poiscem id v book authors z pomocjo ttih idejev
                dbc.idBookAuthors(baid);
                int book_authors_id = 0;
                foreach (int k in dbc.idBookAuthors(baid))
                {
                    book_authors_id = k;
                }

                Books b = new Books(id_b, selectedBook, summary, year, lost, genre_id, publisher_id, location_id);
                Book_Authors ba = new Book_Authors(author_id, id_b, book_authors_id, author_id_waiting);
                dbc.UpdateBooksAuthors(ba);
                dbc.UpdateBooks(b);
                bookslistBox.Items.Clear();
                OutputBooks();
                userUnLendedBookslistBox.Items.Clear();
                userLendedBookslistBox.Items.Clear();
                //OutputBooksOnRents_Lended();
                OutputBooksOnRents_UnLended();
            }
        }

        private void booksDeleteButton_Click(object sender, EventArgs e)
        {
            if (bookslistBox.SelectedItem == null)
            {
                MessageBox.Show("Nobena knjiga ni izbrana.");
            }
            else
            {
                databaseController dbc = new databaseController();
                string selectedBook = bookslistBox.SelectedItem.ToString();//exception needs to be handled
                selectedBook = selectedBook.Trim();
                string[] BookID = selectedBook.Split('|');
                int id_b = Convert.ToInt32(BookID[0].Trim());
                selectedBook = BookID[1].Trim();//title
                string author_name = BookID[2].Trim();
                string author_surname = BookID[3].Trim();
                int lost = Convert.ToInt32(BookID[4].Trim());
                string year = BookID[5].Trim();
                string location_name = BookID[6].Trim();
                string publisher_name = BookID[7].Trim();
                string genre_genretype = BookID[8].Trim();
                int id_g = 0;

                Authors aid = new Authors(0, author_name, author_surname);
                dbc.idAuthors(aid);
                int author_id = 0;
                foreach (int k in dbc.idAuthors(aid))
                {
                    author_id = k;
                }

                Locations lid = new Locations(0, location_name, "");
                dbc.idLocations(lid);
                int location_id = 0;
                foreach (int k in dbc.idLocations(lid))
                {
                    location_id = k;
                }

                Publishers pid = new Publishers(0, publisher_name);
                dbc.idPublishers(pid);
                int publisher_id = 0;
                foreach (int k in dbc.idPublishers(pid))
                {
                    publisher_id = k;
                }

                Genres gid = new Genres(0, genre_genretype);
                dbc.idGenres(gid);
                int genre_id = 0;
                foreach (int k in dbc.idGenres(gid))
                {
                    genre_id = k;
                }


                Books b = new Books(id_b, selectedBook, "", year, lost, genre_id, publisher_id, location_id);
                #region author_id
                Book_Authors id = new Book_Authors(0, id_b);
                dbc.ReadAuthorsID(id);
                int id_a = 0;
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



                Book_Authors ba = new Book_Authors(author_id, id_b);
                //MessageBox.Show("author"+Convert.ToString(author_id), "book" + Convert.ToString(id_b));
                dbc.DeleteBooksAuthors(ba);
                dbc.DeleteBooks(b);
                bookslistBox.Items.Clear();
                OutputBooks();
                userUnLendedBookslistBox.Items.Clear();
                userLendedBookslistBox.Items.Clear();
                //OutputBooksOnRents_Lended();
                OutputBooksOnRents_UnLended();
            }
        }
        private void bookslistBox_DoubleClick(object sender, EventArgs e)
        {
            //SELECT b.id_b, b.title, a.name, a.surname, b.lost, b.year, l.name, p.name, g.genretype
            databaseController dbc = new databaseController();
            string selectedBook = bookslistBox.SelectedItem.ToString();//exception needs to be handled
            selectedBook = selectedBook.Trim();
            string[] BookID = selectedBook.Split('|');
            int id_b = Convert.ToInt32(BookID[0].Trim());
            selectedBook = BookID[1].Trim();//title
            //string summary = BookID[2].Trim();    
            
            int lost = Convert.ToInt32(BookID[4].Trim());
            string year = BookID[5].Trim();
            //string genre_id = BookID[5].Trim();
            //int genre_id = Convert.ToInt32(BookID[5].Trim());
            //int publisher_id = Convert.ToInt32(BookID[6].Trim());
            titleTextBox.Text = selectedBook.ToString();
            //publish_date
            //summaryTextBox.Text = summary.ToString();
            yearTextBox.Text = year.ToString();

            if (lost == 1)
            {
                lostBookCheckBox.Checked = true;
            }
            else
                lostBookCheckBox.Checked = false;
        }
        #endregion

        #region Users
        //register user button
        private void button14_Click(object sender, EventArgs e)
        {
            userRegistrationForm a = new userRegistrationForm();
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
        }

        private void editUserButton_Click(object sender, EventArgs e)
        {
            //u.id_u, u.name, u.surname, u.tel, u.address, u.notes, l.name, l.postalcode
            userUpdateForm a = new userUpdateForm();
            databaseController dbc = new databaseController();
            /*string selectedUser = userShowcomboBox.SelectedItem.ToString();//exception needs to be handled
            selectedUser = selectedUser.Trim();
            string[] UserID1 = selectedUser.Split('|');
            int id_u= Convert.ToInt32(UserID1[0].Trim());

           

            userShowcomboBox.Items.Clear();
                foreach (string name in dbc.ReadUsersForUpdate(u))
                {
                    userShowcomboBox.Items.Add(name);
                }



         
            
            string[] UserID = selectedUser.Split('|');
            user_id_u = Convert.ToInt32(UserID[0].Trim());
            name = UserID[1].Trim();//user's name
            surname = UserID[2].Trim();
            tel = UserID[3].Trim();
            address = UserID[4].Trim();
            email= UserID[5].Trim();
            username= UserID[6].Trim();
            passwordV1 = UserID[7].Trim();
            notes = UserID[8].Trim();
           // location_name = UserID[9].Trim();
           // location_postalcode = UserID[10].Trim();*/
      
            







            a.Show();
            userShowcomboBox.Items.Clear();
            OutputUsers();
        }

        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            if (userShowcomboBox.SelectedItem == null)
            {
                MessageBox.Show("Izbran ni noben uporabnik/član.");
            }
            else
            {
                //u.id_u, u.name, u.surname, u.tel, u.address, u.notes, l.name, l.postalcode
                databaseController dbc = new databaseController();
                string selectedUser = userShowcomboBox.SelectedItem.ToString();//exception needs to be handled
                selectedUser = selectedUser.Trim();
                string[] UserID = selectedUser.Split('|');
                int id_u = Convert.ToInt32(UserID[0].Trim());
                selectedUser = UserID[1].Trim();//user's name
                string surname = UserID[2].Trim();
                string tel = UserID[3].Trim();
                string address = UserID[4].Trim();
                string notes = UserID[5].Trim();
                string location_name = UserID[6].Trim();
                string location_postalcode = UserID[7].Trim();
                Users u = new Users(id_u, selectedUser, surname, tel, address, "", "", "", notes);
                dbc.DeleteUsers(u);
                userShowcomboBox.Items.Clear();
                OutputUsers();
            }
        }
        #endregion

        #region Rents
        private void rentABookButton_Click(object sender, EventArgs e)
        {
    
            if (userShowcomboBox.SelectedItem == null)
            {
                MessageBox.Show("Izberite člana.");
            }
            else
            {
                databaseController dbc = new databaseController();
                string selectedUser = userShowcomboBox.SelectedItem.ToString();//exception needs to be handled
                selectedUser = selectedUser.Trim();
                string[] UserID = selectedUser.Split('|');
                int id_u = Convert.ToInt32(UserID[0].Trim());
                string name = UserID[1].Trim();//title
                string surname = UserID[2].Trim();
                string tel = UserID[3].Trim();
                string address = UserID[3].Trim();
                string location_name = UserID[3].Trim();
                string location_postalcode = UserID[3].Trim();
                Locations lid = new Locations(0, location_name, "");
                dbc.idLocations(lid);
                int location_id = 0;
                foreach (int k in dbc.idLocations(lid))
                {
                    location_id = k;
                }
                Users uid = new Users(0, name, surname, "", "", "", "", 0);
                dbc.idUsers(uid);
                int user_id = 0;
                foreach (int k in dbc.idUsers(uid))
                {
                    user_id = k;
                }
                if (userUnLendedBookslistBox.SelectedItem == null)
                {
                    MessageBox.Show("Izberite knjigo.");
                }
                else
                {         
                string selectedBook = userUnLendedBookslistBox.SelectedItem.ToString();//exception needs to be handled
                selectedBook = selectedBook.Trim();
                string[] BookID = selectedBook.Split('|');
                int id_b = Convert.ToInt32(BookID[0].Trim());
                selectedBook = BookID[1].Trim();//title
                string author_name = BookID[2].Trim();
                string author_surname = BookID[3].Trim();
                int lost = Convert.ToInt32(BookID[4].Trim());
                string year = BookID[5].Trim();
                string location_name_book = BookID[6].Trim();
                string publisher_name = BookID[7].Trim();
                string genre_genretype = BookID[8].Trim();
                int id_g = 0;
                Authors aid = new Authors(0, author_name, author_surname);
                dbc.idAuthors(aid);
                int author_id = 0;
                foreach (int k in dbc.idAuthors(aid))
                {
                    author_id = k;
                }
                Locations lid_book = new Locations(0, location_name, "");
                dbc.idLocations(lid);
                int location_id_book = 0;
                foreach (int k in dbc.idLocations(lid))
                {
                    location_id = k;
                }
                Publishers pid = new Publishers(0, publisher_name);
                dbc.idPublishers(pid);
                int publisher_id = 0;
                foreach (int k in dbc.idPublishers(pid))
                {
                    publisher_id = k;
                }
                Genres gid = new Genres(0, genre_genretype);
                dbc.idGenres(gid);
                int genre_id = 0;
                foreach (int k in dbc.idGenres(gid))
                {
                    genre_id = k;
                }
                Rents rid = new Rents(0, 0, "", id_b, user_id);
                dbc.idRents(rid);
                int rent_id = 0;
                foreach (int k in dbc.idRents(rid))
                {
                    rent_id = k;
                }

                string rent_date = Convert.ToString(DateTime.Now);
                int rent_state = 1;
                Rents rentss = new Rents(rent_id, rent_state, rent_date, id_b, id_u);
                    dbc.UpdateRentsLend(rentss);
                userUnLendedBookslistBox.Items.Clear();
                OutputBooksOnRents_UnLended();
                }
            }
        }
        #endregion

        private void userShowcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            userLendedBookslistBox.Items.Clear();
            userUnLendedBookslistBox.Items.Clear();


            //SELECT u.id_u, u.name, u.surname, u.tel, u.address, u.notes, l.name, l.postalcode 
            databaseController dbc = new databaseController();
            string selectedUser = userShowcomboBox.SelectedItem.ToString();//exception needs to be handled
            selectedUser = selectedUser.Trim();
            string[] UserID = selectedUser.Split('|');
            int id_u = Convert.ToInt32(UserID[0].Trim());
            string name = UserID[1].Trim();//title
            string surname = UserID[2].Trim();
            string tel = UserID[3].Trim();
            string address = UserID[3].Trim();
            string location_name = UserID[3].Trim();
            string location_postalcode = UserID[3].Trim();

            Locations lid = new Locations(0, location_name, "");
            dbc.idLocations(lid);
            int location_id = 0;
            foreach (int k in dbc.idLocations(lid))
            {
                location_id = k;
            }
            Users uid = new Users(0, name, surname, "", "", "", "",0);
            dbc.idUsers(uid);
            int user_id = 0;
            foreach (int k in dbc.idUsers(uid))
            {
                user_id = k;
            }
            Users u = new Users(id_u, name, surname, tel, address, "", "", location_id );
            Rents r = new Rents(0, 1, "", 0, id_u);
            dbc.ReadLendedBooks(r);
            foreach (string name1 in dbc.ReadLendedBooks(r))
            {
                userLendedBookslistBox.Items.Add(name1);
            }

            
            userUnLendedBookslistBox.Items.Clear();
            dbc.ReadUnlendedBooks();
            foreach (string name1 in dbc.ReadUnlendedBooks())
            {
                userUnLendedBookslistBox.Items.Add(name1);
            }
            userUnLendedBookslistBox.Items.Clear();
            //OutputBooksOnRents_Lended();
            OutputBooksOnRents_UnLended();
        }

        private void returnBookButton_Click(object sender, EventArgs e)
        {
            if (userShowcomboBox.SelectedItem == null)
            {
                MessageBox.Show("Izberite člana.");
            }
            else
            {
                databaseController dbc = new databaseController();
                string selectedUser = userShowcomboBox.SelectedItem.ToString();//exception needs to be handled
                selectedUser = selectedUser.Trim();
                string[] UserID = selectedUser.Split('|');
                int id_u = Convert.ToInt32(UserID[0].Trim());
                string name = UserID[1].Trim();//title
                string surname = UserID[2].Trim();
                string tel = UserID[3].Trim();
                string address = UserID[3].Trim();
                string location_name = UserID[3].Trim();
                string location_postalcode = UserID[3].Trim();

                Locations lid = new Locations(0, location_name, "");
                dbc.idLocations(lid);
                int location_id = 0;
                foreach (int k in dbc.idLocations(lid))
                {
                    location_id = k;
                }
                Users uid = new Users(0, name, surname, "", "", "", "", 0);
                dbc.idUsers(uid);
                int user_id = 0;
                foreach (int k in dbc.idUsers(uid))
                {
                    user_id = k;
                }



                if (userUnLendedBookslistBox.SelectedItem == null)
                {
                    MessageBox.Show("Izberite knjigo.");
                }
                else
                {
                    string selectedBook = userLendedBookslistBox.SelectedItem.ToString();//exception needs to be handled
                    selectedBook = selectedBook.Trim();
                    string[] BookID = selectedBook.Split('|');
                    int id_b = Convert.ToInt32(BookID[0].Trim());
                    selectedBook = BookID[1].Trim();//title
                    string author_name = BookID[2].Trim();
                    string author_surname = BookID[3].Trim();
                    int lost = Convert.ToInt32(BookID[4].Trim());
                    string year = BookID[5].Trim();
                    string location_name_book = BookID[6].Trim();
                    string publisher_name = BookID[7].Trim();
                    string genre_genretype = BookID[8].Trim();
                    int id_g = 0;
                    Authors aid = new Authors(0, author_name, author_surname);
                    dbc.idAuthors(aid);
                    int author_id = 0;
                    foreach (int k in dbc.idAuthors(aid))
                    {
                        author_id = k;
                    }
                    Locations lid_book = new Locations(0, location_name, "");
                    dbc.idLocations(lid);
                    int location_id_book = 0;
                    foreach (int k in dbc.idLocations(lid))
                    {
                        location_id = k;
                    }
                    Publishers pid = new Publishers(0, publisher_name);
                    dbc.idPublishers(pid);
                    int publisher_id = 0;
                    foreach (int k in dbc.idPublishers(pid))
                    {
                        publisher_id = k;
                    }
                    Genres gid = new Genres(0, genre_genretype);
                    dbc.idGenres(gid);
                    int genre_id = 0;
                    foreach (int k in dbc.idGenres(gid))
                    {
                        genre_id = k;
                    }
                    Rents rid = new Rents(0, 0, "", id_b, user_id);
                    dbc.idRents(rid);
                    int rent_id = 0;
                    foreach (int k in dbc.idRents(rid))
                    {
                        rent_id = k;
                    }
                    string rent_date = Convert.ToString(DateTime.Now);
                    int rent_state = 0;
                    Rents rentss = new Rents(rent_id, rent_state, rent_date, id_b, id_u);
                    dbc.UpdateRentsUnLend(rentss);
                    userUnLendedBookslistBox.Items.Clear();
                    userLendedBookslistBox.Items.Clear();
                    OutputBooksOnRents_UnLended();
                }
            }

        }
    }
}
