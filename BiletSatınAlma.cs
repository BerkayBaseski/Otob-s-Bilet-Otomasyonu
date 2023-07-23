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
    public partial class Biletal : Form
    {
        public static int id2; 
        SqlConnection baglanti = new SqlConnection("Data Source=Berkay\\SQLEXPRESS;Initial Catalog=biletotomasyon;Integrated Security=True");
        public Biletal()
        {
            InitializeComponent();
        }

        private void Biletal_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool yolcuvarmi = false;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into  Biletalanyolcu_1(Ad, Soyad, Tc_Kimlik, Yaş, Telefon, Cinsiyet,Nereden, Nereye, Fiyat, Tarih,Sefer_saati,Koltuk_no) values('" + txtad.Text.ToString() + "','" + txtsoyad.Text.ToString() + "','" + txttc.Text.ToString() + "','" + cmbyas.Text.ToString() + "','" + mskdtel.Text.ToString() + "', '" + cmbcins.Text.ToString() + "','" + cmbnereden.Text.ToString() + "','" + cmbnereye.Text.ToString() + "','" + label12.Text.ToString() + "','" + dttarih.Value +"' , '"+cmbsefersaat.Text.ToString()+ "' , '" + comboBox6.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("select * from Biletalanyolcu_1 where Tc_Kimlik = '" + txttc.Text.ToString() + "'", baglanti);
            komut2.ExecuteNonQuery();
            SqlDataReader oku = komut2.ExecuteReader();

            while (oku.Read())
            {
                yolcuvarmi = true;
                id2 = Convert.ToInt32(oku["ID"]);
            }
            if (yolcuvarmi)
            {
                baglanti.Close();
                MessageBox.Show("Kayıt Yapıldı");
                temizle();
            }
        }
        public void temizle()
        {
            txtad.Clear();
            txtad.Clear();
            txtsoyad.Clear();
            mskdtel.Clear();
            txttc.Clear();
            cmbyas.Text = "";
            cmbcins.Text = "";
            cmbnereden.Text = "";
            cmbnereye.Text = "";
            cmbsefersaat.Text = "";
            comboBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanıcıgiris2 geri = new Kullanıcıgiris2();
            geri.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbnereden.Text == "ANKARA")
            {
                cmbnereye.Items.Remove("ANKARA");
            }
            else if(cmbnereye.Text == "ANTALYA")
            {
                cmbnereye.Items.Remove("ANTALYA");
            }
            else if(cmbnereden.Text == "BURSA")
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public int fiyat;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(cmbyas.Text == "18-30")
            {
                fiyat = Convert.ToInt32(nmudfiyat.Value);
                int indirim = (fiyat) - (fiyat * 2/10);
                label12.Text = indirim.ToString();
            }
        }

        private void nmudfiyat_ValueChanged(object sender, EventArgs e)
        {
            label12.Text = nmudfiyat.Value.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            biletsecme git = new biletsecme();
            git.ShowDialog();
        }
    }
}
