using NetflixRareBackend.Models;

namespace NetflixRareBackend.Data
{
    public class PostData
    {
        public static List<Post> Posts = new List<Post>
        {
            new Post { Id = 1, User_Id = 1, Category_Id = 2, Title = "The Dawn of Quantum Computing", Publication_Date = new DateTime(2024, 02, 26), Image_Url = "https://example.com/quantum.jpg", Content = "Quantum computing is set to revolutionize the way we solve complex problems. This post delves into the basics of quantum theory and its application in computing.", Approved = false },
            new Post { Id = 2, User_Id = 2, Category_Id = 1, Title = "Exploring the Depths of the Neural Networks", Publication_Date = new DateTime(2024, 03, 03), Image_Url = "https://example.com/neural_networks.jpg", Content = "Neural networks have become a cornerstone of modern AI. This post explores how these networks mimic the human brain to process information.", Approved = true },
        };
    }
}
