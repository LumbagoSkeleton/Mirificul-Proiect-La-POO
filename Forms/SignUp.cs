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
            string errorMessage = ValidareDate();
            
            if(errorMessage != null)
            {
                errorLabel.Text = errorMessage;
            }
            else
            {
                bool admin = false;
                if (ListaRoluri.SelectedItem.ToString() == "Administrator") { admin = true; }
                Forms.Acasa acasa = new Forms.Acasa(admin); acasa.Show(); Hide();
            }
        }

        private string ValidareDate()
        {
            // initializari
            List<TextBox> campuri = new List<TextBox>(new TextBox[] {numeTextBox, prenumeTextBox, emailTextBox, varstaTextBox, parolaTextBox2, parolaTextBox});
            bool ok = false;

            // campuri libere
            foreach (var camp in campuri)
            {
                
                if (camp.Text == "") { ok = true; }
            }
            if (ok) { return "Toate campurile trebuie completate!"; }

            // numele nu este intre 2 si 20 caractere
            if (numeTextBox.Text.Length < 2 || numeTextBox.Text.Length > 20)
            {
                return "Numele trebuie sa fie intre 2 si 20 caractere!";
            }
            // numele contine cifre
            ok = true;
            foreach(var c in numeTextBox.Text)
            {
                if(c >= '0' && c <= '9') { ok = false; break; }
            }
            if(!ok)
            {
                return "Numele nu poate contine cifre!";
            }

            // prenumele nu este intre 2 si 20 caractere
            if (prenumeTextBox.Text.Length < 2 || prenumeTextBox.Text.Length > 20)
            {
                return "Prenumele trebuie sa fie intre 2 si 20 caractere!";
            }
            // prenumele contine cifre
            ok = true;
            foreach (var c in prenumeTextBox.Text)
            {
                if (c >= '0' && c <= '9') { ok = false; break; }
            }
            if (!ok)
            {
                return "Prenumele nu poate contine cifre!";
            }

            // varsta nu contine doar cifre
            ok = true;
            foreach (var c in varstaTextBox.Text)
            {
                if (c <= '0' || c >= '9') { ok = false; break; }
            }
            if (!ok)
            {
                return "Varsta trebuie sa contina doar cifre!";
            }

            // varsta e un numar invalid - optional
            
            // parola nu este intre 4 si 20 caractere
            if (parolaTextBox.Text.Length < 4 || parolaTextBox.Text.Length > 20)
            {
                return "Parola trebuie sa fie intre 4 si 20 caractere!";
            }
            // parola si confirmarea parolei nu bat
            if (parolaTextBox.Text != parolaTextBox2.Text)
            {
                return "Parola si confirmarea parolei sunt diferite!";
            }

            // nu este selectat un rol
            if (ListaRoluri.SelectedItem == null) { return "Trebuie selectat un rol!"; }

            return null;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
