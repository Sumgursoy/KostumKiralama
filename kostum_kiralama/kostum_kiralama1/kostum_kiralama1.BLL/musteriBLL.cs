using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kostum_kiralama1.DAL;
using kostum_kiralama1.Entity;

namespace kostum_kiralama1.BLL
{
    public class musteriBLL
    {
        musteriDAL MusteriDAL;
        public musteriBLL()
        {
            MusteriDAL =new musteriDAL();
        }
        public List<musteri> GetAllItems()
        {
            return MusteriDAL.GetAllItems();
            //BLL gidip getallitem metodu tetiklendiğinde gidip kullanci......DAL a gidip getallaitem metodu çağırı geri dönderdi
        }
        public List<musteri> TxtSearchDuzenleme(musteri Musteri)
        {
            return MusteriDAL.TxtSearchDuzenleme(Musteri);
        }
        public bool UyeEkle(musteri uye)
        {
            // İş kuralları: Örneğin alanların boş olup olmadığını kontrol etme
            if (string.IsNullOrWhiteSpace(uye.Tcno) || string.IsNullOrWhiteSpace(uye.Adi) || string.IsNullOrWhiteSpace(uye.Soyadi) ||
                string.IsNullOrWhiteSpace(uye.Telefon) ||
                string.IsNullOrWhiteSpace(uye.Mail))


            {
                throw new Exception("!!!");
            }

            // Eğer iş kuralları sağlanıyorsa veri ekleme işlemini çağır
            return MusteriDAL.UyeEkle(uye);
        }
        public int AddNewItem(musteri Musteri)
        {
            if ((Musteri.Tcno == "") && (Musteri.Adi == "") && (Musteri.Soyadi == "") && (Musteri.Telefon == ""))
            {
                throw new Exception("Lütfen Alanları doldurunuz.");
            }
            else if (Musteri.Tcno == "")
            {
                throw new Exception("Lütfen TC numaranızı giriniz.");
            }
            else if ((Musteri.Adi == ""))
            {
                throw new Exception("Lütfen Adınızı giriniz.");
            }
            else if (Musteri.Soyadi == "")
            {
                throw new Exception("Lütfen Soyadınızı giriniz.");
            }
            else if (Musteri.Telefon == "")
            {
                throw new Exception("Lütfen Telefon numaranızı giriniz.");
            }
            else if (Musteri.Adres == "")
            {
                throw new Exception("Lütfen Adres giriniz.");
            }
            else if (Musteri.Mail == "")
            {
                throw new Exception("Lütfen Mail giriniz.");
            }
            else
            {
                if (Musteri.Tcno.Length != 11)
                {
                    throw new Exception("Geçerli Tc kimlik numarası giriniz.");
                }
                else if (Musteri.Telefon.Length != 10)
                {
                    throw new Exception("Geçerli Telefon numarası giriniz.");
                }
            }
            return MusteriDAL.AddNewItem(Musteri);//sıralama önemli
        }
        public int DeleteItem(musteri Musteri)
        {
            int sayi;
            sayi = MusteriDAL.DeleteItem(Musteri);
            if (Musteri.Tcno == "")
            {
                throw new Exception("Öğrenci TC kimlik numarasını alanını doldurunuz.");
            }
            else if (sayi == 0)
            {
                throw new Exception("Kayıtlı öğrenci bulunmamaktadır. Silme işlemi gerçekleşmedi");
            }
            return sayi;
        }
        public int UpdateItem(musteri Musteri)
        {
            if (Musteri.Tcno == "")
            {
                throw new Exception("Lütfen öğrencinin TC numarasını giriniz.");
            }
            if (Musteri.Tcno.Length != 11)
            {
                throw new Exception("Lütfen geçerli TC kimlik numarası giriniz.");
            }
            else if ((Musteri.Tcno.Length== 11) && (Musteri.Adi == "") && (Musteri.Soyadi == "") && (Musteri.Telefon == ""))
            {
                throw new Exception("Girdiğiniz tc kimlik numarasına ait öğrenci bulunmamaktadır. O yüzden gücelleme yapamazsınız.");
            }
            else if ((Musteri.Adi == ""))
            {
                throw new Exception("Lütfen Adınızı giriniz.");
            }
            else if (Musteri.Soyadi == "")
            {
                throw new Exception("Lütfen Soyadınızı giriniz.");
            }
            else if (Musteri.Telefon == "")
            {
                throw new Exception("Lütfen Telefon numaranızı giriniz.");
            }
            else
            {
                if (Musteri.Telefon.Length != 10)
                {
                    throw new Exception("Geçerli Telefon numarası giriniz.");
                }
            }
            return MusteriDAL.UpdateItem(Musteri);
        }
        public int BorcUpdateItem()
        {
            return MusteriDAL.BorcUpdateItem();
        }
        public int BorcUpdateSifirlama()
        {
            return MusteriDAL.BorcUpdateSifirlama();
        }

    }
}
    

