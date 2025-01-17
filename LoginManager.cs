using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1.Scripts.Bogus
{
    class LoginManager
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\total\source\repos\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security = True");

        public void Logare(TextBox email, TextBox parola, bool tineMinte)
        {
            // inlocuire ultim user logat
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [Utilizatori] where Email = '" + email.Text + "' and Parola = '" + parola.Text + "'";
            SqlDataReader data = cmd.ExecuteReader(); // returnare user
            data.Read();

            /*
            SqlCommand check = con.CreateCommand(); check.CommandType = System.Data.CommandType.Text; check.CommandText = "select * from [UltimiUserLogat]";
            if (check.ExecuteNonQuery() != 0) // exista ultim user logat
            {
                cmd.CommandText = "update [UltimUserLogat] set Nume = '" + data.GetString(1) + "' set Prenume = '" + data.GetString(2) + "' set Varsta = '" + data.GetInt16(3) + "' set Email = '" + data.GetString(4) + "' set Parola = '" + data.GetString(5) + "' set Rol = '" + data.GetString(6) + "' set DataUltimaLogare = '";
                if(tineMinte)
                {
                    cmd.CommandText = cmd.CommandText + DateTime.Now.ToLongDateString() + "'";
                }
            }
            else // nu exista, trebuie adaugat
            {
                cmd.CommandText = "insert into [UltimUserLogat] (Nume, Prenume, Varsta, Email, Parola, Rol, DataUltimaLogare) values = ('" + data.GetString(1) + "' '" + data.GetString(2) + "' '" + data.GetInt16(3) + "' '" + data.GetString(4) + "' '" + data.GetString(5) + "' '" + data.GetString(6) + "'";
                if (tineMinte)
                {
                    cmd.CommandText = cmd.CommandText + DateTime.Now.ToLongDateString() + "'";
                }
                cmd.CommandText = cmd.CommandText + ")";
            }
            cmd.ExecuteNonQuery();
            */
            
            List<string> dataList = new List<string>();
            dataList.Add(data.GetInt32(0).ToString()); // nr unic
            for (int k = 1; k < 7; k++) { dataList.Add(data.GetString(k)); }
            con.Close();
            Forms.Acasa acasa = new Forms.Acasa(dataList); acasa.Show(); // Hide();
        }

        public void AdaugareUser(int id, TextBox nume, TextBox prenume, TextBox varsta, TextBox email, TextBox parola, string rol)
        {
            // adaugare in utilizatori
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into [Utilizatori] (Id, Nume, Prenume, Varsta, Email, Parola, Rol) values  ('" + id.ToString() + "','" + nume.Text + "','" + prenume.Text + "','" + varsta.Text + "','" + email.Text + "','" + parola.Text + "','" + rol + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            Logare(email, parola, false);
        }
    }
}
