using Investing.Infrastructure.Entities;
using Investing.Repository.Configuration;
using Investing.Repository.Mappings;
using Investing.Services.AssetServices;
using Investing.Shared.Mappings;
using Investing.Shared.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Connection String to the container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x => x.MigrationsAssembly("Investing.Infrastructure")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IFinancialAssetQueryService, BrApiAssetService>();
builder.Services.AddScoped<IRepositoryMapping, AutoMapperConfiguration>();
builder.Services.AddScoped<IMapping<Investing.Domain.Entities.Asset, Investing.Infrastructure.Entities.Asset>, AssetMapping>();
builder.Services.AddScoped<IMapping<Investing.Domain.Entities.AssetClass, Investing.Infrastructure.Entities.AssetClass>, AssetClassMapping>();
builder.Services.AddScoped<IMapping<Investing.Domain.Entities.Sector, Investing.Infrastructure.Entities.Sector>, SectorMapping>();
builder.Services.AddScoped<IMapping<Investing.Domain.Entities.SectorConfiguration, Investing.Infrastructure.Entities.SectorConfiguration>, SectorConfigurationMapping>();
builder.Services.AddScoped<IMapping<Investing.Domain.Entities.Wallet, Investing.Infrastructure.Entities.Wallet>, WalletMapping>();

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
