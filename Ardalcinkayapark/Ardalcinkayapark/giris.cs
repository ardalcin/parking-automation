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
using System.Diagnostics;

namespace Ardalcinkayapark
{
    public partial class giris : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0;Data Source = otomasyonveri.mdb  ");
        public giris()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.google.com.tr");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text=="" && textBox2.Text=="")
            {
                MessageBox.Show("Lütfen Boş Bırakmayınız!");
            }
            else if (textBox1.Text=="")
            {
                MessageBox.Show("Lütfen Kullanıcı Adını Boş Bırakma!");
            }
            else if (textBox2.Text=="")

            {
                MessageBox.Show("lütfen şifrenizi boş bırakmayın!");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from Kullanici where kullaniciadi='" + textBox1.Text.ToString() + "'", baglanti);
                OleDbDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read()==true)
                {
                    if (textBox1.Text.ToString()==okuyucu["kullaniciadi"].ToString()&& textBox2.Text.ToString() == okuyucu["sifre"].ToString())
                    {
                        Form Anamenu = new Anamenu();
                        Anamenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("kullanıcı adı veya şifre yanlış.. Kontrol et!");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("kullanıcı adı veya şifre yanlış..Kontrol et!");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                baglanti.Close();
            }
        }
    }
}
