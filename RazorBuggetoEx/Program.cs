using Microsoft.EntityFrameworkCore;
using RazorBuggetoEx.DAL;
using RazorBuggetoEx.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//Add DbContext
builder.Services.AddDbContext<RazorDbContex>(p =>
{
    p.UseSqlServer(builder.Configuration.GetConnectionString("ShopingConectionString"));
});

builder.Services.AddTransient<IProductService, ProductService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
