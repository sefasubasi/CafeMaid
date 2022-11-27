using CafeMaid.DataBase;
using CafeMaid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (querry.LoginUser(user))
            {
                Response.Write("Basarili.");
            }
            else
            {
                Console.Write("giriş Başarısız.");

            }
        }
    }
}