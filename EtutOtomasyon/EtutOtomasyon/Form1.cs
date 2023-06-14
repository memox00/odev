using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace EtutOtomasyon
{
    public partial class Form1 : Form
    {
        SqlDataAdapter da;
        DataSet ds;
        private string numara;
        public static string veriTutucu { get; set; }



        public Form1()
        {
            InitializeComponent();
        }
        Database vt = new Database();

        private void button1_Click(object sender, EventArgs e)
        {
            FormEtutEkle form2 = new FormEtutEkle();
            form2.Show();
            this.Hide();
        }
        void griddoldur()
        {
            da = new SqlDataAdapter("Select * From tablobilgi", vt.baglanti);
            ds = new DataSet();
            vt.baglanti.Open();
            da.Fill(ds, "ogrenci");
            dataGridView1.DataSource = ds.Tables["ogrenci"];
            vt.baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            griddoldur();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        void etut_sil(string numara)
        {
            string sql = "DELETE FROM tablobilgi WHERE ogrenci_no=@p1";
            SqlCommand komut = new SqlCommand(sql, vt.baglanti);
            vt.baglanti.Open();
            komut = new SqlCommand(sql, vt.baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            komut.ExecuteNonQuery();
            vt.baglanti.Close();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//farenin sağ tuşuna basılmışsa
            {

                int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1)
                {
                    dataGridView1.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    numara = dataGridView1.SelectedCells[0].Value.ToString();

                }
            }
            veriTutucu = dataGridView1.SelectedCells[0].Value.ToString();

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            etut_sil(numara);
            griddoldur();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (veriTutucu != null)
            {
                FormEtutGuncelle frm = new FormEtutGuncelle();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Güncelleme yapılacak satırı seçin.");
            }
        }
    }

}
