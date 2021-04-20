using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theLibraryProject
{
    public partial class prijavaForm : Form
    {
        public prijavaForm()
        {
            InitializeComponent();
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
                Form1 from = new Form1();
                from.Show();
            
            }
              
  


        }

        private void prijavaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
