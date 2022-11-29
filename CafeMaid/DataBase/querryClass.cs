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



        public List<urunModel> urunListesi()
        // public List<urunModel> stokListesi(int type, string search)
        {
            List<urunModel> urunList = new List<urunModel>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select * from urunTable ";


            cmd.CommandType = CommandType.Text;
            cmd.Connection = dataCon.con;


            if (dataCon.con.State == ConnectionState.Closed)
            {

                dataCon.con.Open();

            }

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                urunModel urun = new urunModel();
                urun.Id = Convert.ToInt32((String.Format("{0}", reader["id"])));
                urun.UrunAdi = (String.Format("{0}", reader["urunAdi"]));
                urun.KategoriId = Convert.ToInt32((String.Format("{0}", reader["urunKategoriId"])));
                urun.UrunAciklama= (String.Format("{0}", reader["urunAciklama"]));
                urun.UrunFiyat = (float)Convert.ToDouble((String.Format("{0}", reader["urunFiyat"])));




                urunList.Add(urun);
                //settingsCihazMarkaCombo.Items.Add(sonuc1);

            }
            //textBox1.Text = sonuc + "  " + sonuc1;
            dataCon.con.Close();
            return urunList;
        }




        public List<kategoriModel> kategoriListesi()
        // public List<urunModel> stokListesi(int type, string search)
        {
            List<kategoriModel> kategoriList = new List<kategoriModel>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select * from KategoriTable ";


            cmd.CommandType = CommandType.Text;
            cmd.Connection = dataCon.con;


            if (dataCon.con.State == ConnectionState.Closed)
            {

                dataCon.con.Open();

            }

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                kategoriModel kategori = new kategoriModel();
                kategori.Id = Convert.ToInt32((String.Format("{0}", reader["id"])));
                kategori.Value = (String.Format("{0}", reader["value"]));






                kategoriList.Add(kategori);
                //settingsCihazMarkaCombo.Items.Add(sonuc1);

            }
            //textBox1.Text = sonuc + "  " + sonuc1;
            dataCon.con.Close();

            return kategoriList;
        }




    }
}