using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectComplete.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        
        public int CollectionId { get; set; }
        [ForeignKey("CollectionId")]
         public Collection Collection { get; set; }
        //public List<Like> Likes { get; set; }
        //public List<Comment> Comments { get; set; }
    }
}
