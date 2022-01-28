using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectComplete.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string value { get; set; }
        public string UserName { get; set; }
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
