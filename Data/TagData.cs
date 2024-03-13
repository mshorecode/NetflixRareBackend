using NetflixRareBackend.Models;

namespace NetflixRareBackend.Data
{
    public class TagData
    {
        public static List<Tag> Tags = new List<Tag>
            {
                new Tag { Id = 1, Label = "Technology" },
                new Tag { Id = 2, Label = "Programming" },
                new Tag { Id = 3, Label = "Science" },
            };
    };
}
