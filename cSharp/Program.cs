using Microsoft.EntityFrameworkCore;
using cSharp.Data;
using cSharp.Repositories;
using cSharp.Repositories.Impl;
using cSharp.Services;
using cSharp.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuration de la base de données
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enregistrement des Repositories
builder.Services.AddScoped<IEtudiantRepository, EtudiantRepository>();
builder.Services.AddScoped<IClasseRepository, ClasseRepository>();
builder.Services.AddScoped<IAnneeScolaireRepository, AnneeScolaireRepository>();
builder.Services.AddScoped<IInscriptionRepository, InscriptionRepository>();

// Enregistrement des Services
builder.Services.AddScoped<IEtudiantService, EtudiantService>();
builder.Services.AddScoped<IClasseService, ClasseService>();
builder.Services.AddScoped<IAnneeScolaireService, AnneeScolaireService>();
builder.Services.AddScoped<IInscriptionService, InscriptionService>();

var app = builder.Build();

// Initialiser la base de données
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inscription}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
