namespace NetflixRareBackend.APIs
{
    public class PostAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/posts", (RareDbContext db) => { 
                return db.Posts.ToList();
            });

            //app.MapGet("/api/posts/{userId}", (RareDbContext db, int userId) =>
            //{
            //    try
            //    {
            //        var userPosts = db.Posts.Where(p => );
            //    }
            //    catch 
            //    {
            //        return Results.NotFound();
            //    }
            //});

        }
    }
}
