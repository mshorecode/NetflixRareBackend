using Microsoft.EntityFrameworkCore;
using NetflixRareBackend.Dto;

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

            app.MapPost("/api/post/addReaction", (RareDbContext db, PostReactionDto newReaction) => 
            {
                var postToReact = db.Posts.Include(p => p.Reactions).FirstOrDefault(p => p.Id == newReaction.Post_Id);

                if (postToReact == null)
                { 
                    return Results.NotFound();
                }

                var reactionToAdd = db.Reactions.Find(newReaction.Reactions_Id);


                if (reactionToAdd == null)
                {
                    return Results.NotFound();
                }

                postToReact.Reactions.Add(reactionToAdd);

                db.SaveChanges();

                return Results.Ok();
            });
        }
    }
}
