using Microsoft.EntityFrameworkCore;
using ShoppingStripe.Components;
using ShoppingStripe.Data.Context;
using ShoppingStripe.Infrastructure;
using ShoppingStripe.Services;


var builder = WebApplication.CreateBuilder(args);

//SERVICES
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ICartService, CartService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMvc();
builder.Services.AddControllers();

//Db
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDataBase:MasterData"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Server=localhost;Port=5432;Database=MasterData;;Username=postgres;Password=admin


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();