﻿using mes_ui.Data;
using mes_ui.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient<AuthenticationService>(options =>
{
    options.BaseAddress = new Uri("http://localhost:7122/api/v1/");
});

builder.Services
    .AddScoped<IAuthenticationService, AuthenticationService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IHttpService, HttpService>()
    .AddScoped<ILocalStorageService, LocalStorageService>();


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

