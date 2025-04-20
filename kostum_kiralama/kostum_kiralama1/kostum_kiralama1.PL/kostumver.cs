using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kostum_kiralama1.Entity;
using kostum_kiralama1.BLL;
using System.Data.OleDb;

namespace kostum_kiralama1.PL
{
    public partial class kostumver : Form
    {
        public kostumver()
        {
            InitializeComponent();
        }

        private void kostumver_Load(object sender, EventArgs e)
        {

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
                    //txtAdi.Clear();
                    //txtSoyadi.Clear();
                    //txtTelno.Clear();
                    //txtAdres.Clear();

                    //txtAdi.Enabled = false;
                    //txtSoyadi.Enabled = false;
                    //txtTelno.Enabled = false;
                    //txtAdres.Enabled = false;

                    //errorProvider2.Clear();
                    //errorProvider3.Clear();
                    //errorProvider4.Clear();
                    //errorProvider6.Clear();

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
                    bll.TxtSearchDuzenleme(Musteri);
                    txtAdi.Text = Musteri.Adi;
                    txtSoyadi.Text = Musteri.Soyadi;
                    txtTelno.Text = Musteri.Telefon;
                    txtAdres.Text = Musteri.Adres;

                    errorProvider5.Clear();



                    if ((txtAdi.Text.Trim() == "") && (txtSoyadi.Text.Trim() == "") && (txtTelno.Text.Trim() == ""))
                    {
                        errorProvider5.Clear();
                        errorProvider8.SetError(txtTcno, "Girdiğniz tc kimlik numarasına ait müşteri yok. ");
                        // ErrorProvider açılacak ve
                        //üstteki satırda belirtilen msj çıkacak



                    }
                    else
                    {
                        errorProvider5.Clear();

                        //txtAdi.Enabled = true;
                        //txtSoyadi.Enabled = true;
                        //txtTelno.Enabled = true;
                        //txtAdres.Enabled = true;
                        errorProvider8.SetError(txtTcno, "");
                    }
                }
                //Ogrenci ogrenci = new Ogrenci();
                //ogrenci.TcNo = txtTcno.Text;
                //OgrenciBLL bll = new OgrenciBLL();
                //bll.TxtSearchDuzenleme(ogrenci);
                //txtAdi.Text = ogrenci.Adi;
                //txtSoyadi.Text = ogrenci.Soyadi;
                //txtTelno.Text = ogrenci.TelefonNo;
                //txtAdres.Text = ogrenci.Adres;
            }

            //private void btnyeni_Click(object sender, EventArgs e)
            //{
            //    txtAdi.Clear();
            //    txtAdres.Clear();
            //    txtbarkod.Clear();
            //    txtkitapadi.Clear();
            //    txtrafno.Clear();
            //    txtsayfasayisi.Clear();
            //    txtSoyadi.Clear();
            //    txtTcno.Clear();
            //    txtTelno.Clear();
            //    txtyazar.Clear();
            //    dtpteslimtarih.CustomFormat = " ";
            //    dtpverilistarih.CustomFormat = " ";
            //}

            //private void btnkaydet_Click(object sender, EventArgs e)
            //{
            //    kostum_ver Kostum_ver = new kostum_ver();
            //Kostum_ver.Tcno = txtTcno.Text;
            //Kostum_ver.Adi = txtAdi.Text;
            //Kostum_ver.Soyadi = txtSoyadi.Text;
            //Kostum_ver.Telefon = txtTelno.Text;
            //Kostum_ver.Adres = txtAdres.Text;
            //Kostum_ver.Barkodno = txtbarkod.Text;
            //Kostum_ver.Kostumadi = txtkitapadi.Text;
            //Kostum_ver.Sahibi = txtyazar.Text;
            
            //Kostum_ver.Rafno = txtrafno.Text;
            //Kostum_ver.Verilistarihi = dtpverilistarih.Value;
            //Kostum_ver.Teslimtarihi = dtpteslimtarih.Value;

            //    kostum_verBLL bll = new kostum_verBLL();
            //    try
            //    {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek                
            //        kostum Kostum = new kostum();
            //        Kostum.Barkodno = txtbarkod.Text;
            //        int sonuc = bll.AddNewItem(Kostum_ver);
            //        if (sonuc == 4)
            //        {
            //            kostumBLL bll2 = new kostumBLL();
            //            bll2.UpdateKostumadetiazalt(Kostum);//kitap öğrenciye verilirse kitap adetini azalt
            //            MessageBox.Show("'" + Kostum_ver.Adi + "' Öğrencimize '" + Kostum_ver.Kostumadi + "' kitabı verilmiştir.", "Başarılı");
            //        }
            //        else if (sonuc == 11)
            //        {
            //            DialogResult Cikis;
            //            Cikis = MessageBox.Show("Şuan kütüphanemizde aradığınız " + Kostum_ver.Kostumadi + " kitabı kalmadı. " + Kostum_ver.Kostumadi + " Kitabını teslim alan öğrencilerin teslim tarihleri sırasına göre listelensin mi?", "Kitap Kalmadı Uyarısı!", MessageBoxButtons.YesNo);
            //            if (Cikis == DialogResult.Yes)
            //            {
            //                kalmayankostumlermusterilistesi aranankostumler = new kalmayankostumlermusterilistesi();
            //                aranankostumler.Show();
            //                aranankostumler.dataGridView1.DataSource = bll.BarkodArama(Kostum_ver);
            //                for (int i = 0; i < aranankostumler.dataGridView1.Rows.Count; i++)
            //                {//Kitabı alanların listesi eger geçikti ise kırmızı eğer 2 güün kaldı ise sarı renlte gözüksün
            //                    TimeSpan zamanfarki = DateTime.Now - Convert.ToDateTime(aranankostumler.dataGridView1.Rows[i].Cells["Teslimtarihi"].Value.ToString());
            //                    double gun = zamanfarki.TotalDays;
            //                    if (gun > 0.0)
            //                    {
            //                        aranankostumler.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            //                    }
            //                    else if ((gun <= 0) && (gun >= -2))//eger teslim tarihine iki gün var ise 
            //                    {
            //                        aranankostumler.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            //                    }
            //                }

            //            }
            //            if (Cikis == DialogResult.No)
            //            {

            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

            private void txtbarkod_TextChanged(object sender, EventArgs e)
            {


                if (txtbarkod.Text.Trim() == "")//eğer TextBox1 boş ise
                {
                    errorProvider2.SetError(txtbarkod, "Bu alan boş geçilemez");

                    txtkitapadi.Clear();
                    txtyazar.Clear();
                   // txtsayfasayisi.Clear();
                    txtrafno.Clear();

                } // ErrorProvider açılacak ve
                  //üstteki satırda belirtilen msj çıkacak
                else
                {
                    kostum Kostum = new kostum();
                Kostum.Barkodno = txtbarkod.Text;
                    kostumBLL bll = new kostumBLL();
                    bll.TxtSearchDuzenleme(Kostum);
                    txtkitapadi.Text = Kostum.Kostumadi;
                    txtyazar.Text = Kostum.Sahibi;
                    
                    txtrafno.Text = Kostum.Rafno;

                    errorProvider2.SetError(txtbarkod, "");

                    if ((txtkitapadi.Text.Trim() == "") && (txtyazar.Text.Trim() == "") &&  (txtrafno.Text.Trim() == ""))
                    {
                        //errorProvider5.Clear();
                        errorProvider8.SetError(txtbarkod, "Güncellemek istediğniz barkod numarasına ait kostüm bulunmamaktadır.Textboxlar aktif olmaz");
                        // ErrorProvider açılacak ve
                        //üstteki satırda belirtilen msj çıkacak
                        //txtkitapadi.Enabled = false;
                        //txtyazar.Enabled = false;
                        //txtsayfasayisi.Enabled = false;
                        //txtrafno.Enabled = false;


                    }
                    else
                    {
                        //errorProvider5.Clear();

                        //txtkitapadi.Enabled = true;
                        //txtyazar.Enabled = true;
                        //txtsayfasayisi.Enabled = true;
                        //txtrafno.Enabled = true;
                        errorProvider8.SetError(txtbarkod, "");
                    }


                }// ErrorProvider kapanacak


            }

            private void kitapver_Load(object sender, EventArgs e)
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

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void txtTcno_KeyPress(object sender, KeyPressEventArgs e)
            {
                //sadece sayi girişi
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

            private void txtbarkod_KeyPress(object sender, KeyPressEventArgs e)
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

            private void txtbarkod_VisibleChanged(object sender, EventArgs e)
            {
                if (txtbarkod.Text.Trim() == "")//eğer TextBox1 boş ise
                {
                    errorProvider2.SetError(txtbarkod, "Bu alan boş geçilemez");
                } // ErrorProvider açılacak ve
                  //üstteki satırda belirtilen msj çıkacak
                else
                {
                    errorProvider2.SetError(txtbarkod, "");
                }// ErrorProvider kapanacak
            }

        private void btnkaydet_Click_1(object sender, EventArgs e)
        {
            kostum_ver Kostum_ver = new kostum_ver();
            Kostum_ver.Tcno = txtTcno.Text;
            Kostum_ver.Adi = txtAdi.Text;
            Kostum_ver.Soyadi = txtSoyadi.Text;
            Kostum_ver.Telefon = txtTelno.Text;
            Kostum_ver.Adres = txtAdres.Text;
            Kostum_ver.Barkodno = txtbarkod.Text;
            Kostum_ver.Kostumadi = txtkitapadi.Text;
            Kostum_ver.Sahibi = txtyazar.Text;

            Kostum_ver.Rafno = txtrafno.Text;
            Kostum_ver.Verilistarihi = dtpverilistarih.Value;
            Kostum_ver.Teslimtarihi = dtpteslimtarih.Value;

            kostum_verBLL bll = new kostum_verBLL();
            try
            {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek                
                kostum Kostum = new kostum();
                Kostum.Barkodno = txtbarkod.Text;
                int sonuc = bll.AddNewItem(Kostum_ver);
                if (sonuc == 4)
                {
                    kostumBLL bll2 = new kostumBLL();
                    bll2.UpdateKostumadetiazalt(Kostum);//kitap öğrenciye verilirse kitap adetini azalt
                    MessageBox.Show("'" + Kostum_ver.Adi + "' Müşterimize '" + Kostum_ver.Kostumadi + "' kostümü verilmiştir.", "Başarılı");
                }
                else if (sonuc == 11)
                {
                    DialogResult Cikis;
                    Cikis = MessageBox.Show("Şuan mağazamızda aradığınız " + Kostum_ver.Kostumadi + " kostüm kalmadı. " + Kostum_ver.Kostumadi + " Kostümü teslim alan müşterilerin teslim tarihleri sırasına göre listelensin mi?", "Kostüm Kalmadı Uyarısı!", MessageBoxButtons.YesNo);
                    if (Cikis == DialogResult.Yes)
                    {
                       // kalmayankostumlermusterilistesi aranankostumler = new kalmayankostumlermusterilistesi();
                      //  aranankostumler.Show();
                       // aranankostumler.dataGridView1.DataSource = bll.BarkodArama(Kostum_ver);
                     //   for (int i = 0; i < aranankostumler.dataGridView1.Rows.Count; i++)
                        {//Kitabı alanların listesi eger geçikti ise kırmızı eğer 2 güün kaldı ise sarı renlte gözüksün
                       //     TimeSpan zamanfarki = DateTime.Now - Convert.ToDateTime(aranankostumler.dataGridView1.Rows[i].Cells["Teslimtarihi"].Value.ToString());
                        //    double gun = zamanfarki.TotalDays;
                        //    if (gun > 0.0)
                            {
                        //        aranankostumler.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                         //   }
                         //   else if ((gun <= 0) && (gun >= -2))//eger teslim tarihine iki gün var ise 
                         //   {
                        //        aranankostumler.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                        }

                    }
                    if (Cikis == DialogResult.No)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnyeni_Click_1(object sender, EventArgs e)
        {
            txtAdi.Clear();
            txtAdres.Clear();
            txtbarkod.Clear();
            txtkitapadi.Clear();
            txtrafno.Clear();
          //  txtsayfasayisi.Clear();
            txtSoyadi.Clear();
            txtTcno.Clear();
            txtTelno.Clear();
            txtyazar.Clear();
            dtpteslimtarih.CustomFormat = " ";
            dtpverilistarih.CustomFormat = " ";
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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
    }



