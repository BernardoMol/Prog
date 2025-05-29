using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    // É ESTE OBJETO QUE NOS PERMITE PERCORRER AS NOSSAS TABELAS
    // public class ApplicationDBContext: DbContext // nossa classe, chamada "ApplicationDBContext" está herdando propriedades da entidade do EF Core chamada "DbContext"
    public class ApplicationDBContext: IdentityDbContext<AppUser>{ // Agora estamos pegando da entidade que instalamos a partir da aula 20
        public ApplicationDBContext(DbContextOptions dbContextOptions) // "DbContextOptions dbContextOptions" é um padrão do core entity
        : base(dbContextOptions) // tambem é codigo padrão, pelo que entendi
        {
            
        }

        public DbSet<Stock> Stocks { get; set;} //  Agora "Stocks" representa a tabela Stock do banco
        public DbSet<Comment> Comments { get; set;} //  Agora "Comments" representa a tabela Comment do banco
        public DbSet<JoinTable> JoinTables { get; set;} //  Agora "JoinTables" representa a tabela JoinTable do banco

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // AULA 25
            builder.Entity<JoinTable>().HasKey(x => new {x.AppUserId, x.StockId}); // Aqui estamos dizendo que a tabela JoinTable tem uma chave composta
            builder.Entity<JoinTable>().HasOne(x => x.AppUser).WithMany(x => x.JoinTables).HasForeignKey(x => x.AppUserId); // Aqui estamos dizendo que a tabela JoinTable tem uma chave estrangeira para a tabela AppUser
            builder.Entity<JoinTable>().HasOne(x => x.Stock).WithMany(x => x.JoinTables).HasForeignKey(x => x.StockId); // Aqui estamos dizendo que a tabela JoinTable tem uma chave estrangeira para a tabela Stock
            // fim da  AULA 25
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "Admin",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    // ConcurrencyStamp = Guid.NewGuid().ToString()
                    ConcurrencyStamp ="12345678-1234-1234-1234-123456789001"
                },
                new IdentityRole
                {
                    Id = "User",
                    Name = "User",
                    NormalizedName = "USER",
                    // ConcurrencyStamp = Guid.NewGuid().ToString()
                    ConcurrencyStamp ="12345678-1234-1234-1234-123456789001"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}