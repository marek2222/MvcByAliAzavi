using MvcByAliAzavi.Data;
using System.Web.Mvc;

namespace MvcByAliAzavi.Controllers
{
  public class CategoryController : Controller
  {
    // GET: Category
    public ActionResult Index()
    {
      var db = new LearningContext();
      var categories = db.Categories;
      return View(categories);
    }

  }
}