using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMaid.Models
{
    public class kategoriModel
    {
        private int id;
        private string value;
        private int adet;

        public kategoriModel()
        {
        }

        public kategoriModel(int id, string value)
        {
            this.id = id;
            this.value = value;
        }

        public int Id { get => id; set => id = value; }
        public string Value { get => value; set => this.value = value; }
        public int Adet { get => adet; set => adet = value; }
    }
}