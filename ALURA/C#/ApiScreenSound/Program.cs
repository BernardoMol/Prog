
using ScreenSound.Modelos;
using ScreenSound.Banco;
using Microsoft.EntityFrameworkCore;

// Sem esse pacote, o comando do professor nao funciona
using System.Text.Json.Serialization;
using System.CodeDom.Compiler;

using Microsoft.AspNetCore.Mvc; // para poder pegar as informações via body
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>(); // o DAL é um repositório genérico, então ele pode ser usado para qualquer entidade

// isso foi um ciomando colocado pelo professor para o EF Core liberar a autorização
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) => // retorna todos os ARTISTAS
{
    return Results.Ok(dal.Listar());
});
// NÃO PODE CHAMAR O APP.RUN MAIS DE UMA VEEEZZ!!!!! app.Run();

app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal , string nome) => // retorna um artista específico
{
    var artista =  dal.RecuperarPor(a => a.Nome.Replace(" ", "").ToUpper() == nome.Replace(" ", "").ToUpper());
    if (artista is null){
        return Results.NotFound();
    }
    return Results.Ok(artista);
});

app.MapPost("/Artistas/Add", ([FromServices] DAL<Artista> dal, [FromBody]Artista artista) => // retorna um artista específico
{
    dal.Adicionar(artista);
    return Results.Ok(artista);
});

app.MapDelete("/Artistas/Delete/{id}", ([FromServices] DAL<Artista> dal, int id) => // retorna um artista específico
{
    var artista = dal.RecuperarPor(a => a.Id == id);
    if(artista is null){
        return Results.NotFound();
    }
    dal.Deletar(artista);
    return Results.NoContent();
});

app.MapPut("/Artistas/Att", ([FromServices] DAL<Artista> dal, [FromBody]Artista artista) => // retorna um artista específico
{
    var artistaAtt = dal.RecuperarPor(a => a.Id == artista.Id);
    if(artistaAtt is null){
        return Results.NotFound();
    }
    artistaAtt.Nome = artistaAtt.Nome;
    artistaAtt.Bio = artistaAtt.Bio;
    artistaAtt.FotoPerfil = artistaAtt.FotoPerfil;
    artistaAtt.Musicas = artistaAtt.Musicas;
    dal.Atualizar(artistaAtt);
    return Results.Ok(artistaAtt);
});

app.Run();


