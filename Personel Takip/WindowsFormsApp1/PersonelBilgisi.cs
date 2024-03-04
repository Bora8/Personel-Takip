using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class PersonelBilgisi : Form
    {
        public PersonelBilgisi()
        {
            InitializeComponent();
        }
        public string a, b, c, d, ee, f, g, h, ı, i;

        private void PersonelBilgisi_Load(object sender, EventArgs e)
        {
            label12.Text = a;
            label13.Text = b;
            label14.Text = c;
            label15.Text = d;
            label16.Text = ee;
            richTextBox1.Text = f;
            lblresim.Text = f;
            label18.Text = g;
            label19.Text = h;
            label20.Text = ı;
            lblresim.Text = i;
            pictureBox1.ImageLocation = lblresim.Text;
            lblresim.Visible = false;
            
        }
    }

    
}
