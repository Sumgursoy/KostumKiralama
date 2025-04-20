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
    public partial class musterisilme : Form
    {
        public musterisilme()
        {
            InitializeComponent();
        }

        private void musterisilme_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((txtsilme.Text.Length < 11) || (txtsilme.Text.Length > 11))
            {
                errorProvider1.SetError(txtsilme, "TC Kimlik numarısı 11 karakterli olmalıdır.");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void txtsilme_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sadece sayi girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ogrencisilme_Load(object sender, EventArgs e)
        {
            this.Location = new Point(60, 160);//Form ekranın açılınca yernini belirleme Point(x,y)
        }

        private void btnsil_Click_1(object sender, EventArgs e)
        {
            musteri Musteri = new musteri();
            Musteri.    Tcno = txtsilme.Text;
            musteriBLL bll = new musteriBLL();


            try
            {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
                int sayi;
                sayi = bll.DeleteItem(Musteri);
                if (sayi == 1)
                {
                    MessageBox.Show(Musteri.Tcno + " TC kimlik numaralı müşteri silinmiştir.", "Silme işlemi gerçekleşti", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

