using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otobüsbilet
{
    public partial class Admingiris : Form
    {
        public Admingiris()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Giriş Başarısız");
                MessageBox.Show("Kullanıcı Adı ve/veya Şifre boş bırakılamaz");
                errorProvider1.SetError(textBox1, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(textBox1, "Bu alan boş bırakılamaz");
            }
            if(textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
             if(textBox1.Text == "admin" && textBox2.Text == "1234")
                {
                    Adminpanel ag = new Adminpanel();
                    ag.Show();
                    this.Hide();
                }  
            }
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

        private void Admingiris_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
