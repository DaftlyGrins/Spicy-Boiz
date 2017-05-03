using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace davidsProperties.Models
{
    public class Property
    {
        public int ID { get; set; }
        public int postcode { get; set; }
        public string address { get; set; }
        public decimal rent { get; set; }
    }
}