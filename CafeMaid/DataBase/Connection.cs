using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CafeMaid.DataBase
{
    public class ConnectionClass
    {

        public SqlConnection con;
     
        public ConnectionClass()
        {
            try
            {

                //   JObject settingsJSON = (JObject)configFile.readConfig();

                string connString = "Data Source=.; database=CafeMaidDB;Integrated Security=True";


                //string connString = "Data Source=ASUS;database=HizliSatis;Integrated Security=True";


                this.con = new SqlConnection(@connString);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }


        public SqlConnection conn
        {
            get
            {
                return this.con;
            }
            set
            {
                this.con = value;
            }
        }

    }
}