namespace NetflixRareBackend.APIs
{
    public class TagAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/tags", (RareDbContext db) => {
                return db.Tags.ToList();
            });


            app.MapGet("/api/tags/{tagId}", (RareDbContext db, int tagId) =>
            {
                try
                {
                    var userTagToDelete = db.Tags.FirstOrDefault(t => t.Id == tagId);
                    db.Tags.Remove(userTagToDelete);
                    return Results.Ok();
                }
                catch
                {
                    return Results.NotFound();
                }
            });

        }
    }
}
