using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using AxAcroPDFLib;

namespace WindowsFormsApp1
{
    public partial class Ana_Ekran : Form
    {
        public Ana_Ekran()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True");
        private void DatabaseGetir()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Bilgiler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            baglanti.Close();
            button9.Visible = true;
            button10.Visible = true;
        }
        private void Ana_Ekran_Load(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True"))
            {
                baglanti.Open();

                string sorgu = "SELECT Departman FROM Departman";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    using (SqlDataReader reader = komut.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string departman = reader["Departman"].ToString();
                            if (!comboBox1.Items.Contains(departman))
                            {
                                comboBox1.Items.Add(departman);
                            }
                        }
                    }
                }
            }

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;

            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            richTextBox1.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            comboBox1.Visible = false;
            pictureBox1.Visible = false;
            button7.Visible = false;

            button5.Visible = false;
            button6.Visible = false;
            textBox1.Visible = false;
            button9.Visible = false;

            textBox9.Visible = false;
            button10.Visible = false;
            dateTimePicker1.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;

            button11.Visible = false;
            label23.Visible = false;
            textBox12.Visible = false;
            label24.Visible = false;
            textBox13.Visible = false;
            label25.Visible = false;
            textBox14.Visible = false;
            axAcroPDF1.Visible = false;
        }
        private void ikinciekran()
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;

            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            richTextBox1.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            comboBox1.Visible = true;
            pictureBox1.Visible = true;
            button7.Visible = true;

            button5.Visible = true;
            dateTimePicker1.Visible = true;
            dataGridView1.Visible = false;
            button11.Visible = true;
            button9.Visible = false;
            button10.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {   if(axAcroPDF1.Visible == false)
            {
                dataGridView1.DataSource = null;
                Ana_Ekran_Load(sender, e);
                dataGridView1.Visible = true;
                label20.Visible = false;
            }
            else if (axAcroPDF1.Visible == true)
            {
                axAcroPDF1.Visible = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ikinciekran();
            label20.Visible = false;

        }
        private void button5_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            button5.Visible = false;
            textBox1.Visible = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True"))
                {
                    baglanti.Open();

                    string sorgu = "INSERT INTO Departman (Departman) VALUES (@Departman)";

                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@Departman", textBox1.Text);
                        komut.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Başarıyla Eklenmiştir.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox5.Text = openFileDialog1.FileName;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox4.TextLength == 11)
            {
                if (textBox9.Text == "")
                {
                    SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True");
                    baglanti.Open();
                    string sorgu = "Insert Into Bilgiler(Fotoğraf, İsim, Soyisim, KimlikNumarası, Telefon, Mail, Departman, GörevTanımı, Adres, DoğumTarihi) VALUES (@Fotoğraf, @İsim, @Soyisim, @KimlikNumarası, @Telefon, @Mail, @Departman, @GörevTanımı, @Adres, @DoğumTarihi)";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Fotoğraf", textBox5.Text);
                    komut.Parameters.AddWithValue("@İsim", textBox2.Text);
                    komut.Parameters.AddWithValue("@Soyisim", textBox3.Text);
                    komut.Parameters.AddWithValue("@KimlikNumarası", textBox4.Text);
                    komut.Parameters.AddWithValue("@Telefon", textBox6.Text);
                    komut.Parameters.AddWithValue("@Mail", textBox7.Text);
                    komut.Parameters.AddWithValue("@Departman", comboBox1.Text);
                    komut.Parameters.AddWithValue("@GörevTanımı", textBox8.Text);
                    komut.Parameters.AddWithValue("@Adres", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@DoğumTarihi", dateTimePicker1.Value.Date);
                    komut.ExecuteNonQuery();
                    
                    MessageBox.Show("Başarıyla Kaydedildi.");
                    SqlCommand komut1 = new SqlCommand("SELECT IDPersonel FROM Bilgiler WHERE KimlikNumarası = @KimlikNumarası", baglanti);
                    komut1.Parameters.AddWithValue("@KimlikNumarası", textBox4.Text);

                    
                    object result = komut1.ExecuteScalar();

                    if (result != null)
                    {
                        textBox9.Text = result.ToString();
                    }
                    baglanti.Close();

                }
                else if (textBox9.Text != null)
                {
                    baglanti.Open();
                    SqlCommand komut1 = new SqlCommand("UPDATE Bilgiler SET Fotoğraf = @Fotoğraf, İsim = @İsim, Soyisim = @Soyisim, KimlikNumarası = @KimlikNumarası, Telefon = @Telefon, Mail = @Mail, Departman = @Departman, GörevTanımı = @GörevTanımı, Adres = @Adres, DoğumTarihi = @DoğumTarihi WHERE IDPersonel = @IDPersonel", baglanti);
                    komut1.Parameters.AddWithValue("@IDPersonel", textBox9.Text);
                    komut1.Parameters.AddWithValue("@Fotoğraf", textBox5.Text);
                    komut1.Parameters.AddWithValue("@İsim", textBox2.Text);
                    komut1.Parameters.AddWithValue("@Soyisim", textBox3.Text);
                    komut1.Parameters.AddWithValue("@KimlikNumarası", textBox4.Text);
                    komut1.Parameters.AddWithValue("@Telefon", textBox6.Text);
                    komut1.Parameters.AddWithValue("@Mail", textBox7.Text);
                    komut1.Parameters.AddWithValue("@Departman", comboBox1.Text);
                    komut1.Parameters.AddWithValue("@GörevTanımı", textBox8.Text);
                    komut1.Parameters.AddWithValue("@Adres", richTextBox1.Text);
                    komut1.Parameters.AddWithValue("@DoğumTarihi", dateTimePicker1.Value.Date);
                    komut1.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Başarıyla Güncellendi.");
                }
                
            }
            else
            {
                MessageBox.Show("Kimlik numarsı 11 harf olmak zorundadır", "Personel Kayıt");
            }
            if(label23.Visible == true)
            {
                using (SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True"))
                    {
                        baglanti.Open();
                        SqlCommand komut2 = new SqlCommand("INSERT INTO Belge(IDPersonel, İsim, Soyisim, Belge) VALUES(@IDPersonel, @İsim, @Soyisim, @Belge)", baglanti);
                        komut2.Parameters.AddWithValue("@IDPersonel", textBox9.Text);
                        komut2.Parameters.AddWithValue("@İsim", textBox2.Text);
                        komut2.Parameters.AddWithValue("@Soyisim", textBox3.Text);
                        komut2.Parameters.AddWithValue("@Belge", textBox12.Text);
                        komut2.ExecuteNonQuery();
                    }
                
            }
            if (label24.Visible == true)
            {
                using (SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True"))
                {
                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("INSERT INTO Belge(IDPersonel, İsim, Soyisim, Belge) VALUES(@IDPersonel, @İsim, @Soyisim, @Belge)", baglanti);
                    komut2.Parameters.AddWithValue("@IDPersonel", textBox9.Text);
                    komut2.Parameters.AddWithValue("@Belge", textBox13.Text);
                    komut2.Parameters.AddWithValue("@İsim", textBox2.Text);
                    komut2.Parameters.AddWithValue("@Soyisim", textBox3.Text);
                    komut2.ExecuteNonQuery();
                }
            }
            if (label25.Visible == true)
            {
                using (SqlConnection baglanti = new SqlConnection("Data Source=GUROL\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True"))
                {
                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("INSERT INTO Belge(IDPersonel, İsim, Soyisim, Belge) VALUES(@IDPersonel, @İsim, @Soyisim, @Belge)", baglanti);
                    komut2.Parameters.AddWithValue("@IDPersonel", textBox9.Text);
                    komut2.Parameters.AddWithValue("@Belge", textBox14.Text);
                    komut2.Parameters.AddWithValue("@İsim", textBox2.Text);
                    komut2.Parameters.AddWithValue("@Soyisim", textBox3.Text);
                    komut2.ExecuteNonQuery();
                }
            }
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = 0;
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            richTextBox1.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label20.Visible = true;
            label20.Text = "(Telefon numaranızı 05********* şeklide boşluksuz yazınız.)";
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                ikinciekran();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                richTextBox1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pictureBox1.ImageLocation = textBox5.Text;
                button5.Visible = false;
                button6.Visible = false;
            }
            else if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen bir kişi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {

            textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlCommand komut1 = new SqlCommand("DELETE Bilgiler WHERE IDPersonel = @IDPersonel", baglanti);
            komut1.Parameters.AddWithValue("@IDPersonel", textBox9.Text);
            baglanti.Open();
            komut1.ExecuteNonQuery();
            baglanti.Close();
            DatabaseGetir();
            textBox9.Text = "";
            MessageBox.Show("Başarıyla Silindi.");

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PersonelBilgisi pb = new PersonelBilgisi();
            textBox11.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            pb.i = textBox11.Text;
            pb.a = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            pb.b = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            pb.c = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            pb.d = textBox10.Text;
            pb.ee = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            pb.f = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            pb.g = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            pb.h = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            pb.ı = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            pb.Show();

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int maxKarakterSayisi = 10;
            string textBoxMetni = textBox10.Text;
            if (textBoxMetni.Length > maxKarakterSayisi)
                textBoxMetni = textBoxMetni.Substring(0, maxKarakterSayisi);
            textBox10.Text = textBoxMetni;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (label23.Visible == false)
            {
                openFileDialog2.Filter = "Belge Dosyaları|*.pdf;*.docx;*.txt|Tüm Dosyalar|*.*";

                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    string belgeYolu = openFileDialog2.FileName;
                    textBox12.Text = belgeYolu;
                    label23.Text = Path.GetFileName(belgeYolu);

                    label23.Visible = true;
                    MessageBox.Show("İşlem başarılı.");
                }

            }
            else if (label23.Visible == true && label24.Visible == false)
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    string belgeYolu = openFileDialog2.FileName;
                    textBox13.Text = belgeYolu;
                    label24.Text = Path.GetFileName(belgeYolu);
                    label24.Visible = true;

                    MessageBox.Show("İşlem başarılı.");
                }
            }
            else if (label23.Visible == true && label24.Visible == true)
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    string belgeYolu = openFileDialog2.FileName;
                    textBox14.Text = belgeYolu;
                    label25.Text = Path.GetFileName(belgeYolu);
                    label25.Visible = true;
                    MessageBox.Show("İşlem başarılı.");
                }
            }
        }

        private void label23_DoubleClick(object sender, EventArgs e)
        {
            if (axAcroPDF1.Visible == false)
            {
                axAcroPDF1.Visible = true;

                axAcroPDF1.LoadFile(textBox12.Text);

            }
            else if (axAcroPDF1.Visible == true)
            {
                axAcroPDF1.Visible = false;
            }

        }

        private void label24_DoubleClick(object sender, EventArgs e)
        {
            if (axAcroPDF1.Visible == false)
            {
                axAcroPDF1.Visible = true;

                axAcroPDF1.LoadFile(textBox13.Text);

            }
            else if (axAcroPDF1.Visible == true)
            {
                axAcroPDF1.Visible = false;
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {
            if (axAcroPDF1.Visible == false)
            {
                axAcroPDF1.Visible = true;

                axAcroPDF1.LoadFile(textBox14.Text);

            }
            else if (axAcroPDF1.Visible == true)
            {
                axAcroPDF1.Visible = false;
            }
        }

        

        private void button12_Click(object sender, EventArgs e)
        {
            Belgeler bg = new Belgeler();
            bg.Show();
            this.Hide();
        }

        
    }
}
