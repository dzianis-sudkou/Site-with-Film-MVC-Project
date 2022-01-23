using ProjectComplete.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectComplete.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Theme Theme { get; set; }
        public string ImageUrl { get; set; }
        List<Item> Item { get; set; }

    }
}
