using NetflixRareBackend.Models;

namespace NetflixRareBackend.Data
{
    public class TagData
    {
        public static List<Tag> Tags = new List<Tag>
            {
                new Tag
                {
                  Id = 1,
                  Label = "Informative"
                },

                new Tag
                {
                  Id = 2,
                  Label = "Quick Read"
                },
            };
    };
}
