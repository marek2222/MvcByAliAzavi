using MvcByAliAzavi.Data;
using MvcByAliAzavi.Models;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace MvcByAliAzavi.Controllers
{
  public class ProductsController : Controller
  {
    private LearningContext db = new LearningContext();


    public ActionResult Index(ProductSearchModels model)
    {
      // To Bind the category drop down in search section
      ViewBag.Categories = db.Categories.Where(x => x.IsActive == true);

      // Get Products
      model.Products = db.Products
          .Where(
              x =>
              (model.ProductName == null || x.ProductName.Contains(model.ProductName))
              && (model.Price == null || x.Price < model.Price)
              && (model.Category == null || x.CategoryId == model.Category)
             )
          .OrderBy(model.Sort + " " + model.SortDir)
          .Skip((model.Page - 1) * model.PageSize)
          .Take(model.PageSize)
          .ToList();

      // total records for paging
      model.TotalRecords = db.Products
          .Count(x =>
              (model.ProductName == null || x.ProductName.Contains(model.ProductName))
              && (model.Price == null || x.Price < model.Price)
              && (model.Category == null || x.CategoryId == model.Category)
              );

      return View(model);
    }
  }
}