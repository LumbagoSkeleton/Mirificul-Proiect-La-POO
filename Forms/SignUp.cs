using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        // buton autentificare
        private void button2_Click(object sender, EventArgs e)
        {
            
            errorLabel.Text = ValidareDate();
        }

        private string ValidareDate()
        {
            string errorMessage = "Toate campurile trebuie completate!";
            //List<TextBox> campuri = ;
            //for
            return errorMessage;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
