using Microsoft.EntityFrameworkCore;
using SolutionEx5Gateaux.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CatalogueGateaux>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:GateauxConnection"]);
});

//builder.Services.AddSingleton<IGateauRepository, MemGateauRepository>();
builder.Services.AddScoped<IGateauRepository, BDGateauRepository>();
builder.Services.AddScoped<IIngredientRep, BDIngredientRep>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
 name: "default",
 pattern: "{controller=Gateaux}/{action=Liste}/{id?}"
);

InitBD.Seed(app);

app.Run();
