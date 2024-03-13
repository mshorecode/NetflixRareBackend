using NetflixRareBackend.Models;

namespace NetflixRareBackend.Data
{
    public class CategoryData
    {
        public static List<Category> Categories = new List<Category>
        {
            new Category { Id = 1, Label = "Technology" },
            new Category { Id = 2, Label = "Science" },
            new Category { Id = 3, Label = "Art" },
        };
    }
}
