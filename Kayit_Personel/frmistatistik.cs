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
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=MEHMET;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void frmistatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("Select count(*) From tbl_personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {

                LblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM tbl_personel WHERE PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevlipersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM tbl_personel WHERE PerDurum=0;", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekarpersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();


            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select COUNT(DISTINCT(PerSehir)) from tbl_personel ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblsehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("SELECT SUM(PerMaas) FROM tbl_personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                toplammaas.Text = dr5[0].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("SELECT AVG(PerMaas) FROM tbl_personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                ortmaas.Text = dr6[0].ToString();

            }
            baglanti.Close();

        
    }
    }
}
