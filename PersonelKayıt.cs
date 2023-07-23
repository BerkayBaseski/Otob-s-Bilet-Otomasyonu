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
    public partial class Kayıtol : Form
    {
        public Kayıtol()
        {
            InitializeComponent();
        }
       SqlConnection baglanti = new SqlConnection("Data Source=Berkay\\SQLEXPRESS;Initial Catalog=biletotomasyon;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Personel_1(Ad, Soyad, Tc_Kimlik, Kullanıcı_adı, Şifre, Telefon, Cinsiyet, Yaş) values('" + txtad.Text.ToString() + "','" + txtsoyad.Text.ToString() + "','" + txttc.Text.ToString() + "','"+ txtusername.Text.ToString() + "','" + txtsifre.Text.ToString() + "', '"+mskdtel.Text.ToString()+"','"+comboBox1.Text.ToString()+"','"+textBox1.Text.ToString()+"')", baglanti);


            if (txtad.Text == string.Empty || txtsifre.Text == string.Empty || txtsoyad.Text == string.Empty || txtusername.Text == string.Empty || txttc.Text == string.Empty || mskdtel.Text == string.Empty || txtsifret.Text == string.Empty)
            {
                errorProvider1.SetError(txtad, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(txtsifre, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(txtsifret, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(txtsoyad, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(txttc, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(mskdtel, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(txtusername, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(comboBox1, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(textBox1, "Bu alan boş bırakılamaz");
            }
            if(txtad.Text != string.Empty && txtsifre.Text != string.Empty && txtsoyad.Text != string.Empty && txtusername.Text != string.Empty && txttc.Text != string.Empty && txtsifret.Text != string.Empty && textBox1.Text != string.Empty && comboBox1.Text != string.Empty)
            {
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Eklendi","İnformation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                baglanti.Close();
            }
            if(txtsifre.Text == txtsifret.Text)
            {
                MessageBox.Show("Belirlenen Şifre ile Şifre tekrar aynı değerde olmalıdır","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if(txttc.Text.Length < 11 && txttc.Text.Length > 11)
            {
                MessageBox.Show("T.C Kimlik No 11 haneli olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            txtad.Clear();
            txtsoyad.Clear();
            txtsifre.Clear();
            txtsifret.Clear();
            txttc.Clear();
            txtusername.Clear();
            textBox1.Clear();
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

        private void Kayıtol_Load(object sender, EventArgs e)
        {
            txtsifre.UseSystemPasswordChar = true;
            txtsifret.UseSystemPasswordChar = true;
        }
    }
}
