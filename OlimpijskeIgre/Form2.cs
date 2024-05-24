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
using System.Configuration;

namespace OlimpijskeIgre
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void OtvoriFormu(int broj)
        {
            if (broj == 0)
            {
                Sport1 forma = new Sport1();
                forma.Show();
            }
            else if (broj == 1)
            {
                Drzava1 forma = new Drzava1();
                forma.Show();
            }
            else if (broj == 2)
            {
                Ekipe1 forma = new Ekipe1();
                forma.Show();
            }
            else if (broj == 3)
            {
                Igraci forma = new Igraci();
                forma.Show();
            }
            else if (broj == 4)
            {
                Trener forma = new Trener();
                forma.Show();
            }
            else if (broj == 5)
            {
                Sudija forma = new Sudija();
                forma.Show();
            }
            else if (broj == 6)
            {
                Utakmica forma = new Utakmica();
                forma.Show();
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OtvoriFormu(comboBox1.SelectedIndex);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
