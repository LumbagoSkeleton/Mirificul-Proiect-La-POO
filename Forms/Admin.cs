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
    public partial class Admin : Form
    {
        private List<string> data;

        public Admin(List<string> Data)
        {
            data = Data;
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void inapoi_Click(object sender, EventArgs e)
        {
            Forms.Acasa acasa = new Forms.Acasa(data); acasa.Show(); Hide();
        }
    }
}
