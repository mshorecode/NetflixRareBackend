using NetflixRareBackend.Models;

namespace NetflixRareBackend.APIs
{
    public class CategoryAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/categories", (RareDbContext db) =>
            {
                return db.Categories;
            });

            //create category
            app.MapPost("/api/categories/new", (RareDbContext db, Category category) =>
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return Results.Created($"/api/categories/{category.Id}", category);
            });

            //delete category
            app.MapDelete("/api/categories/{id}", (RareDbContext db, int id) =>
            {
                Category categoryToDelete = db.Categories.SingleOrDefault(c => c.Id == id);
                if (categoryToDelete != null)
                {
                    db.Categories.Remove(categoryToDelete);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                return Results.BadRequest("Category not found");
            });

            //edit category
            app.MapPut("/api/categories/{id}", (RareDbContext db, Category updatedCategory) =>
            {
                Category categoryToUpdate = db.Categories.SingleOrDefault(c => c.Id == updatedCategory.Id);
                if (categoryToUpdate != null)
                {
                    categoryToUpdate.Label = updatedCategory.Label;  
                    db.SaveChanges();
                    return Results.Ok(categoryToUpdate);
                }
                return Results.BadRequest("No category found");
            });
        }
    }
}
