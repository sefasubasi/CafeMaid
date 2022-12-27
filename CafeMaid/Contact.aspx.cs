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
            //if ((bool)Session["IsAdmin"])
            {
                kullanici_sayi.Text = querry.ToplamKullanici().ToString();
                urun_sayi.Text = querry.ToplamUrun().ToString();
                aktif_adisyon_label.Text = querry.aktif_adisyon().ToString();
                tamamlanan_gunluk_adisyon.Text = querry.tamamla_adisyon().ToString();
            }
           



        }


        [WebMethod]
        public static List <urunModel> urunRapor()
        {
            querryClass querry = new querryClass();
            return querry.urunRapor();
        }


        [WebMethod]
        public static List<kategoriModel> kategoriRapor()
        {
            querryClass querry = new querryClass();
            return querry.kategoriRapor();
        }
        protected void Button3_Click(object sender, EventArgs e)
        { 
            Session.RemoveAll();
            Response.Redirect("login.aspx");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            kategoriModel nesne = new kategoriModel ();
            nesne.Value = TextBox5.Text;
            querry.insertKategori(nesne);
        }
    }
}