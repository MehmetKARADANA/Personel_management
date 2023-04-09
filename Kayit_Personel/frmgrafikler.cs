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

namespace Kayit_Personel
{
    public partial class frmgrafikler : Form
    {
        public frmgrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=MEHMET;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void frmgrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("SELECT PerSehir,Count(*) FROM tbl_personel GROUP BY PerSehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);//series parantezi içi chart ile birebir aynı olmalıdır,AddXY nin içindeki 0 1 indeksleri sıralanma mantığına göre
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("SELECT PerMeslek,AVG(PerMaas) FROM tbl_personel GROUP BY PerMeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);//series parantezi içi chart ile birebir aynı olmalıdır,AddXY nin içindeki 0 1 indeksleri sıralanma mantığına göre
            }
            baglanti.Close();
        }
    }
}
