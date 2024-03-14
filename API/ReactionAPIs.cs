namespace NetflixRareBackend.APIs
{
    public class ReactionAPIs
    {
        public static void Map(WebApplication app)
        {

            app.MapGet("/api/reactions", (RareDbContext db) => 
            { 
                return db.Reactions.ToList(); 
            });
        }
    }
}
