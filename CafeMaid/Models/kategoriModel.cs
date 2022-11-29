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
    }
}