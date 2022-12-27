using CafeMaid.DataBase;
using CafeMaid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Description;
using Newtonsoft.Json;

namespace CafeMaid
{
    public partial class Login : System.Web.UI.Page
    {
         
        querryClass querry = new querryClass();
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }



        protected void Button1_Click(object sender, EventArgs e)
        {

            userModel user = new userModel(0, TextBox1.Text, TextBox2.Text);
            user = querry.LoginUser(user);
            if (user!=null)
            {
                Session.Timeout = 10;            
                
                Session.Add("KullaniciAdi", TextBox1.Text);
                Session.Add("Sifre", TextBox2.Text);
                Session.Add("EPosta", user.EPosta);
                Session.Add("TelefonNo", user.TelefonNo);
                Session.Add("IsAdmin", user.IsAdmin);
                Session.Add("Id", user.Id);

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successAlert();", true);
                if (user.IsAdmin)
                {
                    Response.Redirect("Contact.aspx", true);

                }
                else
                {
                    Response.AddHeader("Refresh", "3; url=menu.aspx");
                    //Response.Redirect("Menu.aspx", true);

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "falseAlert();", true);
            }
               

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            userModel user = new userModel(0, TextBox3.Text, TextBox5.Text);
            if (querry.insertUser(user) && TextBox4.Text==TextBox5.Text)
            {
                Session.Timeout = 10;
                Session.Add("KullaniciAdi", TextBox3.Text);
                Session.Add("Sifre", TextBox5.Text);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "trueRegisterAlert();", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "falseRegisterAlert();", true);

            }
        }
    }
}