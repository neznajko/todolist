////////////////////////////////////////////////////////////////
using todolist.Data;
////////////////////////////////////////////////////////////////
using Microsoft.EntityFrameworkCore;
////////////////////////////////////////////////////////////////
var builder = WebApplication.CreateBuilder( args );

builder.Services.AddRazorPages();
builder.Services.AddDbContext <TodolistContext> ();

var app = builder.Build();

// This is for running the app in a docker container
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService <TodolistContext> ();
    dbContext.Database.Migrate();
}
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();
////////////////////////////////////////////////////////////////