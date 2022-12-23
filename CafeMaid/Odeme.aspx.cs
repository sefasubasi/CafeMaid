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
    public partial class Odeme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool OdemeYap(int kartId)
        {
            string kAdi = "";
            if (HttpContext.Current.Session["kullaniciAdi"] != null)
            {
                kAdi = HttpContext.Current.Session["kullaniciAdi"].ToString();

            }
            querryClass q = new querryClass();

            return q.odemeYap(kAdi,kartId); 


        }
    }
}