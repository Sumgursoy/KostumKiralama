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
using Tulpep.NotificationWindow;//form geçiş ekranı için



namespace kostum_kiralama1.PL
{
    public partial class Kullanicigirisi : Form
    {
        public Kullanicigirisi()
        {
            InitializeComponent();
        }

       
       

        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void Kullanicigirisi_Load(object sender, EventArgs e)
        {
            this.Location = new Point(260, 150);//Form ekranın açılınca yernini belirleme Point(x,y)
        }

        private void Kullanicigirisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //İlk girişş yaptığımda arkada borcları hesaplıyorum o yüzdem program çok kasıyordu o yüzden 
            //program arkada çalışırken(verileri öğrenci listesine yazarrken) form açılmasını sağlayan 

        }



        private void txtkullaniciadi_TextChanged(object sender, EventArgs e)
        {
        }
        //private void txtsifre_KeyPress(object sender, KeyPressEventArgs e)
        //{//boşluk girişini engeller
        //    e.Handled = Char.IsWhiteSpace(e.KeyChar);
        //}
        //private void txtkullaniciadi_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //boşluk girişini engeller
        //    e.Handled = Char.IsWhiteSpace(e.KeyChar);
       // }

        private void btngiris_Click_1(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            kullanici_girisi Kullanicigirisi = new kullanici_girisi();
            //önce textboxları değişkenlere atıyorum herhangi bir değişiklik yaptığımda kolay olsun 
            //tablodaki değişkenlerle aynı olacak dikkat 
            Kullanicigirisi.Kullaniciadi = txtkullaniciadi.Text;
            Kullanicigirisi.Sifre = txtsifre.Text;
            kullanici_girisiBLL bll = new kullanici_girisiBLL();

            try
            {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
                string kullaniciadisoyadi = bll.Arama(Kullanicigirisi);
                //sağ altta açılır form ekranı
                {
                    PopupNotifier popup = new PopupNotifier();
                    //   popup.Image = Properties.Resources.userana;
                    popup.ImagePadding = new Padding(5);
                    popup.TitleText = "Merhaba".ToUpper().PadLeft(1);
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
                }
                Form formekranı = new Form1();
                formekranı.Text = "musteri : " + kullaniciadisoyadi;
                formekranı.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_PwReminder_Click_1(object sender, EventArgs e)
        {
            Form uyeol = new kullaniciuyeol();
            uyeol.Show();
            this.Hide();
        }

        private void txtkullaniciadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsWhiteSpace(e.KeyChar);
        }

        private void txtsifre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsWhiteSpace(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
       
    }
}

