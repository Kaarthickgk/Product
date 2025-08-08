using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductWebApi.Model
{
    public class Product
    {
      
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        
        [Display(Name = "Product Name")]
        [StringLength(100,MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 100 characters")]
        public string Name { get; set; } = null!;

        [Display(Name = "Product Price")]
        [Range(1, 9999.99, ErrorMessage = "Price must be between 1 and 9999.99")]
        public decimal Price { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Manufacture Date ")]
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; }
    }
}
