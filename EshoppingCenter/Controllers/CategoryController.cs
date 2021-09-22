using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshoppingCenter.DataStore;
using EshoppingCenter.Models;

namespace EshoppingCenter.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EcommerceContext _ecommerceContext;

        public CategoryController(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoryObjectList = _ecommerceContext.Category;
            return View();
        }
    }
}
