using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kostum_kiralama1.BLL;
using kostum_kiralama1.DAL;
using kostum_kiralama1.Entity;

namespace kostum_kiralama1.BLL
{
    public class kostum_iadeBLL
    {
        kostum_iadeDAL Kostum_iadeDAL;
       public kostum_iadeBLL()
        {  
         Kostum_iadeDAL = new kostum_iadeDAL();
        }
 public List<kostum_iade> GetAllItems()
    {

        return Kostum_iadeDAL.GetAllItems();
        //BLL gidip getallitem metodu tetiklendiğinde gidip KitapiadeDAL a gidip getallaitem metodu çağırı geri dönderdi
    }
    public int AddNewItem(kostum_iade Kostum_iade)
    {
        int sayi;
        if ((Kostum_iade.Tcno == "") && (Kostum_iade.Barkodno == ""))
        {
            throw new Exception("Lüften Tc kimlik numarası ve Barkod numarası alanlarını giriniz!!");
        }
        else if (Kostum_iade.Barkodno == "")
        {
            throw new Exception("Lütfen Barkod numarası kısmını boş bırakmayınız");
        }
        else if (Kostum_iade.Tcno == "")
        {
            throw new Exception("Lütfen öğrenci TC kimlik numarasını giriniz");
        }
        else
        {
            sayi = Kostum_iadeDAL.AddNewItem(Kostum_iade);//eğer sorgu çalışmadıysa öğrenci bu kitabı almamıştır bilgisi  dönecek
            if (sayi == 0)
            {
                throw new Exception("Öğrencimiz Bu kitabı almamıştır.");
            }
        }
        return sayi;
    }
    public List<kostum_iade> TcArama(kostum_iade Kostum_iade)
    {
        return Kostum_iadeDAL.TcArama(Kostum_iade);
        //BLL gidip TcArama metodu tetiklendiğinde gidip KitapiadeDALL a gidip TcArama metodu çağırı geri dönderdi
    }
    public List<kostum_iade> KostumBarkodNoArama(kostum_iade Kostum_iade)
    {
        return Kostum_iadeDAL.KostumBarkodNoArama(Kostum_iade);
        //BLL gidip KitaapBarkodNoArama metodu tetiklendiğinde gidip KitapiadeDAL a gidip KitaapBarkodNoArama metodu çağırı geri dönderdi
    }
    public List<kostum_iade> BarkodArama(kostum_iade Kostum_iade  )
    {
        return Kostum_iadeDAL.BarkodArama( Kostum_iade);
        //BLL gidip BarkodArama metodu tetiklendiğinde gidip KitapiadeDAL a gidip BarkodArama metodu çağırı geri dönderdi
    }
}
}

       
