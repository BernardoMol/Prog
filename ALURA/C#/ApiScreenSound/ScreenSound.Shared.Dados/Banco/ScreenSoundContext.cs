// using Microsoft.Data.SqlClient;
// using Microsoft.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
public class ScreenSoundContext: DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }

    // private string connectionString = "Data Source=DESKTOP-DV5DOKH\\SQLEXPRESS;Initial Catalog=ScreenSound;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    private string connectionString = "Server=tcp:screensound-server-mol.database.windows.net,1433;Initial Catalog=ScreenSoundV0;Persist Security Info=False;User ID=bernardomol;Password=B#rnardom0l13;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
    }
}
