using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AndrejsLanguages.Web.Data;
using AndrejsLanguages.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var sqlConnection = builder.Configuration["ConnectionStrings:Munson:SqlDb"];

builder.Services.AddSqlServer<LanguageDbContext>(sqlConnection, options => options.EnableRetryOnFailure());

builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<ReviewService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.CreateDbIfNotExists();

app.Run();
