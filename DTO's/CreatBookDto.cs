using System.ComponentModel.DataAnnotations;

namespace DTO_s
{
    public class CreatBookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Price is required")]
        [Range(100, 1000, ErrorMessage = "Price must be between 100 and 1000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(50, ErrorMessage = "Author name cannot be longer than 50 characters.")]
        public string Author { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(30, ErrorMessage = "Genre cannot be longer than 30 characters.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Published Date is required.")]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
