using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using kostum_kiralama1.Entity;

namespace kostum_kiralama1.DAL
{
    public class kostum_verDAL
    {
        private accsessconnection Accsessconnection;
        public kostum_verDAL()
        {
            Accsessconnection = new accsessconnection();
        }

        public List<kostum_ver> GetAllItems()///dalın entity yi referans alması lazım
        {//datatable üzerinde veriileri çekiyorum
            OleDbCommand cmd = Accsessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd.CommandText = "select * from kostum_ver";



            //entity katmanından sonra data table işlevini yitirdi
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());

            //return dt;

            List<kostum_ver> kitapvers = new List<kostum_ver>();//entity de oluşturduğum class ismi
            OleDbDataReader rdr = cmd.ExecuteReader();
            //cmd nesnesini çalıştırıp daha sonra dönüp tekeer teker okuyup bu kullanicigirisi listesini doldurmamız gerekiyor

            while (rdr.Read())
            {//bütün tablodaki kolonları(alanları) kitapver classımın alanlarına koydum
                kostum_ver kitapver = new kostum_ver();
                kitapver.Tcno = rdr["Tcno"].ToString();
                kitapver.Adi = rdr["Adi"].ToString();
                kitapver.Soyadi = rdr["Soyadi"].ToString();
                kitapver.Telefon = rdr["Telefon"].ToString();
                kitapver.Adres = rdr["Adres"].ToString();
                kitapver.Barkodno = rdr["Barkodno"].ToString();
                kitapver.Kostumadi = rdr["Kostumadi"].ToString();
                kitapver.Sahibi = rdr["Sahibi"].ToString();
                kitapver.Rafno = rdr["Rafno"].ToString();
                kitapver.Verilistarihi = Convert.ToDateTime(rdr["Verilistarihi"]);
                kitapver.Teslimtarihi = Convert.ToDateTime(rdr["Teslimtarihi"]);




                kitapvers.Add(kitapver);
                //int conver.toin() içine yazılır
            }
            return kitapvers;//listeyi geriye döndermiş oldum
        }
        //öğrencinin şuan elinde olan kitap bilgileri çekiyorum
        public List<kostum_ver> TcArama(kostum_ver kitapver)///dalın entity yi referans alması lazım
        {//datatable üzerinde veriileri çekiyorum
            OleDbCommand cmd = Accsessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd.CommandText = "select * from kostum_ver";
            List<kostum_ver> kitapvers = new List<kostum_ver>();//entity de oluşturduğum class ismi
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (kitapver.Tcno == rdr["Tcno"].ToString())
                {
                    kostum_ver kitapver2 = new kostum_ver();
                    kitapver2.Tcno = rdr["Tcno"].ToString();
                    kitapver2.Adi = rdr["Adi"].ToString();
                    kitapver2.Soyadi = rdr["Soyadi"].ToString();
                    kitapver2.Telefon = rdr["Telefon"].ToString();
                    kitapver2.Adres = rdr["Adres"].ToString();
                    kitapver2.Barkodno = rdr["Barkodno"].ToString();
                    kitapver2.Kostumadi = rdr["Kostumadi"].ToString();
                    kitapver2.Sahibi = rdr["Sahibi"].ToString();
                    kitapver2.Rafno = rdr["Rafno"].ToString();
                    kitapver2.Verilistarihi = Convert.ToDateTime(rdr["Verilistarihi"]);
                    kitapver2.Teslimtarihi = Convert.ToDateTime(rdr["Teslimtarihi"]);
                    kitapvers.Add(kitapver2);
                }
            }
            return kitapvers;
        }
        //aranan kitabın kimlerde oldukları çekilir
        public List<kostum_ver> KostumBarkodNoArama(kostum_ver kitapver)
        {//datatable üzerinde veriileri çekiyorum
            OleDbCommand cmd = Accsessconnection.GetOleDbCommand();
            cmd.CommandText = "select * from kostum_ver";
            List<kostum_ver> kitapvers = new List<kostum_ver>();//entity de oluşturduğum class ismi
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (kitapver.Barkodno == rdr["Barkodno"].ToString())
                {//Kitap şaun kimleri elinde onların listesi
                    kostum_ver kitapver2 = new kostum_ver();
                    kitapver2.Tcno = rdr["Tcno"].ToString();
                    kitapver2.Adi = rdr["Adi"].ToString();
                    kitapver2.Soyadi = rdr["Soyadi"].ToString();
                    kitapver2.Telefon = rdr["Telefon"].ToString();
                    kitapver2.Adres = rdr["Adres"].ToString();
                    kitapver2.Barkodno = rdr["Barkodno"].ToString();
                    kitapver2.Kostumadi = rdr["Kostumadi"].ToString();
                    kitapver2.Sahibi = rdr["Sahibi"].ToString();              
                    kitapver2.Rafno = rdr["Rafno"].ToString();
                    kitapver2.Verilistarihi = Convert.ToDateTime(rdr["Verilistarihi"]);
                    kitapver2.Teslimtarihi = Convert.ToDateTime(rdr["Teslimtarihi"]);
                    kitapvers.Add(kitapver2);
                }
            }
            return kitapvers;//listeyi geriye döndermiş oldum
        }
        public List<kostum_ver> BarkodArama(kostum_ver kitapver)///dalın entity yi referans alması lazım
        {//datatable üzerinde veriileri çekiyorum
            OleDbCommand cmd = Accsessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd.CommandText = "select * from kostum_ver where Barkodno='" + kitapver.Barkodno + "' Order by Teslimtarihi ";

            List<kostum_ver> kitapvers = new List<kostum_ver>();//entity de oluşturduğum class ismi
            OleDbDataReader rdr = cmd.ExecuteReader();
            //cmd nesnesini çalıştırıp daha sonra dönüp tekeer teker okuyup bu kullanicigirisi listesini doldurmamız gerekiyor

            while (rdr.Read())
            {//bütün tablodaki kolonları(alanları) kullaniicgirisi classımın alanlarına koydum

                //Kitap kitap = new Kitap();

                if (kitapver.Barkodno == rdr["Barkodno"].ToString())
                {
                    kostum_ver kitapver2 = new kostum_ver();
                    kitapver2.Tcno = rdr["Tcno"].ToString();
                    kitapver2.Adi = rdr["Adi"].ToString();
                    kitapver2.Soyadi = rdr["Soyadi"].ToString();
                    kitapver2.Telefon = rdr["Telefon"].ToString();
                    kitapver2.Adres = rdr["Adres"].ToString();
                    kitapver2.Barkodno = rdr["Barkodno"].ToString();
                    kitapver2.Kostumadi = rdr["Kostumadi"].ToString();
                    kitapver2.Sahibi = rdr["Sahibi"].ToString();           
                    kitapver2.Rafno = rdr["Rafno"].ToString();
                    kitapver2.Verilistarihi = Convert.ToDateTime(rdr["Verilistarihi"]);
                    kitapver2.Teslimtarihi = Convert.ToDateTime(rdr["Teslimtarihi"]);



                    kitapvers.Add(kitapver2);
                }

                //int conver.toin() içine yazılır
            }
            return kitapvers;//listeyi geriye döndermiş oldum
        }
        public List<kostum_ver> TxtSearchDuzenleme(kostum_ver kitapver)
        {//bunu txtboxların içini direk güncelleme yapmak istediği şeyi doldurması için getirdim
            OleDbCommand cmd = Accsessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd.CommandText = "select * from kostum_ver where Barkodno='" + kitapver.Barkodno + "' and Tcno='" + kitapver.Tcno + "'";
            List<kostum_ver> kitapvers = new List<kostum_ver>();//entity de oluşturduğum class ismi
            OleDbDataReader rdr = cmd.ExecuteReader();
            //cmd nesnesini çalıştırıp daha sonra dönüp tekeer teker okuyup bu kullanicigirisi listesini doldurmamız gerekiyor

            if (rdr.Read())
            {

                //if ((rdr["Barkodno"].ToString() == kitapver.Barkodno) && (rdr["Tcno"].ToString() == kitapver.Tcno))
                //{
                kitapver.Barkodno = rdr["Barkodno"].ToString();
                kitapver.Kostumadi = rdr["Kostumadi"].ToString();
                kitapver.Sahibi = rdr["Sahibi"].ToString();
                kitapver.Rafno = rdr["Rafno"].ToString();
                kitapver.Verilistarihi = Convert.ToDateTime(rdr["Verilistarihi"]);

                kitapvers.Add(kitapver);
                //break;
                //}

            }
            return kitapvers;

        }
        //bu katmanda bu fonksiyonda ekleme işlemi yapıyorum ve iş katmanında işlem yapabilmek için buradan iş katmanına değer döndeeriyorum
        public int AddNewItem(kostum_ver kitapver)
        {

            string cmdText = "INSERT INTO [kostum_ver] ([Tcno],[Adi],[Soyadi],[Telefon]," +
                "[Adres],[Barkodno],[Kostumadi],[Sahibi],[Rafno],[Verilistarihi],[Teslimtarihi])";
            cmdText += String.Format(" Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", kitapver.Tcno, kitapver.Adi, kitapver.Soyadi, kitapver.Telefon,
                kitapver.Adres, kitapver.Barkodno, kitapver.Kostumadi, kitapver.Sahibi, kitapver.Rafno, kitapver.Verilistarihi, kitapver.Teslimtarihi);
            //tabloda hangi dergerimin geleceği indexi düngünce yazdım
            //string veya datetime tırnak içinde .Gerisi normal biçimde yani tırnak olmıcak 
            OleDbCommand cmd = Accsessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha           
            OleDbCommand cmd2 = Accsessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd2.CommandText = "select *from musteri";
            OleDbDataReader rdr = cmd2.ExecuteReader();
            OleDbCommand cmd3 = Accsessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd3.CommandText = "select * from kostum";
            OleDbDataReader rdr2 = cmd3.ExecuteReader();
            OleDbCommand cmd4 = Accsessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd4.CommandText = "select * from kostum_ver";
            OleDbDataReader rdr3 = cmd4.ExecuteReader();
            int bir_ogrenci_ayni_kitabi_bir_kez_almali = 0;
            int kitap_adeti = 0;
            while (rdr3.Read())
            {//burada öğrenci aynı kitabı alamışmı diye kontrol ettim
                if ((rdr3["Barkodno"].ToString() == kitapver.Barkodno) && (rdr3["Tcno"].ToString() == kitapver.Tcno))
                {
                    bir_ogrenci_ayni_kitabi_bir_kez_almali += 1;
                }
            }
            OleDbCommand cmdkitapadeti = Accsessconnection.GetOleDbCommand();//tabloyu getirdim okuma işlmei yapıcam
            cmdkitapadeti.CommandText = "select * from kostum where Barkodno='" + kitapver.Barkodno + "' and Adet<=0";//elimizde verebileceğimiz kitap var mı diye kontruol ediyorum
            OleDbDataReader rdrkitapadeti = cmdkitapadeti.ExecuteReader();
            //burada iş katmanının görevlerini yapmıyorum burada iş katmanında yapıcağım işler için sayı dönderiyorum
            if (rdrkitapadeti.Read())//sadece bir veriyi okuma için yaptım
            {//elimizde kitap yok ise dışarda hata vermek için
                kitap_adeti = 11;
            }
            int sayi = 0;
            if (bir_ogrenci_ayni_kitabi_bir_kez_almali > 0)
            {//eger oğrenci kitabı daha önce aldıysa hala elindeyse öğrenciye aynı ktap verilemez
                sayi = 5;
            }
            else if (kitap_adeti == 11)
            {
                sayi = 11;
            }
            else
            {
                while (rdr.Read())
                {
                    if ((rdr["Tcno"].ToString() == kitapver.Tcno))
                    {//kayıtlı öğrenci varmı 
                        sayi += 1;
                    }
                }
                while (rdr2.Read())
                {
                    if ((rdr2["Barkodno"].ToString() == kitapver.Barkodno))
                    {//kütüphanede kayıtlı kitap varmı
                        sayi += 3;
                    }
                }
                if (sayi == 4)
                {//sayıyı tutuyorum çünkü kayıtlı kitab veya öğrenci olammış olabilir eger 4 ise ikiside var 
                    cmd.CommandText = cmdText;
                    cmd.ExecuteNonQuery();
                }
            }
            return sayi;
        }
        public int DeleteItem(kostum_ver kitapver)
        {//silme işlemi
            OleDbCommand cmd = Accsessconnection.GetOleDbCommand();
            //Eğer tc gitap idae etmek istenen kişinin tc kimlik numarası ile barkodnumarası aynı olan kitap geri iade edilsin
            cmd.CommandText = string.Format("Delete From kostum_ver where Tcno='" + kitapver.Tcno + "' and Barkodno='" + kitapver.Barkodno + "'");
            return cmd.ExecuteNonQuery();
        }
        public int UpdateItem(kostum_ver kitapver)
        {
            OleDbCommand cmd = Accsessconnection.GetOleDbCommand();
            cmd.CommandText = string.Format("Update kostum_ver set Tcno='" + kitapver.Tcno + "',Adi='" + kitapver.Adi + "',Soyadi='" + kitapver.Soyadi +
                "',Telefon='" + kitapver.Telefon + "',Adres='" + kitapver.Adres +
                "',Barkodno='" + kitapver.Barkodno + "',Kostumadi='" + kitapver.Kostumadi +
                "',Sahibi='" + kitapver.Sahibi +
                "',Rafno='" + kitapver.Rafno + "',Verilistarihi='" + kitapver.Verilistarihi +
                "',Teslimtarihi='" + kitapver.Teslimtarihi +


                "'where Tcno='" + kitapver.Tcno + "'");

            return cmd.ExecuteNonQuery();


        }




    }
}
