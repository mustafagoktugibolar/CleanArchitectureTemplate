using CleanArchitectureDemo.Application;
using CleanArchitectureDemo.Persistence;
using CleanArchitectureDemo.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
// add application services
builder.Services.AddApplication();

// add persistance
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapHealthChecks("/probe");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    //apply migrations
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.ApplyMigrations(context);
}

app.Run();