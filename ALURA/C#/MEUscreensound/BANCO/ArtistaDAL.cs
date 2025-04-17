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
    public class ArtistaDAL
    {
        private readonly conexaoComBanco connection;

        public ArtistaDAL(conexaoComBanco connection)
        {
            this.connection = connection;
        }

        public IEnumerable<TabelaArtista> ObterArtistas()
        {
            return connection.TabelaArtista.ToList(); // Retorna todos os artistas da tabela
        }

        public void AdicionarArtista(TabelaArtista artista)
        {
            connection.TabelaArtista.Add(artista); // Adiciona o artista à tabela
            connection.SaveChanges(); // Salva as alterações no banco de dados
        }

        public void AtualizarArtista(TabelaArtista artista)
        {
            connection.TabelaArtista.Update(artista); // Adiciona o artista à tabela
            connection.SaveChanges(); // Salva as alterações no banco de dados
        }

        public void DeletarArtista(TabelaArtista artista)
        {
            connection.TabelaArtista.Remove(artista); // Adiciona o artista à tabela
            connection.SaveChanges(); // Salva as alterações no banco de dados
        }
        public Artista? RecuperarPeloNome(string nome)
        {
            return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
        }
    }
}