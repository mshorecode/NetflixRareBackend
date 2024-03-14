using NetflixRareBackend.Models;

namespace NetflixRareBackend.APIs
{
    public class TagAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/api/tags", (RareDbContext db, Tag tagToAdd) => 
            { 
                db.Tags.Add(tagToAdd);
                db.SaveChanges();
                return Results.Ok();
            });
            
            app.MapGet("/api/tags", (RareDbContext db) => {
                return db.Tags.ToList();
            });

            app.MapDelete("/api/tags/{tagId}", (RareDbContext db, int tagId) =>
            {
                try
                {
                    var userTagToDelete = db.Tags.FirstOrDefault(t => t.Id == tagId);
                    db.Tags.Remove(userTagToDelete);
                    db.SaveChanges();
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
