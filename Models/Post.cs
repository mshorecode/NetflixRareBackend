namespace NetflixRareBackend.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Category_Id { get; set; }
        public string Title { get; set; }
        public DateTime? Publication_Date { get; set; }
        public string? Image_Url { get; set; }
        public string Content { get; set; }
        public bool Approved { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}
