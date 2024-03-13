using NetflixRareBackend.Models;

namespace NetflixRareBackend.APIs
{
    public class PostAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/posts", (RareDbContext db) => { 
                return db.Posts.ToList();
            });

            app.MapGet("/api/posts/{userId}", (RareDbContext db, int userId) =>
            {
                try
                {
                    var userPosts = db.Posts.Where(p => p.User_Id == userId );
                    return Results.Ok(userPosts);
                }
                catch
                {
                    return Results.NotFound();
                }
            });

            app.MapGet("/api/posts/{userId}/subscribed", (RareDbContext db, int userId) => {

                try
                {
                    var userSubs = db.Subscriptions.Where(sub => sub.Follower_Id == userId);
                    var userSubsPosts = from subs in userSubs
                                        join post in db.Posts on subs.Author_Id equals post.User_Id
                                        select post;
                    return Results.Ok(userSubsPosts);
                }
                catch
                {
                    return Results.NotFound();
                }
            });


            app.MapGet("/api/posts/{postId}", (RareDbContext db, int postId) =>
            {
                try
                {
                    var userPostToDelete = db.Posts.FirstOrDefault(p => p.Id == postId);
                    db.Posts.Remove(userPostToDelete);
                    return Results.Ok();
                }
                catch
                {
                    return Results.NotFound();
                }
            });


            app.MapGet("/api/posts/{userId}", (RareDbContext db, int userId, Post userPost) => 
            {
                if (userId != null)
                {
                    db.Posts.Add(userPost);
                    return Results.Ok();
                }
                else
                {
                    return Results.NotFound();
                }
            });


        }
    }
}
