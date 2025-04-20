using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kostum_kiralama1.DAL;
using kostum_kiralama1.Entity;

namespace kostum_kiralama1.BLL
{
    public class kostum_verBLL
    {
        kostum_verDAL KostumverDAL;
        public kostum_verBLL()
        {
            KostumverDAL = new kostum_verDAL();
        }
        public List<kostum_ver> GetAllItems()
        {
            return KostumverDAL.GetAllItems();
            //BLL gidip getallitem metodu tetiklendiğinde gidip kitapverDAL a gidip getallaitem metodu çağırı geri dönderdi
        }
        public int AddNewItem(kostum_ver Kostumver)
        {
            int sonuc = 0;
            if ((Kostumver.Tcno == "") && (Kostumver.Barkodno == ""))
            {
                throw new Exception("Lüften Tc kimlik numarası ve Barkod numarası alanlarını giriniz!!");
            }
            else if (Kostumver.Barkodno == "")
            {
                throw new Exception("Lütfen Barkod numarası kısmını boş bırakmayınız.");
            }
            else if (Kostumver.Tcno == "")
            {
                throw new Exception("Lütfen öğrenci TC kimlik numarasını giriniz.");
            }
            else
            {
                sonuc = KostumverDAL.AddNewItem(Kostumver);//sıralamaya dikkat et
                if (sonuc != 11 && sonuc != 5 && sonuc != 4)
                {
                    if (sonuc == 1)
                    {
                        throw new Exception("Kütüphanemizde girdiğiniz barkod numarasına kayıtlı kitap bulunmamaktadır.");
                    }
                    else if (sonuc == 3)
                    {
                        throw new Exception("Kütüphanemizde Kayıtlı öğrenci bulumamaktatır.");
                    }
                    else
                    {
                        throw new Exception("Kütüphanemizde Kayıtlı öğrenci ve kayıtlı kitap bulunmamaktadır.");
                    }
                }
                else if (sonuc == 5)
                {
                    throw new Exception("Aynı öğrenci bir kitabı birden fazla kez alamaz.");
                }

            }
            return sonuc;
        }
        public List<kostum_ver> TcArama(kostum_ver Kostumver)
        {
            return KostumverDAL.TcArama(Kostumver);
            //BLL gidip TcArama metodu tetiklendiğinde gidip kitapverDAL a gidip TcArama metodu çağırı geri dönderdi
        }
        public List<kostum_ver> KostumBarkodNoArama(kostum_ver Kostumver)
        {
            return KostumverDAL.KostumBarkodNoArama(Kostumver);
            //BLL gidip KitaapBarkodNoArama metodu tetiklendiğinde gidip kitapverDAL a gidip KitaapBarkodNoArama metodu çağırı geri dönderdi
        }
        public List<kostum_ver> TxtSearchDuzenleme(kostum_ver Kostumver)
        {
            return KostumverDAL.TxtSearchDuzenleme(Kostumver);
        }
        public List<kostum_ver> BarkodArama(kostum_ver Kostumver)
        {
            return KostumverDAL.KostumBarkodNoArama(Kostumver);
            //BLL gidip BarkodArama metodu tetiklendiğinde gidip kitapverDAL a gidip BarkodArama metodu çağırı geri dönderdi
        }
        public int DeleteItem(kostum_ver Kostumver)
        {
            return KostumverDAL.DeleteItem(Kostumver);
        }
        public int UpdateItem(kostum_ver Kostumver)
        {
            return KostumverDAL.UpdateItem(Kostumver);
        }
    }
}

    

