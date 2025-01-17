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
    public partial class Profil : Form
    {
        private List<string> data;

        public Profil(List<string> Data)
        {
            InitializeComponent();
            data = Data;
            numeText.Text = data[1];
            prenumeText.Text = data[2];
            varstaText.Text = data[3];
            emailText.Text = data[4];
            rolText.Text = data[6];
        }

        private void Profil_Load(object sender, EventArgs e)
        {

        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            Forms.Acasa acasa = new Forms.Acasa(data); acasa.Show(); Hide();
        }
    }
}
