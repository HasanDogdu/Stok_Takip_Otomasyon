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

namespace StokTakipOtomasyon
{
    public partial class frmMüşteriListele : Form
    {
        public frmMüşteriListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-AT2VJJI;Initial Catalog=Stok_Takip;Integrated Security=True");
        DataSet daset = new DataSet();
       
        private void frmMüşteriListele_Load(object sender, EventArgs e)
        {
            Kayıt_Göster();
        }

        private void Kayıt_Göster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from müşteri", baglanti);
            adtr.Fill(daset, "müşteri");
            dataGridView1.DataSource = daset.Tables["müşteri"];
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            txtAdSoyad.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update müşteri set adsoyad=@adsoyad,telefon=@telefon,adres=@adres,email=@email where tc=@tc",baglanti);
            cmd.Parameters.AddWithValue("@tc", txtTc.Text);
            cmd.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["müşteri"].Clear();
            Kayıt_Göster();
            MessageBox.Show("güncelleme başarılı !");
            txtTc.Clear();
            txtAdSoyad.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            txtEmail.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Delete from müşteri where tc='" + dataGridView1.CurrentRow.Cells["tc"].Value.ToString()+"'", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["müşteri"].Clear();
            Kayıt_Göster();
            MessageBox.Show("Kayıt Silindi !");
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from müşteri where tc like'%"+txtTcAra.Text+"%'",baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
