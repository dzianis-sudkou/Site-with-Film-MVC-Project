using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectComplete.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int ItemId { get; set; } 

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
