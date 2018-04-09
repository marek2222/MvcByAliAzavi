using System;
using System.ComponentModel.DataAnnotations;

namespace MvcByAliAzavi.Models
{
  public class Product
  {
    [Key]
    public Int32 ProductId { get; set; }

    [Required]
    [Display(Name = "Product Name")]
    public String ProductName { get; set; }

    [Required]
    [Display(Name = "Price")]
    public Decimal Price { get; set; }

    [Required]
    [Display(Name = "Category")]
    public Int32 CategoryId { get; set; }

    public String Image { get; set; }

    public String Thumb { get; set; }

    public virtual Category Categories { get; set; }
  }
}