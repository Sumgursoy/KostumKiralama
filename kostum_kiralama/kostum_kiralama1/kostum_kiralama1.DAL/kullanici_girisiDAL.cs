using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using kostum_kiralama1.Entity;


namespace kostum_kiralama1.DAL
{
    public class kullanici_girisiDAL
    {
        private accsessconnection Accessconnection;
        public kullanici_girisiDAL()
        {
            Accessconnection = new accsessconnection();
        }
        public List<kullanici_girisi> GetAllItems()///dalın entity yi referans alması lazım
        {//datatable üzerinde veriileri çekiyorum
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd.CommandText = "select * from kullanici_girisi";



            //entity katmanından sonra data table işlevini yitirdi
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());

            //return dt;

            List<kullanici_girisi> kullanicigirisis = new List<kullanici_girisi>();//entity de oluşturduğum class ismi
            OleDbDataReader rdr = cmd.ExecuteReader();
            //cmd nesnesini çalıştırıp daha sonra dönüp tekeer teker okuyup bu kullanicigirisi listesini doldurmamız gerekiyor

            while (rdr.Read())
            {//bütün tablodaki kolonları(alanları) kullaniicgirisi classımın alanlarına koydum
                kullanici_girisi Kullanicigirisi = new kullanici_girisi();
                Kullanicigirisi.Kullaniciadi = rdr["Kullaniciadi"].ToString();
                Kullanicigirisi.Sifre = rdr["Sifre"].ToString();
                Kullanicigirisi.Adi = rdr["Adi"].ToString();
                Kullanicigirisi.Soyadi = rdr["Soyadi"].ToString();

                kullanicigirisis.Add(Kullanicigirisi);
                //int conver.toin() içine yazılır
            }
            return kullanicigirisis;//listeyi geriye döndermiş oldum
        }
        public string Arama(kullanici_girisi Kullanici_girisi)///dalın entity yi referans alması lazım
        {//datatable üzerinde veriileri çekiyorum
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();//bağlantı hazır komut yazılmadı daha
            cmd.CommandText = "select * from kullanici_girisi ";
            OleDbDataReader rdr = cmd.ExecuteReader();
            //cmd nesnesini çalıştırıp daha sonra dönüp tekeer teker okuyup bu kullanicigirisi listesini doldurmamız gerekiyor
            string kullaniciadi = "";
            while (rdr.Read())
            {
                if ((rdr["Kullaniciadi"].ToString() == Kullanici_girisi.Kullaniciadi) && (rdr["Sifre"].ToString() == Kullanici_girisi.Sifre))
                {//kullanıcı adı ve şifre doğru ise bana kullanıcı adını ve soyadını dönder.
                    kullaniciadi = rdr["Adi"].ToString() + " " + rdr["Soyadi"].ToString();
                }
            }
            return kullaniciadi;
        }
        public string AddNewItem(kullanici_girisi Kullanicigirisi)
        {
            string cmdText = "INSERT INTO [kullanici_girisi] ([Kullaniciadi],[Sifre],[Adi],[Soyadi])";
            cmdText += String.Format(" Values('{0}','{1}','{2}','{3}')", Kullanicigirisi.Kullaniciadi, Kullanicigirisi.Sifre, Kullanicigirisi.Adi, Kullanicigirisi.Soyadi);
            //tabloda hangi dergerimin geleceği indexi aynı olamak zorumda
            //string veya datetime tırnak içinde .Gerisi normal biçimde yani tırnak olmıcak 
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = cmdText;
            cmd.ExecuteNonQuery();
            return Kullanicigirisi.Adi + " " + Kullanicigirisi.Soyadi;//açılır pencere mesajı için dönderiyorum
        }

        public int DeleteItem(kullanici_girisi Kullanici_girisi)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = string.Format("Delete From kullanici_girisi where Kullaniciadi='" + Kullanici_girisi.Kullaniciadi + "'");
            //{0} ilk paramametre demek
            //kullanıcı adına göre silme

            return cmd.ExecuteNonQuery();
        }

        public int UpdateItem(kullanici_girisi Kullanici_girisi)
        {//guncellemeyi sona bıraktım unutmaaaaaa
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = string.Format("Update kullanici_girisi set Sifre='" + Kullanici_girisi.Sifre + "',Adi='" + Kullanici_girisi.Adi + "',Soyadi='" + Kullanici_girisi.Soyadi + "'where Kullaniciadi='" + Kullanici_girisi.Kullaniciadi + "'");

            return cmd.ExecuteNonQuery();


        }

    }
    }
