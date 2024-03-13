using NetflixRareBackend.Dto;
using NetflixRareBackend.Models;

namespace NetflixRareBackend.APIs
{
    public class UserAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/checkuser", (RareDbContext db, UserAuthDto userAuthDto) =>
            {
                var userUid = db.Users.SingleOrDefault(user => user.Uid == userAuthDto.Uid);

                if (userUid == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(userUid);
                }
            });

            app.MapPost("/register", (RareDbContext db, User user) =>
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Results.Created($"/user/{user.Id}", user);
            });

            app.MapGet("/user", (RareDbContext db) => 
            {
                return db.Users.ToList();
            });

            app.MapGet("/user/{userId}", (RareDbContext db, int userId) =>
            {
                return db.Users.SingleOrDefault(u => u.Id == userId);
            });
        }
    }
}
