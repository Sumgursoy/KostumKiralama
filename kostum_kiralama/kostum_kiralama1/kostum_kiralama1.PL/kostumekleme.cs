using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kostum_kiralama1.BLL;
using kostum_kiralama1.Entity;

namespace kostum_kiralama1.PL
{
    public partial class kostumekleme : Form
    {
        public kostumekleme()
        {
            InitializeComponent();
        }

        private void kostumekleme_Load(object sender, EventArgs e)
        {

        }
        //private void btnkaydet_Click(object sender, EventArgs e)
        //{
        //    kostum Kostum = new kostum();
        //    Kostum.Barkodno = txtbarkod.Text;
        //    Kostum.Kostumadi = txtkitapadi.Text;
        //    Kostum.Sahibi = txtyazar.Text;
           
        //    Kostum.Rafno = txtrafno.Text;
        //    try
        //    {
        //        Kostum.Adet = Convert.ToInt16(txtkitapadeti.Text);
        //    }
        //    catch (FormatException hata)
        //    {

        //        MessageBox.Show("Lütfen Kitap adeti alanını boş bırakmayınız.Sayısal değer giriniz.", "FormatException HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    kostumBLL bll = new kostumBLL();
        //    try
        //    {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
        //        int ekleme;
        //        ekleme = bll.AddNewItem(Kostum);
        //        if (ekleme == 1)
        //        {
        //            MessageBox.Show("Kitap kaydı başarılya oluşturuldu.", "Başarılı Kayıt");
        //        }
        //    }
        //    catch (OleDbException ex)
        //    {
        //        if (ex.ErrorCode == -2147467259)
        //        {
        //            MessageBox.Show("Girmiş olduğunuz barkod numarası kullanılmaktadır.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btntemizle_Click(object sender, EventArgs e)
        //{
        //    txtbarkod.Clear();
        //    txtkitapadi.Clear();
        //    txtrafno.Clear();
        //    txtsayfasayisi.Clear();
        //    txtyazar.Clear();
        //    txtkitapadeti.Clear();
        //}

        private void txtbarkod_KeyPress(object sender, KeyPressEventArgs e)
        {//sadece sayi girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtsayfasayisi_KeyPress(object sender, KeyPressEventArgs e)
        {//sadece sayi girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtkitapadeti_KeyPress(object sender, KeyPressEventArgs e)
        {//sadece sayı girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtrafno_KeyPress(object sender, KeyPressEventArgs e)
        {//sadece sayi girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtkitapadi_VisibleChanged(object sender, EventArgs e)
        {
            if (txtkitapadi.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider2.SetError(txtkitapadi, "Bu alan boş geçilemez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider2.SetError(txtkitapadi, "");
            }// ErrorProvider kapanacak
        }

        private void txtbarkod_VisibleChanged(object sender, EventArgs e)
        {
            if (txtbarkod.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider1.SetError(txtbarkod, "Bu alan boş geçilemez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider1.SetError(txtbarkod, "");
            }// ErrorProvider kapanacak
        }

        private void txtyazar_VisibleChanged(object sender, EventArgs e)
        {
            if (txtyazar.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider3.SetError(txtyazar, "Bu alan boş geçilemez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider3.SetError(txtyazar, "");
            }// ErrorProvider kapanacak
        }


        private void txtrafno_VisibleChanged(object sender, EventArgs e)
        {
            if (txtrafno.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider5.SetError(txtrafno, "Bu alan boş geçilemez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider5.SetError(txtrafno, "");
            }// ErrorProvider kapanacak
        }

        private void txtkitapadeti_VisibleChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtkitapadeti.Text) <= 0)//eğer TextBox1 boş ise
            {
                errorProvider8.SetError(txtkitapadeti, "Kostüm adeti 0'dan büyük olmak zorunda.");
            }// ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider8.Clear();
            }// ErrorProvider kapanacak
        }

        private void kitapekleme_Load(object sender, EventArgs e)
        {
            this.Location = new Point(400, 100);//Form ekranın açılınca yernini belirleme Point(x,y)
            errorProvider1.BlinkRate = 100000;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider2.BlinkRate = 100000;
            errorProvider2.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider3.BlinkRate = 100000;
            errorProvider3.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider4.BlinkRate = 1000000;
            errorProvider4.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider5.BlinkRate = 1000000;
            errorProvider5.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider6.BlinkRate = 400;
            errorProvider6.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
        }

        private void txtbarkod_TextChanged(object sender, EventArgs e)
        {
            if (txtbarkod.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider1.SetError(txtbarkod, "Bu alan boş geçilemez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider1.SetError(txtbarkod, "");
            }// ErrorProvider kapanacak
        }

        private void txtkitapadi_TextChanged(object sender, EventArgs e)
        {
            if (txtkitapadi.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider2.SetError(txtkitapadi, "Bu alan boş geçilemez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider2.SetError(txtkitapadi, "");
            }// ErrorProvider kapanacak
        }

        private void txtyazar_TextChanged(object sender, EventArgs e)
        {
            if (txtyazar.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider3.SetError(txtyazar, "Bu alan boş geçilemez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider3.SetError(txtyazar, "");
            }// ErrorProvider kapanacak
        }

        

        private void txtrafno_TextChanged(object sender, EventArgs e)
        {
            if (txtrafno.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider5.SetError(txtrafno, "Bu alan boş geçilemez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider5.SetError(txtrafno, "");
            }// ErrorProvider kapanacak
        }

        private void txtkitapadeti_TextChanged(object sender, EventArgs e)
        {
            if (txtkitapadeti.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider6.SetError(txtkitapadeti, "Bu alan boş geçilemez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider6.SetError(txtkitapadeti, "");
            }// ErrorProvider kapanacak
            if (txtkitapadeti.Text == "0" || txtkitapadeti.Text == "")
            {
                errorProvider8.SetError(txtkitapadeti, "Kostüm adeti 0'dan büyük olmak zorunda.");
            }
            //else if (Convert.ToInt32(txtkitapadeti.Text) <= 0)//eğer TextBox1 boş ise
            //{

            //}// ErrorProvider açılacak ve
            ////üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider8.SetError(txtkitapadeti, "");
            }// ErrorProvider kapanacak
        }

        private void btnkaydet_Click_1(object sender, EventArgs e)
        {
            kostum Kostum = new kostum();
            Kostum.Barkodno = txtbarkod.Text;
            Kostum.Kostumadi = txtkitapadi.Text;
            Kostum.Sahibi = txtyazar.Text;
            // Kostum.Adet = Convert.ToInt16(txtkitapadeti.Text); 
            Kostum.Rafno = txtrafno.Text;
            try
            {
                Kostum.Adet = Convert.ToInt16(txtkitapadeti.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Kostüm adeti alanını boş bırakmayınız.Sayısal değer giriniz.", "FormatException HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            kostumBLL bll = new kostumBLL();
            try
            {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
                int ekleme;
                ekleme = bll.AddNewItem(Kostum);
                if (ekleme == 1)
                {
                    MessageBox.Show("Kostüm kaydı başarılya oluşturuldu.", "Başarılı Kayıt");
                }
            }
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("Girmiş olduğunuz barkod numarası kullanılmaktadır.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
            //int adet;
            //if (!int.TryParse(txtkitapadeti.Text, out adet) || adet <= 0)
            //{
            //    MessageBox.Show("Lütfen geçerli bir kostüm adedi giriniz. Sayısal bir değer olmalıdır.",
            //                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //Kostum.Adet = adet;

            //Kostum.Rafno = txtrafno.Text;

            //try
            //{
            //    kostumBLL bll = new kostumBLL();
            //    int ekleme = bll.AddNewItem(Kostum);

            //    if (ekleme != 0)
            //    {
            //        MessageBox.Show("Kayıt başarıyla oluşturuldu.", "Başarılı Kayıt");
            //    }
            //}
            //catch (OleDbException ex)
            //{
            //    if (ex.ErrorCode == -2147467259) // Hata kodu kontrolü
            //    {
            //        MessageBox.Show("Girmiş olduğunuz barkod numarası zaten kullanılıyor.",
            //                        "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        MessageBox.Show($"Veritabanı hatası: {ex.Message}", "HATA",
            //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "HATA",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}









        }


        private void btntemizle_Click_1(object sender, EventArgs e)
        {
            txtbarkod.Clear();
            txtkitapadi.Clear();
            txtrafno.Clear();
            
            txtyazar.Clear();
           txtkitapadeti.Clear();
        }

        private void txtbarkod_TextChanged_1(object sender, EventArgs e)
        {

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


