using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using ScreenSound.API.Endpoints;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Dados.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Configurações de serviços
builder.Services.AddDbContext<ScreenSoundContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"])
        .UseLazyLoadingProxies();
});

// Configuração de identidade
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<PessoaComAcesso>()
    .AddEntityFrameworkStores<ScreenSoundContext>();

// Serviços de acesso ao banco
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();
builder.Services.AddTransient<DAL<Genero>>();
builder.Services.AddTransient<DAL<PessoaComAcesso>>();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração de serialização JSON
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Configuração de CORS (antes do Build!)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5031",          // Ambiente de desenvolvimento
                "https://seu-frontend-prod.com"   // Ambiente de produção
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Debug: mostra a connection string em uso
Console.WriteLine("🔌 Connection String em uso:");
Console.WriteLine(builder.Configuration.GetConnectionString("ScreenSoundDB"));

// Middlewares
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseAuthorization();

// Endpoints
app.AddEndPointsArtistas();
app.AddEndPointsMusicas();
app.AddEndPointGeneros();

// Endpoints de autenticação
app.MapGroup("auth").MapIdentityApi<PessoaComAcesso>().WithTags("Autorização");

app.MapPost("auth/logout", async ([FromServices] SignInManager<PessoaComAcesso> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok(new { message = "Logout realizado com sucesso!" });
}).RequireAuthorization().WithTags("Autorização");

// Swagger UI (apenas em desenvolvimento)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();