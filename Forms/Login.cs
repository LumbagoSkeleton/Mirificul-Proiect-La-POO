using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        // creare cont
        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp(); signUp.Show(); this.Hide();
        }

        // validare date
        private string ValidareDate()
        {

            if (textBox1.Text == "" || textBox2.Text == "") // campuri libere
            {
                return "Trebuie completate toate campurile!";
            }
            // verificare date din baza de date
            return null;
        }

        // logare
        private void button1_Click(object sender, EventArgs e)
        {
            string errorMessage = ValidareDate();
            if (errorMessage != null) 
            {
                errorLabel.Text = errorMessage;
            }
            else
            {
                Acasa acasa = new Acasa(false); acasa.Show(); Hide();
            }
        }

        
    }
}
