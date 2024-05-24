using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpijskeIgre
{
    public partial class Trener : Form
    {
        DataTable dt_trener;
        public Trener()
        {
            InitializeComponent();
        }
        private void GridPopulate()
        {
            StringBuilder naredba = new StringBuilder("SELECT id, ime + prezime as ime, vrsta FROM Trener");
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            dt_trener = new DataTable();
            adapter.Fill(dt_trener);
            Grid_Trener.DataSource = dt_trener;
            Grid_Trener.AllowUserToAddRows = false;
            Grid_Trener.Columns["id"].Visible = true;
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("SELECT id FROM Trener ");
            naredba.Append(" WHERE ime = " + textBox1.Text);
            naredba.Append(" AND prezime = " + textBox2.Text);
            naredba.Append(" AND vrsta = " + textBox3.Text);
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(naredba.ToString(), veza);
            naredba = new StringBuilder("INSERT INTO Trener (ime ,prezime, vrsta) VALUES('");
            naredba.Append(textBox1.Text + "', '");
            naredba.Append(textBox2.Text + "', '");
            naredba.Append(textBox3.Text + "') ");
            Komanda = new SqlCommand(naredba.ToString(), veza);
            try
            {
                veza.Open();
                Komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }
            GridPopulate();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_id.Text) > 0)
            {
                StringBuilder naredba = new StringBuilder("UPDATE Trener SET ");
                naredba.Append(" ime = '" + textBox1.Text.ToString() + "', ");
                naredba.Append(" prezime = '" + textBox2.Text.ToString() + "', ");
                naredba.Append(" vrsta = '" + textBox3.Text.ToString() + "' ");
                naredba.Append(" WHERE id = " + txt_id.Text);
                SqlConnection veza = Konekcija.Connect();
                SqlCommand Komanda = new SqlCommand(naredba.ToString(), veza);
                try
                {
                    veza.Open();
                    Komanda.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
                GridPopulate();
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_id.Text) > 0)
            {
                string naredba = "DELETE FROM Trener WHERE id = " + txt_id.Text;
                SqlConnection veza = Konekcija.Connect();
                SqlCommand Komanda = new SqlCommand(naredba, veza);
                try
                {
                    veza.Open();
                    Komanda.ExecuteNonQuery();
                    veza.Close();
                    GridPopulate();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
            }
        }

        private void Trener_Load(object sender, EventArgs e)
        {
            GridPopulate();
        }
    }
}
