using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Data;
using Microsoft.Extensions.DependencyInjection;
using MovieApp;
using System.Net.Http.Headers;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<TmdbClient>();

builder.Services.AddHttpClient("tmdb", httpClientFactory =>
{
    httpClientFactory.BaseAddress = new Uri("https://api.themoviedb.org/3");
    httpClientFactory.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    httpClientFactory.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJkMzI3ZjRiMTk0YzkzOGIzMWI4NWQ5ZWZmNDUyOWE4NyIsInN1YiI6IjY0Yjk1NjZmMTEzODZjMDBjYWY3OWVhOCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.8mrtq7htaNwl_QvuDZCVhBxIU2y0QoCjzDcV9hk0UYU");
});








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

app.Run();


