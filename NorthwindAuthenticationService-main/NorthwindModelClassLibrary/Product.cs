using System.ComponentModel.DataAnnotations;

namespace NorthwindModelClassLibrary
{
    public class Product
    {

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [MinLength(4, ErrorMessage = "Product Name should be 4 or more chars.")]
        [StringLength(50, ErrorMessage = "Product name cannot exceed 50 chars.")]
        public string ProductName { get; set; } = "";

        [Required(ErrorMessage = "Unit Price is required.")]
        [Range(minimum: 1, maximum: 1000, ErrorMessage = "Unit price shuld be between 1 and 1000.")]
        [Display(Name = "Price Per Unit")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Units in stock is required.")]
        [Range(1, 1000, ErrorMessage = "Units In Stock can be between 1 and 1000.")]
        [Display(Name = "Stock Level")]
        public short UnitsInStock { get; set; }

    }
}
