using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMaid.Models
{
    public class siparisModel
    {

        int id;
        int userId;
        string siparisNo;
        DateTime siparisDate;
        bool siparisState;

        public siparisModel()
        {
        }

        public siparisModel(int id, int userId, string siparisNo, DateTime siparisDate, bool siparisState)
        {
            this.id = id;
            this.userId = userId;
            this.siparisNo = siparisNo;
            this.siparisDate = siparisDate;
            this.siparisState = siparisState;
        }

        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public DateTime SiparisDate { get => siparisDate; set => siparisDate = value; }
        public bool SiparisState { get => siparisState; set => siparisState = value; }
    }
}