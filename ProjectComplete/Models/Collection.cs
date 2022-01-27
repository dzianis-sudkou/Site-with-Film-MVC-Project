using ProjectComplete.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectComplete.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Name Of Collection")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Display(Name="Description Of Collection")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be from 3 to 100 letters.")]
        public string Description { get; set; }

        [Display(Name = "Theme Of Collection")]
        public Theme Theme { get; set; }
        [Display(Name = "Image Of Collection")]
        [Required]
        public string ImageUrl { get; set; }
        List<Item> Items { get; set; }
        public string UserId { get; set; }
        [ForeignKey("CollectionId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
