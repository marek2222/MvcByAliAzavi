using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcByAliAzavi.Models
{
  public class ProductSearchModels
  {
    [Key]
    public Int32 ProductId { get; set; }

    [Display(Name = "Product Name")]
    public String ProductName { get; set; }

    [Display(Name = "Price (Max.)")]
    public Decimal? Price { get; set; }

    [Display(Name = "Category")]
    public Int32? Category { get; set; }

    public Int32 Page { get; set; }
    public Int32 PageSize { get; set; }
    public String Sort { get; set; }
    public String SortDir { get; set; }
    public Int32 TotalRecords { get; set; }
    public List<Product> Products { get; set; }

    public ProductSearchModels()
    {
      Page = 1;
      PageSize = 5;
      Sort = "ProductId";
      SortDir = "DESC";
    }
  }
}