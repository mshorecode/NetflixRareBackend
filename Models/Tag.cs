﻿namespace NetflixRareBackend.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
