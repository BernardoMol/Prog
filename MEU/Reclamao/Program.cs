using Reclamao.Banco;
using Reclamao.Banco.Modelos;
using MySql.Data.MySqlClient; // permite a conexão com o mysql
 
var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles(); // Geralmente necessário para Razor Pages/MVC para servir arquivos estáticos como CSS/JS
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages(); // Use MapRazorPages() para rotear as páginas Razor



// --- TESTE DE CONEXÃO MySQL AQUI ---
Console.WriteLine("Iniciando teste de conexão MySQL durante a inicialização da aplicação...");
using var conexao = new Conexao_MySQL().Conectar();
try
{
    conexao.Open();
    Console.WriteLine("Conexão Aberta");
}
catch (Exception ex)
{
    Console.WriteLine("FUDEU!");
    Console.WriteLine(ex.Message);
}


// --- TESTE DE CONSULTA MySQL AQUI ---
Console.WriteLine("Iniciando teste de CONSULTA MySQL durante a inicialização da aplicação...");
string query;
MySqlCommand comando;
MySqlDataReader leitor;

try
{
    // conexao.Open(); // Abre a conexão
    // Console.WriteLine("ABRI.");

    List<Reclamacao> reclamacoes = new List<Reclamacao>();
    query = "SELECT id, conteudo, Imagem FROM reclamacao;";

    comando = new MySqlCommand(query, conexao); // Crie o comando
    leitor = comando.ExecuteReader(); // Executo o comando

    Console.WriteLine("CONSULTANDO.");
    // Console.WriteLine("\n" + reader);

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

        Console.WriteLine($"ID: {item.Id}, Conteúdo: {item.Conteudo}, Imagem: {item.Imagem ?? "NULL"}");
    }


    conexao.Close();
    Console.WriteLine("FECHEI.");

}
catch (Exception ex)
{
    Console.WriteLine("CONSULTA FUDEU!");
    Console.WriteLine(ex.Message);
}



// --- TESTE DE INSERÇÃO MySQL AQUI ---
// try
// {
//     conexao.Open(); // Abre a conexão
//     query = "INSERT INTO reclamacao (conteudo, Imagem) VALUES (@conteudo, @imagem);";
//     comando = new MySqlCommand(query, conexao); // Crie o comando
//     comando.Parameters.AddWithValue("@conteudo", "Minha nova reclamação de teste do app!");
//     comando.Parameters.AddWithValue("@imagem", "url_da_imagem_teste.jpg");
//     comando.ExecuteNonQuery(); // (ExecuteNonQuery() para INSERT, UPDATE, DELETE)

//     Console.WriteLine("INSERINDO RECCLAMAÇÃO.");
//     // Console.WriteLine("\n" + reader);

//     conexao.Close();
//     Console.WriteLine("FECHEI.");

// }
// catch (Exception ex)
// {
//     Console.WriteLine("CONSULTA FUDEU!");
//     Console.WriteLine(ex.Message);
// }

// --- TESTE DE DELEÇÃO MySQL AQUI ---
try
{
    conexao.Open(); // Abre a conexão
    query = "DELETE FROM reclamacao WHERE id = @id";
    comando = new MySqlCommand(query, conexao); // Crie o comando
    comando.Parameters.AddWithValue("@id", 12312313);
    comando.ExecuteNonQuery(); // (ExecuteNonQuery() para INSERT, UPDATE, DELETE)

    Console.WriteLine("DELETANDO RECCLAMAÇÃO.");
    // Console.WriteLine("\n" + reader);

    conexao.Close();
    Console.WriteLine("FECHEI.");

}
catch (Exception ex)
{
    Console.WriteLine("CONSULTA FUDEU!");
    Console.WriteLine(ex.Message);
}


// --- TESTE DE UPDATE MySQL AQUI ---
try
{
    conexao.Open(); // Abre a conexão
    // daria pra mudar at[e o ID
    // query = "UPDATE reclamacao SET id = @idNovo, conteudo = @novoConteudo, Imagem = @novaImagem WHERE id = @idAntigo";
    //command.Parameters.AddWithValue("@idNovo", 456)
    // command.Parameters.AddWithValue("@idAntigo", 123)    
    query = "UPDATE reclamacao SET conteudo = @novoConteudo, Imagem = @novaImagem WHERE id = @id;";
    comando = new MySqlCommand(query, conexao); // Crie o comando
    comando.Parameters.AddWithValue("@novoConteudo", "Muié LINDA! te amo d+++++++");
    comando.Parameters.AddWithValue("@novaImagem", "nada");
    comando.Parameters.AddWithValue("@id", 12312314);
    comando.ExecuteNonQuery(); // (ExecuteNonQuery() para INSERT, UPDATE, DELETE)

    Console.WriteLine("UPDATANDO RECCLAMAÇÃO.");
    // Console.WriteLine("\n" + reader);

    conexao.Close();
    Console.WriteLine("FECHEI.");

}
catch (Exception ex)
{
    Console.WriteLine("CONSULTA FUDEU!");
    Console.WriteLine(ex.Message);
}

// --- TESTE DE BUSCA UNICA ---
try
{
    conexao.Open(); // Abre a conexão
    query = "SELECT id, conteudo, Imagem FROM reclamacao WHERE id = @idBusca;";
    comando = new MySqlCommand(query, conexao); // Crie o comando
    comando.Parameters.AddWithValue("@idBusca", 12312314);
    leitor = comando.ExecuteReader(); // executa

    Console.WriteLine("Busca UNICA.");
    if (leitor.Read()) // leitor.Read() retorna true se encontrou uma linha 
    {
        Reclamacao reclamacaoEncontrada = new Reclamacao
        {
            Id = leitor.GetInt32("id"),
            Conteudo = leitor.GetString("conteudo"),
            Imagem = leitor.IsDBNull(leitor.GetOrdinal("Imagem")) ? null : leitor.GetString("Imagem")
        };
        
        Console.WriteLine("Registro encontrado:");
        Console.WriteLine($"ID: {reclamacaoEncontrada.Id}");
        Console.WriteLine($"Conteúdo: {reclamacaoEncontrada.Conteudo}");
        Console.WriteLine($"Imagem: {reclamacaoEncontrada.Imagem ?? "N/A"}");
    }
    else
    {
        Console.WriteLine($"Nenhum registro encontrado com ID = 12312314.");
    }
    Console.WriteLine("--- FIM DA BUSCA ---");

}
catch (Exception ex)
{
    Console.WriteLine("CONSULTA FUDEU!");
    Console.WriteLine(ex.Message);
}

app.Run();




    