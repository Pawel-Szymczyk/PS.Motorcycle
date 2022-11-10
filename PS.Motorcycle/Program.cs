using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using PS.Motorcycle.Data;
using Microsoft.Azure.Cosmos;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Infrastructure.CosmosDB;
using PS.Motorcycle.Application;
using SmartBreadcrumbs.Extensions;
using System.Reflection;
using PS.Motorcycle.Domain.Services;
using PS.Motorcycle.Infrastucture.AzureCognitiveSearch;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// TODO: to check it out later
//var environmentVariables = configuration.GetSection("environmentVariables");
//builder.Services.Configure<DatabaseConfig>(environmentVariables);

// retrieve secrets...
//string cosmos_enpoint = Environment.GetEnvironmentVariable("COSMOS_ENDPOINT");
//string cosmos_key = Environment.GetEnvironmentVariable("COSMOS_KEY");
//string cosmos_enpoint = builder.Configuration["environmentVariables:COSMOS_ENDPOINT"];
//string cosmos_key = builder.Configuration["environmentVariables:COSMOS_KEY"];

//// New instance of CosmosClient class
//using CosmosClient client = new(
//    accountEndpoint: cosmos_enpoint,
//    authKeyOrResourceToken: cosmos_key
//);


// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;

});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<IBreadcrumbService, BreadcrumbService>();


builder.Services.AddCosmosRepository();
builder.Services.AddAzureCognitiveAzureService();
builder.Services.AddApplication();



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

app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
