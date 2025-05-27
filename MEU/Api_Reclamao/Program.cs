var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// --- ADICIONE ESTA LINHA PARA RECONHECER SEUS CONTROLADORES ---
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Você pode querer usar o DeveloperExceptionPage para ver erros mais detalhados em desenvolvimento
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

// --- ADICIONE ESTAS DUAS LINHAS PARA HABILITAR O ROTEAMENTO DE CONTROLADORES ---
app.UseRouting(); // Essencial para o roteamento baseado em atributos ([Route])
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Mapeia todos os controladores da sua aplicação
});


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}