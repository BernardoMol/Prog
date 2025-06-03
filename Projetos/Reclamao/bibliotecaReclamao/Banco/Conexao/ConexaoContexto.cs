using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using bibliotecaReclamao.Banco.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace bibliotecaReclamao.Banco.Conexao
{
    public class ConexaoContexto : IdentityDbContext <Usuario, IdentityRole<int>, int>
    {
        public DbSet<Reclamacao> Reclamacao { get; set; }
        // public DbSet<Usuario> Usuarios { get; set; }
        public ConexaoContexto(DbContextOptions<ConexaoContexto> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // **PASSO CRUCIAL: Chamar o método base PRIMEIRO**
            // Isso permite que o Identity configure suas tabelas padrão.
            base.OnModelCreating(modelBuilder);

            // Mapear a entidade Usuario para a tabela "Usuarios"
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
             modelBuilder.Entity<Usuario>().Ignore(u => u.AccessFailedCount);

            // Mapear as propriedades do IdentityUser para suas colunas existentes:
            modelBuilder.Entity<Usuario>().Property(u => u.Id).HasColumnName("UsuarioId");
            modelBuilder.Entity<Usuario>().Property(u => u.UserName).HasColumnName("NomeUsuario");
            modelBuilder.Entity<Usuario>().Property(u => u.Email).HasColumnName("EmailUsuario");
            modelBuilder.Entity<Usuario>().Property(u => u.PasswordHash).HasColumnName("SenhaUsuario");
        }

    }

}