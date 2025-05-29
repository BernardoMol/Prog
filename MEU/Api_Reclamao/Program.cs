var builder = WebApplication.CreateBuilder(args);


// 1. Adicionar serviços de CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            // ATENÇÃO: Substitua "http://localhost:3000" pela URL exata do seu frontend.
            // Se seu frontend for deployado em outro lugar, adicione essa URL também.
            // Para desenvolvimento, "http://localhost:3000" é comum.
            policy.WithOrigins("http://localhost:3000") 
                  .AllowAnyHeader()    // Permite qualquer tipo de cabeçalho na requisição (ex: Content-Type)
                  .AllowAnyMethod()    // Permite qualquer método HTTP (GET, POST, PUT, DELETE)
                  .AllowCredentials(); // Permite o envio de cookies ou credenciais (se necessário)
        });

    // Opcional: Se você precisar de uma política mais aberta para testes (NÃO RECOMENDADO EM PRODUÇÃO)
    options.AddPolicy("AllowAll", 
        policy =>
        {
            policy.AllowAnyOrigin() // Permite requisições de QUALQUER origem (perigoso em produção)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddOpenApi();
builder.Services.AddControllers();






var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

// 2. Usar o middleware de CORS
// Coloque app.UseCors() ANTES de app.MapControllers();
app.UseCors(); // Isso usa a política padrão (AddDefaultPolicy)

// Se você quisesse usar a política "AllowAll" (NÃO RECOMENDADO PARA PRODUÇÃO):
// app.UseCors("AllowAll");

app.MapControllers(); // <<< Aqui é o que faz funcionar os controllers!

// Endpoint extra (exemplo)
// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// bom para verificar mas um erro ENORME depois de dar deploy
// Ela tenta acessar a própria API no momento que ela está inicializando — e isso trava tudo e causa o erro 503.
// var apiURL = "http://minha-api-reclamacao.onrender.com/Reclamacao/Reclamacao";
// using (HttpClient client = new HttpClient())
// {
//     Console.Write("vou passar para a variavel");
//     HttpResponseMessage response = await client.GetAsync(apiURL);
//     string jsonResponse = await response.Content.ReadAsStringAsync();
//     Console.Write("passei");
//     Console.Write(jsonResponse);
// }


// var resposta = ReclamacaoController.GetAllReclamacoes();
// Console.Write(resposta);

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
