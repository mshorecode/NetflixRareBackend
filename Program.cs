using NetflixRareBackend.APIs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

CategoryAPIs.Map(app);
CommentAPIs.Map(app);
PostAPIs.Map(app);
ReactionAPIs.Map(app);
SubscriptionAPIs.Map(app);
TagAPIs.Map(app);
UserAPIs.Map(app);

app.Run();