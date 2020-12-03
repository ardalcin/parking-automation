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
    public partial class arabagiris : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0;Data Source = otomasyonveri.mdb  ");
        public arabagiris()
        {
            InitializeComponent();
        }

        private void arabagiris_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand kom = new OleDbCommand("select * from parkyeri where durum like (0)",baglanti);
            OleDbDataReader okuyucu = kom.ExecuteReader();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["parkalani"].ToString());
            }
            baglanti.Close();   
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string saat = DateTime.Now.ToShortTimeString();
            string tarih = DateTime.Now.ToShortDateString();
            baglanti.Open();
            OleDbCommand eklekom = new OleDbCommand("insert into musteri (p, marka,model,plaka,adi,soyadi,gsaat,gtarih,durum,aracyikama) values('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+saat.ToString()+"','" + tarih.ToString() + "','0','" + comboBox2.Text + "')", baglanti);
            eklekom.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            OleDbCommand kom3 = new OleDbCommand("update parkyeri set durum='1' where parkalani like'" + comboBox1.Text + "'", baglanti);
            kom3.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            OleDbCommand kom4 = new OleDbCommand("insert into gecmis (plaka,adi,soyadi,marka,model,p,aracyikama,gsaat,gtarih) values ('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','"+saat.ToString()+"','" + tarih.ToString() + "')", baglanti);
            kom4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Kaydedildi");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

           
            arabagiris_Load(sender, e);
           

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
