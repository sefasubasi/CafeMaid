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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static List<urunModel> GetUrunList(string str)
        {
            List<urunModel> testObj = new List<urunModel>();
            querryClass q = new querryClass();

            testObj = q.urunListesi();



            return testObj;
        }


        [WebMethod]
        public static List<kategoriModel> GetKategoriList()
        {
            List<kategoriModel> testObj = new List<kategoriModel>();
            querryClass q = new querryClass();

            testObj = q.kategoriListesi();



            return testObj;
        }


    }
}