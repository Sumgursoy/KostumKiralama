using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kostum_kiralama1.DAL;
using kostum_kiralama1.Entity;

namespace kostum_kiralama1.BLL
{
    public class kullanici_girisiBLL
    {
        kullanici_girisiDAL KullanicigirisiDAL;//ataması yapıcı metoda yağılır
        public kullanici_girisiBLL()
        {//ctor tab tab yapıcı metod yapar
            KullanicigirisiDAL = new kullanici_girisiDAL();
        }
        public List<kullanici_girisi> GetAllItems()
        {
            // ilk önce güvenlik önlemleri alınana kodlar
            //Validasyon işlemlerini yapıldığı kodlar


            return KullanicigirisiDAL.GetAllItems();
            //BLL gidip getallitem metodu tetiklendiğinde gidip kullanci......DAL a gidip getallaitem metodu çağırı geri dönderdi

        }
        public string AddNewItem(kullanici_girisi Kullanicigirisi)
        {
            // ilk önce güvenlik önlemleri alınana kodlar
            //Validasyon işlemlerini yapıldığı kodlar
            if ((Kullanicigirisi.Kullaniciadi == "") && (Kullanicigirisi.Adi == "") && (Kullanicigirisi.Soyadi == "") && (Kullanicigirisi.Sifre == ""))
            {
                throw new Exception("Boş alanları doldurunuz.");
            }
            else if (Kullanicigirisi.Kullaniciadi == "")
            {
                throw new Exception("Kullanıcı adını doldurunuz.");
            }
            else if (Kullanicigirisi.Sifre.Length < 3)
            {
                throw new Exception("Sifreniz en az 4 karakter olmalıdır.");
            }
            else if (Kullanicigirisi.Adi == "")
            {
                throw new Exception("Lütfen adınızı giriniz.");
            }
            else if (Kullanicigirisi.Soyadi == "")
            {
                throw new Exception("Lütfen soyadınızı giriniz.");
            }
            return KullanicigirisiDAL.AddNewItem(Kullanicigirisi);//sıralamaya dikkat et
        }
        public string Arama(kullanici_girisi Kullanicigirisi)///dalın entity yi referans alması lazım
        {
            string kullaniciadi = KullanicigirisiDAL.Arama(Kullanicigirisi);
            //kullanıcıadı =
            if ((Kullanicigirisi.Kullaniciadi == "") && (Kullanicigirisi.Sifre == ""))
            {
                throw new Exception("Kullanici adinizi ve şifrenizi giriniz");
            }
            else if (Kullanicigirisi.Kullaniciadi == "")
            {
                throw new Exception("Kullanici adinizi giriniz");
            }
            else if (Kullanicigirisi.Sifre == "")
            {
                throw new Exception("Şifrenizi giriniz");
            }
            else if (kullaniciadi == "")
            {
                throw new Exception("Kullanici adi veya şifreniz yanlış");
            }
            return kullaniciadi;
        }
        public int DeleteItem(kullanici_girisi Kullanicigirisi)
        {
            return KullanicigirisiDAL.DeleteItem(Kullanicigirisi);
        }
        public int UpdateItem(kullanici_girisi Kullanicigirisi)
        {
            return KullanicigirisiDAL.UpdateItem(Kullanicigirisi);
        }
    }
}
    
      

