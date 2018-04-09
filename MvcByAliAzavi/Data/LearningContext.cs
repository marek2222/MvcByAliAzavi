using MvcByAliAzavi.Models;
using System.Data.Entity;

namespace MvcByAliAzavi.Data
{
  public class LearningContext : DbContext
  {
    public DbSet<Category>  Categories  { get; set; }
    public DbSet<Product>   Products    { get; set; }
    public DbSet<Product2>  Products2   { get; set; }

    public DbSet<ProductSearchModels> ProductSearchModels { get; set; }

    public System.Data.Entity.DbSet<MvcByAliAzavi.Models.ProductModel> ProductModels { get; set; }
  }
}