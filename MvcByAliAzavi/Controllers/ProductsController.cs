using MvcByAliAzavi.Data;
using MvcByAliAzavi.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace MvcByAliAzavi.Controllers
{
  public class ProductsController : Controller
  {
    private LearningContext db = new LearningContext();

    // GET: Products
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


    // GET: Products/Create
    public ActionResult Create()
    {
      // To Bind the category drop down in search section
      ViewBag.Categories = db.Categories.Where(x => x.IsActive == true);
      var model = new ProductModel();
      return View(model);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ProductModel model)
    {
      var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
      if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
      {
        ModelState.AddModelError("ImageUpload", "This field is required");
      }
      else if (!imageTypes.Contains(model.ImageUpload.ContentType))
      {
        ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
      }

      if (ModelState.IsValid)
      {
        var product = new Product();
        product.ProductName = model.ProductName;
        product.Price = model.Price;
        product.CategoryId = model.CategoryId;

        // Save image to folder and get path
        var imageName = String.Format("{0:yyyyMMdd-HHmmssfff}", DateTime.Now);
        var extension = System.IO.Path.GetExtension(model.ImageUpload.FileName).ToLower();
        using (var img = System.Drawing.Image.FromStream(model.ImageUpload.InputStream))
        {
          product.Image = String.Format("/ProductImages/{0}{1}", imageName, extension);
          product.Thumb = String.Format("/ProductImages/{0}_thumb{1}", imageName, extension);

          // Save thumbnail size image, 100 x 100
          SaveToFolder(img, extension, new Size(100, 100), product.Thumb);

          // Save large size image, 600 x 600
          SaveToFolder(img, extension, new Size(600, 600), product.Image);
        }

        db.Products.Add(product);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      // If any error return back to the page
      ViewBag.Categories = db.Categories.Where(x => x.IsActive == true);
      return View(model);
    }


    // GET: Products/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Product product = db.Products.Find(id);
      if (product == null)
      {
        return HttpNotFound();
      }

      ViewBag.Categories = db.Categories.Where(x => x.IsActive == true);
      return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,CategoryId")] Product model)
    {
      if (ModelState.IsValid)
      {
        var product = db.Products.Find(model.ProductId);
        if (product == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        product.ProductName = model.ProductName;
        product.Price = model.Price;
        product.CategoryId = model.CategoryId;
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.Categories = db.Categories.Where(x => x.IsActive == true);
      return View(model);
    }


    // GET: Products/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Product product = db.Products.Find(id);
      if (product == null)
      {
        return HttpNotFound();
      }
      ViewBag.Category = db.Categories.Find(product.CategoryId).CategoryName;
      return View(product);
    }


    // GET: Products/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      Product product = db.Products.Find(id);
      if (product == null)
        return HttpNotFound();

      ViewBag.Category = db.Categories.Find(product.CategoryId).CategoryName;
      return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Product product = db.Products.Find(id);
      db.Products.Remove(product);
      db.SaveChanges();
      return RedirectToAction("Index");
    }




    private void SaveToFolder(Image img, string extension, Size newSize, string pathToSave)
    {
      // Get new resolution
      Size imgSize = NewImageSize(img.Size, newSize);
      using (System.Drawing.Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
      {
        newImg.Save(Server.MapPath(pathToSave), img.RawFormat);
      }
    }


    public Size NewImageSize(Size imageSize, Size newSize)
    {
      Size finalSize;
      double tempval;
      if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
      {
        if (imageSize.Height > imageSize.Width)
          tempval = newSize.Height / (imageSize.Height * 1.0);
        else
          tempval = newSize.Width / (imageSize.Width * 1.0);

        finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
      }
      else
        finalSize = imageSize; // image is already small size

      return finalSize;
    }




  }
}