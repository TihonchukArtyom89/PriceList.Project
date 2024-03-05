var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//вызов объектов необходимых для mvc и 
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
//app.MapGet("/", () => "Hello World!");

app.Run();
