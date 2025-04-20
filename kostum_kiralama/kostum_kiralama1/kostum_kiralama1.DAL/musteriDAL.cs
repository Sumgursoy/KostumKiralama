using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using kostum_kiralama1.Entity;
using System.Security.Cryptography;

namespace kostum_kiralama1.DAL
{
    public class musteriDAL
    {
        private accsessconnection Accessconnection;
        //new acceesscone.... yapma yapıcı metod altında yapılırmış
        public musteriDAL()
        {
            Accessconnection = new accsessconnection();
        }
       
        public List<musteri> GetAllItems()
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = "SELECT * FROM musteri";

            List<musteri> musteriler = new List<musteri>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                musteri Musteri = new musteri
                {
                    Tcno = rdr["Tcno"].ToString(),
                    Adi = rdr["Adi"].ToString(),
                    Soyadi = rdr["Soyadi"].ToString(),
                    Telefon = rdr["Telefon"].ToString(),
                    Adres = rdr["Adres"].ToString(),
                 //   Borc = Convert.ToInt32(rdr["Borc"])
                   
                };

                musteriler.Add(Musteri);
            }
            return musteriler;
        }

        public List<musteri> TxtSearchDuzenleme(musteri Musteri)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = "SELECT * FROM musteri";

            List<musteri> musteriler = new List<musteri>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (Musteri.Tcno ==rdr["Tcno"].ToString())
                {
                    Musteri.Adi = rdr["Adi"].ToString();
                    Musteri.Soyadi = rdr["Soyadi"].ToString();
                    Musteri.Telefon = rdr["Telefon"].ToString();
                    Musteri.Adres = rdr["Adres"].ToString();
                  //  Musteri.Borc = Convert.ToInt32(rdr["Borc"]);
                  Musteri.Mail= rdr["Mail"].ToString();

                    musteriler.Add(Musteri);
                    break;
                }
            }
            return musteriler;
        }

        public int AddNewItem(musteri Musteri)
        {
            string cmdText = "INSERT INTO [musteri] ([Tcno], [Adi], [Soyadi], [Telefon], [Adres]) " +
                 "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            cmdText = string.Format(cmdText, Musteri.Tcno, Musteri.Adi, Musteri.Soyadi, Musteri.Telefon, Musteri.Adres,Musteri.Mail);


            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = cmdText;

            return cmd.ExecuteNonQuery();
        }

        public int DeleteItem(musteri Musteri)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = string.Format("DELETE FROM musteri WHERE Tcno = '{0}'", Musteri.Tcno);

            return cmd.ExecuteNonQuery();
        }

        public int UpdateItem(musteri Musteri)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = string.Format(
                "UPDATE Musteri SET Adi = '{1}', Soyadi = '{2}', Telefon = '{3}', Adres = '{4}' WHERE Tcno = '{0}'",
                Musteri.Tcno, Musteri.Adi, Musteri.Soyadi, Musteri.Telefon, Musteri.Adres);

            return cmd.ExecuteNonQuery();
            //        {  OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            //        cmd.CommandText = "UPDATE Musteri SET Adi = @Adi, Soyadi = @Soyadi, Telefon = @Telefon, Adres = @Adres WHERE Tcno = @Tcno";

            //            // Parametrelerin eklenmesi
            //            cmd.Parameters.AddWithValue("@Tcno", Musteri.Tcno);
            //            cmd.Parameters.AddWithValue("@Adi", Musteri.Adi);
            //cmd.Parameters.AddWithValue("@Soyadi", Musteri.Soyadi);
            //cmd.Parameters.AddWithValue("@Telefon", Musteri.Telefon);
            //cmd.Parameters.AddWithValue("@Adres", Musteri.Adres);


            // Sorguyu çalıştır ve etkilenen satır sayısını döndür
           // return cmd.ExecuteNonQuery();
        }

        public int BorcUpdateItem()
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = "UPDATE musteri AS m, kostum_ver AS k " +
                              "SET m.Borc = m.Borc + Date() - k.TeslimTarihi " +
                              "WHERE k.TeslimTarihi < #" + DateTime.Now.ToString("yyyy/MM/dd") + "# AND k.Tcno = m.Tcno";

            return cmd.ExecuteNonQuery();
        }
        public bool UyeEkle(musteri uye)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\sumgu\OneDrive\Masaüstü\kostum_kiralama1\kostum_kiralama.accdb;";
            OleDbConnection baglanti = new OleDbConnection(connectionString);
            try
            {
                //sorgu
                string sorgu = "INSERT INTO musteri (Tcno,Adi,Soyadi, Telefon, Mail) " +
                               "VALUES (@Tcno,@Adi,@Soyadi, @Telefon,@Mail)";

               OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Tcno", uye.Tcno);
                komut.Parameters.AddWithValue("@Adi", uye.Adi);
                komut.Parameters.AddWithValue("@Soyadi", uye.Soyadi);
                komut.Parameters.AddWithValue("@Telefon", uye.Telefon);
                komut.Parameters.AddWithValue("@Mail", uye.Mail);
            

                baglanti.Open();
                int result = komut.ExecuteNonQuery();
                return result > 0; // Etkilenen satır sayısı kontrolü
            }
            catch (Exception ex)
            {
                throw new Exception("Veritabanına ekleme sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        public int BorcUpdateSifirlama()
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = "UPDATE musteri SET Borc = 0 WHERE Borc > 0";

            return cmd.ExecuteNonQuery();
        }
    }
}
