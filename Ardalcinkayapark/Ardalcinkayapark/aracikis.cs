using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Ardalcinkayapark
{
    public partial class aracikis : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0;Data Source = otomasyonveri.mdb  ");
        public aracikis()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void aracikis_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand kom = new OleDbCommand("select * from musteri where durum='0'",baglanti);
            OleDbDataReader okuyucu = kom.ExecuteReader();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["plaka"].ToString());
            }
            baglanti.Close();
        }
        DateTime tarih;
        string parkyeri = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double aracyikama = 0;
            baglanti.Open();
            OleDbCommand kom2 = new OleDbCommand
           ("select * from musteri where durum='0' and plaka LIKE'" + comboBox1.Text + "'", baglanti);
            OleDbDataReader okuyucu2 = kom2.ExecuteReader();
            while (okuyucu2.Read())

            {
                label8.Text = okuyucu2["marka"].ToString();
                label9.Text = okuyucu2["model"].ToString();
                label10.Text = okuyucu2["adi"].ToString();
                label11.Text = okuyucu2["soyadi"].ToString();
                tarih = Convert.ToDateTime(okuyucu2["gsaat"].ToString());
                parkyeri = okuyucu2["p"].ToString();
                label12.Text = okuyucu2["aracyikama"].ToString();
            }
            if (label12.Text=="Var")
            {
                aracyikama = 15;

            }
            else if (label12.Text=="Yok")
            {
                aracyikama = 0;
            }
            baglanti.Close();

            System.TimeSpan zaman;
            DateTime sondeger = DateTime.Now;
            zaman = sondeger.Subtract(tarih);
            double saat = Convert.ToDouble(zaman.TotalHours);
            double para = 6 * double.Parse(saat.ToString("0.##"));
            label13.Text = (aracyikama + para).ToString() + " TL";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand kom3 = new OleDbCommand("update parkyeri set durum='0' where parkalani='" + parkyeri + "'", baglanti);
            kom3.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            OleDbCommand kom4 = new OleDbCommand("update musteri set durum='1' where plaka='" + comboBox1.Text + "'", baglanti);
            kom4.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            OleDbCommand kom5 = new OleDbCommand("update gecmis set csaat='" + DateTime.Now + "',fiyat='"+label13.Text+"' where plaka='"+comboBox1.Text+"'", baglanti);
            kom5.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşleminiz Başarıyla Tamamlandı");
            parkyeri = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            aracikis_Load(sender, e);
            

        }

       
    }
}
