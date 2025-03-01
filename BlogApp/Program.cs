using BlogApp.Repository;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("Program");

builder.Services.AddControllersWithViews();
builder.Services.AddSession(); 
builder.Services.AddScoped<IBlogRepository, MockBlogRepository>();
builder.Services.AddScoped<IAuthorRepository, MockAuthorRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSession(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

