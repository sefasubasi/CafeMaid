using CafeMaid.DataBase;
using CafeMaid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CafeMaid
{
    public partial class Menu : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      
        [WebMethod]
        public static List<urunModel> GetUrunListAll(string str)
        {
            querryClass q = new querryClass();

            List<urunModel> testObj = new List<urunModel>();
            

            testObj = q.urunListesi();



            return testObj;
        }

        [WebMethod]       
        public static List<urunModel> GetUrunList(int kategoriId)
        {

            querryClass q = new querryClass();

            List<urunModel> testObj = new List<urunModel>();
           
            testObj = q.urunListesi(kategoriId);



            return testObj;
        }


        [WebMethod]
        public static List<siparisModel> GetSiparisList(string str)
        {
            querryClass q = new querryClass();

            List<siparisModel> testObj = new List<siparisModel>();


            testObj = q.siparisListesi("user");



            return testObj;
        }
        [WebMethod]
        public static bool UrunEkle(string urunAd, string urunAciklama, string urunFiyat, string urunResim,string selectionId)
        {
            querryClass q = new querryClass();


            urunModel nesne = new urunModel();
            nesne.UrunAdi = urunAd;
            nesne.UrunAciklama = urunAciklama;
            nesne.KategoriId = Convert.ToInt32(selectionId);
            nesne.UrunFiyat = Convert.ToInt32(urunFiyat);
            nesne.UrunImage = urunResim;
           return q.insertUrun(nesne);

        }

        [WebMethod]
        public static bool AddBankKart(string kartSahibi,string kartNo,string kartCvc,string kartSKT)
        {
            querryClass q = new querryClass();


            cardModel card = new cardModel();
            card.KartEtiket = "etiket";
            card.KartSahibi = kartSahibi;
            card.KartNo = kartNo;
            card.KartCvc = kartCvc;
            card.KartSKT = kartSKT;
            card.IsActive = true;

           return  q.addBankKart("user",card);

        }

        [WebMethod]
        public static bool BankKartSil(int kartId)
        {
            querryClass q = new querryClass();

            return q.bankKartSil("user", kartId);
        }

        [WebMethod]
        public static List<cardModel> GetBankKartList(string str)
        {
            querryClass q = new querryClass();

            List<cardModel> testObj = new List<cardModel>();


            testObj = q.bankKartListesi("user");



            return testObj;
        }

        [WebMethod(EnableSession =true)]
        [System.Web.Script.Services.ScriptMethod]
        public static bool SepeteUrunEkle(int id,int adet)
        {
        querryClass q = new querryClass();

            string kAdi = "";
            if (HttpContext.Current.Session["kullaniciAdi"] != null)
            {
                kAdi = HttpContext.Current.Session["kullaniciAdi"].ToString();
                int siparisId = q.ActiveSiparisNo(kAdi);

                if (siparisId == -1)
                {

                    string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                    string siparisNo = "";



                    Random rnd = new Random();

                    for (int i = 0; i < 8; i++) siparisNo += (a[(rnd.Next() % 62)]);

                    siparisId = q.createOrder(kAdi, siparisNo);

                }

                return q.insertOrderItem(siparisId, id, adet);


            }
            else
            {
               
                HttpContext.Current.Response.Redirect("Login.aspx",true);

            }
            return false;
        }

        [WebMethod]
        public static List<kategoriModel> GetKategoriList()
        {
            querryClass q = new querryClass();

            List<kategoriModel> testObj = new List<kategoriModel>();
           

            testObj = q.kategoriListesi();



            return testObj;
        }
        
       [WebMethod]
        public static List<urunModel> GetSepetListesi(string str)
        {
            string kAdi = "";
            if (HttpContext.Current.Session["kullaniciAdi"]!=null)
            {
                 kAdi = HttpContext.Current.Session["kullaniciAdi"].ToString();

            }
            querryClass q = new querryClass();

            List<urunModel> testObj = new List<urunModel>();


            testObj = q.sepetListesi(kAdi);

 

            return testObj;
        }


        [WebMethod]
        public static bool UpdateSepetAdet(int urunId,int adet)
        {
            string kAdi = "";
            if (HttpContext.Current.Session["kullaniciAdi"] != null)
            {
                kAdi = HttpContext.Current.Session["kullaniciAdi"].ToString();

            }
            querryClass q = new querryClass();



            return q.updateUrunAdet(urunId, adet);
            
        }


        [WebMethod]
        public static List<urunModel> GetArananUrun(string aranan)
        {            
            querryClass q = new querryClass();

            List<urunModel> testObj = new List<urunModel>();


            testObj = q.arananUrunListesi(aranan);



            return testObj;
        }


    }
}