using Microsoft.EntityFrameworkCore;
using TrabalhoFinal.Application.Interfaces;
using TrabalhoFinal.Application.Mappings;
using TrabalhoFinal.Infrastructure.Data;
using TrabalhoFinal.Infrastructure.Repositories;
using TrabalhoFinal.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

MappingConfig.RegisterMappings();

builder.Services.AddScoped<IEditoraRepository, EditoraRepository>();
builder.Services.AddScoped<IMangaRepository, MangaRepository>();

builder.Services.AddScoped<IEditoraService, EditoraService>();
builder.Services.AddScoped<IMangaService, MangaService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
