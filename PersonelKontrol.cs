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

namespace otobüsbilet
{
    public partial class perskont : Form
    {
        SqlConnection baglanti;
        SqlCommand komut2;
        SqlDataAdapter da;
        public perskont()
        {
            InitializeComponent();
        }
        void getir()
        {
            baglanti = new SqlConnection("Data Source = Berkay\\SQLEXPRESS; Initial Catalog = biletotomasyon; Integrated Security = True");
            baglanti.Open();
            da = new SqlDataAdapter("select * from Personel_1", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void perskont_Load(object sender, EventArgs e)
        {
            txtsifre.UseSystemPasswordChar = true;
            txtsifret.UseSystemPasswordChar = true;
            getir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txttc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mskdtel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtusername.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtsifre.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Personel_1 where ID = @id ";
            komut2 = new SqlCommand(sorgu, baglanti);
            komut2.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            baglanti.Open();
            komut2.ExecuteNonQuery();
            baglanti.Close();
            getir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Personel_1 SET Ad = @ad, Soyad=@soyad, Tc_Kimlik = @tc, Yaş = @yaş, Telefon = @tel, Cinsiyet = @cinsiyet, Kullanıcı_adı = @username, Şifre = @şifre  WHERE ID = @id";
            komut2 = new SqlCommand(sorgu, baglanti);
            komut2.Parameters.AddWithValue("@id", textBox1.Text);
            komut2.Parameters.AddWithValue("@ad", txtad.Text);
            komut2.Parameters.AddWithValue("@soyad", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@tc", txttc.Text);
            komut2.Parameters.AddWithValue("@yaş", textBox2.Text);
            komut2.Parameters.AddWithValue("@tel", mskdtel.Text);
            komut2.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
            komut2.Parameters.AddWithValue("@username", txtusername.Text);
            komut2.Parameters.AddWithValue("@şifre", textBox1.Text);
            baglanti.Open();
            komut2.ExecuteNonQuery();
            baglanti.Close();
            getir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adminpanel ap = new Adminpanel();
            this.Hide();
            ap.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kayıtol git = new Kayıtol();
            this.Hide();
            git.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                txtsifre.UseSystemPasswordChar = false;
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                txtsifre.UseSystemPasswordChar = true;
            }

        }
    }
}
