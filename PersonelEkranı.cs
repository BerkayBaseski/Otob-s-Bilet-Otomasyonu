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
    public partial class Kullanıcıgiris2 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=Berkay\\SQLEXPRESS;Initial Catalog=biletotomasyon;Integrated Security=True");
        public Kullanıcıgiris2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Personel_1 set Şifre='" + textBox5.Text + "' where ID=" + Convert.ToInt32(Kullanıcıgiris.id) + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Şifre Güncellendi");


        }

        private void biletAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Biletal al = new Biletal();
            this.Hide();
            al.Show();
        }

        private void Kullanıcıgiris2_Load(object sender, EventArgs e)
        {
            textBox5.UseSystemPasswordChar = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Ad, Soyad, Kullanıcı_adı, Şifre, Telefon from Personel_1 where ID =" + Convert.ToInt32(Kullanıcıgiris.id) + "", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["Ad"].ToString();
                textBox2.Text = read["Soyad"].ToString();
                textBox3.Text = read["Kullanıcı_adı"].ToString();
                textBox4.Text = read["Şifre"].ToString();
                maskedTextBox1.Text = read["Telefon"].ToString();
            }
            baglanti.Close();
        }

        private void biletİptalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            biletiptal ip = new biletiptal();
            this.Hide();
            ip.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanıcıgiris frm3 = new Kullanıcıgiris();
            this.Hide();
            frm3.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox5.UseSystemPasswordChar = false;
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox5.UseSystemPasswordChar = true;
            }

        }
    }
}
