using NetflixRareBackend.Models;

namespace NetflixRareBackend.Data
{
    public class CommentData
    {
        public static List<Comment> Comments = new List<Comment>
        {
            new Comment { Id = 1, Author_Id = 1, Post_Id = 2, Content = "Really insightful article, thanks for sharing!", Created_On = new DateTime(2024-03-04) },
            new Comment { Id = 2, Author_Id = 2, Post_Id = 1, Content = "I never knew quantum computing was so fascinating.", Created_On = new DateTime(2024-02-25)}
        };
    }
}
