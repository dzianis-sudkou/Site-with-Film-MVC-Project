using ProjectComplete.Data.Enums;

namespace ProjectComplete.Data.ViewModels
{
    public class NewCollectionVM
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Theme Theme { get; set; }
        public string UserId { get; set; }
    }
}
