using MvcByAliAzavi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcByAliAzavi.Controllers
{
  public class CategoryController : Controller
  {
    // GET: Category
    public ActionResult Index()
    {
      var categories = new List<Category>();
      categories.Add(new Category { CategoryId = 1, CategoryName = "Laptop" });
      categories.Add(new Category { CategoryId = 1, CategoryName = "Software" });
      categories.Add(new Category { CategoryId = 1, CategoryName = "Accessories" });

      return View(categories);
    }

  }
}