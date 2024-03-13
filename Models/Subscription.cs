namespace NetflixRareBackend.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int Follower_Id { get; set; }
        public int Author_Id { get; set; }
        public DateTime Created_On { get; set; }
        public DateTime? Ended_On { get; set; }
    }
}
