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
    public partial class kostumiade : Form
    {
        public kostumiade()
        {
            InitializeComponent();
        }

        private void kostumiade_Load(object sender, EventArgs e)
        {

        }

        //private void btniade_Click(object sender, EventArgs e)
        //{
        //    kostum_ver kostumver2 = new kostum_ver();
        //    kostumver2.Barkodno = txtbarkodver.Text;
        //    kostumver2.Tcno = txtTcno.Text;
        //    kostum_verBLL bll5 = new kostum_verBLL();
        //    bll5.TxtSearchDuzenleme(kostumver2);
        //    kostum_iade kostumiade = new kostum_iade();
        //    kostumiade.Tcno = txtTcno.Text;
        //    kostumiade.Adi = txtAdi.Text;
        //    kostumiade.Soyadi = txtSoyadi.Text;
        //    kostumiade.Telefon = txtTelno.Text;
        //    kostumiade.Adres = txtAdres.Text;
        //    kostumiade.Barkodno = txtbarkodver.Text;
        //    kostumiade.Kostumadi = txtkitapadi.Text;
        //    kostumiade.Sahibi = txtyazar.Text;

        //    kostumiade.Rafno = txtrafno.Text;
        //    kostumiade.Verilistarihi = kostumver2.Verilistarihi;
        //    kostumiade.Iadetarihi = dtpteslimtarih.Value;
        //    kostumiade kostum_vers = new kostumiade();
        //    //önce textboxları değişkenlere atıyorum herhangi bir değişiklik yaptığımda kolay olsun 
        //    kostumver2.Tcno = txtTcno.Text;
        //    kostumver2.Barkodno = txtbarkodver.Text;
        //    kostum_iadeBLL bll2 = new kostum_iadeBLL();
        //    try
        //    {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
        //        bll2.AddNewItem(kostumiade);//kitap iade tablosuna öğrencinin bilgileri kitap bilgileri teslim edilen tarhi girilir.
        //        MessageBox.Show("Teslim işlemi gerçekleşti.", "Başarılı");
        //        kostum_verBLL bllkitapver = new kostum_verBLL();
        //        kostum Kostum = new kostum();
        //        Kostum.Barkodno = txtbarkodver.Text;
        //        kostumBLL bll3 = new kostumBLL();
        //        bll3.UpdateKostumadetiarttir(Kostum);//kitabı geri teslim ettiyse Kitabın Adeti artar
        //        bllkitapver.DeleteItem(kostumver2);//Kitabı teslim ettiği için kitapver tablosunda silinir.
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btntemizle_Click(object sender, EventArgs e)
        //{
        //    txtAdi.Clear();
        //    txtAdres.Clear();
        //    txtbarkodver.Clear();
        //    txtkitapadi.Clear();
        //    txtrafno.Clear();
        //    txtsayfasayisi.Clear();
        //    txtSoyadi.Clear();
        //    txtTcno.Clear();
        //    txtTelno.Clear();
        //    txtyazar.Clear();
        //    dtpteslimtarih.CustomFormat = " ";
        //}

        private void txtbarkod_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTcno_TextChanged_1(object sender, EventArgs e)
        {
            if (txtTcno.Text.Trim() == "")//eğer txtTcno boş ise
            {
                errorProvider1.SetError(txtTcno, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider1.SetError(txtTcno, "");
            }// ErrorProvider kapanacak
            if ((txtTcno.Text.Length < 11) || (txtTcno.Text.Length > 11))
            {
                errorProvider5.SetError(txtTcno, "TC Kimlik numarısı 11 karakterli olmalıdır.");
                errorProvider8.SetError(txtTcno, "");
                txtAdi.Clear();
                txtSoyadi.Clear();
                txtTelno.Clear();
                txtAdres.Clear();
            }
            else
            {
                musteri Musteri = new musteri();
                Musteri.Tcno = txtTcno.Text;
                musteriBLL bll = new musteriBLL();
                bll.TxtSearchDuzenleme(Musteri);//eğer girilen tc 11 haneli ise bilgileri getir
                txtAdi.Text = Musteri.Adi;
                txtSoyadi.Text = Musteri.Soyadi;
                txtTelno.Text = Musteri.Telefon;
                txtAdres.Text = Musteri.Adres;
                errorProvider5.Clear();
                if ((txtAdi.Text.Trim() == "") && (txtSoyadi.Text.Trim() == "") && (txtTelno.Text.Trim() == ""))
                {
                    errorProvider5.Clear();
                    errorProvider8.SetError(txtTcno, "Girdiğniz tc kimlik numarasına ait öğrenci yok. ");
                    // ErrorProvider açılacak ve
                    //üstteki satırda belirtilen msj çıkacak
                }
                else
                {
                    errorProvider5.Clear();
                    errorProvider8.SetError(txtTcno, "");
                }
            }
        }

        private void txtbarkod_TextChanged_1(object sender, EventArgs e)
        {
            if (txtbarkodver.Text.Trim() == "")//eğer txtbarkodver boş ise
            {
                errorProvider2.SetError(txtbarkodver, "Bu alan boş geçilemez");
                txtkitapadi.Clear();
                txtyazar.Clear();
              //  txtsayfasayisi.Clear();
                txtrafno.Clear();
            }
            else
            {
                kostum_ver Kostum_ver = new kostum_ver();
                Kostum_ver.Barkodno = txtbarkodver.Text;
                Kostum_ver.Tcno = txtTcno.Text;
                kostum_verBLL bll = new kostum_verBLL();
                bll.TxtSearchDuzenleme(Kostum_ver);//eğer öğrenci bu kitabı aldıysa bu kitabın bilgilerini getir
                txtkitapadi.Text = Kostum_ver.Kostumadi;
                txtyazar.Text = Kostum_ver.Sahibi;
                
                txtrafno.Text = Kostum_ver.Rafno;

                errorProvider2.SetError(txtbarkodver, "");

                if ((txtkitapadi.Text.Trim() == "") && (txtyazar.Text.Trim() == "")  && (txtrafno.Text.Trim() == ""))
                {
                    errorProvider8.SetError(txtbarkodver, "Müşteri girdiğniz barkod numaralı kostümü almamıştır.Geri teslim işlemi gerçekleştiremez.");
                }
                else
                {
                    errorProvider8.SetError(txtbarkodver, "");
                }
            }
        }

        private void txtTcno_KeyPress(object sender, KeyPressEventArgs e)
        {//sadece sayi girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtbarkodver_KeyPress(object sender, KeyPressEventArgs e)
        {//sadece sayi girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTcno_VisibleChanged(object sender, EventArgs e)
        {
            if (txtTcno.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider1.SetError(txtTcno, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider1.SetError(txtTcno, "");
            }// ErrorProvider kapanacak
        }

        private void txtbarkodver_VisibleChanged(object sender, EventArgs e)
        {
            if (txtbarkodver.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider2.SetError(txtbarkodver, "Bu alan boş geçilemez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider2.SetError(txtbarkodver, "");
            }// ErrorProvider kapanacak
        }

        private void kitapiade_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 100);//Form ekranın açılınca yernini belirleme Point(x,y)
            errorProvider1.BlinkRate = 100000;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider2.BlinkRate = 100000;
            errorProvider2.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider3.BlinkRate = 100000;
            errorProvider3.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider4.BlinkRate = 1000000;
            errorProvider4.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider5.BlinkRate = 400;
            errorProvider5.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

            errorProvider8.BlinkRate = 400;
            errorProvider8.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
        }

        private void btniade_Click_1(object sender, EventArgs e)
        {

            kostum_ver kostumver2 = new kostum_ver();
            kostumver2.Barkodno = txtbarkodver.Text;
            kostumver2.Tcno = txtTcno.Text;
            kostum_verBLL bll5 = new kostum_verBLL();
            bll5.TxtSearchDuzenleme(kostumver2);
            kostum_iade kostumiade = new kostum_iade();
            kostumiade.Tcno = txtTcno.Text;
            kostumiade.Adi = txtAdi.Text;
            kostumiade.Soyadi = txtSoyadi.Text;
            kostumiade.Telefon = txtTelno.Text;
            kostumiade.Adres = txtAdres.Text;
            kostumiade.Barkodno = txtbarkodver.Text;
            kostumiade.Kostumadi = txtkitapadi.Text;
            kostumiade.Sahibi = txtyazar.Text;

            kostumiade.Rafno = txtrafno.Text;
            kostumiade.Verilistarihi = kostumver2.Verilistarihi;
            kostumiade.Iadetarihi = dtpteslimtarih.Value;
            kostumiade kostum_vers = new kostumiade();
            //önce textboxları değişkenlere atıyorum herhangi bir değişiklik yaptığımda kolay olsun 
            kostumver2.Tcno = txtTcno.Text;
            kostumver2.Barkodno = txtbarkodver.Text;
            kostum_iadeBLL bll2 = new kostum_iadeBLL();
            try
            {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
                bll2.AddNewItem(kostumiade);//kitap iade tablosuna öğrencinin bilgileri kitap bilgileri teslim edilen tarhi girilir.
                MessageBox.Show("Teslim işlemi gerçekleşti.", "Başarılı");
                kostum_verBLL bllkitapver = new kostum_verBLL();
                kostum Kostum = new kostum();
                Kostum.Barkodno = txtbarkodver.Text;
                kostumBLL bll3 = new kostumBLL();
                bll3.UpdateKostumadetiarttir(Kostum);//kitabı geri teslim ettiyse Kitabın Adeti artar
                bllkitapver.DeleteItem(kostumver2);//Kitabı teslim ettiği için kitapver tablosunda silinir.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntemizle_Click_1(object sender, EventArgs e)
        {
            txtAdi.Clear();
            txtAdres.Clear();
            txtbarkodver.Clear();
            txtkitapadi.Clear();
            txtrafno.Clear();
            //txtsayfasayisi.Clear();
            txtSoyadi.Clear();
            txtTcno.Clear();
            txtTelno.Clear();
            txtyazar.Clear();
            dtpteslimtarih.CustomFormat = " ";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    

