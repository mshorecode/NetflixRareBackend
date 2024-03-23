using NetflixRareBackend.Models;

namespace NetflixRareBackend.APIs
{
    public class SubscriptionAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/subscriptions/{followerId}/{authorId}", (RareDbContext db, int authorId, int followerId) =>
            {
                Subscription subscriptionById = db.Subscriptions.FirstOrDefault(s => s.Author_Id == authorId && s.Follower_Id == followerId);

                if (subscriptionById != null)
                {
                    return Results.Ok(subscriptionById.Id);
                }

                return Results.NoContent();

            });

            app.MapPost("/api/subscriptions", (RareDbContext db, Subscription subscription) =>
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
                return Results.Created($"/api/subscriptions/{subscription.Id}", subscription);
            });

            app.MapDelete("/api/subscriptions/{id}", (RareDbContext db, int id) =>
            {
                Subscription subToDelete = db.Subscriptions.SingleOrDefault(s => s.Id == id);
                if (subToDelete != null)
                {
                    db.Subscriptions.Remove(subToDelete);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                return Results.BadRequest("Subscription not found");
            });
        }
    }
}
