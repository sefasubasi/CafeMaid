﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMaid.Models
{
    public class urunModel
    {

        private int id;
        private string urunAdi;
        private int kategoriId;
        private string urunAciklama;
        private float urunFiyat;

        public urunModel()
        {
        }

        public urunModel(int id, string urunAdi, int kategoriId, string urunAciklama, float urunFiyat)
        {
            this.id = id;
            this.urunAdi = urunAdi;
            this.kategoriId = kategoriId;
            this.urunAciklama = urunAciklama;
            this.urunFiyat = urunFiyat;
        }

        public int Id { get => id; set => id = value; }
        public string UrunAdi { get => urunAdi; set => urunAdi = value; }
        public int KategoriId { get => kategoriId; set => kategoriId = value; }
        public string UrunAciklama { get => urunAciklama; set => urunAciklama = value; }
        public float UrunFiyat { get => urunFiyat; set => urunFiyat = value; }
    }
}