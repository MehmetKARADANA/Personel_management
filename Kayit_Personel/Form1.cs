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

namespace Kayit_Personel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet.tbl_personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
          //  this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet.tbl_personel);

        }
        SqlConnection baglanti = new SqlConnection("Data Source=MEHMET;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtmeslek.Text = "";
            cmbsehir.Text = "";
            msbmaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();
        }

            private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet.tbl_personel);

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_personel (PerAd,PerSoyad,PerMeslek,PerSehir,PerMaas,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p4", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p5", msbmaas.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            komut.ExecuteNonQuery();//bu işlem yapılmazsa kodlar çalışmaz insert update delete de kullanılır okumada değil
            baglanti.Close();
            MessageBox.Show("Personel eklendi");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From tbl_personel where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update  tbl_personel Set PerAd=@a1,PerSoyad=@a2,PerMaas=@a3,PerMeslek=@a4,PerSehir=@a5,PerDurum=@a6 where Perid=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", msbmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a4", txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a5", cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a6", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtid.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel guncellendi");
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            //hücre indekslerini veri tabanına göre girmek önemli
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msbmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            // şimdi personel durumu halledicem

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
                // radioButton2.Checked = false;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
                //  radioButton1.Checked = false;
            }
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fri = new frmistatistik();
            fri.Show();
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            frmgrafikler frg = new frmgrafikler();
            frg.Show();
        }

        private void btnraporlar_Click(object sender, EventArgs e)
        {
            frmRaporlar frm1 = new frmRaporlar();
            frm1.Show();
        }
    }
}
