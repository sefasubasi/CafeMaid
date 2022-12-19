using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace CafeMaid.Models
{
    public class userModel
    {

        private int id;
        private string kullaniciAdi;

        private string ePosta;
        private string telefonNo;
        private bool isAdmin;


        private string sifre;

        public userModel()
        {
        }

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public string KullaniciAdi { get => kullaniciAdi; set => kullaniciAdi = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public int Id { get => id; set => id = value; }
        public string EPosta { get => ePosta; set => ePosta = value; }
        public string TelefonNo { get => telefonNo; set => telefonNo = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        public userModel( string kullaniciAdi, string sifre)
        {

            this.kullaniciAdi = kullaniciAdi;
            this.sifre = sifre;


        }

        public userModel(int id, string kullaniciAdi, string sifre)
        {


            this.id = id;
            this.kullaniciAdi = kullaniciAdi;
            this.sifre = sifre;


        }

        public userModel(int id, string kullaniciAdi, string ePosta, string telefonNo, bool isAdmin, string sifre)
        {
            this.id = id;
            this.kullaniciAdi = kullaniciAdi;
            this.ePosta = ePosta;
            this.telefonNo = telefonNo;
            this.isAdmin = isAdmin;
            this.sifre = sifre;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

    }
}