using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using kostum_kiralama1.Entity;

namespace kostum_kiralama1.DAL
{
    public class kostum_iadeDAL
    {
        private accsessconnection Accessconnection;
        public kostum_iadeDAL()
        {
            Accessconnection = new accsessconnection();
        }


        public List<kostum_iade> GetAllItems()
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = "select * from kostum_iade";

            List<kostum_iade> kostumIades = new List<kostum_iade>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                kostum_iade kostumIade = new kostum_iade();
                kostumIade.Tcno = rdr["Tcno"].ToString();
                kostumIade.Adi = rdr["Adi"].ToString();
                kostumIade.Soyadi = rdr["Soyadi"].ToString();
                kostumIade.Telefon = rdr["Telefon"].ToString();
                kostumIade.Adres = rdr["Adres"].ToString();
                kostumIade.Barkodno = rdr["Barkodno"].ToString();
                kostumIade.Kostumadi = rdr["Kostumadi"].ToString();
                kostumIade.Sahibi = rdr["Sahibi"].ToString();
                kostumIade.Rafno = rdr["Rafno"].ToString();
                kostumIade.Verilistarihi = Convert.ToDateTime(rdr["Verilistarihi"]);
                kostumIade.Iadetarihi = Convert.ToDateTime(rdr["Iadetarihi"]);

                kostumIades.Add(kostumIade);
            }
            return kostumIades;
        }

        public List<kostum_iade> TcArama(kostum_iade KostumIade)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = "select * from kostum_iade";

            List<kostum_iade> kostumIades = new List<kostum_iade>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (KostumIade.Tcno == rdr["Tcno"].ToString())
                {
                    kostum_iade kostumIade2 = new kostum_iade();
                    kostumIade2.Tcno = rdr["Tcno"].ToString();
                    kostumIade2.Adi = rdr["Adi"].ToString();
                    kostumIade2.Soyadi = rdr["Soyadi"].ToString();
                    kostumIade2.Telefon = rdr["Telefon"].ToString();
                    kostumIade2.Adres = rdr["Adres"].ToString();
                    kostumIade2.Barkodno = rdr["Barkodno"].ToString();
                    kostumIade2.Kostumadi = rdr["Kostumadi"].ToString();
                    kostumIade2.Sahibi = rdr["Sahibi"].ToString();
                    kostumIade2.Rafno = rdr["Rafno"].ToString();
                    kostumIade2.Verilistarihi = Convert.ToDateTime(rdr["Verilistarihi"]);
                    kostumIade2.Iadetarihi = Convert.ToDateTime(rdr["Iadetarihi"]);

                    kostumIades.Add(kostumIade2);
                }
            }
            return kostumIades;
        }

        public List<kostum_iade> KostumBarkodNoArama(kostum_iade kostumIade)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = "select * from kostum_iade";

            List<kostum_iade> kostumIades = new List<kostum_iade>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (kostumIade.Barkodno == rdr["Barkodno"].ToString())
                {
                    kostum_iade kostumIade2 = new kostum_iade();
                    kostumIade2.Tcno = rdr["Tcno"].ToString();
                    kostumIade2.Adi = rdr["Adi"].ToString();
                    kostumIade2.Soyadi = rdr["Soyadi"].ToString();
                    kostumIade2.Telefon = rdr["Telefon"].ToString();
                    kostumIade2.Adres = rdr["Adres"].ToString();
                    kostumIade2.Barkodno = rdr["Barkodno"].ToString();
                    kostumIade2.Kostumadi = rdr["Kostumadi"].ToString();
                    kostumIade2.Sahibi = rdr["Sahibi"].ToString();
                    kostumIade2.Rafno = rdr["Rafno"].ToString();
                    kostumIade2.Verilistarihi = Convert.ToDateTime(rdr["Verilistarihi"]);
                    kostumIade2.Iadetarihi = Convert.ToDateTime(rdr["Iadetarihi"]);

                    kostumIades.Add(kostumIade2);
                }
            }
            return kostumIades;
        }

        public List<kostum_iade> BarkodArama(kostum_iade kostumIade)
        {
            OleDbCommand cmd = Accessconnection.GetOleDbCommand();
            cmd.CommandText = "select * from kostum_iade";

            List<kostum_iade> kostumIades = new List<kostum_iade>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (kostumIade.Barkodno == rdr["Barkodno"].ToString())
                {
                    kostumIade.Tcno = rdr["Tcno"].ToString();
                    kostumIade.Adi = rdr["Adi"].ToString();
                    kostumIade.Soyadi = rdr["Soyadi"].ToString();
                    kostumIade.Telefon = rdr["Telefon"].ToString();
                    kostumIade.Adres = rdr["Adres"].ToString();
                    kostumIade.Barkodno = rdr["Barkodno"].ToString();
                    kostumIade.Kostumadi = rdr["Kostumadi"].ToString();
                    kostumIade.Sahibi = rdr["Sahibi"].ToString();
                    kostumIade.Rafno = rdr["Rafno"].ToString();
                    kostumIade.Verilistarihi = Convert.ToDateTime(rdr["Verilistarihi"]);
                    kostumIade.Iadetarihi = Convert.ToDateTime(rdr["Iadetarihi"]);

                    kostumIades.Add(kostumIade);
                }
            }
            return kostumIades;
        }

        public int AddNewItem(kostum_iade KostumIade)
        {
            OleDbCommand cmd2 = Accessconnection.GetOleDbCommand();
            cmd2.CommandText = "select * from kostum_ver";
            OleDbDataReader rdr = cmd2.ExecuteReader();
            int sayi = 0;

            while (rdr.Read())
            {
                if ((rdr["Tcno"].ToString() == KostumIade.Tcno) && (rdr["Barkodno"].ToString() == KostumIade.Barkodno))
                {
                    string cmdText = "INSERT INTO [kostum_iade] ([Tcno],[Adi],[Soyadi],[Telefon]," +
                                     "[Adres],[Barkodno],[Kostumadi],[Sahibi],[Rafno],[Verilistarihi],[Iadetarihi])";
                    cmdText += String.Format(" Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", KostumIade.Tcno, KostumIade.Adi, KostumIade.Soyadi, KostumIade.Telefon,
                        KostumIade.Adres, KostumIade.Barkodno, KostumIade.Kostumadi, KostumIade.Sahibi, KostumIade.Rafno, KostumIade.Verilistarihi, KostumIade.Iadetarihi);

                    //tabloda hangi dergerimin geleceği indexi düngünce yazdım
                    //string veya datetime tırnak içinde .Gerisi normal biçimde yani tırnak olmıcak 
                    OleDbCommand cmd = Accessconnection.GetOleDbCommand();
                    cmd.CommandText = cmdText;
                    cmd.ExecuteNonQuery();
                    sayi += 1;//öğrenci bu kitabı almıştır anlamına geliyor yani geri iade işlemi yapılıyor yapıldığı için dışarda hata mesajı vermicem
                }
            }
            return sayi;
        }







    }
}
       



