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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OlimpijskeIgre
{
    public partial class Ekipe1 : Form
    {
        DataTable dt_sport;
        DataTable dt_ekipa;
        DataTable dt_drzava;
        public Ekipe1()
        {
            InitializeComponent();
        }

        private void Ekipe1_Load(object sender, EventArgs e)
        {
            cmb_sportPopulate();
            cmb_drzavaPopulate();
            GridPopulate();
        }
        private void cmb_sportPopulate()
        {
            StringBuilder naredba = new StringBuilder("SELECT id, naziv FROM Sport");
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            dt_sport = new DataTable();
            adapter.Fill(dt_sport);
            Cmb_Sport.DataSource = dt_sport;
            Cmb_Sport.ValueMember = "naziv";
            Cmb_Sport.DisplayMember = "naziv";
            Cmb_Sport.SelectedIndex = -1;
        }
        private void cmb_drzavaPopulate()
        {
            StringBuilder naredba = new StringBuilder("SELECT id, naziv FROM Drzava");
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            dt_drzava = new DataTable();
            adapter.Fill(dt_drzava);
            Cmb_Drzava.DataSource = dt_drzava;
            Cmb_Drzava.ValueMember = "naziv";
            Cmb_Drzava.DisplayMember = "naziv";
            Cmb_Drzava.SelectedIndex = -1;
        }
        private void GridPopulate()
        {
            StringBuilder naredba = new StringBuilder("SELECT id, nazivEkipe  FROM Ekipa");
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            dt_ekipa = new DataTable();
            adapter.Fill(dt_ekipa);
            Grid_Ekipa.DataSource = dt_ekipa;
            Grid_Ekipa.AllowUserToAddRows = false;
            Grid_Ekipa.Columns["id"].Visible = true;
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            string nazivSporta = Cmb_Sport.SelectedItem.ToString();
            string nazivDrzave = Cmb_Drzava.SelectedItem.ToString();
            StringBuilder naredba = new StringBuilder("SELECT id FROM Ekipa ");
            naredba.Append(" WHERE nazivSporta = '" + Cmb_Sport.SelectedValue + "'");
            naredba.Append(" AND nazivDrzave = '" + Cmb_Drzava.SelectedValue + "'");
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(naredba.ToString(), veza);
            naredba = new StringBuilder("EXEC Ekipa_Insert ");
            naredba.Append("@nazivDrzave = '" + Cmb_Drzava.SelectedValue.ToString() + "', ");
            naredba.Append("@nazivSporta = '" + Cmb_Sport.SelectedValue.ToString() + "'");
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
    }
}
