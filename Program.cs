////////////////////////////////////////////////////////////////
using todolist.Data;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddRazorPages();
builder.Services.AddDbContext <TodolistContext> ();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();
////////////////////////////////////////////////////////////////