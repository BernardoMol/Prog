using bibliotecaReclamao.Banco.Conexao;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using bibliotecaReclamao.Banco.Modelos; // Garanta que este using esteja correto
using Microsoft.AspNetCore.Identity.UI.Services; // Necessário para IEmailSender
using System.Threading.Tasks; // Necessário para Task
using System; // Necessário para Console

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConexaoContexto>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication(); // Este middleware é crucial para o Identity funcionar corretamente
app.UseAuthorization();

app.MapControllers();

app.Run();