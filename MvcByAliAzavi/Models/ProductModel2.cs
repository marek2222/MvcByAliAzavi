using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MvcByAliAzavi.Models
{
  public class ProductModel2
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

    [NotMapped]
    [Required]
    [DataType(DataType.Upload)]
    [Display(Name = "Choose File")]
    public HttpPostedFileBase ImageUpload { get; set; }
  }
}