using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using kostum_kiralama1.BLL;
using kostum_kiralama1.DAL;
using kostum_kiralama1.Entity;
using static kostum_kiralama1.BLL.kostumBLL;


namespace kostum_kiralama1.BLL
{
    public class kostumBLL
    {

        kostumDAL Kostumdal;
        public kostumBLL()
        {
            Kostumdal = new kostumDAL();
        }
        public List<kostum> GetAllItems()
        {
            return Kostumdal.GetAllItems();
        }
        public DataTable GetKostumData()
        {
          return Kostumdal.GetKostumData();
        }
        public Tuple<string[], string[], double[]> Grafik()
        {
            return Kostumdal.Grafik();
        }
        public List<kostum> Arama(kostum Kostum)
        {
            if (Kostum.Barkodno == "")
            {
                throw new Exception("Lütfen Barkod numarasını giriniz!!");
            }
            else if (Kostumdal.Arama(Kostum).Count <= 0)
            {
                throw new Exception("Kütüphanemizde kostüm mevcut değil");
            }
            return Kostumdal.Arama(Kostum);
        }
        public List<kostum> KostumAdiArama(kostum Kostum)
        {
            if (Kostum.Kostumadi == "")
            {
                throw new Exception("Lütfen kostüm adını giriniz!!");
            }
            else if (Kostumdal.KostumAdiArama(Kostum).Count <= 0)
            {
                throw new Exception("Kütüphanemizde kostüm mevcut değil");
            }
            return Kostumdal.KostumAdiArama(Kostum);
        }
        public List<kostum> TxtSearchDuzenleme(kostum Kostum)
        {
            return Kostumdal.TxtSearchDuzenleme(Kostum);
        }
        public int AddNewItem(kostum Kostum)
        {
            if ((Kostum.Barkodno == "") && (Kostum.Kostumadi == "") && (Kostum.Sahibi == "") && (Kostum.Rafno == "") )
            {
                throw new Exception("Lütfen Alanları doldurunuz");
            }
            else if (Kostum.Barkodno == "")
            {
                throw new Exception("Lütfen Barkod numarasını giriniz!!");
            }
            else if ((Kostum.Kostumadi == ""))
            {
                throw new Exception("Lütfen Kitap Adını giriniz!!");
            }
            else if (Kostum.Sahibi == "")
            {
                throw new Exception("Lütfen Kitabın Yazarı'nın ismini giriniz!!");
            }

            else if (Kostum.Rafno == "")
            {
                throw new Exception("Lütfen Kitabın raf numarasını  giriniz!!");
            }
            //else if (Kostum.Adet <= 0)
            //{
            //    throw new Exception("Lütfen Geçerli kitap adeti giriniz.");
            //}
            return Kostumdal.AddNewItem(Kostum);//sıralamaya dikkat et
        }
        public int DeleteItem(kostum Kostum)
        {
            int sonuc = Kostumdal.DeleteItem(Kostum);
            if (Kostum.Barkodno == "")
            {
                throw new Exception("Silmek istediğiniz Kitabın Barkod numarasını giriniz");
            }
            else if (sonuc == 0)
            {
                throw new Exception("Kütüphanemizde silmek için girdiğiniz barkod numarasına ait kitap mevcut değildir. Silme işlemi gerçekleşemez.");
            }
            return Kostumdal.DeleteItem(Kostum);
        }
        public int UpdateItem(kostum Kostum)
        {
            if (Kostum.Barkodno == "")
            {
                throw new Exception("Lütfen Barkod numarasını giriniz!!");
            }
            else if ((Kostum.Barkodno != "") && (Kostum.Kostumadi == "") && (Kostum.Sahibi == "") && (Kostum.Rafno == ""))
            {
                throw new Exception("Güncellemek istedğiniz barkod numarasına ait kütüphanemizde kitap bulunmamaktadır.");
            }
            else if ((Kostum.Kostumadi == ""))
            {
                throw new Exception("Lütfen Kitap Adını giriniz!!");
            }
            else if (Kostum.Sahibi == "")
            {
                throw new Exception("Lütfen Kitabın Yazarı'nın ismini giriniz!!");
            }

            else if (Kostum.Rafno == "")
            {
                throw new Exception("Lütfen Kitabın raf numarasını  giriniz!!");
            }
            else if (Kostum.Adet < 0)
            {
                throw new Exception("Lütfen Geçerli kitap adeti giriniz.");
            }
            return Kostumdal.UpdateItem(Kostum);
        }
        public int UpdateKostumadetiazalt(kostum Kostum)
        {
            return Kostumdal.UpdateKostumadetiazalt(Kostum);
        }
        public int UpdateKostumadetiarttir(kostum Kostum)
        {
            return Kostumdal.UpdateKostumadetiarttir(Kostum);
        }
       
            }
        }

      