using ProjectComplete.Models;

namespace ProjectComplete.Data.ViewModels
{
    public class NewItemsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
        //public List<Like> Likes { get; set; }
        //public List<Comment> Comments { get; set; }
    }
}
