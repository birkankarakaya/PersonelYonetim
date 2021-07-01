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

namespace PersonelYonetim
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HK06P7L\\SQLEXPRESS;Initial Catalog=PersonelDB;Integrated Security=True");

        void Temizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtSehir.Text = "";
            txtMaas.Text = "";
            txtMeslek.Text = "";
            rdbEvli.Checked = false;
            rdbBekar.Checked = false;
            txtAd.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelDBDataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.personelDBDataSet.Tbl_Personel);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert Into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1, @p2, @p3, @p4, @p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtSehir.Text);
            komut.Parameters.AddWithValue("@p4", txtMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label7.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelDBDataSet.Tbl_Personel);
        }

        private void rdbEvli_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEvli.Checked == true) 
            {
                label7.Text = "True";
            }
        }

        private void rdbBekar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBekar.Checked == true)
            {
                label7.Text = "False";
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtPerId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label7.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label7_SizeChanged(object sender, EventArgs e)
        {

        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
            if (label7.Text == "True") 
            {
                rdbEvli.Checked = true;
            }
            if (label7.Text == "False")
            {
                rdbBekar.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("DELETE FROM Tbl_Personel Where PerID=@k1", baglanti);
            sil.Parameters.AddWithValue("k1", txtPerId.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi", "Bilgi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1, PerSoyad=@a2, PerSehir=@a3, PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 Where PerID=@a7", baglanti);
            guncelle.Parameters.AddWithValue("@a1", txtAd.Text);
            guncelle.Parameters.AddWithValue("@a2", txtSoyad.Text);
            guncelle.Parameters.AddWithValue("@a3", txtSehir.Text);
            guncelle.Parameters.AddWithValue("@a4", txtMaas.Text);
            guncelle.Parameters.AddWithValue("@a5", label7.Text);
            guncelle.Parameters.AddWithValue("@a6", txtMeslek.Text);
            guncelle.Parameters.AddWithValue("@a7", txtPerId.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi", "Bilgi");
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            FrmIstatistik fr = new FrmIstatistik();
            fr.Show();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafik frmGrafik = new FrmGrafik();
            frmGrafik.Show();
        }
    }
}
