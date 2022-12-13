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
        
 

        [WebMethod(EnableSession =true)]
        public static bool SepeteUrunEkle(int id,int adet)
        {
        querryClass q = new querryClass();

            string kAdi=HttpContext.Current.Session["kullaniciAdi"].ToString();
            int siparisId = q.ActiveSiparisNo(kAdi);
            
            if (siparisId==-1)
            {

                string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

               string siparisNo = "";


              
                Random rnd = new Random();

                for (int i = 0; i < 8; i++) siparisNo += (a[(rnd.Next() % 62)]);


            

                siparisId =q.createOrder(kAdi, siparisNo);

            }






            return q.insertOrderItem(siparisId, id, adet); 
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
            string kAdi = HttpContext.Current.Session["kullaniciAdi"].ToString();
            querryClass q = new querryClass();

            List<urunModel> testObj = new List<urunModel>();


            testObj = q.sepetListesi(kAdi);



            return testObj;
        }


        [WebMethod]
        public static bool UpdateSepetAdet(int urunId,int adet)
        {
            string kAdi = HttpContext.Current.Session["kullaniciAdi"].ToString();
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