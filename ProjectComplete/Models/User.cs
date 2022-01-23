using System.ComponentModel.DataAnnotations;

namespace ProjectComplete.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public List<Collection> Collections { get; set; }
    }
}
