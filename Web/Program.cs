using Application;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Load}/{action=Index}/{id?}");

app.Run();
