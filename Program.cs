using Biblioteca_MVC.DataContext;
using Biblioteca_MVC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Auth0.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BibliotecaDBDataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddTransient<BibliotecaDBDataContext, BibliotecaDBDataContext>();
builder.Services.AddTransient<BooksRepository, BooksRepository>();
builder.Services.AddTransient<MembersRepository, MembersRepository>();
builder.Services.AddTransient<BookLoansRepository, BookLoansRepository>();
builder.Services.AddTransient<CategoryRepository, CategoryRepository>();
builder.Services
    .AddAuth0WebAppAuthentication(options => { options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });
var app = builder.Build();
app.UseAuthentication();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
