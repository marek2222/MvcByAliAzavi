using System;
using System.ComponentModel.DataAnnotations;

namespace MvcByAliAzavi.Models
{
  public class Category
  {
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [Display(Name = "Category Name")]
    [StringLength(30, ErrorMessage = "The {0} must be between {2} to {1} characters", MinimumLength = 5)]
    public String CategoryName { get; set; }

    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }
  }
}