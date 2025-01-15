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
    public partial class Acasa : Form
    {
        private bool admin;
        public Acasa(bool admin)
        {
            this.admin = admin;
            InitializeComponent();
        }

        private void Acasa_Load(object sender, EventArgs e)
        {
            if (!admin) { gestionare.Hide(); }
        }

        private void gestionare_Click(object sender, EventArgs e)
        {

        }
    }
}
