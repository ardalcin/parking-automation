using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ardalcinkayapark
{
    public partial class Anamenu : Form
    {
        public Anamenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form ekleform = new arabagiris();
            ekleform.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form cikisform = new aracikis();
            cikisform.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Konum = new konum();
            Konum.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form kayit = new gecmis();
            kayit.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
