using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Belgeler : Form
    {
        public Belgeler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            axAcroPDF1.Visible = true;
            OpenFileDialog belge = new OpenFileDialog();
            belge.Filter = "PDF Dosapaları (*.Pdf) | *.Pdf";
            if(belge.ShowDialog () == DialogResult.OK )
            {
                label1.Visible = true;
                textBox1.Text = belge.FileName;
                axAcroPDF1.LoadFile(belge.FileName);
                label1.Text = Path.GetFileName(belge.FileName);
            }

        }

        private void Belgeler_Load(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True"))
            {
                baglanti.Open();
                string sorgu = "SELECT İsim FROM Bilgiler";
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    using (SqlDataReader reader = komut.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string kişi = reader["İsim"].ToString();
                            comboBox1.Items.Add(kişi);
                        }
                    }
                }
            }
            label1.Visible=false;
            axAcroPDF1.Visible=false;
            textBox1.Visible = false;
            textBox2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True"))
            {
                baglanti.Open();
                comboBox2.Items.Clear();

                string selectedIsim = comboBox1.SelectedItem.ToString();
                string sorgu1 = "SELECT Soyisim FROM Bilgiler WHERE İsim = @Isim";

                using (SqlCommand komut1 = new SqlCommand(sorgu1, baglanti))
                {
                    komut1.Parameters.AddWithValue("@Isim", selectedIsim);

                    using (SqlDataReader reader = komut1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string kişi1 = reader["Soyisim"].ToString();
                            comboBox2.Items.Add(kişi1);
                        }
                    }
                }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True"))
            {
                baglanti.Open();

                string selectedIsim = comboBox1.SelectedItem?.ToString();
                string selectedSoyisim = comboBox2.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(selectedIsim) && !string.IsNullOrEmpty(selectedSoyisim))
                {
                    string sorgu1 = "SELECT IDPersonel FROM Bilgiler WHERE İsim = @Isim AND Soyisim = @Soyisim";

                    using (SqlCommand komut1 = new SqlCommand(sorgu1, baglanti))
                    {
                        komut1.Parameters.AddWithValue("@Isim", selectedIsim);
                        komut1.Parameters.AddWithValue("@Soyisim", selectedSoyisim);

                        using (SqlDataReader reader = komut1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox2.Text = reader["IDPersonel"].ToString();
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO Belge(IDPersonel, İsim, Soyisim, Belge) VALUES(@IDPersonel, @İsim, @Soyisim, @Belge)", baglanti);
                komut.Parameters.AddWithValue("@IDPersonel", textBox2.Text);
                komut.Parameters.AddWithValue("@İsim", comboBox1.Text);
                komut.Parameters.AddWithValue("@Soyisim", comboBox2.Text);
                komut.Parameters.AddWithValue("@Belge", textBox1.Text);
                komut.ExecuteNonQuery();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (axAcroPDF1.Visible == true)
            {
                Belgeler_Load(sender, e);
            }
            else
            {
                Ana_Ekran aeg = new Ana_Ekran();
                aeg.ShowDialog();
                Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT Belge From Belge WHERE IDPersonel = @IDPersonel", baglanti);
                komut.Parameters.AddWithValue("@IDPersonel", textBox2.Text);
                using (SqlDataReader reader = komut.ExecuteReader())
                {
                    // DataTable oluştur
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // DataGridView'e verileri atama
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BelgeBilgisi bb = new BelgeBilgisi();
            bb.a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bb.Show();
        }
    }
}



