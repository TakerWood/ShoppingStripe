using Microsoft.EntityFrameworkCore;
using ShoppingStripe.Components;
using ShoppingStripe.Data.Context;
using ShoppingStripe.Infrastructure;
using ShoppingStripe.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMvc();

builder.Services.AddControllers();

//Db
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("MasterData"));
});

//SERVICES
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPaymentsService, PaymentsService>();
builder.Services.AddScoped<ICartService, CartService>();

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