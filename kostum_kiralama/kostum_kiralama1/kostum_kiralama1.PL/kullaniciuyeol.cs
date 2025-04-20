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
using System.Data.OleDb;
using Tulpep.NotificationWindow;

namespace kostum_kiralama1.PL
{
    public partial class kullaniciuyeol : Form
    {
        public kullaniciuyeol()
        {
            InitializeComponent();
        }
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\sumgu\OneDrive\Masaüstü\kostum_kiralama1\kostum_kiralama.accdb;";

        //  private void kullaniciuyeol_Load(object sender, EventArgs e)
        //  {

        // }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    kullanici_girisi Kullanicigirisi = new kullanici_girisi();
        //    //önce textboxları değişkenlere atıyorum herhangi bir değişiklik yaptığımda kolay olsun 
        //    //tablodaki değişkenlerle aynı olacak dikkat et
        //    Kullanicigirisi.Kullaniciadi = txtKullaniciadi.Text;
        //    Kullanicigirisi.Sifre = txtSifre.Text;
        //    Kullanicigirisi.Adi = txtAdi.Text;
        //    Kullanicigirisi.Soyadi = txtsoyadi.Text;

        //    kullanici_girisiBLL bll = new kullanici_girisiBLL();
        //    try
        //    {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
        //        string kullaniciadisoyadi = bll.AddNewItem(Kullanicigirisi);
        //        if (kullaniciadisoyadi != "")
        //        {
        //            MessageBox.Show("Kaydınız başarılya oluşturuldu.", "ÜYE KAYIT");
        //            PopupNotifier popup = new PopupNotifier();
        //          ///  popup.Image = Properties.Resources.userana;
        //            popup.ImagePadding = new Padding(5);
        //            popup.TitleText = "yeni üye kaydı.".ToUpper().PadLeft(1);
        //            popup.TitleColor = Color.Green;//başlık yazı rengi


        //            popup.HeaderHeight = 025;
        //            popup.HeaderColor = Color.Green;//başlık  rengi
        //            popup.ContentHoverColor = Color.Yellow;//
        //            popup.TitleFont = new Font("Segoe Script", 12, FontStyle.Bold);// Font("Yazı tipi",boyutu,şekli); 
        //            popup.ContentFont = new Font("Cooper Black", 14, FontStyle.Regular);// Font("Yazı tipi",boyutu,şekli); 

        //            popup.ContentText = kullaniciadisoyadi.PadLeft(1);
        //            popup.BorderColor = Color.Yellow;//mesajın dış çepesi çercevesi
        //            popup.BodyColor = Color.Black;//mesajın içi
        //            popup.ContentColor = Color.Green;//text yazı rengi

        //            popup.ContentHoverColor = Color.Black;
        //            popup.TitlePadding = new Padding(3, 12, 5, 3);//sol , yukarı, aşağı sağ
        //            popup.ContentPadding = new Padding(5, 0, 0, 0);
        //            //  popup.BodyColor = Color.Red;
        //            popup.Popup();
        //            Form kullanicigiriisi = new Kullanicigirisi();
        //            kullanicigiriisi.Show();
        //            this.Hide();
        //        }
        //    }
        //    catch (OleDbException ex)
        //    {
        //        if (ex.ErrorCode == -2147467259)
        //        {
        //            MessageBox.Show("Girmiş olduğunuz kullanıcı adı kullanılmaktadır.", "DİKKAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{// Çıkış butonuna tıklanırsa uye ol formunu kapatıyorum kullanıcıgiriş formunu açıyorum.
        //    this.Close();
        //    Kullanicigirisi kitapg = new Kullanicigirisi();
        //    kitapg.Show();
        //}

        private void label5_Click(object sender, EventArgs e)
        {
            Form kullanicigirisekrani = new Kullanicigirisi();
            kullanicigirisekrani.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form kullanicigirisekrani = new Kullanicigirisi();
            kullanicigirisekrani.Show();
            this.Hide();
        }

        private void kullaniciuyeol_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtKullaniciadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //boşluk girişini engeller
            e.Handled = Char.IsWhiteSpace(e.KeyChar);
        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //boşluk girişini engeller
            e.Handled = Char.IsWhiteSpace(e.KeyChar);
        }

        private void kullaniciuyeol_Load(object sender, EventArgs e)
        {
            this.Location = new Point(260, 150);//Form ekranın açılınca yernini belirleme Point(x,y)
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Kullanicigirisi kitapg = new Kullanicigirisi();
            kitapg.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            kullanici_girisi Kullanicigirisi = new kullanici_girisi();
            //önce textboxları değişkenlere atıyorum herhangi bir değişiklik yaptığımda kolay olsun 
            //tablodaki değişkenlerle aynı olacak dikkat et
            Kullanicigirisi.Kullaniciadi = txtKullaniciadi.Text;
            Kullanicigirisi.Sifre = txtSifre.Text;
            Kullanicigirisi.Adi = txtAdi.Text;
            Kullanicigirisi.Soyadi = txtsoyadi.Text;

            kullanici_girisiBLL bll = new kullanici_girisiBLL();
            try
            {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
                string kullaniciadisoyadi = bll.AddNewItem(Kullanicigirisi);
                if (kullaniciadisoyadi != "")
                {
                    MessageBox.Show("Kaydınız başarılya oluşturuldu.", "ÜYE KAYIT");
                    PopupNotifier popup = new PopupNotifier();
                    ///  popup.Image = Properties.Resources.userana;
                    popup.ImagePadding = new Padding(5);
                    popup.TitleText = "yeni üye kaydı.".ToUpper().PadLeft(1);
                    popup.TitleColor = Color.Green;//başlık yazı rengi


                    popup.HeaderHeight = 025;
                    popup.HeaderColor = Color.Green;//başlık  rengi
                    popup.ContentHoverColor = Color.Yellow;//
                    popup.TitleFont = new Font("Segoe Script", 12, FontStyle.Bold);// Font("Yazı tipi",boyutu,şekli); 
                    popup.ContentFont = new Font("Cooper Black", 14, FontStyle.Regular);// Font("Yazı tipi",boyutu,şekli); 

                    popup.ContentText = kullaniciadisoyadi.PadLeft(1);
                    popup.BorderColor = Color.Yellow;//mesajın dış çepesi çercevesi
                    popup.BodyColor = Color.Black;//mesajın içi
                    popup.ContentColor = Color.Green;//text yazı rengi

                    popup.ContentHoverColor = Color.Black;
                    popup.TitlePadding = new Padding(3, 12, 5, 3);//sol , yukarı, aşağı sağ
                    popup.ContentPadding = new Padding(5, 0, 0, 0);
                    //  popup.BodyColor = Color.Red;
                    popup.Popup();
                    Form kullanicigiriisi = new Kullanicigirisi();
                    kullanicigiriisi.Show();
                    this.Hide();
                }
            }
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("Girmiş olduğunuz kullanıcı adı kullanılmaktadır.", "DİKKAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Kullanicigirisi kullanicigirisekrani = new Kullanicigirisi();
            kullanicigirisekrani.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 gecis = new Form1();
            gecis.Show();
            this.Hide();    
        }
    }
}

