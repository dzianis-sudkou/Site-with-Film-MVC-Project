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
        public string Name { get; set; }
        [Display(Name="Description Of Collection")]
        public string Description { get; set; }
        [Display(Name = "Theme Of Collection")]
        public Theme Theme { get; set; }
        [Display(Name = "Image Of Collection")]
        public string ImageUrl { get; set; }
        List<Item> Items { get; set; }
        //public int UserId { get; set; }

        //[ForeignKey("UserId")]
        //public User User { get; set; }

    }
}
