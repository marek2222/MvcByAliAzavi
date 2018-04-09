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
    }
  }
}