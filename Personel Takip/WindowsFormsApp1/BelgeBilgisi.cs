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
    public partial class BelgeBilgisi : Form
    {
        public BelgeBilgisi()
        {
            InitializeComponent();
        }
        public string a;
        private void BelgeBilgisi_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox1.Text = a;
            axAcroPDF1.LoadFile(textBox1.Text);
        }
    }
}
