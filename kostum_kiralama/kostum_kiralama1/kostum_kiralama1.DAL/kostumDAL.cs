using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using kostum_kiralama1.Entity;
using System.Data;

namespace kostum_kiralama1.DAL
{
    public class kostumDAL
    {

        private accsessconnection Accessconnection;
        //new acceesscone.... yapma yapıcı metod altında yapılırmış
       
        public kostumDAL()
        {
            Accessconnection = new accsessconnection();
        }
        public DataTable GetKostumData()
        {
            DataTable dataTable = new DataTable();
            using (OleDbConnection connection = new OleDbConnection())
            {
                string query = "SELECT * FROM kostum";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
                    }
                }
            }
            return dataTable;
        }
            //Bütün Kitapları listeme(veri tabanından burdan çekilir)
            public List<kostum> GetAllItems()///dalın entity yi referans alması lazım
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd.CommandText = "select * from kostum";
            List<kostum> kostums = new List<kostum>();//entity de oluşturduğum class ismi
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                kostum Kostum = new kostum();
                Kostum.Barkodno = rdr["Barkodno"].ToString();
                Kostum.Kostumadi = rdr["Kostumadi"].ToString();
                Kostum.Sahibi = rdr["Sahibi"].ToString();
                Kostum.Rafno = rdr["Rafno"].ToString();
                Kostum.Adet = Convert.ToInt16(rdr["Adet"]);
                kostums.Add(Kostum);
            }
            return kostums;//listeyi geriye döndermiş oldum
        }

        public Tuple<string[], string[], double[]> Grafik()//grafik için adı barkodnumarası ve adeti için birden fazla dizi dönderiyorum
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = "select * from kostum";
            OleDbDataReader rdr = cmd.ExecuteReader();
            OleDbCommand cmd2 = Accessconnection.GetOleDbCommand();
            cmd2.CommandText = "select * from kostum";
            OleDbDataReader rdr2 = cmd2.ExecuteReader();
            double[] grafikAdetleri = new double[20];//kitap adetlerini tutuyorum 
            string[] grafikBarkodnumarasi = new string[20];//barkodnumaralarını tutuyorum
            string[] grafikKostumadi = new string[20];//kitap adlarını tutuyorum
            int Adetleri = 0;//kütüphande birde fazla kitap olduğu için bilgileri dizinin indislerine atayabilmek için bunu dizi indisi olarak kullandım.
            while (rdr.Read())
            {//elimizde olan kitap adetleri yani verilmeye hazır kitaplar
                grafikBarkodnumarasi[Adetleri] = rdr["Barkodno"].ToString();//barkodnumarasınıa göre adetleri getirmek görüntü açısı daha iyi
                grafikKostumadi[Adetleri] = rdr["Kostumadi"].ToString();//kitap adına göre getirme üstüne getirerek kitap adı adetinden kaç tane olduğu gözükür
                grafikAdetleri[Adetleri] = Convert.ToDouble(rdr["Adet"].ToString());
                Adetleri++;
            }
            int Adetleri2 = 0;//bu değişkeni kullanmamım sebebi öğrencilere verilmiş kitab var mı var ise o kitabıın kaç tanesi öğrenciye verildiği bulunur sonrasında o kitabın kütüphandeki taoplam kitap adeti bulunur.
            while (rdr2.Read())
            {//kitap tablosundaki adetler saydı şimdi bu kitaba ait barkod numarasını alanlar kaç tane adetini bulup toplam kitap sayısını buluyorum
                OleDbCommand cmd3 = Accessconnection.GetOleDbCommand();
                cmd3.CommandText = "select * from kostum_ver where Barkodno='" + rdr2["Barkodno"].ToString() + "'";
                OleDbDataReader rdr3 = cmd3.ExecuteReader();
                int alinmiskostumsayisi = 0;
                while (rdr3.Read())
                {//barkodnumarası aynı olanları say yani kitap tablosundaki barkodnumarasını kaç kişi kişi aldıysa toplam kitap sayısını arttır.
                    alinmiskostumsayisi++;
                }
                grafikAdetleri[Adetleri2] += alinmiskostumsayisi;//kitap tablosunda boşta kitap adetine o kitabın kaç tanesi öğrencilere vverilmiş onu kitap adetine ekler ve o kitapdan kaç tane olduğunu bulurum.
                Adetleri2++;
            }
            return Tuple.Create(grafikKostumadi, grafikBarkodnumarasi, grafikAdetleri);//birden fazla dizi dönderiyorum
        }

        //Gelen barkodnumarasına göre veritabanından kitap bilgilerini listede tutuyorum
        public List<kostum> Arama(kostum kostum)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = "select * from kostum";
            List<kostum> kostums = new List<kostum>();//entity de oluşturduğum class ismi
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (kostum.Barkodno == rdr["Barkodno"].ToString())
                {
                    kostum.Barkodno = rdr["Barkodno"].ToString();
                    kostum.Kostumadi = rdr["Kostumadi"].ToString();
                    kostum.Sahibi = rdr["Sahibi"].ToString();
                    kostum.Rafno = rdr["Rafno"].ToString();
                    kostum.Adet = Convert.ToInt16(rdr["Adet"]);

                    kostums.Add(kostum);
                }
            }
            return kostums;//listeyi geriye döndermiş oldum
        }

        //Gelen kitap adına göre veritabanından kitap bilgilerini listede tutuyorum
        public List<kostum> KostumAdiArama(kostum kostum)
        {//datatable üzerinde veriileri çekiyorum
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd.CommandText = "select * from kostum";
            List<kostum> kostums = new List<kostum>();//entity de oluşturduğum class ismi
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {//Dışardan gelen kitapadi tablomda var mı diye kontrol ediyorum var ise oluşturduğum listeme ekliyorum.
                if (kostum.Kostumadi == rdr["Kostumadi"].ToString())
                {
                    kostum.Barkodno = rdr["Barkodno"].ToString();
                    kostum.Kostumadi = rdr["Kostumadi"].ToString();
                    kostum.Sahibi = rdr["Sahibi"].ToString();              
                    kostum.Rafno = rdr["Rafno"].ToString();
                    kostum.Adet = Convert.ToInt16(rdr["Adet"]);
                    kostums.Add(kostum);
                }
            }
            return kostums;//listeyi geriye döndermiş oldum
        }

        public List<kostum> TxtSearchDuzenleme(kostum kostum)
        {//bunu txtboxların içini direk güncelleme yapmak istediği şeyi doldurması için getirdim
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd.CommandText = "select * from kostum";
            List<kostum> kostums = new List<kostum>();//entity de oluşturduğum class ismi
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {//gelen barkod numarası tablodaki ile aynı ise nesnemdeki değişkenlere tablomdaki verileri ata.sonra oluşturduğum listeme nesnemi ata en son listemi dönder
                if (kostum.Barkodno == rdr["Barkodno"].ToString())
                {
                    kostum.Barkodno = rdr["Barkodno"].ToString();
                    kostum.Kostumadi = rdr["Kostumadi"].ToString();
                    kostum.Sahibi = rdr["Sahibi"].ToString();
                    kostum.Rafno = rdr["Rafno"].ToString();
                    kostum.Adet = Convert.ToInt16(rdr["Adet"]);
                    kostums.Add(kostum);
                    break;
                }
            }
            return kostums;
        }
        //veritabanına ekleme işlemi yapıyorum
        public int AddNewItem(kostum kostum)
        {
            string cmdText = "INSERT INTO [kostum] ([Barkodno],[Kostumadi],[Sahibi],[Rafno],[Adet])";
            cmdText += String.Format(" Values('{0}','{1}','{2}','{3}','{4}')", kostum.Barkodno, kostum.Kostumadi, kostum.Sahibi, kostum.Rafno, kostum.Adet);
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = cmdText;
            return cmd.ExecuteNonQuery();
        }
        //veritabanından silme işlemi yapıyorum
        public int DeleteItem(kostum Kostum)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = string.Format("Delete From kostum where Barkodno='" + Kostum.Barkodno + "'");
            return cmd.ExecuteNonQuery();
        }
        public int UpdateItem(kostum Kostum)
        {//Eğer kitap bilgilerini güncelleştiriyorsa kitapiadede ve kitapver tablosundada güncellemesi lazım o yüzden cmd2 ve cmd3 ü yazdım
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            OleDbCommand cmd2 = Accessconnection.GetOleDbCommand();
            OleDbCommand cmd3 = Accessconnection.GetOleDbCommand();
            cmd.CommandText = string.Format("Update kostum set Adet=" + Kostum.Adet + " , Kostumadi='" + Kostum.Kostumadi + "',Sahibi='" + Kostum.Sahibi + "',Rafno='" + Kostum.Rafno + "' where Borkodno='" + Kostum.Barkodno.ToString() + "'");
            cmd2.CommandText = string.Format("Update kostum_ver set  Kostumadi='" + Kostum.Kostumadi + "',Sahibi='" + Kostum.Sahibi + "',Rafno='" + Kostum.Rafno + "' where Barkodno='" + Kostum.Barkodno.ToString() + "'");
            cmd3.CommandText = string.Format("Update kostum_iade set  Kostumadi='" + Kostum.Kostumadi + "',Sahibi='" + Kostum.Sahibi + "',Rafno='" + Kostum.Rafno + "' where Barkodno='" + Kostum.Barkodno.ToString() + "'");
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            return cmd.ExecuteNonQuery();
        }
        public int UpdateKostumadetiazalt(kostum Kostum)
        {//eğer öğrenciye kitap verirsek adetten düşer
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = string.Format("Update kostum set Adet=Adet - 1  where Barkodno='" + Kostum.Barkodno + "'");
            return cmd.ExecuteNonQuery();
        }
        public int UpdateKostumadetiarttir(kostum Kostum)
        {//eğer öğrenci kitabı geri teslim ederse kitap adeti artar
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = string.Format("Update kostum set Adet=Adet + 1 where Barkodno='" + Kostum.Barkodno + "'");
            return cmd.ExecuteNonQuery();
        }
        public List<kostum> GetAllKostumlar()
        {
            List<kostum> kostumlar = new List<kostum>();

            // Burada veritabanı bağlantısı kurarak, kostüm verilerini alıyoruz.
            // Bu örnekte veri almak için basit bir liste dönüyoruz.
            // Gerçek uygulamanızda Access DB veya başka bir veritabanı bağlantısı yapılacak.

            // Örnek veriler:
            kostumlar.Add(new kostum() { Barkodno = "001", Kostumadi = "Superman", Sahibi = "Ali", Rafno = "Raf1", Adet = 5 });
            kostumlar.Add(new kostum() { Barkodno = "002", Kostumadi = "Batman", Sahibi = "Veli", Rafno = "Raf2", Adet = 3 });

            return kostumlar;
        }

    }
}

