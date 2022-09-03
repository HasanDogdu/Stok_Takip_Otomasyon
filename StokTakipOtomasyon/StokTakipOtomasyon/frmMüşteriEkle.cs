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
    public partial class frmMüşteriEkle : Form
    {
        public frmMüşteriEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-AT2VJJI;Initial Catalog=Stok_Takip;Integrated Security=True");
        private void frmMüşteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into müşteri(tc,adsoyad,telefon,adres,email) values(@tc,@adsoyad,@telefon,@adres,@email)", baglanti);
            cmd.Parameters.AddWithValue("@tc", txtTc.Text);
            cmd.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            cmd.Parameters.AddWithValue("@adres",txtAdres.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri kaydı eklendi !");
            txtTc.Clear();
            txtAdSoyad.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            txtEmail.Clear();
        }
    }
}
