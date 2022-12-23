using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CafeMaid.DataBase;
using CafeMaid.Models;

namespace CafeMaid
{
    public partial class Contact : Page
    {
        querryClass querry = new querryClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            kullanici_sayi.Text = querry.ToplamKullanici().ToString();
            urun_sayi.Text = querry.ToplamUrun().ToString();
            aktif_adisyon_label.Text = querry.aktif_adisyon().ToString();
            tamamlanan_gunluk_adisyon.Text = querry.tamamla_adisyon().ToString();



        }


        [WebMethod]
        public static List <urunModel> urunRapor()
        {
            querryClass querry = new querryClass();
            return querry.urunRapor();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}