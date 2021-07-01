using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelYonetim
{
    public partial class FrmGiris : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HK06P7L\\SQLEXPRESS;Initial Catalog=PersonelDB;Integrated Security=True");

        public FrmGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand giris = new SqlCommand("select*from Tbl_Admin where Kullanici=@p1 and Sifre=@p2", baglanti);
            giris.Parameters.AddWithValue("@p1", textBox1.Text);
            giris.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = giris.ExecuteReader();
            if (dr.Read())
            {
                FrmAnasayfa frmAnasayfa = new FrmAnasayfa();
                frmAnasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            baglanti.Close();
        }
    }
}
