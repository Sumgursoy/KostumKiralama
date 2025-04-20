using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kostum_kiralama1.BLL;
using kostum_kiralama1.Entity;



namespace kostum_kiralama1.PL
{
    public partial class musteriekle : Form
    {
        private musteriBLL Musteribll;
        public musteriekle()
        {
            InitializeComponent();
            Musteribll=new musteriBLL();
        }

        private void musteriekle_Load(object sender, EventArgs e)
        {

        }
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\sumgu\OneDrive\Masaüstü\kostum_kiralama1\kostum_kiralama.accdb;";
        //private void btnkaydet_Click(object sender, EventArgs e)
        //{
        //    musteri  Musteri = new musteri();
        //    Musteri.TcNo = txtTcno.Text;
        //    Musteri.Adi = txtAdi.Text;
        //    Musteri.Soyadi = txtSoyadi.Text;
        //    Musteri.Telefon = txtTelno.Text;
        //    Musteri.Adres = txtAdres.Text;

        //    musteriBLL bll = new musteriBLL();
        //    try
        //    {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
        //        int ekleme;
        //        ekleme = bll.AddNewItem(Musteri);
        //        if (ekleme == 1)
        //        {
        //            MessageBox.Show("Öğrenci başarıyla kaydedildi.", "Başarılı kayıt");
        //        }
        //    }
        //    catch (OleDbException ex)
        //    {
        //        if (ex.ErrorCode == -2147467259)
        //        {
        //            MessageBox.Show("Girmiş olduğunuz Tc kimlik numaralı öğrenci zaten kayıtlıdır!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btntemizle_Click(object sender, EventArgs e)
        //{
        //    txtTcno.Clear();
        //    txtAdi.Clear();
        //    txtSoyadi.Clear();
        //    txtTelno.Clear();
        //    txtAdres.Clear();
        //}

        private void txtTcno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sadece sayi girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTelno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sadece sayi girişi
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

        private void ogrenciekle_Load(object sender, EventArgs e)
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

            errorProvider5.BlinkRate = 400;
            errorProvider5.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

            errorProvider6.BlinkRate = 400;
            errorProvider6.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
        }

        private void txtAdi_VisibleChanged(object sender, EventArgs e)
        {
            if (txtAdi.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider2.SetError(txtAdi, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider2.SetError(txtAdi, "");
            }// ErrorProvider kapanacak
        }

        private void txtSoyadi_VisibleChanged(object sender, EventArgs e)
        {
            if (txtSoyadi.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider3.SetError(txtSoyadi, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider3.SetError(txtSoyadi, "");
            }// ErrorProvider kapanacak
        }

        private void txtTelno_VisibleChanged(object sender, EventArgs e)
        {
            if (txtTelno.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider4.SetError(txtTelno, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider4.SetError(txtTelno, "");
            }// ErrorProvider kapanacak
        }

        private void txtAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtAdi.Text.Trim() == "")
            {
                errorProvider2.SetError(txtAdi, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider2.SetError(txtAdi, "");
            }
        }

        private void txtTcno_TextChanged(object sender, EventArgs e)
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
            if ((txtTcno.Text.Length < 11) || (txtTcno.Text.Length > 11))
            {
                errorProvider5.SetError(txtTcno, "TC Kimlik numarısı 11 karakterli olmalıdır.");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void txtSoyadi_TextChanged(object sender, EventArgs e)
        {
            if (txtSoyadi.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider3.SetError(txtSoyadi, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider3.SetError(txtSoyadi, "");
            }// ErrorProvider kapanacak
        }

        private void txtTelno_TextChanged(object sender, EventArgs e)
        {

            if (txtTelno.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider4.SetError(txtTelno, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider4.SetError(txtTelno, "");
            }// ErrorProvider kapanacak
            if ((txtTelno.Text.Length < 10) || (txtTelno.Text.Length > 10))
            {
                errorProvider6.SetError(txtTelno, "Telefon numarısı 10 haneli olmalıdır. Örneğin : (5340829924)");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void btnkaydet_Click_1(object sender, EventArgs e)
        //{
        //    musteri Musteri = new musteri();
        //    Musteri.TcNo = txtTcno.Text;
        //    Musteri.Adi = txtAdi.Text;
        //    Musteri.Soyadi = txtSoyadi.Text;
        //    Musteri.Telefon = txtTelno.Text;
        // //   Musteri.Adres = txtAdres.Text;

        //    musteriBLL bll = new musteriBLL();
        //    try
        //    {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
        //        int ekleme;
        //        ekleme = bll.AddNewItem(Musteri);
        //        if (ekleme == 1)
        //        {
        //            MessageBox.Show("Müşteri başarıyla kaydedildi.", "Başarılı kayıt");
        //        }
        //    }
        //    catch (OleDbException ex)
        //    {
        //        if (ex.ErrorCode == -2147467259)
        //        {
        //            MessageBox.Show("Girmiş olduğunuz Tc kimlik numaralı müşteri zaten kayıtlıdır!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void btntemizle_Click_1(object sender, EventArgs e)
        {
            txtTcno.Clear();
            txtAdi.Clear();
            txtSoyadi.Clear();
            txtTelno.Clear();
           // txtAdres.Clear();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            musteri Musteri = new musteri();
            Musteri.Tcno = txtTcno.Text;
            Musteri.Adi = txtAdi.Text;
            Musteri.Soyadi = txtSoyadi.Text;
            Musteri.Telefon = txtTelno.Text;
            //   Musteri.Adres = txtAdres.Text;

            musteriBLL bll = new musteriBLL();
            try
            {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
                int ekleme;
                ekleme = bll.AddNewItem(Musteri);
                if (ekleme == 1)
                {
                    MessageBox.Show("Müşteri başarıyla kaydedildi.", "Başarılı kayıt");
                }
            }
            //catch (OleDbException ex)
            //{
            //    if (ex.ErrorCode == -2147467259)
            //    {
            //        MessageBox.Show("Girmiş olduğunuz Tc kimlik numaralı müşteri zaten kayıtlıdır!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Entity sınıfına kullanıcıdan gelen verileri atama
                musteri yeniUye = new musteri
                {
                    Tcno = txtTcno.Text,
                    Adi = txtAdi.Text,
                    Soyadi = txtSoyadi.Text,
                    Telefon = txtTelno.Text,
                    Mail=txt_Mail.Text
                };

                // Üye ekleme işlemi
                bool eklendiMi = Musteribll.UyeEkle(yeniUye);

                if (eklendiMi)
                {
                    MessageBox.Show("Üye başarıyla eklendi.");

                    // E-posta gönderim işlemi
                    try
                    {
                        string subject = "Kostüm Kiralama Üyelik Bilgileriniz";
                        string body = $"Merhaba {yeniUye.Adi} {yeniUye.Soyadi},\n\n" +
                                      //$"TC Kimlik Numaranız: {yeniUye.Tcno}\n" +
                                      //$"Telefon Numaranız: {yeniUye.Telefon}\n\n" +
                                      $"Kostümcü81'e katıldığınız için teşekkür ederiz!";

                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("yldrmoykuuu@gmail.com"); // Gönderen adres
                        mail.To.Add(txt_Mail.Text); // Kullanıcının mail adresi
                        mail.Subject = subject;
                        mail.Body = body;

                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // SMTP sunucusu
                        smtpClient.Port = 587; // Genelde kullanılan SMTP portu
                        smtpClient.Credentials = new NetworkCredential("kostumcu81@gmail.com", "upmi wbjj bhna nsbs"); // Giriş bilgileri
                        smtpClient.EnableSsl = true; // Güvenli bağlantı için SSL aktif

                        smtpClient.Send(mail); // E-posta gönderimi
                        MessageBox.Show("Üyeye e-posta gönderildi.");
                    }
                    catch (Exception emailEx)
                    {
                        MessageBox.Show("E-posta gönderilirken bir hata oluştu: " + emailEx.Message);
                    }

                    // Formu temizle
                    txtTcno.Clear();
                    txtAdi.Clear();
                    txtSoyadi.Clear();
                    txtTelno.Clear();
                    txt_Mail.Clear();
                }
                else
                {
                    MessageBox.Show("Üye eklenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
