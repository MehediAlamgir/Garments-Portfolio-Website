using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public string Caption { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}
