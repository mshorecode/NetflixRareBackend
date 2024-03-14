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
                if (userId != 0)
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

            app.MapPatch("/api/posts/{postId}", (RareDbContext db, int postId, Post editedPost) => 
            {
                var postToEdit = db.Posts.FirstOrDefault(p => p.Id == postId);

                if (postToEdit == null)
                {
                    return Results.NotFound();
                }

                if (editedPost.Category_Id != null)
                { 
                    postToEdit.Category_Id = editedPost.Category_Id;
                }

                if (editedPost.Title != null)
                { 
                    postToEdit.Title = editedPost.Title;
                }

                if (editedPost.Publication_Date != null)
                { 
                    postToEdit.Publication_Date = editedPost.Publication_Date;
                }

                if (editedPost.Image_Url != null)
                { 
                    postToEdit.Image_Url = editedPost.Image_Url;
                }

                if (editedPost.Content != null)
                { 
                    postToEdit.Content = editedPost.Content;
                }

                if (editedPost.Approved != null)
                { 
                    postToEdit.Approved = editedPost.Approved;
                }

                db.SaveChanges();

                return Results.Ok();
               
            });
        }
    }
}
