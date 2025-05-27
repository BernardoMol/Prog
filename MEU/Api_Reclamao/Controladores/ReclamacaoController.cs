using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient; // permite a conexão com o mysql

using Reclamao.Banco; // é onde esta a classe de conexão com o banco
using Reclamao.Banco.Modelos; // é onde esta o modelo de reclamações

namespace Api_Reclamao.Controladores
{
    // localhost:xxxx/Reclamacao/ReclamacaoControler
    [Route("Reclamacao/[controller]")]

    public class ReclamacaoController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllReclamacoes()
        {
            List<Reclamacao> reclamacoes = new List<Reclamacao>();
            MySqlConnection? conexao = null; // Inicializa como nulo
            MySqlCommand? comando = null; // Inicializa como nulo
            MySqlDataReader? leitor = null; // Inicializa como nulo
            string query = null;

            try
            {
                conexao = new Conexao_MySQL().Conectar();
                conexao.Open();
                
                query = "SELECT id, conteudo, Imagem FROM reclamacao;";
                comando = new MySqlCommand(query, conexao);
                leitor = comando.ExecuteReader();

                // Console.WriteLine é usado para logging básico.
                Console.WriteLine("CONSULTANDO RECLAMAÇÕES.");

                while (leitor.Read())
                {
                    Reclamacao item = new Reclamacao
                    {
                        Id = leitor.GetInt32("id"),
                        Conteudo = leitor.GetString("conteudo"),
                        // Use GetOrdinal e IsDBNull para tratar valores nulos da coluna 'Imagem'
                        Imagem = leitor.IsDBNull(leitor.GetOrdinal("Imagem")) ? null : leitor.GetString("Imagem")
                    };
                    reclamacoes.Add(item);
                }
                leitor.Close(); // Fechar o leitor após o uso
                return Ok(reclamacoes);
            }
            catch (MySqlException ex)
            {
                // Retorna um erro 500 com a mensagem de exceção
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
                leitor.Close();
            }
            catch (Exception ex)
            {
                // Retorna um erro 500 para outros tipos de exceção
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
                leitor.Close();
            }
        }
    }
}