using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; // Adicione esta linha!
using Microsoft.EntityFrameworkCore; // Necessário para DbContext e DbSet
using ScreenSound.BANCO;
using ScreenSound.BANCO.Modelos; // Certifique-se de que esse namespace contém TabelaArtista


namespace ScreenSound.BANCO
{
    public class conexaoComBanco : DbContext
    {
        private string connectionString = "Data Source=DESKTOP-DV5DOKH\\SQLEXPRESS;Initial Catalog=ScreenSound;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString); // faz a conexão com o banco de dados
        }
        public DbSet<TabelaArtista> TabelaArtista { get; set; } = null!;
        public DbSet<TabelaMusicas> TabelaMusicas { get; set; } = null!;
    }
}

// //  // CONEXÃO BÁSICA, SO PRA MOSTARAR QUE ACESSOU O BANCO
// {
//     public class conexaoComBanco
//     {
//         private string connectionString = "Data Source=DESKTOP-DV5DOKH\\SQLEXPRESS;Initial Catalog=ScreenSound;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

//         public SqlConnection ObterConexao()
//         {
//             return new SqlConnection(connectionString);
//         }
//     }
// }