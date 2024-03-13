namespace NetflixRareBackend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Author_Id { get; set; }
        public int Post_Id { get; set; }
        public string Content { get; set; }
        public DateTime Created_On { get; set; }
    }
}
