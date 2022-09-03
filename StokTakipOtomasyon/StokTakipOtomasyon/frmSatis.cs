using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipOtomasyon
{
    public partial class frmSatis : Form
    {
        public frmSatis()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmMüşteriEkle ekle = new frmMüşteriEkle();
            ekle.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmMüşteriListele listele = new frmMüşteriListele();
            listele.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
