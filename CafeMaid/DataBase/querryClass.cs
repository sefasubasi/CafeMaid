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
                SqlDataReader reader;
                if (dataCon.con.State == ConnectionState.Closed)
                {
                    dataCon.con.Open();
                }
                cmd.Connection = dataCon.con;
                cmd.CommandText ="declare @userId as int; " +
"set @userId=(select id from KullaniciTable where kullaniciAdi=@kullaniciAdi) " +
"if (@userId is null) " +
"begin " +
"insert into KullaniciTable(kullaniciAdi,Sifre) OUTPUT inserted.id  values  (@kullaniciAdi,@sifre) " +
"end; " +
"else if(@userId!=0) " +
"begin " +
"declare @s Table( id  int)   " +
"select* from @s " +
"end; ";


                cmd.Parameters.AddWithValue("@kullaniciAdi", userModel.KullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", userModel.Sifre);//

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataCon.con.Close();
                    return true;
                }

                dataCon.con.Close();
                return false;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
//            cmd.CommandText = "declare @userId as int; " +
//"set @userId=(select id from KullaniciTable where kullaniciAdi=@kullaniciAdi) " +
//"if (@userId is null) " +
//"begin " +
//"insert into KullaniciTable(kullaniciAdi,Sifre) OUTPUT inserted.id  values  (@kullaniciAdi,@sifre) " +
//"end; " +
//"else if(@userId!=0) " +
//"begin " +
//"declare @s Table( id  int)   " +
//"select* from @s " +
//"end; ";

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





        public int ActiveSiparisNo(string kAdi)
        {
            int temp = -1;

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
                cmd.CommandText = "select id from SiparisTable   WHERE   userId=(select id from KullaniciTable where kullaniciAdi=@kAdi) and siparisState='false'";
                cmd.Parameters.AddWithValue("@kAdi", kAdi);


                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    temp = Convert.ToInt32(String.Format("{0}", dr["id"]));
                    dataCon.con.Close();
                    return temp;
                }
                dr.Close();
                return temp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return temp;
            }

        }

        public int createOrder(string kAdi,string siparisNo)
        {
            try
            {

                //   MessageBox.Show(faturaToStokModel.FaturaId + " " + faturaToStokModel.StokId + " " + faturaToStokModel.Adet);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                if (dataCon.con.State == ConnectionState.Closed)
                {
                    dataCon.con.Open();
                }
                cmd.Connection = dataCon.con;
                cmd.CommandText = "insert into SiparisTable(userId,siparisNo,siparisDate,siparisState) OUTPUT inserted.id values ((select id from KullaniciTable where  kullaniciAdi=@userName),@siparisNo,@siparisDate,@siparisState)";

                cmd.Parameters.AddWithValue("@userName", kAdi);

                cmd.Parameters.AddWithValue("@siparisNo", siparisNo);
                cmd.Parameters.AddWithValue("@siparisDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@siparisState", false);



              reader=  cmd.ExecuteReader();
                int Id=-1;
                while (reader.Read())
                {
                     Id = Convert.ToInt32((String.Format("{0}", reader["id"])));

                }

                dataCon.con.Close();
                return Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }

        }


        public Boolean insertOrderItem(int siparisNo, int urunId,int urunAdet)
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
                // cmd.CommandText = "insert into SiparisToUrunTable(siparisId,urunId,urunAdet) values (@siparisId,@urunId,@urunAdet)";
                cmd.CommandText = "declare @sTUId as int; " +
"set @sTUId=-1; " +
"set @sTUId=(select id from SiparisToUrunTable where siparisId=@siparisId and urunId=@urunId) " +
"if (@sTUId is null) " +
"begin " +
"insert into SiparisToUrunTable(siparisId,urunId,urunAdet) values (@siparisId,@urunId,@urunAdet) " +
"end; " +
"else if(@sTUId!=-1) " +
"begin " +
"update SiparisToUrunTable set urunAdet+=@urunAdet where id=@sTUId; " +
"end; ";



                cmd.Parameters.AddWithValue("@siparisId", siparisNo);
                cmd.Parameters.AddWithValue("@urunId", urunId);
                cmd.Parameters.AddWithValue("@urunAdet", urunAdet);


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
                urun.UrunImage = (String.Format("{0}", reader["urunImage"]));




                urunList.Add(urun);
                //settingsCihazMarkaCombo.Items.Add(sonuc1);

            }
            //textBox1.Text = sonuc + "  " + sonuc1;
            dataCon.con.Close();
            return urunList;
        }


        public List<urunModel> urunListesi(int kategoriId)
        // public List<urunModel> stokListesi(int type, string search)
        {
            List<urunModel> urunList = new List<urunModel>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select * from urunTable where urunKategoriId=@kategoriId";
            cmd.Parameters.AddWithValue("@kategoriId", kategoriId);


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
                urun.UrunAciklama = (String.Format("{0}", reader["urunAciklama"]));
                urun.UrunFiyat = (float)Convert.ToDouble((String.Format("{0}", reader["urunFiyat"])));
                urun.UrunImage = (String.Format("{0}", reader["urunImage"]));





                urunList.Add(urun);
                //settingsCihazMarkaCombo.Items.Add(sonuc1);

            }
            //textBox1.Text = sonuc + "  " + sonuc1;
            dataCon.con.Close();
            return urunList;
        }

        public List<urunModel> sepetListesi(string Kadi)
        // public List<urunModel> stokListesi(int type, string search)
        {
            List<urunModel> urunList = new List<urunModel>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            //cmd.CommandText = "select Distinct STU.id as siId, U.*,STU.urunAdet from UrunTable U,SiparisToUrunTable STU " +
            //"where U.id=STU.urunId and U.id in( " +
            //"select urunId from SiparisToUrunTable where siparisId in  " +
            //"(select ST.id from SiparisTable ST,KullaniciTable K " +
            //"where St.userId=K.id and St.siparisState=0 and K.kullaniciAdi=@kAdi )) ";


            cmd.CommandText = "select Distinct STU.id as siId, U.*,STU.urunAdet  " +
            "from UrunTable U, " +
            "SiparisToUrunTable STU, " +
            "SiparisTable ST, " +
            "KullaniciTable K " +
            "where " +
            "U.id=STU.urunId and St.userId=K.id and St.siparisState=0 and K.kullaniciAdi=@kAdi " +
            "and siparisId=ST.id ";

            cmd.Parameters.AddWithValue("@kAdi", Kadi);


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
                urun.Id = Convert.ToInt32((String.Format("{0}", reader["siId"])));
                urun.UrunAdi = (String.Format("{0}", reader["urunAdi"]));
                urun.KategoriId = Convert.ToInt32((String.Format("{0}", reader["urunKategoriId"])));
                urun.UrunAciklama = (String.Format("{0}", reader["urunAciklama"]));
                urun.UrunFiyat = (float)Convert.ToDouble((String.Format("{0}", reader["urunFiyat"])));
                urun.UrunImage = (String.Format("{0}", reader["urunImage"]));
                urun.UrunAdet = (int)Convert.ToInt32((String.Format("{0}", reader["urunAdet"])));




                urunList.Add(urun);
                //settingsCihazMarkaCombo.Items.Add(sonuc1);

            }
            //textBox1.Text = sonuc + "  " + sonuc1;
            dataCon.con.Close();
            return urunList;
        }


        public Boolean updateUrunAdet(int urunId, int urunAdet)
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
                if (urunAdet>0)
                {
                    cmd.CommandText = "update SiparisToUrunTable set urunAdet=@urunAdet where id=@urunId";

                }
                else
                {
                    cmd.CommandText = "delete from SiparisToUrunTable where  id=@urunId";

                }

                cmd.Parameters.AddWithValue("@urunId", urunId);
                cmd.Parameters.AddWithValue("@urunAdet", urunAdet);


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
        public Boolean odemeYap(string kAdi)
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
             

                    cmd.CommandText = "update SiparisTable set siparisState=1 where id=" +
                    "(select id from SiparisTable where siparisState=0 and userId = (select id from KullaniciTable where kullaniciAdi = @kAdi))";



                cmd.Parameters.AddWithValue("@kAdi", kAdi);


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

        public List<urunModel> arananUrunListesi(string aranan)
        // public List<urunModel> stokListesi(int type, string search)
        {
            List<urunModel> urunList = new List<urunModel>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select * from UrunTable where urunAciklama Like '%"+aranan+"%' or urunAdi Like '%"+aranan+"%'";
           


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
                urun.UrunAciklama = (String.Format("{0}", reader["urunAciklama"]));
                urun.UrunFiyat = (float)Convert.ToDouble((String.Format("{0}", reader["urunFiyat"])));
                urun.UrunImage = (String.Format("{0}", reader["urunImage"]));




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