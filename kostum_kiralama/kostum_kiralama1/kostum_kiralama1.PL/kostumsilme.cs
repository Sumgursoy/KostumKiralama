using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kostum_kiralama1.BLL;
using kostum_kiralama1.Entity;

namespace kostum_kiralama1.PL
{
    public partial class kostumsilme : Form
    {
        public kostumsilme()
        {
            InitializeComponent();
        }

        private void kostumsilme_Load(object sender, EventArgs e)
        {

        }
       

        private void txtbarkodno_KeyPress(object sender, KeyPressEventArgs e)
        {            //sadece sayi girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kitapsilme_Load(object sender, EventArgs e)
        {
            this.Location = new Point(100, 200);//Form ekranın açılınca yernini belirleme Point(x,y)
        }

        private void btnsilme_Click_1(object sender, EventArgs e)
        {

            kostum Kostum = new kostum();
            Kostum.Barkodno = txtbarkodno.Text;
            kostumBLL bll = new kostumBLL();
            try
            {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
                bll.DeleteItem(Kostum);
                MessageBox.Show("Mağazadan (" + Kostum.Barkodno + ") barkod numaralı kostüm silinmiştir.", "Silme işlemi başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 gecis = new Form1();
            gecis.Show();
            this.Hide();
        }
    }
}
