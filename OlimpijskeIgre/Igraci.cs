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
    public partial class Igraci : Form
    {
        DataTable dt_igraci;
        DataTable dt_ekipa;
        public Igraci()
        {
            InitializeComponent();
        }
        private void cmb_ekipaPopulate()
        {
            StringBuilder naredba = new StringBuilder("SELECT id, nazivEkipe FROM Ekipa");
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            dt_ekipa = new DataTable();
            adapter.Fill(dt_ekipa);
            cmb_Ekipa.DataSource = dt_ekipa;
            cmb_Ekipa.ValueMember = "id";
            cmb_Ekipa.DisplayMember = "nazivEkipe";
            cmb_Ekipa.SelectedIndex = -1;
        }
        private void GridPopulate()
        {
            StringBuilder naredba = new StringBuilder("SELECT id, ime + ' ' + prezime as ime FROM Igraci");
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            dt_igraci = new DataTable();
            adapter.Fill(dt_igraci);
            Grid_Igraci.DataSource = dt_igraci;
            Grid_Igraci.AllowUserToAddRows = false;
            Grid_Igraci.Columns["id"].Visible = true;
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {

            StringBuilder naredba = new StringBuilder("SELECT id FROM Igraci ");
            naredba.Append(" WHERE ime = " + textBox2.Text);
            naredba.Append(" AND prezime = " + textBox3.Text);
            naredba.Append(" AND br_medalja = " + textBox1.Text);
            naredba.Append(" AND ekipa_id = " + cmb_Ekipa.SelectedValue);
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(naredba.ToString(), veza);
            naredba = new StringBuilder("INSERT INTO Igraci (ime, prezime, br_medalja,ekipa_id) VALUES('");
            naredba.Append(textBox2.Text + "', '");
            naredba.Append(textBox3.Text + "', '");
            naredba.Append(textBox1.Text + "', '");
            naredba.Append(cmb_Ekipa.SelectedValue + "') ");
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
                StringBuilder naredba = new StringBuilder("UPDATE Igraci SET ");
                naredba.Append(" ime = '" + textBox1.Text.ToString() + "', ");
                naredba.Append(" prezime = '" + textBox2.Text + "', ");
                naredba.Append(" br_medalja = '" + textBox3.Text + "', ");
                naredba.Append(" ekipa_id = '" + cmb_Ekipa.SelectedValue + "', ");
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
                string naredba = "DELETE FROM Igraci WHERE id = " + txt_id.Text;
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

        private void Igraci_Load(object sender, EventArgs e)
        {
            cmb_ekipaPopulate();
            GridPopulate();
        }
    }
}
