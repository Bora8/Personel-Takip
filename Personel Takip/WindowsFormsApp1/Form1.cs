using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Giriş_Ekranı : Form
    {
        public Giriş_Ekranı()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        //     baglanti = ("Server = localhost\SQLEXPRESS; Database = master; Trusted_Connection = True;");
            textBox3.Visible = false;
            textBox4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == textBox1.Text && textBox4.Text == textBox2.Text)
            {
                Ana_Ekran aeg = new Ana_Ekran();
                aeg.ShowDialog();
                Hide();
            }
        }
    }
}
