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
    public partial class Acasa : Form
    {
        private List<string> data;
        private bool admin;

        public Acasa(List<string> Data)
        {
            data = Data; 
            if (data[6] == "Administrator") admin = true;
            InitializeComponent();
        }

        private void Acasa_Load(object sender, EventArgs e)
        {
            if (!admin) { gestionare.Hide(); }
        }

        private void gestionare_Click(object sender, EventArgs e)
        {
            Forms.Admin admin = new Forms.Admin(data); admin.Show(); Hide();
        }

        private void rezervareRuta_Click(object sender, EventArgs e)
        {
            Forms.Rute rute = new Forms.Rute(data); rute.Show(); Hide();
        }

        private void profil_Click(object sender, EventArgs e)
        {
            Forms.Profil profil = new Forms.Profil(data); profil.Show(); Hide();
        }
    }
}
