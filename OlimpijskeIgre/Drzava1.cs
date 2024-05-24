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
    public partial class Drzava1 : Form
    {
        DataTable dt_drzava;
        public Drzava1()
        {
            InitializeComponent();
        }

        private void Drzava_Load(object sender, EventArgs e)
        {
            GridPopulate();
        }

        private void GridPopulate()
        {
            StringBuilder naredba = new StringBuilder("SELECT id, naziv, br_medalja as BrojMedalja FROM Drzava");
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            dt_drzava = new DataTable();
            adapter.Fill(dt_drzava);
            Grid_Drzave.DataSource = dt_drzava;
            Grid_Drzave.AllowUserToAddRows = false;
            Grid_Drzave.Columns["id"].Visible = true;
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("SELECT id FROM Drzava ");
            naredba.Append(" WHERE naziv = " + textBox1.Text);
            naredba.Append(" AND br_medalja = " + textBox2.Text);
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(naredba.ToString(), veza);
            naredba = new StringBuilder("INSERT INTO Drzava (naziv, br_medalja) VALUES('");
            naredba.Append(textBox1.Text + "', '");
            naredba.Append(textBox2.Text + "') ");
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
                StringBuilder naredba = new StringBuilder("UPDATE Drzava SET ");
                naredba.Append(" naziv = '" + textBox1.Text.ToString() + "', ");
                naredba.Append(" br_medalja = '" + textBox2.Text + "' ");
                naredba.Append(" WHERE id = " + txt_id.Text);
                SqlConnection veza = Konekcija.Connect();
                SqlCommand Komanda = new SqlCommand(naredba.ToString(), veza);
                textBox3.Text = naredba.ToString();
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
                string naredba = "DELETE FROM Drzava WHERE id = " + txt_id.Text;
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
    }
}
