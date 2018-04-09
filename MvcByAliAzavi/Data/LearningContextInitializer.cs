using MvcByAliAzavi.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace MvcByAliAzavi.Data
{
  public class LearningContextInitializer : DropCreateDatabaseIfModelChanges<LearningContext>
  {
    protected override void Seed(LearningContext context)
    {
      var categories = new List<Category>
       {
          new Category { CategoryId = 1, CategoryName =  "Laptop" },
          new Category { CategoryId = 1, CategoryName = "Software" },
          new Category { CategoryId = 1, CategoryName = "Accessories" }
       };

      // add data into table and save to db
      foreach (var category in categories)
      {
        context.Categories.Add(category);
      }
      context.SaveChanges();


      // add data into table and save to db
      foreach (var category in categories)
      {
        context.Categories.Add(category);
      }
      context.SaveChanges();

      // Add records into Product table 
      var products = new List<Product>
      {
        new Product{ProductId = 1, ProductName = "Dell Inspiron", Price = 750, CategoryId =1 },
        new Product{ProductId = 2, ProductName = "Dell Chromebook", Price = 875, CategoryId =1 },
        new Product{ProductId = 3, ProductName = "Lenovo Yoga Pro 2", Price = 1000, CategoryId =1 },
        new Product{ProductId = 4, ProductName = "Lenovo Yoga Pro 2 Ultrabook", Price = 1175, CategoryId =1 },

        new Product{ProductId = 5, ProductName = "Office 365", Price = 175, CategoryId =2 },
        new Product{ProductId = 6, ProductName = "Windows 8", Price = 550, CategoryId =2 },
        new Product{ProductId = 7, ProductName = "Nortan Antivirus", Price = 200, CategoryId =2 },
        new Product{ProductId = 8, ProductName = "Visual Studio 2013", Price = 905, CategoryId =2 },

        new Product{ProductId = 10, ProductName = "Logistic Keyboard", Price = 36, CategoryId =3 },
        new Product{ProductId = 9, ProductName = "IBM Mouse", Price = 22, CategoryId =3 },
        new Product{ProductId = 9, ProductName = "Laptop Screen Guard", Price = 30, CategoryId =3 },
        new Product{ProductId = 9, ProductName = "Mini HDMI Cod", Price = 37, CategoryId =3 }
      };

      // add data into table and save to db
      foreach (var product in products)
      {
        context.Products.Add(product);
      }
      context.SaveChanges();
    }
  }
}