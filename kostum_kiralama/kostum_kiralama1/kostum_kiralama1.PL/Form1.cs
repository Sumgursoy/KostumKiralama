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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void ögrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form musterie = new musteriekle();
            musterie.Show();

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musterisilme musteris = new musterisilme();
            musteris.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(30, 100);//Form ekranın açılınca yernini belirleme Point(x,y)
            backgroundWorker1.RunWorkerAsync();
        }
        //private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Form musterig = new musteriguncelleme();
        //    musterig.Show();
        //}

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form musteril = new musterilistele();
            musteril.Show();
        }

        private void ekleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form kostume = new kostumekleme();
            kostume.Show();
        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form kostums = new kostumsilme();
            kostums.Show();
        }

        //private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Form kostumg = new kostumguncelleme();
        //    kostumg.Show();
        //}

        private void listeleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form kostuml = new kostumlistele();
            kostuml.Show();
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kitapVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kostumv = new kostumver();
            kostumv.Show();
        }

        private void kitapİadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kostumi = new kostumiade();
            kostumi.Show();
        }

        private void öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form musterikostumliste = new musterikostumlistele();
            musterikostumliste.Show();
        }

        private void barkoNumarasınaGöreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kostumbarkod = new kostumarama();
            kostumbarkod.Show();
        }

        private void kitapAdınaGöreToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  Form kostumadina = new kostumadinagörearama_();
           // kostumadina.Show();
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            musteriBLL bll2 = new musteriBLL();
            bll2.BorcUpdateSifirlama();

            musteriBLL bll = new musteriBLL();
            bll.BorcUpdateItem();

            ////İlk girişş yaptığımda arkada borcları hesaplıyorum o yüzdem program çok kasıyordu o yüzden 
            //////program arkada çalışırken(verileri öğrenci listesine yazarrken) form açılmasını sağlayan 
            //OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\alisa\\source\\repos\\KutuphaneOtamasyonuu\\kutuphane.accdb");
            //baglanti.Open();
            //OleDbCommand cmd = new OleDbCommand("select * from Kitapver", baglanti);//bunları sadece tabloyu çağırdım okuma yapmak için çağırdım yoksa işlmelerim katmanlı mimaride yapıldı 
            //                                                                        //verilerde katmanlı mimaride alınıp işlendi
            //OleDbDataReader okuyucu = cmd.ExecuteReader();
            //OleDbCommand cmd2 = new OleDbCommand("select * from Ogrenci", baglanti);
            //OleDbDataReader okuyucu2 = cmd2.ExecuteReader();
            //while (okuyucu2.Read())
            //{
            //    Ogrenci ogrenci2 = new Ogrenci();
            //    ogrenci2.TcNo = okuyucu2["TcNo"].ToString();
            //    ogrenci2.Borc = 0;
            //    OgrenciBLL bll2 = new OgrenciBLL();
            //    bll2.BorcUpdateSifirlama(ogrenci2);
            //}
            //while (okuyucu.Read())
            //{
            //    TimeSpan zamanfarki = DateTime.Now - Convert.ToDateTime(okuyucu["Teslimtarihi"].ToString());
            //    double gün = zamanfarki.TotalDays;
            //    if (gün > 0.0)
            //    {//eğer teslim tarihi ile bu gün arasında fark varsa git onu öğrenci tablosuna borc olarak ekle

            //        Ogrenci ogrenci = new Ogrenci();
            //        ogrenci.TcNo = okuyucu["Tcno"].ToString();
            //        ogrenci.Borc = Convert.ToInt32(gün);
            //        OgrenciBLL bll = new OgrenciBLL();
            //        bll.BorcUpdateItem(ogrenci);

            //    }
            //}
            // cmd4.CommandText = string.Format();
            //string tel = "55555532";
            ////  string tc = "12313241231";
            //string tc = "111";
            //OleDbCommand cmd4 = new OleDbCommand();
            //cmd4.Connection = baglanti;
            //DateTime tarih = DateTime.Now;
            //cmd4.CommandText = "update  Kitapver  set Telefon='" + tel + "' where Teslimtarihi<'"  + #31/10/2020# + "'";
            //cmd4.Parameters.AddWithValue("@tarih", DateTime.Now);
            //cmd4.ExecuteNonQuery();
            //baglanti.Close();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult Cikis;
            Cikis = MessageBox.Show("Program Kapatılacak Emin siniz?", "Kapatma Uyarısı!", MessageBoxButtons.YesNo);
            if (Cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
            if (Cikis == DialogResult.No)
            {
                Form formekranı = new Form1();
                formekranı.Show();
            }
        }

       
        private void grafiklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form grafik = new KostumAdetleriGrafikGosterimi();
            grafik.Show();
        }

        private void kitabıKmAldıKimTeslimEttiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kostumukimalmis = new Kostumuteslimalaniadeedenlerinlistesi();
            kostumukimalmis.Show();
        }

        private void kitapToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ekleToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            kostumekleme kostumekleme = new kostumekleme();
            kostumekleme.Show();
        }

        private void silToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            kostumsilme kostumsilme = new kostumsilme();
            kostumsilme.Show();
        }

        private void listeleToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            kostumlistele kostumlistele = new kostumlistele();  
            kostumlistele.Show();   
        }

        //private void düzenleToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    kostumguncelleme kostumguncelleme = new kostumguncelleme(); 
        //    kostumguncelleme.Show();
        //}

        private void araToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            kostumarama kostumarama = new kostumarama();
            kostumarama.Show();
        }

        private void barkoNumarasınaGöreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        //private void güncelleToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    musteriguncelleme musteriguncelleme = new musteriguncelleme();
        //    musteriguncelleme.Show();
        //}

        private void listeleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            musterilistele musterilistele = new musterilistele();
            musterilistele.Show();
        }

        private void kitapAlımİadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void kitapVerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            kostumver kostumver = new kostumver();
            kostumver.Show();
        }

        private void kitapİadeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            kostumiade kostumiade = new kostumiade();
            kostumiade.Show();
        }

        private void öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            musterikostumlistele musterikostumlistele = new musterikostumlistele();
            musterikostumlistele.Show();
        }

        private void grafiklerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            KostumAdetleriGrafikGosterimi kostumAdetleriGrafikGosterimi=new KostumAdetleriGrafikGosterimi();
            kostumAdetleriGrafikGosterimi.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

