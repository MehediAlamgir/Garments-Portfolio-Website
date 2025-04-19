using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModels
{
    public class ProductImageViewModel
    {
        [Required]
        [Display(Name = "Image File")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Caption")]
        public string Caption { get; set; }
    }
}
