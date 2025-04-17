using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ScreenSound.Banco;
using ScreenSound.Shared.Dados.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Net.WebSockets;


namespace ScreenSound.Banco;

// public class ScreenSoundContext : DbContext
public class ScreenSoundContext : IdentityDbContext<PessoaComAcesso, PerfilDeAcesso, int>
{ 
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<PerfilDeAcesso> PerfilDeAcesso { get; set; }
    public DbSet<PessoaComAcesso> PessoaComAcesso { get; set; }
    public DbSet<AvaliacaoArtista> AvaliacaoArtistas { get; set; }
    // Dev
    // private string connectionString = "Data Source=DESKTOP-DV5DOKH\\SQLEXPRESS;Initial Catalog=ScreenSound;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    // prod 
    private const string connectionString = "Server=tcp:screensound-server-mol.database.windows.net,1433;Initial Catalog=ScreenSoundV0;Persist Security Info=False;User ID=bernardomol;Password=B#rnardom0l13;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    // Esse construtor é usado em tempo de execução (por injeção de dependência, etc.)
    public ScreenSoundContext(DbContextOptions<ScreenSoundContext> options) : base(options)
    {
    }

    // Esse construtor é necessário para que o EF CLI crie o contexto no design-time
    public ScreenSoundContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(connectionString, opts =>
                {
                    opts.MigrationsAssembly("ScreenSound.Shared.Dados");
                })
                .UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // ← essencial para Identity funcionar
        modelBuilder.Entity<Musica>()
            .HasMany(c => c.Generos)
            .WithMany(c => c.Musicas);

        modelBuilder.Entity<AvaliacaoArtista>()
            .HasKey(a => new {a.ArtistaId, a.PessoaId});

    }
}

// public class ScreenSoundContext : DbContext
// {
//     public DbSet<Artista> Artistas { get; set; }
//     public DbSet<Musica> Musicas { get; set; }
//     public DbSet<Genero> Generos { get; set; }

//     public ScreenSoundContext(DbContextOptions<ScreenSoundContext> options) : base(options)
//     {
//     }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Musica>()
//             .HasMany(c => c.Generos)
//             .WithMany(c => c.Musicas);
//     }
// }