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
    public partial class biletiptal : Form
    {
        SqlConnection baglanti;
        SqlCommand komut2;
        SqlDataAdapter da;
        public biletiptal()
        {
            InitializeComponent();
        }

        void getir()
        {
            baglanti = new SqlConnection("Data Source = Berkay\\SQLEXPRESS; Initial Catalog = biletotomasyon; Integrated Security = True");
            baglanti.Open();
            da = new SqlDataAdapter("select * from Biletalanyolcu_1", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Biletalanyolcu_1 where ID = @id ";
            komut2 = new SqlCommand(sorgu, baglanti);
            komut2.Parameters.AddWithValue("@id", Convert.ToInt32(textBox4.Text));
            baglanti.Open();
            komut2.ExecuteNonQuery();
            baglanti.Close();
            getir();

        }

        private void biletiptal_Load(object sender, EventArgs e)
        {
            getir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kullanıcıgiris2 ger = new Kullanıcıgiris2();
            this.Hide();
            ger.Show();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cmbnereden.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cmbnereye.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox5.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void cmbnereden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbnereden.Text == "ANKARA")
            {
                cmbnereye.Items.Remove("ANKARA");
            }
            else if (cmbnereye.Text == "ANTALYA")
            {
                cmbnereye.Items.Remove("ANTALYA");
            }
            else if (cmbnereden.Text == "BURSA")
            {
                cmbnereye.Items.Remove("BURSA");
            }
            else if (cmbnereden.Text == "ERZİNCAN")
            {
                cmbnereye.Items.Remove("ERZİNCAN");
            }
            else if (cmbnereden.Text == "İZMİR")
            {
                cmbnereye.Items.Remove("İZMİR");
            }
            else if (cmbnereden.Text == "MALATYA")
            {
                cmbnereye.Items.Remove("MALATYA");
            }
            else if (cmbnereden.Text == "MUĞLA")
            {
                cmbnereye.Items.Remove("MUĞLA");
            }
            else if (cmbnereden.Text == "TEKİRDAĞ")
            {
                cmbnereye.Items.Remove("TEKİRDAĞ");
            }
            else if (cmbnereden.Text == "TRABZON")
            {
                cmbnereye.Items.Remove("TRABZON");
            }
            else if (cmbnereden.Text == "SAMSUN")
            {
                cmbnereye.Items.Remove("SAMSUN");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Biletalanyolcu_1 SET Ad = @ad, Soyad=@soyad, Tc_Kimlik = @tc, Yaş = @yaş, Telefon = @tel, Cinsiyet = @cinsiyet, Nereden = @nereden, Nereye = @nereye, Sefer_saati = @saat, Tarih = @tarih WHERE ID = @id";
            komut2 = new SqlCommand(sorgu, baglanti);
            komut2.Parameters.AddWithValue("@id", textBox4.Text);
            komut2.Parameters.AddWithValue("@ad", textBox2.Text);
            komut2.Parameters.AddWithValue("@soyad", textBox3.Text);
            komut2.Parameters.AddWithValue("@tc", textBox1.Text);
            komut2.Parameters.AddWithValue("@yaş", comboBox1.Text);
            komut2.Parameters.AddWithValue("@tel", maskedTextBox1.Text);
            komut2.Parameters.AddWithValue("@cinsiyet", comboBox2.Text);
            komut2.Parameters.AddWithValue("@nereden", cmbnereden.Text);
            komut2.Parameters.AddWithValue("@nereye", cmbnereye.Text);
            komut2.Parameters.AddWithValue("@saat", comboBox5.Text);
            komut2.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);
            baglanti.Open();
            komut2.ExecuteNonQuery();
            baglanti.Close();
            getir();
        }
    }
}
