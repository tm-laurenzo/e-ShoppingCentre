using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EshoppingCenter.Models
{
    public class Product
    {
     
        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image { get; set; }

    }
}
 