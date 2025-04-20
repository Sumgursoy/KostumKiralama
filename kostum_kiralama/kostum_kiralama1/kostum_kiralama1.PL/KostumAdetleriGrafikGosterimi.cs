using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using kostum_kiralama1.BLL;
using kostum_kiralama1.Entity;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas;
using System.Data.OleDb;

namespace kostum_kiralama1.PL
{
    public partial class KostumAdetleriGrafikGosterimi : Form
    {
        public KostumAdetleriGrafikGosterimi()
        {
            InitializeComponent();
        }

        private void KostumAdetleriGrafikGosterimi_Load(object sender, EventArgs e)
        {
            this.Location = new Point(200, 40);//Form ekranın açılınca yernini belirleme Point(x,y)
            kostum Kostum = new kostum();
            //bu grafiği ilk yaptığım FORM LOAD içinde kullanıyordum yani katmanlı mimari içinde değil FORM LOAD içinde veri okuma çağırma işlemlerimi yapıyordum
            //bunun sebebi ise benim grafikleri doldurmam için bana 3 tane dizi lazımdı List<Kitap> yaparak bana3 tane dizi dönderemiyordum 
            //sonrasında Tuple<int, int> diye bir yöntem öğrendim sonra o yöntemi kendi grafiğime uygulayarak katmanlı mimariye çevirdim
            //bütün aşamalarım katmanlı mimaride.Yani FORM LOAD içinde sadece bll katmanına erişiyorum.
            kostumBLL bll = new kostumBLL();
            var grafikicindonenbirdiziler = bll.Grafik();//geriye dönen 3 dizimi tutuyorum bunları Item1 Item2 Item3 diye kullanacağım

            // zedGraphControl1 Barkod numarasına göre Adetleri grafikleme
            GraphPane myPane = zedGraphControl1.GraphPane;
            // Baslık ekleme X,Y Eksenine başlık eklem
            myPane.Title.Text = "Kostümlerin adet cizelgesi";
            myPane.XAxis.Title.Text = "Kostümlerin Barkod Numaraları";
            myPane.YAxis.Title.Text = "Kostümlerin toplam adetleri";
            //Kitap sayısına ait çubuk oluşturulacak x ekseni boş olacak sonradan onlara barkod numaralarını gircem Y ekseni yukarda ys1 listesine eklenen kitap adetleri gelecek
            BarItem myBar = myPane.AddBar("Kostüm sayısı", null, grafikicindonenbirdiziler.Item3, Color.Red);//Geriye dönen Item3 Kitapadetleri Dizisine eşittir
            myBar.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);
            //X etiketleri arasına çizin
            myPane.XAxis.MajorTic.IsBetweenLabels = true;
            //X ekseni etiketlerini boş bırakmıştım şimdi ise yukarda oluşan labels2 nesnesine atadığım barkod numaralarını X eksenine etiket olarak atıyorum
            myPane.XAxis.Scale.TextLabels = grafikicindonenbirdiziler.Item2;//Item2 = Barkodnumaraları
            //XAxis'i metin türü olarak ayarladım.
            myPane.XAxis.Type = AxisType.Text;
            //küçük ölcekli görüntüleme aktif
            myPane.XAxis.MinorGrid.IsVisible = true;
            //Eksen bölme arkplan renk ayarları
            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            zedGraphControl1.AxisChange();

            //zedGraphControl1 Kitap adına göre Adetleri grafiklemek
            GraphPane myPane2 = zedGraphControl2.GraphPane;
            // Baslık ekleme X,Y Eksenine başlık eklem
            myPane2.Title.Text = "Kostümlerin adet cizelgesi";
            myPane2.YAxis.Title.Text = "Kostüm Adları";
            myPane2.XAxis.Title.Text = "Kostümlerin toplam adetleri";
            //Kitap sayısına ait çubuk oluşturulacak y ekseni boş olacak sonradan onlara kiyap adlarını gircem X eksenine ise yukarda ys1 listesine eklenen kitap adetleri gelecek
            //Yani daha hoş duracağı için kitap adlarını yan şekilde y eksenine yazdırdım.
            BarItem myBar2 = myPane2.AddBar("Kostüm sayısı", grafikicindonenbirdiziler.Item3, null, Color.Red);
            myBar2.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);
            //Bunları Yukardakilerden farklı olarak YAxis kullanmamım sebebebi Y Ekseninde Kitap Adları yazacak değerler X Ekseninde gözükecek
            //Y etiketleri arasına çizin
            myPane2.YAxis.MajorTic.IsBetweenLabels = true;
            //Y ekseni etiketlerini boş bırakmıştım şimdi ise yukarda oluşan labels3 nesnesine atadığım kitap adlarını Y eksenine etiket olarak atıyorum
            myPane2.YAxis.Scale.TextLabels = grafikicindonenbirdiziler.Item1;//Item1= Kitap adları
            //YAxis'i metin türü olarak ayarladım.
            myPane2.YAxis.Type = AxisType.Text;
            // küçük ölçekli görüntüleme yanlış sonuçlara görünmez
            myPane2.YAxis.MinorGrid.IsVisible = true;
            myPane2.BarSettings.Base = BarBase.Y;
            //Eksen bölme arkplan renk ayarları
            myPane2.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            myPane2.Fill = new Fill(Color.FromArgb(250, 250, 255));
            zedGraphControl2.AxisChange();

            //bunu oluşturmamım sebebi zaten barkod numaraları net bir şekilde gözüküyor üstüne gelince sadece kitap sayıları gözüksün diye nesne tanımladım 
            zedGraphControl1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(zedGraphControl1_PointValueEvent);
        }
        private string zedGraphControl1_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {//çubuğun üstüne gelince (Kitap Sayısı: Kaç adetse) yazar
            //BarItem myBar = myPane.AddBar("Kitap sayısı", null, ys1, Color.Red);
            //üst satırdaki kodu açıklama satırı olarak yazmamım sebebi Aşağıdaki kodda görüldüğü gibi herhangi bir ("Kitap sayısı") yazmıyor .
            //curve.Label.Text gidicek yukarıda açıklama olrak gösterdiğim çalışan koda gidicek ilk parametre olan  "kitap sayısı"  nı alıcak sonrasında ise Y exsenindeli değişkenleri yazıcak
            //Y eksenindeki değişkenler Kitaba Ait Toplam Kitap Adet Sayılarını getirir.
            //Her Kitap için Öğrenciye Verilmiş Ve Verilmeye hazır boşta kitabın adetini getirir.
            return curve.Label.Text + " ; " + (curve[iPt].Y.ToString());
        }

        //private void button1_Click(object sender, EventArgs e)
        //{//Textboxlardaki isimleri başlık vermek
        //    GraphPane baslik = zedGraphControl1.GraphPane;
        //    // Baslık ekleme X,Y Eksenine başlık eklem          
        //    baslik.Title.Text = txtbaslik.Text;
        //    baslik.YAxis.Title.Text = txtyeksenibaslik.Text;
        //    baslik.XAxis.Title.Text = txtxeksenibaslik.Text;
        //    //aşağıdaki adımları yapmamım sebebi bu kodu yazdımtan sonra tabcontrol2 tıklayıp tekrar buraya tıklayınca değiştirm yapıyordu
        //    //fakat butona basınca direk değiştirmiyordu form loadda atadığım isimleri
        //    //sonrasında deneme diye başka çizelge oluşturdum çok saçma sekilde orada formu aşağı alıp
        //    //tekrar açınca değişiklik oluyordu hatta y eksenini sola dayıyordum yani yen ekseni ekranda gözükmüyordu(mause ile sola çekiyorum ) bu sefer y eksenini değiştiriyor.
        //    //bende başta  this.Refresh(); komudunu denedim fakat olmadı sonrasında formu gizleyip tekrar göstermeyi yaptım başlık atamalarında sonra ikinci seferde oldu
        //    //en son formu gizleme ve tekrar gösterme işlemini başlık değişikliklerini başlık atamalarından sonrasına aldım
        //    this.Hide();//form ekranını gizliyorum
        //    this.Show();//form ekranını tekrar açıyorum
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{//dışardan veri almadan verdiğim başlıkları geri getirme
        //    GraphPane baslik = zedGraphControl1.GraphPane;
        //    // Baslık ekleme X,Y Eksenine başlık eklem          
        //    baslik.Title.Text = "Kütüphadeki kitapların adet cizelgesi";
        //    baslik.XAxis.Title.Text = "Kitapların Barkod Numaraları";
        //    baslik.YAxis.Title.Text = "Kitapların toplam adetleri";
        //    //aşağıdaki adımları yapmamım sebebi bu kodu yazdımtan sonra tabcontrol2 tıklayıp tekrar buraya tıklayınca değiştirm yapıyordu
        //    //fakat butona basınca direk değiştirmiyordu form loadda atadığım isimleri
        //    //sonrasında deneme diye başka çizelge oluşturdum çok saçma sekilde orada formu aşağı alıp
        //    //tekrar açınca değişiklik oluyordu hatta y eksenini sola dayıyordum yani yen ekseni ekranda gözükmüyordu(mause ile sola çekiyorum ) bu sefer y eksenini değiştiriyor.
        //    //bende başta  this.Refresh(); komudunu denedim fakat olmadı sonrasında formu gizleyip tekrar göstermeyi yaptım başlık atamalarında sonra ikinci seferde oldu
        //    //en son formu gizleme ve tekrar gösterme işlemini başlık değişikliklerini başlık atamalarından sonrasına aldım
        //    this.Hide();//form ekranını gizliyorum
        //    this.Show();//form ekranını tekrar açıyorum
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{//Textboxlardaki isimleri başlık vermek
        //    GraphPane baslik = zedGraphControl2.GraphPane;
        //    // Baslık ekleme X,Y Eksenine başlık eklem          
        //    baslik.Title.Text = txtbaslik2.Text;
        //    baslik.YAxis.Title.Text = txtyeksenibaslik2.Text;
        //    baslik.XAxis.Title.Text = txtxeksenibaslik2.Text;
        //    //aşağıdaki adımları yapmamım sebebi bu kodu yazdımtan sonra tabcontrol2 tıklayıp tekrar buraya tıklayınca değiştirm yapıyordu
        //    //fakat butona basınca direk değiştirmiyordu form loadda atadığım isimleri
        //    //sonrasında deneme diye başka çizelge oluşturdum çok saçma sekilde orada formu aşağı alıp
        //    //tekrar açınca değişiklik oluyordu hatta y eksenini sola dayıyordum yani yen ekseni ekranda gözükmüyordu(mause ile sola çekiyorum ) bu sefer y eksenini değiştiriyor.
        //    //bende başta  this.Refresh(); komudunu denedim fakat olmadı sonrasında formu gizleyip tekrar göstermeyi yaptım başlık atamalarında sonra ikinci seferde oldu
        //    //en son formu gizleme ve tekrar gösterme işlemini başlık değişikliklerini başlık atamalarından sonrasına aldım
        //    this.Hide();//form ekranını gizliyorum
        //    this.Show();//form ekranını tekrar açıyorum
        //}
        //private void button3_Click(object sender, EventArgs e)
        //{//dışardan veri almadan verdiğim başlıkları geri getirme
        //    GraphPane baslik = zedGraphControl2.GraphPane;
        //    // Baslık ekleme X,Y Eksenine başlık eklem          
        //    baslik.Title.Text = "Kütüphadeki kitapların adet cizelgesi";
        //    baslik.YAxis.Title.Text = "Kitap Adları";
        //    baslik.XAxis.Title.Text = "Kitapların toplam adetleri";
        //    //aşağıdaki adımları yapmamım sebebi bu kodu yazdımtan sonra tabcontrol2 tıklayıp tekrar buraya tıklayınca değiştirm yapıyordu
        //    //fakat butona basınca direk değiştirmiyordu form loadda atadığım isimleri
        //    //sonrasında deneme diye başka çizelge oluşturdum çok saçma sekilde orada formu aşağı alıp
        //    //tekrar açınca değişiklik oluyordu hatta y eksenini sola dayıyordum yani yen ekseni ekranda gözükmüyordu(mause ile sola çekiyorum ) bu sefer y eksenini değiştiriyor.
        //    //bende başta  this.Refresh(); komudunu denedim fakat olmadı sonrasında formu gizleyip tekrar göstermeyi yaptım başlık atamalarında sonra ikinci seferde oldu
        //    //en son formu gizleme ve tekrar gösterme işlemini başlık değişikliklerini başlık atamalarından sonrasına aldım
        //    this.Hide();//form ekranını gizliyorum
        //    this.Show();//form ekranını tekrar açıyorum
      //  }


        private void zedGraphControl1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GraphPane baslik = zedGraphControl1.GraphPane;
            // Baslık ekleme X,Y Eksenine başlık eklem          
          //  baslik.Title.Text = txtbaslik.Text;
          //  baslik.YAxis.Title.Text = txtyeksenibaslik.Text;
           // baslik.XAxis.Title.Text = txtxeksenibaslik.Text;
            //aşağıdaki adımları yapmamım sebebi bu kodu yazdımtan sonra tabcontrol2 tıklayıp tekrar buraya tıklayınca değiştirm yapıyordu
            //fakat butona basınca direk değiştirmiyordu form loadda atadığım isimleri
            //sonrasında deneme diye başka çizelge oluşturdum çok saçma sekilde orada formu aşağı alıp
            //tekrar açınca değişiklik oluyordu hatta y eksenini sola dayıyordum yani yen ekseni ekranda gözükmüyordu(mause ile sola çekiyorum ) bu sefer y eksenini değiştiriyor.
            //bende başta  this.Refresh(); komudunu denedim fakat olmadı sonrasında formu gizleyip tekrar göstermeyi yaptım başlık atamalarında sonra ikinci seferde oldu
            //en son formu gizleme ve tekrar gösterme işlemini başlık değişikliklerini başlık atamalarından sonrasına aldım
            this.Hide();//form ekranını gizliyorum
            this.Show();//form ekranını tekrar açıyorum
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // dışardan veri almadan verdiğim başlıkları geri getirme
            GraphPane baslik = zedGraphControl1.GraphPane;
            // Baslık ekleme X,Y Eksenine başlık eklem          
            baslik.Title.Text = "Kostüm adet cizelgesi";
            baslik.XAxis.Title.Text = "Kostümlerin Barkod Numaraları";
            baslik.YAxis.Title.Text = "Kostümlerin toplam adetleri";
            //aşağıdaki adımları yapmamım sebebi bu kodu yazdımtan sonra tabcontrol2 tıklayıp tekrar buraya tıklayınca değiştirm yapıyordu
            //fakat butona basınca direk değiştirmiyordu form loadda atadığım isimleri
            //sonrasında deneme diye başka çizelge oluşturdum çok saçma sekilde orada formu aşağı alıp
            //tekrar açınca değişiklik oluyordu hatta y eksenini sola dayıyordum yani yen ekseni ekranda gözükmüyordu(mause ile sola çekiyorum ) bu sefer y eksenini değiştiriyor.
            //bende başta  this.Refresh(); komudunu denedim fakat olmadı sonrasında formu gizleyip tekrar göstermeyi yaptım başlık atamalarında sonra ikinci seferde oldu
            //en son formu gizleme ve tekrar gösterme işlemini başlık değişikliklerini başlık atamalarından sonrasına aldım
            this.Hide();//form ekranını gizliyorum
            this.Show();//form ekranını tekrar açıyorum
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            {//Textboxlardaki isimleri başlık vermek
                GraphPane baslik = zedGraphControl2.GraphPane;
                // Baslık ekleme X,Y Eksenine başlık eklem          
            //    baslik.Title.Text = //txtbaslik2.Text;
           //     baslik.YAxis.Title.Text = txtyeksenibaslik2.Text;
             //   baslik.XAxis.Title.Text = txtxeksenibaslik2.Text;
                //aşağıdaki adımları yapmamım sebebi bu kodu yazdımtan sonra tabcontrol2 tıklayıp tekrar buraya tıklayınca değiştirm yapıyordu
                //fakat butona basınca direk değiştirmiyordu form loadda atadığım isimleri
                //sonrasında deneme diye başka çizelge oluşturdum çok saçma sekilde orada formu aşağı alıp
                //tekrar açınca değişiklik oluyordu hatta y eksenini sola dayıyordum yani yen ekseni ekranda gözükmüyordu(mause ile sola çekiyorum ) bu sefer y eksenini değiştiriyor.
                //bende başta  this.Refresh(); komudunu denedim fakat olmadı sonrasında formu gizleyip tekrar göstermeyi yaptım başlık atamalarında sonra ikinci seferde oldu
                //en son formu gizleme ve tekrar gösterme işlemini başlık değişikliklerini başlık atamalarından sonrasına aldım
             //   this.Hide();//form ekranını gizliyorum
             //   this.Show();//form ekranını tekrar açıyorum
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //dışardan veri almadan verdiğim başlıkları geri getirme
            GraphPane baslik = zedGraphControl2.GraphPane;
            // Baslık ekleme X,Y Eksenine başlık eklem          
            baslik.Title.Text = "Kostümlerin adet cizelgesi";
            baslik.YAxis.Title.Text = "Kostüm Adları";
            baslik.XAxis.Title.Text = "Kostümlerin toplam adetleri";
            //aşağıdaki adımları yapmamım sebebi bu kodu yazdımtan sonra tabcontrol2 tıklayıp tekrar buraya tıklayınca değiştirm yapıyordu
            //fakat butona basınca direk değiştirmiyordu form loadda atadığım isimleri
            //sonrasında deneme diye başka çizelge oluşturdum çok saçma sekilde orada formu aşağı alıp
            //tekrar açınca değişiklik oluyordu hatta y eksenini sola dayıyordum yani yen ekseni ekranda gözükmüyordu(mause ile sola çekiyorum ) bu sefer y eksenini değiştiriyor.
            //bende başta  this.Refresh(); komudunu denedim fakat olmadı sonrasında formu gizleyip tekrar göstermeyi yaptım başlık atamalarında sonra ikinci seferde oldu
            //en son formu gizleme ve tekrar gösterme işlemini başlık değişikliklerini başlık atamalarından sonrasına aldım
            this.Hide();//form ekranını gizliyorum
            this.Show();//form ekranını tekrar açıyorum
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 gecis = new Form1();
            gecis.Show();
            this.Hide();
        }

        private void zedGraphControl2_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        //private void SaveChartToPdf(System.Windows.Forms.DataVisualization.Charting.Chart chart, string pdfFilePath)
        //{
        //    // Chart'ı bir bitmap olarak yakala
        //    var bitmap = new Bitmap(chart.Width, chart.Height);
        //    chart.DrawToBitmap(bitmap, new Rectangle(0, 0, chart.Width, chart.Height));

        //    // PDF yazıcıya yazma işlemi
        //    using (PdfWriter writer = new PdfWriter(pdfFilePath))
        //    {
        //        using (PdfDocument pdf = new PdfDocument(writer))
        //        {
        //            Document document = new Document(pdf);
        //            document.Add(new Paragraph("Grafiğin PDF'ye Aktarılması").SetBold().SetFontSize(18));

        //            // Grafik görüntüsünü PDF'ye ekle
        //            var image = new Image(iText.IO.Image.ImageDataFactory.Create(bitmap, null));
        //            document.Add(image);
        //        }
        //    }
        //}

        //// Buton tıklandığında grafiği PDF'ye aktarma işlemi


        //private void button5_Click(object sender, EventArgs e)
        //{
        //    // SaveFileDialog ile PDF kaydetme yolu seç
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
        //    saveFileDialog.Title = "PDF Kaydet";
        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string pdfFilePath = saveFileDialog.FileName;

        //    try
        //    {
        //        // Chart'ı PDF'ye aktarma
        //        SaveChartToPdf(chart1, pdfFilePath);

        //        MessageBox.Show("Grafik PDF'ye başarıyla aktarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}

      
        


        
    

        
            
           
    
    




