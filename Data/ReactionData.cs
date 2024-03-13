using NetflixRareBackend.Models;

namespace NetflixRareBackend.Data
{
    public class ReactionData
    {
        public static List<Reaction> Reactions = new List<Reaction>
        {
            new Reaction { Id = 1, Label = "Like", Image_Url = "like.png" },
            new Reaction { Id = 2, Label = "Love", Image_Url = "love.png" },
            new Reaction { Id = 3, Label = "Haha", Image_Url = "haha.png" },
        };
    }
};
