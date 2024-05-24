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
    public partial class Sport1 : Form
    {
        DataTable dt_sport;
        public Sport1()
        {
            InitializeComponent();
        }

        private void Sport_Load(object sender, EventArgs e)
        {
            GridPopulate();
        }

        private void GridPopulate()
        {
            StringBuilder naredba = new StringBuilder("SELECT id, naziv, br_faza as BrojFaza,vrsta as Vrsta FROM Sport");
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            dt_sport = new DataTable();
            adapter.Fill(dt_sport);
            Grid_Sport.DataSource = dt_sport;
            Grid_Sport.AllowUserToAddRows = false;
            Grid_Sport.Columns["id"].Visible = true;
        }

        private void btn_insert_Click_1(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("SELECT id FROM Sport ");
            naredba.Append(" WHERE naziv = " + textBox1.Text);
            naredba.Append(" AND br_faza = " + textBox2.Text);
            naredba.Append(" AND br_faza = " + textBox3.Text);
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(naredba.ToString(), veza);
            naredba = new StringBuilder("INSERT INTO Sport (naziv, br_faza, vrsta) VALUES('");
            naredba.Append(textBox1.Text + "', '");
            naredba.Append(textBox2.Text + "', '");
            naredba.Append(textBox3.Text + "') ");
            textBox4.Text = naredba.ToString();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            //Update
            if (Convert.ToInt32(txt_id.Text) > 0)
            {
                StringBuilder naredba = new StringBuilder("Update Sport ");
                naredba.Append(" @naziv = '" + textBox1.Text + "', ");
                naredba.Append(" @br_faza = '" + textBox2.Text + "', ");
                naredba.Append(" @vrsta = '" + textBox3.Text + "', ");
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
                string naredba = "DELETE FROM Sport WHERE id = " + txt_id.Text;
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
