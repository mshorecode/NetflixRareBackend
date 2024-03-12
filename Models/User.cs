namespace NetflixRareBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set;}
        public string Bio { get; set; }
        public string Profile_Image_Url { get; set; }
        public string Email { get; set; }
        public DateTime Created_On { get; set; }
        public bool Active { get; set; }
        public bool Is_Staff { get; set; }
        public string Uid { get; set; }
    }
}
