var options = new WebApplicationOptions{
    WebRootPath = "wwwroot" 
};

var builder = WebApplication.CreateBuilder(options);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
    _ = app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(static endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "trentino-forecast",
        pattern: "trentino-forecast",
        defaults: new { controller = "TrentinoForecastController", action = "GetExternalWeather" });

    _ = endpoints.MapControllerRoute(
        name: "trentino-locations",
        pattern: "trentino-locations",
        defaults: new { controller = "TrentinoLocationsController", action = "GetLocations" });

    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    _ = endpoints.MapControllers();
    
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
