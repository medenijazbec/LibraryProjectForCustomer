using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using theLibraryProject.Classes;

namespace theLibraryProject
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }
        databaseController db = new databaseController();
        public static string username = "";
      
        static string Encrypt(string password)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = sha1.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameLoginTextBox.Text == "" || passwordTextBox.Text == "")
            {
                errorProvider1.SetError(usernameLoginTextBox, "Polje je obvezno!");
                errorProvider1.SetError(passwordTextBox, "Polje je obvezno!");
            }
            else
            {
                databaseController dbc = new databaseController();
                string password = "";
                
                password = passwordTextBox.Text;
                string username = usernameLoginTextBox.Text;
                password = Encrypt(passwordTextBox.Text);

                string fetchedPassword = "";
                Users getUserCreds = new Users(username);
                dbc.ReadUserLogin(getUserCreds);
                foreach (string name in dbc.ReadUserLogin(getUserCreds))
                {
                    fetchedPassword = name;   
                }

                if (password == fetchedPassword)
                {
                    MessageBox.Show("Prijava uspešna!");
                    Form1 form = new Form1();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Prijava neuspešna. Preverite vnos.");
                }
                


               
            
            }
        }

        private void prijavaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
