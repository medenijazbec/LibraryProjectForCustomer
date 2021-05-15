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
    public partial class userUpdateForm : Form
    {
        public userUpdateForm()
        {
            InitializeComponent();
            usernameTextBox.Enabled = false;
            passwordChangeTextbox.Enabled = false;
            passwordChangeTextboxV2.Enabled = false;
            OutputLocations();
           // OutputUsers();
        }
 
        databaseController db = new databaseController();
        public void OutputLocations()
        {
            foreach (string name in db.ReadLocations())
            {
                locationsComboBox.Items.Add(name);
            }
        }
       /* public void OutputUsers(int id)
        {
            foreach (int string in db.ReadUsersForUpdate(Form1.user_id_u))
            {
               comboBox1.Items.Add(name);
            }
        }*/

        static string Encrypt(string password)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = sha1.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }

        private void updateUserButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Izbran ni noben uporabnik/član.");
            }
            else
            {
                if (locationsComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Izbran ni noben kraj.");
                }
                else
                {
                    databaseController dbc = new databaseController();
                    string password = "";
                    if (checkBox1.Checked)
                    {

                        password = passwordChangeTextbox.Text;
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

                        int id_u = 0;
                        id_u = Form1.user_id_u;
                        string name = nameTextBox.Text;
                        string surname = Convert.ToString(surnameTextBox.Text);
                        string tel = Convert.ToString(telTextBox.Text);
                        string address = Convert.ToString(addressTextBox.Text);
                        string email = Convert.ToString(emailTextBox.Text);
                        string username = Convert.ToString(usernameTextBox.Text);
                        //password
                        string notes = Convert.ToString(richTextBox1.Text);
                        #region location_id
                        string selectedLocation = locationsComboBox.SelectedItem.ToString();//exception needs to be handled
                        selectedLocation = selectedLocation.Trim();
                        string[] LocationID = selectedLocation.Split('|');
                        selectedLocation = LocationID[1].Trim();
                        int location_id = Convert.ToInt32(LocationID[0].Trim());
                        #endregion
                        Users user = new Users(id_u, name, surname, tel, address, email, username, password, notes, location_id);
                        dbc.UpdateUsers(user);
                    }
                    else
                    {
                        #region location_id_member
                        string selectedLocation1 = locationsComboBox.SelectedItem.ToString();//exception needs to be handled
                        selectedLocation1 = selectedLocation1.Trim();
                        string[] LocationID1 = selectedLocation1.Split('|');
                        selectedLocation1 = LocationID1[1].Trim();
                        int location_id_member = Convert.ToInt32(LocationID1[0].Trim());
                        #endregion
                        int id_u_member = 0;
                        string name_member = nameTextBox.Text;
                        string surname_member = Convert.ToString(surnameTextBox.Text);
                        string tel_member = Convert.ToString(telTextBox.Text);
                        string address_member = Convert.ToString(addressTextBox.Text);
                        string email_member = Convert.ToString(emailTextBox.Text);
                        string notes_member = Convert.ToString(richTextBox1.Text);
                        //password
                        string notes1 = Convert.ToString(richTextBox1.Text);
                        Users member = new Users(id_u_member, name_member, surname_member, tel_member, address_member, email_member, notes_member, location_id_member);
                        dbc.UpdateUsers(member);
                    }
                }
                
            }

            
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                usernameTextBox.Enabled = true;
                passwordChangeTextbox.Enabled = true;
                passwordChangeTextboxV2.Enabled = true;
            }
            else
            {
                usernameTextBox.Enabled = false;
                passwordChangeTextbox.Enabled = false;
                passwordChangeTextboxV2.Enabled = false;
            }
        }
        private void userUpdateForm_Load(object sender, EventArgs e)
        {
           
            
            databaseController dbc = new databaseController();
            dbc.ReadUsersForUpdate();
            foreach (string name2 in dbc.ReadUsersForUpdate())
            {
                comboBox1.Items.Add(name2);
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            databaseController dbc = new databaseController();
            string selectedUser = comboBox1.SelectedItem.ToString();//exception needs to be handled
            selectedUser = selectedUser.Trim();
            string[] UserID1 = selectedUser.Split('|');
            int id_u = Convert.ToInt32(UserID1[0].Trim());
            string[] UserID = selectedUser.Split('|');

            string name = UserID[1].Trim();//user's name
            string surname = UserID[2].Trim();
            string tel = UserID[3].Trim();
            string address = UserID[4].Trim();
            string email = UserID[5].Trim();
            string username = UserID[6].Trim();
            //string  passwordV1 = UserID[7].Trim();
            string notes = UserID[7].Trim();

            nameTextBox.Text = name;
            surnameTextBox.Text = surname;
            telTextBox.Text = tel;
            addressTextBox.Text = address;
            emailTextBox.Text = email;
            usernameTextBox.Text = username;
            richTextBox1.Text = notes;





            int location_id = Form1.user_location_id;
            Locations readid = new Locations(Form1.user_location_id, Form1.name);
            dbc.ReadLocationsID(readid);
        }
    }
}
