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
    public partial class Kullanıcıgiris : Form
    {
        public Kullanıcıgiris()
        {
            InitializeComponent();
        }
        static public int id;
        SqlConnection baglanti = new SqlConnection("Data Source = Berkay\\SQLEXPRESS; Initial Catalog = biletotomasyon; Integrated Security = True");
        private void button1_Click(object sender, EventArgs e)
        {
            bool kullanıcıvarmi = false;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from  Personel_1 where Kullanıcı_adı = '" + textBox1.Text.ToString() + "' and Şifre ='" + textBox2.Text.ToString() + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                kullanıcıvarmi = true;
                id = Convert.ToInt32(oku["ID"]); 
            }
            baglanti.Close();
            if (kullanıcıvarmi)
            {
                if(textBox1.Text != string.Empty && textBox2.Text != string.Empty)
                {
                    MessageBox.Show("Giriş Başarılı");
                    Kullanıcıgiris2 user = new Kullanıcıgiris2();
                    user.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
                errorProvider1.SetError(textBox1, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(textBox2, "Bu alan boş bırakılamaz");
                MessageBox.Show("Kullanıcı adı ve/veya şifre boş bırakılamaz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kayıtol kayıt = new Kayıtol();
            kayıt.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = true;
            }

        }

        private void Kullanıcıgiris_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
