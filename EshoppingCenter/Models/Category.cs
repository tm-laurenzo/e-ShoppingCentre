using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EshoppingCenter.Models;

namespace EshoppingCenter.Models
{
    public class Category
    {
       public string Id { get; set; }
       public string Name { get; set; }
       public  ICollection<Product> ListOfProducts { get; set; }


    }
}
