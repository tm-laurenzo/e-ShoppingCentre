using Newtonsoft.Json;
using EshoppingCenter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EshoppingCenter.DataStore
{
    public class Seeder
    {

        public Seeder(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public async Task SeedData(EcommerceContext context)
        {
            

            try
            {
                //Category
                //var dirDb = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                context.Database.EnsureCreated();
                if (context.Category.Any() == false)
                {
                    var data = File.ReadAllText(Path.Combine(WebHostEnvironment.WebRootPath,  "JsonFiles", "Category.json"));
                    var listOfCategoryObj = JsonConvert.DeserializeObject<List<Category>>(data);

                    await context.Category.AddRangeAsync(listOfCategoryObj);

                    await context.SaveChangesAsync();
                }
             
                //Product
                context.Database.EnsureCreated();
                if (context.Product.Any() == false)
                {
                    var data = File.ReadAllText(Path.Combine(WebHostEnvironment.WebRootPath, "JsonFiles", "Product.json"));
                    var listOfProductObj = JsonConvert.DeserializeObject<List<Product>>(data);

                    await context.Product.AddRangeAsync(listOfProductObj);

                    await context.SaveChangesAsync();
                }

               
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex + " Is the error thrown at seeder");
            }
        }

    }
}
