using Microsoft.EntityFrameworkCore;
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

            app.MapGet("/api/posts/{categoryId}", (RareDbContext db, int categoryId) =>
            {
                try
                {
                    var postsWithCategory = db.Posts.FirstOrDefault(p => p.Category_Id == categoryId);
                    return Results.Ok(postsWithCategory);
                }
                catch
                {
                    return Results.NotFound();
                }
            });

            app.MapGet("/api/posts/{tagId}", (RareDbContext db, int tagId) => 
            {
                try
                {
                    var postsWithTag = db.Posts.Include(p => p.Tags);
                    var postsWithRequestedTag = postsWithTag.Where(p => p.Tags.Where(t => t.Id == tagId).Count() != 0);
                    return Results.Ok(postsWithRequestedTag);
                }
                catch
                {
                    return Results.NotFound();
                }
            });

            app.MapGet("/api/posts/search", (RareDbContext db, string Query) => 
            { 
                var searchedPost = db.Posts.FirstOrDefault(p => p.Title.ToLower().Contains(Query.ToLower()));

                if (searchedPost != null)
                {
                    return Results.Ok(searchedPost);
                }
                else
                {
                    return Results.NotFound();
                }
            });


            app.MapDelete("/api/posts/{postId}", (RareDbContext db, int postId) =>
            {
                try
                {
                    var userPostToDelete = db.Posts.FirstOrDefault(p => p.Id == postId);
                    db.Posts.Remove(userPostToDelete);
                    db.SaveChanges();
                    return Results.Ok();
                }
                catch
                {
                    return Results.NotFound();
                }
            });


            app.MapPost("/api/posts/{userId}", (RareDbContext db, int userId, Post userPost) => 
            {
                if (userId != null)
                {
                    db.Posts.Add(userPost);
                    db.SaveChanges();
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
