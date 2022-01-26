using System.ComponentModel.DataAnnotations;

namespace ProjectComplete.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public List<Collection> Collections { get; set; }
        public List<Item> Items { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
