using BlogApp.Repository;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");
using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("Program");
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<IBlogRepository, MockBlogRepository>();
    builder.Services.AddSingleton<IAuthorRepository, MockAuthorRepository>();
    builder.Services.AddControllersWithViews();
}
else if (builder.Environment.IsStaging())
{
    builder.Services.AddSingleton<IBlogRepository, SqlBlogRepository>();
    builder.Services.AddSingleton<IAuthorRepository, SqlAuthorRepository>();
    builder.Services.AddResponseCaching();
}
else if (builder.Environment.IsProduction())
{
    builder.Services.AddSingleton<IBlogRepository, SqlBlogRepository>();
    builder.Services.AddSingleton<IAuthorRepository, SqlAuthorRepository>();
    builder.Services.AddResponseCaching();
}else if (builder.Environment.EnvironmentName == "QA")
{
    // builder.Services.AddSingleton<IBlogRepository, CustomBlogRepository>();
    // builder.Services.AddSingleton<IAuthorRepository, CustomAuthorRepository>();
    builder.Services.AddResponseCaching();
}
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); 

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

