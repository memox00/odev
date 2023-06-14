using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EtutOtomasyon
{
    public partial class FormEtutGuncelle : Form
    {
        Database vt = new Database();
        string ogrencino;

        public FormEtutGuncelle()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            vt.baglanti.Open();
            SqlCommand komutOB = new SqlCommand("Update  tablobilgi set ogrenci_ad=@p2,ogrenci_soyad=@p3,ogrenci_adres=@p4,etut_ders_adi=@p5,etut_ders_suresi=@p6 where ogrenci_no=@p1", vt.baglanti);
            komutOB.Parameters.AddWithValue("@p1", tbOgrenciNo.Text);
            komutOB.Parameters.AddWithValue("@p2", tbOgrencıAd.Text);
            komutOB.Parameters.AddWithValue("@p3", tbOgrenciSoyad.Text);
            komutOB.Parameters.AddWithValue("@p4", tbOgrenciAdres.Text);
            komutOB.Parameters.AddWithValue("@p5", tbDers.Text);
            komutOB.Parameters.AddWithValue("@p6", tbEtutSure.Text);
            komutOB.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Başarılı.");
            vt.baglanti.Close();
        }
        void Listele(string numara)
        {


            try
            {
                vt.baglanti.Open();
                SqlCommand komut = new SqlCommand(" Select * from tablobilgi where ogrenci_no = @parametre", vt.baglanti);
                komut.Parameters.AddWithValue("@parametre", numara);
                komut.ExecuteNonQuery();
                SqlDataReader dr = komut.ExecuteReader();
                dr.Read();
                tbOgrenciNo.Text = numara;
                tbOgrencıAd.Text = dr["ogrenci_ad"].ToString().Trim();

                tbOgrenciSoyad.Text = dr["ogrenci_soyad"].ToString().Trim();
                tbOgrenciAdres.Text = dr["ogrenci_adres"].ToString().Trim();
                tbDers.Text = dr["etut_ders_adi"].ToString().Trim();
                tbEtutSure.Text = dr["etut_ders_suresi"].ToString().Trim();

                vt.baglanti.Close();
            }
            catch (ArgumentNullException hata)
            {

                MessageBox.Show("Lütfen Bir Satır Seçin ve Ardından Tekrar Deneyin :)" + hata);
            }


        }

        private void FormEtutGuncelle_Load(object sender, EventArgs e)
        {
            ogrencino = Form1.veriTutucu;
            Listele(ogrencino);

        }
    }
}
