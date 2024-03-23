using NetflixRareBackend.Dto;
using NetflixRareBackend.Models;

namespace NetflixRareBackend.APIs
{
    public class CommentAPIs
    {
        public static void Map(WebApplication app)
        {
            //view post comments
            app.MapGet("/api/comments/{postId}", (RareDbContext db, int postId) =>
            {
                Post post = db.Posts.SingleOrDefault(p => p.Id == postId);
                if (post == null)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
                List<Comment> comments = db.Comments
                                                .Where(c => c.Post_Id == postId)
                                                .OrderByDescending(c => c.Created_On)
                                                .ToList();
                if (comments.Count == 0)
                {
                    return Results.NotFound("no comments found");
                }
                return Results.Ok(comments);
            });

            //create comment
            app.MapPost("/api/comments/new", (RareDbContext db, Comment comment) =>
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return Results.Created($"/api/comments/{comment.Id}", comment);
            });

            //edit comment
            app.MapPut("/api/comments/{id}", (RareDbContext db, EditCommentDto updatedComment) =>
            {
                Comment commentToUpdate = db.Comments.SingleOrDefault(c => c.Id == updatedComment.Id);
                if (commentToUpdate != null)
                {
                    commentToUpdate.Content = updatedComment.Content;
                    db.SaveChanges();
                    return Results.Ok(commentToUpdate);
                }
                return Results.BadRequest("No comment found");
            });

            //delete comment
            app.MapDelete("/api/comments/{id}", (RareDbContext db, int id) =>
            {
                Comment commentToDelete = db.Comments.SingleOrDefault(c => c.Id == id);
                if (commentToDelete != null)
                {
                    db.Comments.Remove(commentToDelete);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                return Results.BadRequest("Comment not found");
            });
        }
    }
};
