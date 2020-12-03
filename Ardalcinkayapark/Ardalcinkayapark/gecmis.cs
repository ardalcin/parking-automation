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
    public partial class gecmis : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0;Data Source = otomasyonveri.mdb  ");
        public gecmis()
        {
            InitializeComponent();
        }
        DataTable tablo = new DataTable();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter ara=new OleDbDataAdapter("select * from gecmis where plaka like '%"+textBox1.Text+"%'",baglanti);
            ara.Fill(tablo);
            baglanti.Close();
            dataGridView1.DataSource = tablo;
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
       
          

        private void gecmis_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from gecmis", baglanti);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
           
            
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString(); //[0] sütun numarası
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand verisil = new OleDbCommand("delete from gecmis where plaka =@plaka ", baglanti);
            verisil.Parameters.AddWithValue("@plaka", textBox2.Text);
            verisil.ExecuteNonQuery();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); //[0] sütun numarası
            baglanti.Close();
            gecmis_Load(sender, e);
        }
    }
}
