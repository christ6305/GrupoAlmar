using APPTareasPendientes.Models;
using APPTareasPendientes.Services;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<AppSettingsModel>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddHttpClient<TareaService>((serviceProvider, client) =>
{
    var apiSettings = serviceProvider.GetRequiredService<IOptions<AppSettingsModel>>().Value;
    client.BaseAddress = new Uri(apiSettings.BaseAddress);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tarea}/{action=Index}/{id?}");

app.Run();
