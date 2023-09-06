using Clube.Data;
using Clube.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;
using static Clube.Shared.YoutubeDownloader;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<IObserver<double> , YoutubeDownloader>();
builder.Services.AddTransient<IProgress<double>, ProgressTracker>();
builder.Services.AddSingleton<YoutubeDownloaderService>();

//builder.Services.AddAuthentication()
//    .AddGoogle( googleOptions => {
//        googleOptions.ClientId = builder.Configuration["Authentication:External:Google:ClientId"]!;
//        googleOptions.ClientSecret = builder.Configuration["Authentication:External:Google:ClientSecret"]!;
//    } )
//    .AddTwitter( twitterOptions => {
//        twitterOptions.ConsumerKey = builder.Configuration["Authentication:External:Twitter:ApiKey"]!;
//        twitterOptions.ConsumerSecret = builder.Configuration["Authentication:External:Twitter:ApiSecret"]!;
//    } )
//    .AddFacebook( facebookOptions =>
//    {
//        facebookOptions.AppId = builder.Configuration["Authentication:External:Facebook:AppId"]!;
//        facebookOptions.AppSecret = builder.Configuration["Authentication:External:Facebook:AppSecret"]!;
//        facebookOptions.AccessDeniedPath = "/AccessDeniedPathInfo";
//    } );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler( "/Error" );
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage( "/_Host" );

app.Run();
