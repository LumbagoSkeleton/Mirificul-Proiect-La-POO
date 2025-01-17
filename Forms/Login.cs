using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Forms
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\total\source\repos\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security = True");
        Scripts.Bogus.LoginManager loginManager = new Scripts.Bogus.LoginManager();
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

        private bool CautareUtilizator()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Utilizatori] where Email = '" + textBox1.Text + "' and Parola = '" + textBox2.Text + "'";
            int check = cmd.ExecuteNonQuery();
            if (check == 0) { con.Close(); return false; }
            else { con.Close(); return true; }
        }

        // validare date - returneaza mesajul de eroare daca se aplica, null in caz contrar
        private string ValidareDate()
        {
            if (textBox1.Text == "" || textBox2.Text == "") // campuri libere
            {
                return "Trebuie completate toate campurile!";
            }

            // verificare date din baza de date
            if(!CautareUtilizator()) { return "Datele introduse sunt incorecte!"; }
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
                loginManager.Logare(textBox1, textBox2, checkBox1.Checked);
                Hide();
            }
        }
    }
}
