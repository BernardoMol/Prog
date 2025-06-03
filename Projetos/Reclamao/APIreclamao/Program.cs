using bibliotecaReclamao.Banco.Conexao;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using bibliotecaReclamao.Banco.Modelos; // Garanta que este using esteja correto
using Microsoft.AspNetCore.Identity.UI.Services; // Necessário para IEmailSender
using System.Threading.Tasks; // Necessário para Task
using System; // Necessário para Console

// Adicione o using para o namespace onde você colocou NullEmailSender.cs
// Se você a colocou em 'APIreclamao/Services/NullEmailSender.cs', o using é este:
using APIreclamao.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConexaoContexto>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddIdentity<Usuario, IdentityRole<int>>(options =>
{
    // Desativa a necessidade de confirmação de e-mail para login
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ConexaoContexto>()
.AddDefaultTokenProviders();

builder.Services.AddTransient<IEmailSender<Usuario>, APIreclamao.Services.NullEmailSender>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGroup("auth").MapIdentityApi<Usuario>().WithTags("Authorization");

app.UseHttpsRedirection();
app.UseAuthentication(); // Este middleware é crucial para o Identity funcionar corretamente
app.UseAuthorization();

app.MapControllers();

app.Run();