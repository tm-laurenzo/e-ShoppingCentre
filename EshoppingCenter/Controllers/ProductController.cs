using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshoppingCenter.DataStore;
using EshoppingCenter.Models;


namespace EshoppingCenter.Controllers
{
    public class ProductController : Controller
    {
        private readonly EcommerceContext _ecommerceContext;

        public ProductController(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productObjectList = _ecommerceContext.Product;
            ViewBag.category = _ecommerceContext.Category;
            return View(productObjectList);
        }

        public IActionResult ProductDetails(string id)
        {
            var product = _ecommerceContext.Product
                .FirstOrDefault(x => x.Id == id);

            return View(product);
        }

        [HttpGet]
        public IActionResult ProductByCategory(string name)
        {
            if (name == "All" || name == null)
            {
                return RedirectToAction("Index");

            }
            string id = "";
            IEnumerable<Category> categoryObjectList = _ecommerceContext.Category;
            foreach (var item in categoryObjectList)
            {
                if(name == item.Name)
                {
                    id = item.Id;
                }
            }
            IEnumerable<Product> productObjectList = _ecommerceContext.Product
                .Where(x => x.CategoryId == id);

            return View(productObjectList);
        }
    }
}
