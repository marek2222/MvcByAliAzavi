using MvcByAliAzavi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcByAliAzavi.Data
{
  public class LearningContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
  }
}