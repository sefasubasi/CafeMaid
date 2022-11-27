using CafeMaid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CafeMaid.DataBase
{
    public class querryClass
    {
        ConnectionClass dataCon = new ConnectionClass();

        public querryClass()
        {

        }



        public Boolean insertUser(userModel userModel)
        {
            try
            {

                //   MessageBox.Show(faturaToStokModel.FaturaId + " " + faturaToStokModel.StokId + " " + faturaToStokModel.Adet);
                SqlCommand cmd = new SqlCommand();

                if (dataCon.con.State == ConnectionState.Closed)
                {
                    dataCon.con.Open();
                }
                cmd.Connection = dataCon.con;
                cmd.CommandText = "insert into KullaniciTable(kullaniciAdi,Sifre) values (@kullaniciAdi,@sifre)";
                cmd.Parameters.AddWithValue("@kullaniciAdi", userModel.KullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", userModel.Sifre);//


                cmd.ExecuteNonQuery();
                dataCon.con.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }
        public Boolean LoginUser(userModel userModel)
        {

            try
            {
                //   MessageBox.Show(faturaToStokModel.FaturaId + " " + faturaToStokModel.StokId + " " + faturaToStokModel.Adet);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                if (dataCon.con.State == ConnectionState.Closed)
                {
                    dataCon.con.Open();
                }
                cmd.Connection = dataCon.con;
                cmd.CommandText = "select * from KullaniciTable   WHERE   kullaniciAdi Collate SQL_Latin1_General_CP1254_CS_AS = @kullaniciAdi  and sifre Collate SQL_Latin1_General_CP1254_CS_AS = @sifre";
                cmd.Parameters.AddWithValue("@kullaniciAdi", userModel.KullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", userModel.Sifre);


                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    dataCon.con.Close();
                    return true;
                }
                dr.Close();
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }
    }
}