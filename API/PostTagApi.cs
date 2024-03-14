using NetflixRareBackend.Models;
using NetflixRareBackend.Dto;
using Microsoft.EntityFrameworkCore;

namespace NetflixRareBackend.API
{
    public class PostTagApi
    {
        public static void Map(WebApplication app)
        {

            //add tag to post
            app.MapPatch("/api/posts/{postId}/tag", (RareDbContext db, PostTagDto postTag) =>
            {
                Post post = db.Posts
                              .Include(p => p.Tags)
                              .SingleOrDefault(p => p.Id == postTag.Post_Id);
                Tag tag = db.Tags
                            .SingleOrDefault(t => t.Id == postTag.Tag_Id);
                if (post == null)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
                try
                {
                    post.Tags.Add(tag);
                    db.SaveChanges();
                    return Results.Ok(postTag);
                }
                catch (ArgumentNullException)
                {
                    return Results.BadRequest("Tag not found");
                }
            });

            //remove tag from post
            app.MapPatch("/api/posts/{postId}/remove", (RareDbContext db, PostTagDto postTag) =>
            {
                Post post = db.Posts
                              .Include(p => p.Tags)
                              .SingleOrDefault(p => p.Id == postTag.Post_Id);
                if (post == null)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
                if (post.Tags.Count < 1)
                {
                    return Results.BadRequest("No tags found");
                }
                Tag tagToRemove = post.Tags
                                      .SingleOrDefault(t => t.Id == postTag.Tag_Id);
                if (tagToRemove == null)
                {
                    return Results.BadRequest("Tag not found");
                }

                post.Tags.Remove(tagToRemove);
                db.SaveChanges();
                return Results.Ok("tag removed");

            });

        }
    }
}
