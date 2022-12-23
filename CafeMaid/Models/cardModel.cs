using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMaid.Models
{
    public class cardModel
    {
        private int id;
        private string kartEtiket;
        private string kartSahibi;
        private string kartNo;
        private string kartSKT;
        private string kartCvc;
        private bool isActive;

        public cardModel()
        {
        }

        public cardModel(string kartEtiket, string kartSahibi, string kartNo, string kartSKT, string kartCvc, bool isActive)
        {
            this.kartEtiket = kartEtiket;
            this.kartSahibi = kartSahibi;
            this.kartNo = kartNo;
            this.kartSKT = kartSKT;
            this.kartCvc = kartCvc;
            this.isActive= isActive;
        }



        public int Id { get => id; set => id = value; }
        public string KartEtiket { get => kartEtiket; set => kartEtiket = value; }
        public string KartSahibi { get => kartSahibi; set => kartSahibi = value; }
        public string KartNo { get => kartNo; set => kartNo = value; }
        public string KartSKT { get => kartSKT; set => kartSKT = value; }
        public string KartCvc { get => kartCvc; set => kartCvc = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
    }
}