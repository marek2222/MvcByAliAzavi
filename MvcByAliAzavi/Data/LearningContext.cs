using MvcByAliAzavi.Models;
using System.Data.Entity;

namespace MvcByAliAzavi.Data
{
  public class LearningContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
  }
}