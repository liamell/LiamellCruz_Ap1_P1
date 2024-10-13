using LiamellCruz_Ap1_P1.Components;
using LiamellCruz_Ap1_P1.DAL;
using LiamellCruz_Ap1_P1.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Contexto>(o => o.UseSqlite(ConStr));

builder.Services.AddScoped<PrestamoService>();
builder.Services.AddScoped<CobroService>();
builder.Services.AddScoped<DeudorService>();
builder.Services.AddScoped<DetallesCobroService>();

builder.Services.AddBlazorBootstrap();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

