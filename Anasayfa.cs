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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kayıtol kayıt = new Kayıtol();
            kayıt.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanıcıgiris kg = new Kullanıcıgiris();
            this.Hide();
            kg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admingiris ag = new Admingiris();
            this.Hide();
            ag.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
