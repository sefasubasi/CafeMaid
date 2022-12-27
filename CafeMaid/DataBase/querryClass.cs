﻿using CafeMaid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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
"insert into KullaniciTable(kullaniciAdi,ePosta,telefonNo,sifre,isAdmin) OUTPUT inserted.id  values  (@kullaniciAdi,@ePosta,@telefonNo,@sifre,@isAdmin) " +
"end; " +
"else if(@userId!=0) " +
"begin " +
"declare @s Table( id  int)   " +
"select* from @s " +
"end; ";


                cmd.Parameters.AddWithValue("@kullaniciAdi", userModel.KullaniciAdi);
                cmd.Parameters.AddWithValue("@ePosta", userModel.EPosta);
                cmd.Parameters.AddWithValue("@telefonNo", userModel.TelefonNo);
                cmd.Parameters.AddWithValue("@sifre", userModel.Sifre);//
                cmd.Parameters.AddWithValue("@isAdmin", userModel.IsAdmin);


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

        }
        public userModel LoginUser(userModel userModel)
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
                userModel user=new userModel();

                if (dr.Read())
                {
                     user.Id = Convert.ToInt32((String.Format("{0}", dr["id"])));
                    user.KullaniciAdi = (String.Format("{0}", dr["kullaniciAdi"]));
                    user.EPosta = (String.Format("{0}", dr["ePosta"]));
                    user.TelefonNo = (String.Format("{0}", dr["telefonNo"]));
                    user.IsAdmin =(bool) bool.Parse(String.Format("{0}", dr["isAdmin"]));
                    user.Sifre = (String.Format("{0}", dr["sifre"]));

                    dataCon.con.Close();
                    return user;
                }
                dr.Close();
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
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


        public int ToplamKullanici()
        {
            
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            if (dataCon.con.State == ConnectionState.Closed)
            {
                dataCon.con.Open();
            }
            cmd.Connection = dataCon.con;
            cmd.CommandText = "select COUNT(id) as cnt from KullaniciTable";

            dr = cmd.ExecuteReader();
            int temp=-1;
            if(dr.Read())
            {
                temp = Convert.ToInt32(dr["cnt"].ToString());
            }

                dataCon.con.Close();
                return temp;

        }


        public int ToplamUrun()
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            if (dataCon.con.State == ConnectionState.Closed)
            {
                dataCon.con.Open();
            }
            cmd.Connection = dataCon.con;
            cmd.CommandText = " select COUNT(id) as cnt from UrunTable";

            dr = cmd.ExecuteReader();
            int temp = -1;
            if (dr.Read())
            {
                temp = Convert.ToInt32(dr["cnt"].ToString());
            }

            dataCon.con.Close();
            return temp;

        }


        public int aktif_adisyon()
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            if (dataCon.con.State == ConnectionState.Closed)
            {
                dataCon.con.Open();
            }
            cmd.Connection = dataCon.con;
            cmd.CommandText = "select count(*) as cnt from SiparisTable where siparisState=0;";

            dr = cmd.ExecuteReader();
            int temp = -1;
            if (dr.Read())
            {
                temp = Convert.ToInt32(dr["cnt"].ToString());
            }

            dataCon.con.Close();
            return temp;

        }

        public int tamamla_adisyon()
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            if (dataCon.con.State == ConnectionState.Closed)
            {
                dataCon.con.Open();
            }
            cmd.Connection = dataCon.con;
            cmd.CommandText = "select count(*)+1 as cnt from SiparisTable where siparisState=1 and siparisDate=(SELECT CONVERT(char(10), GetDate(),126))";

            dr = cmd.ExecuteReader();
            int temp = -1;
            if (dr.Read())
            {
                temp = Convert.ToInt32(dr["cnt"].ToString());
            }

            dataCon.con.Close();
            return temp;
        }

        public List<urunModel> urunRapor()
        // public List<urunModel> stokListesi(int type, string search)
        {
            List<urunModel> urunList = new List<urunModel>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "declare @table Table(urun_id varchar(50) ,toplam_adet varchar(50) ); " +
                "iNSERT INTO @table(urun_id, toplam_adet) select urunId, SUM(urunAdet) as toplam " +
                "from SiparisToUrunTable group by urunId order by toplam desc " +
                "select U.*, Tm.toplam_adet from UrunTable U, @table Tm where U.id= Tm.urun_id ";


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
                urun.UrunAdet = Convert.ToInt32((String.Format("{0}", reader["toplam_adet"])));




                urunList.Add(urun);
                //settingsCihazMarkaCombo.Items.Add(sonuc1);

            }
            //textBox1.Text = sonuc + "  " + sonuc1;
            dataCon.con.Close();
            return urunList;
        }




        public List<kategoriModel> kategoriRapor()
        // public List<urunModel> stokListesi(int type, string search)
        {
            List<kategoriModel> kategoriList = new List<kategoriModel>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select K.id, K.value,sum(urunAdet) as adet from SiparisToUrunTable STU " +
                " inner join UrunTable U on U.id=STU.urunId " +
                " inner join KategoriTable K on K.id=U.urunKategoriId " +
                " group by K.id,K.value ";


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
                kategori.Adet = Convert.ToInt32((String.Format("{0}", reader["adet"])));




                kategoriList.Add(kategori);
                //settingsCihazMarkaCombo.Items.Add(sonuc1);

            }
            //textBox1.Text = sonuc + "  " + sonuc1;
            dataCon.con.Close();
            return kategoriList;
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
        public Boolean odemeYap(string kAdi,int kartId)
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
             

                    cmd.CommandText = "declare @sId int; " +
"set @sId = (select id from SiparisTable where siparisState=0 and userId = (select id from KullaniciTable where kullaniciAdi = @kAdi )) " +
"update SiparisTable set siparisState=1 where id= " +
"(select id from SiparisTable where siparisState=0 and userId =(select id from KullaniciTable where kullaniciAdi = @KAdi)); " +
"insert into KullaniciToFaturaTable (siparisId,kartId) values ( @sId, @kId ); " +



                cmd.Parameters.AddWithValue("@kAdi", kAdi);
                cmd.Parameters.AddWithValue("@kId", kartId);



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

        public Boolean addBankKart(string kAdi,cardModel cardModel)
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
                cmd.CommandText = "declare @ID table (id int)" +
                    "update  KartTable set isActive='false' " +
"where isActive!='false' and id in ( " +
"select KTK.kartId  " +
"from KullaniciToKartTable KTK, " +
"KullaniciTable K " +
"where K.id=KTK.kullaniciId and " +
"K.kullaniciAdi=@kAdi ) " +
"insert into KartTable (kartEtiket,kartSahibi,kartNo,kartSKT,kartCvc,isActive)" +
" OUTPUT inserted.id into @ID values (@kartEtiket,@kartSahibi,@kartNo,@kartSKT,@kartCvc,@isActive)" +
"insert into KullaniciToKartTable(kullaniciId, kartId) values " +
"((select id from KullaniciTable where kullaniciAdi = @kAdi),(select id from @ID))";



                cmd.Parameters.AddWithValue("@kAdi", kAdi);
                cmd.Parameters.AddWithValue("@kartEtiket", cardModel.KartEtiket);
                cmd.Parameters.AddWithValue("@kartSahibi", cardModel.KartSahibi);
                cmd.Parameters.AddWithValue("@kartNo", cardModel.KartNo);
                cmd.Parameters.AddWithValue("@kartCvc", cardModel.KartCvc);
                cmd.Parameters.AddWithValue("@KartSKT", cardModel.KartSKT);
                cmd.Parameters.AddWithValue("@isActive", cardModel.IsActive);

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
        public Boolean bankKartSil(string kAdi, int kartId)
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
                cmd.CommandText ="if((select isActive from KartTable where id=@kartId)!=0) " +
                                "begin  " +
                                "update  KartTable set isActive='true' " +
                                "where isActive!='true' and id = ( " +
                                "select max(KTK.kartId ) " +
                                "from KullaniciToKartTable KTK, " +
                                "KullaniciTable K, " +
                                "KartTable KT " +
                                "where  KT.id=KTK.kartId  and KT.isActive='false' and K.id=KTK.kullaniciId and " +
                                "K.kullaniciAdi='user' ) " +
                                "end; " +
                                "delete from KullaniciToKartTable where  kartId=@kartId and kullaniciId=(select id from KullaniciTable where kullaniciAdi=@kAdi); " +
                                "delete from KartTable where id=@kartId; ";





                cmd.Parameters.AddWithValue("@kAdi", kAdi);
                cmd.Parameters.AddWithValue("@kartId", kartId);



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
        public List<cardModel> bankKartListesi(string kAdi)
        // public List<urunModel> stokListesi(int type, string search)
        {
            List<cardModel> cardList = new List<cardModel>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText ="select * from KartTable " +
"where id in ( " +
"select KTK.kartId  " +
"from KullaniciToKartTable KTK, " +
"KullaniciTable K " +
"where K.id=KTK.kullaniciId and " +
"K.kullaniciAdi=@kAdi ) ";

            cmd.Parameters.AddWithValue("@kAdi", kAdi);


            cmd.CommandType = CommandType.Text;
            cmd.Connection = dataCon.con;


            if (dataCon.con.State == ConnectionState.Closed)
            {

                dataCon.con.Open();

            }

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                cardModel card = new cardModel();
                card.Id = Convert.ToInt32((String.Format("{0}", reader["id"])));
                card.KartEtiket = (String.Format("{0}", reader["kartEtiket"]));
                card.KartSahibi =(String.Format("{0}", reader["kartSahibi"]));
                card.KartNo = (String.Format("{0}", reader["kartNo"]));
                card.KartSKT = (String.Format("{0}", reader["kartSKT"]));
                card.KartCvc = (String.Format("{0}", reader["kartCvc"]));
                card.IsActive = (bool)bool.Parse(String.Format("{0}", reader["isActive"]));





                cardList.Add(card);
                //settingsCihazMarkaCombo.Items.Add(sonuc1);

            }
            //textBox1.Text = sonuc + "  " + sonuc1;
            dataCon.con.Close();
            return cardList;
        }

        public List<siparisModel> siparisListesi(string kAdi)
        // public List<urunModel> stokListesi(int type, string search)
        {
            List<siparisModel> siparisList = new List<siparisModel>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select * from SiparisTable  where siparisState='true' and  " +
"userId=(select id from KullaniciTable where kullaniciAdi=@kAdi) ";

            cmd.Parameters.AddWithValue("@kAdi", kAdi);


            cmd.CommandType = CommandType.Text;
            cmd.Connection = dataCon.con;


            if (dataCon.con.State == ConnectionState.Closed)
            {

                dataCon.con.Open();

            }

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                siparisModel siparis = new siparisModel();
                siparis.Id = Convert.ToInt32((String.Format("{0}", reader["id"])));
                siparis.UserId = Convert.ToInt32(String.Format("{0}", reader["userId"]));
                siparis.SiparisNo= (String.Format("{0}", reader["siparisNo"]));
                siparis.SiparisDate = DateTime.Parse(String.Format("{0}", reader["siparisDate"]));  
                siparis.SiparisState= (bool)bool.Parse(String.Format("{0}", reader["siparisState"]));





                siparisList.Add(siparis);
                //settingsCihazMarkaCombo.Items.Add(sonuc1);

            }
            //textBox1.Text = sonuc + "  " + sonuc1;
            dataCon.con.Close();
            return siparisList;
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




        public Boolean insertKategori(kategoriModel model)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();

                if (dataCon.con.State == ConnectionState.Closed)
                {
                    dataCon.con.Open();
                }
                cmd.Connection = dataCon.con;
                cmd.CommandText = "INSERT INTO KategoriTable(value) VALUES (@value)";


                cmd.Parameters.AddWithValue("@value", model.Value);


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


        public Boolean insertUrun(urunModel model)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();

                if (dataCon.con.State == ConnectionState.Closed)
                {
                    dataCon.con.Open();
                }
                cmd.Connection = dataCon.con;
                cmd.CommandText = "INSERT INTO UrunTable(urunAdi,urunKategoriId,urunAciklama,urunFiyat,urunImage) VALUES (@urunadi,@kategoriid,@urunaciklama,@urunfiyat,@urunimage)";
                cmd.Parameters.AddWithValue("@urunadi", model.UrunAdi);
                cmd.Parameters.AddWithValue("@kategoriid", model.KategoriId);
                cmd.Parameters.AddWithValue("@urunaciklama", model.UrunAciklama);
                cmd.Parameters.AddWithValue("@urunfiyat", model.UrunFiyat);
                cmd.Parameters.AddWithValue("@urunimage", model.UrunImage);




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


    }
}


