using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EtutOtomasyon
{
    public partial class FormEtutEkle : Form
    {
        Database vt = new Database();

        public FormEtutEkle()
        {
            InitializeComponent();
        }

        private void FormEtutEkle_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu = "insert into tablobilgi (ogrenci_no,ogrenci_ad,ogrenci_soyad,ogrenci_adres,etut_ders_adi,etut_ders_suresi) values (@ogrenci_no,@ogrenci_ad,@ogrenci_soyad,@ogrenci_adres,@etut_ders_adi,@etut_ders_suresi)";
            vt.baglanti.Open();
            SqlCommand cmd = new SqlCommand(sorgu, vt.baglanti);

            cmd.Parameters.AddWithValue("@ogrenci_no", tbOgrenciNo.Text);
            cmd.Parameters.AddWithValue("@ogrenci_ad", tbOgrencıAd.Text);
            cmd.Parameters.AddWithValue("@ogrenci_soyad", tbOgrenciSoyad.Text);
            cmd.Parameters.AddWithValue("@ogrenci_adres", tbOgrenciAdres.Text);
            cmd.Parameters.AddWithValue("@etut_ders_adi", tbDers.Text);
            cmd.Parameters.AddWithValue("@etut_ders_suresi", tbEtutSure.Text);
            cmd.ExecuteNonQuery();

            vt.baglanti.Close();
            MessageBox.Show("İşlem başarıyla gerçekleştirildi.");



        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
