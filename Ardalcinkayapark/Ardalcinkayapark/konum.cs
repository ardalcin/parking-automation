using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Ardalcinkayapark
{
    public partial class konum : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0;Data Source = otomasyonveri.mdb  ");
        public konum()
        {
            InitializeComponent();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void konum_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand veri = new OleDbCommand
         ("Select * from parkyeri,musteri where parkyeri.parkalani=musteri.p and musteri.durum='0'", baglanti);
            OleDbDataReader okuyucu = veri.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu["p"].ToString()=="A1")
                {
                    pictureBox1.BackColor = Color.Red;
                    label11.Text = okuyucu["plaka"].ToString();
                    label11.BackColor = Color.Red;
                    label11.Visible = true;
                    label1.BackColor = Color.Red;
                }
                if (okuyucu["p"].ToString() == "A2")
                {
                    pictureBox2.BackColor = Color.Red;
                    label12.Text = okuyucu["plaka"].ToString();
                    label12.BackColor = Color.Red;
                    label12.Visible = true;
                    label2.BackColor = Color.Red;
                }
                if (okuyucu["p"].ToString() == "A3")
                {
                    pictureBox3.BackColor = Color.Red;
                    label13.Text = okuyucu["plaka"].ToString();
                    label13.BackColor = Color.Red;
                    label13.Visible = true;
                    label3.BackColor = Color.Red;

                }
                if (okuyucu["p"].ToString() == "A4")
                {
                    pictureBox4.BackColor = Color.Red;
                    label14.Text = okuyucu["plaka"].ToString();
                    label14.BackColor = Color.Red;
                    label14.Visible = true;
                    label4.BackColor = Color.Red;
                }
                if (okuyucu["p"].ToString() == "A5")
                {
                    pictureBox5.BackColor = Color.Red;
                    label15.Text = okuyucu["plaka"].ToString();
                    label15.BackColor = Color.Red;
                    label15.Visible = true;
                    label5.BackColor = Color.Red;
                }
                if (okuyucu["p"].ToString() == "A6")
                {
                    pictureBox6.BackColor = Color.Red;
                    label16.Text = okuyucu["plaka"].ToString();
                    label16.BackColor = Color.Red;
                    label16.Visible = true;
                    label6.BackColor = Color.Red;
                }
                if (okuyucu["p"].ToString() == "A7")
                {
                    pictureBox7.BackColor = Color.Red;
                    label17.Text = okuyucu["plaka"].ToString();
                    label17.BackColor = Color.Red;
                    label17.Visible = true;
                    label7.BackColor = Color.Red;
                }
                if (okuyucu["p"].ToString() == "A8")
                {
                    pictureBox8.BackColor = Color.Red;
                    label18.Text = okuyucu["plaka"].ToString();
                    label18.BackColor = Color.Red;
                    label18.Visible = true;
                    label8.BackColor = Color.Red;
                }
                if (okuyucu["p"].ToString() == "A9")
                {
                    pictureBox9.BackColor = Color.Red;
                    label19.Text = okuyucu["plaka"].ToString();
                    label19.BackColor = Color.Red;
                    label19.Visible = true;
                    label9.BackColor = Color.Red;
                }
                if (okuyucu["p"].ToString() == "A10")
                {
                    pictureBox10.BackColor = Color.Red;
                    label20.Text = okuyucu["plaka"].ToString();
                    label20.BackColor = Color.Red;
                    label20.Visible = true;
                    label10.BackColor = Color.Red;
                }
            }
            
            baglanti.Close();
        }
    }
}
