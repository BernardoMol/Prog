using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // é esta DLL que me deixa fazer as imposições nas variaveis
using CursoWindowsFormsBiblioteca.Database;
using System.Data;

namespace CursoWindowsFormsBiblioteca.Classes
{
    public class Cliente
    {
        public class Unit
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Código do Cliente é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Código deve ser numérico")]
            [StringLength(6, MinimumLength = 6, ErrorMessage = "Código precisa de 6 Numeros")]
            public string Id { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Nome do Cliente é obrigatório")]
            [StringLength(50, ErrorMessage = "Cliente Máximo 50 caracteres")]
            public string Nome { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Nome da Mãe é obrigatório")]
            [StringLength(50, ErrorMessage = "Mãe Máximo 50 caracteres")]
            public string NomeMae { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Nome do Pai é obrigatório")]
            [StringLength(50, ErrorMessage = "Pai Máximo 50 caracteres")]
            public string NomePai { get; set; }

            public bool NaoTemPai { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "CPF obrigarório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "CPF deve ser numérico")]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF Necessário 11 caracteres")]
            public string Cpf { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Genero obrigarório")]
            public int Genero { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "CEP obrigarório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "CEP deve ser numérico")]
            [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP Necessário 8 caracteres")]
            public string Cep { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Logradouro é obrigatório")]
            [StringLength(100, ErrorMessage = "Logradouro Máximo 100 caracteres")]
            public string Logradouro { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Complemnto é obrigatório")]
            [StringLength(100, ErrorMessage = "Complemnto Máximo 100 caracteres")]
            public string Complemento { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Bairro é obrigatório")]
            [StringLength(100, ErrorMessage = "BairroMáximo 100 caracteres")]
            public string Bairro { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Cidade é obrigatório")]
            [StringLength(100, ErrorMessage = "Cidade Máximo 100 caracteres")]
            public string Cidade { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Estdo é obrigatório")]
            [StringLength(100, ErrorMessage = "Estdo Máximo 100 caracteres")] // meio inutil pq é dropbox, mas a classe pode ser usada em outro ambiente.....
            public string Estado { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Telefone é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Telefone deve ser numérico")]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "Telefone Precisa ter 11 Dígitos")]
            public string Telefone { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Profissao é obrigatório")]
            [StringLength(100, ErrorMessage = "Profissao Máximo 100 caracteres")]
            public string Profissao { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Renda é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Renda deve ser numérico")]
            [Range(0, double.MaxValue, ErrorMessage = "Renda deve ser positiva")]
            public Double RendaFamiliar { get; set; }


            public void ValidaClasse()
            {
                ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(this, context, results, true);

                if (isValid == false)
                {
                    StringBuilder sbrErrors = new StringBuilder();
                    foreach (var validationResult in results)
                    {
                        sbrErrors.AppendLine(validationResult.ErrorMessage);
                    }
                    throw new ValidationException(sbrErrors.ToString());
                }
            }

            public void ValidaComplemento()
            {
                if (this.NomePai == this.NomeMae)
                {
                    throw new Exception("Nome do pai e da mãe não podem ser iguais");
                }

                if (this.NaoTemPai == false)
                {
                    if (this.NomePai == "")
                    {
                        throw new Exception("Se tem pai, o nome PPRECISA ser preenchido");
                    }
                }
                bool validaCPF = Cls_Uteis.Valida(this.Cpf);

                if (validaCPF == false)
                {
                    throw new Exception("CPF Inválido");
                }

            }

            #region "Crud do Fichário SQL"

            public void IncluirFicharioSQL(string conexao)
            {

                string clienteJSON = Cls_Uteis.SerializeObject(this);

                FicharioSQLServer F = new FicharioSQLServer(conexao);
                if (F.status)
                {
                    F.Incluir(this.Id, clienteJSON);
                    if (!(F.status))
                    {
                        throw new Exception(F.mensagem);
                    }
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public Unit BuscarFicharioSQL(string id, string conexao)
            {

                FicharioSQLServer F = new FicharioSQLServer(conexao);
                // FAÇO a BUSCA
                string clienteJson = F.Buscar(id);
                // Verifico se a BUSCA deu certo
                if (F.status == true)
                {
                    return Cls_Uteis.DesSerializedClassUnit<Cliente.Unit>(clienteJson);
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public void AlterarFicharioSQL(string conexao)
            {
                string clienteJson = Cls_Uteis.SerializeObject(this);
                FicharioSQLServer F = new FicharioSQLServer(conexao);
                // Verifico se a BUSCA deu certo
                if (F.status == true)
                {
                    F.Alterar(this.Id, clienteJson);
                    if (!(F.status))
                    {
                        throw new Exception(F.mensagem);
                    }
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public void ApagarFicharioSQL(string conexao)
            {
                //Verifico conexão
                FicharioSQLServer F = new FicharioSQLServer(conexao);
                if (F.status == true)
                {
                    F.Apagar(this.Id);
                    // Verifico se apagou
                    if (!(F.status == true))
                    {
                        throw new Exception(F.mensagem);
                    }
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public List<string> ListaFicharioSQL(string conexao)
            {
                //Verifico conexão
                FicharioSQLServer F = new FicharioSQLServer(conexao);
                if (F.status == true)
                {
                    List<string> todosJson = F.BuscarTodos();
                    return todosJson;
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }
            #endregion


            #region "Crud do Fichário DB"

            public void IncluirFicharioDB(string conexao)
            {

                string clienteJSON = Cls_Uteis.SerializeObject(this);

                FicharioDB F = new FicharioDB(conexao);
                if (F.status)
                {
                    F.Incluir(this.Id, clienteJSON);
                    if (!(F.status))
                    {
                        throw new Exception(F.mensagem);
                    }
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public Unit BuscarFicharioDB(string id, string conexao)
            {

                FicharioDB F = new FicharioDB(conexao);
                // FAÇO a BUSCA
                string clienteJson = F.Buscar(id);
                // Verifico se a BUSCA deu certo
                if (F.status == true)
                {
                    return Cls_Uteis.DesSerializedClassUnit<Cliente.Unit>(clienteJson);
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public void AlterarFicharioDB(string conexao)
            {
                string clienteJson = Cls_Uteis.SerializeObject(this);
                FicharioDB F = new FicharioDB(conexao);
                // Verifico se a BUSCA deu certo
                if (F.status == true)
                {
                    F.Alterar(this.Id, clienteJson);
                    if (!(F.status))
                    {
                        throw new Exception(F.mensagem);
                    }
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public void ApagarFicharioDB(string conexao)
            {
                //Verifico conexão
                FicharioDB F = new FicharioDB(conexao);
                if (F.status == true)
                {
                    F.Apagar(this.Id);
                    // Verifico se apagou
                    if (!(F.status == true))
                    {
                        throw new Exception(F.mensagem);
                    }
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public List<string> ListaFicharioDB(string conexao)
            {
                //Verifico conexão
                FicharioDB F = new FicharioDB(conexao);
                if (F.status == true)
                {
                    List<string> todosJson = F.BuscarTodos();
                    return todosJson;
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }
            #endregion


            #region "Crud do Fichário"

            public void IncluirFichario(string conexao)
            {

                string clienteJSON = Cls_Uteis.SerializeObject(this);

                Fichario F = new Fichario(conexao);
                if (F.status)
                {
                    F.Incluir(this.Id, clienteJSON);
                    if (!(F.status))
                    {
                        throw new Exception(F.mensagem);
                    }
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public Unit BuscarFichario(string id, string conexao)
            {

                Fichario F = new Fichario(conexao);
                // FAÇO a BUSCA
                string clienteJson = F.Buscar(id);
                // Verifico se a BUSCA deu certo
                if (F.status == true)
                {
                    return Cls_Uteis.DesSerializedClassUnit<Cliente.Unit>(clienteJson);
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public void AlterarFichario(string conexao)
            {
                string clienteJson = Cls_Uteis.SerializeObject(this);
                Fichario F = new Fichario(conexao);
                // Verifico se a BUSCA deu certo
                if (F.status == true)
                {
                    F.Alterar(this.Id, clienteJson);
                    if (!(F.status))
                    {
                        throw new Exception(F.mensagem);
                    }
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public void ApagarFichario(string conexao)
            {
                //Verifico conexão
                Fichario F = new Fichario(conexao);
                if (F.status == true)
                {
                    F.Apagar(this.Id);
                    // Verifico se apagou
                    if (!(F.status == true))
                    {
                        throw new Exception(F.mensagem);
                    }
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }

            public List<string> ListaFichario(string conexao)
            {
                //Verifico conexão
                Fichario F = new Fichario(conexao);
                if (F.status == true)
                {
                    List<string> todosJson = F.BuscarTodos();
                    return todosJson;
                }
                else
                {
                    throw new Exception(F.mensagem);
                }
            }
            #endregion

            #region "CRUD fichario DB SQL SERVER relacional"

            #region Funções Aucxiliares
            public string ToInsert()
            {
                string SQL; // Declarar a variável SQL
                SQL = @"INSERT INTO TB_Cliente (
                        Id,
                        Nome,
                        NomeMae,          -- Ordem das colunas
                        NomePai,          -- e dos valores deve ser a mesma
                        NaoTemPai,
                        Cpf,
                        Genero,
                        Cep,
                        Logradouro,
                        Complemento,
                        Bairro,
                        Cidade,
                        Estado,
                        Telefone,
                        Profissao,
                        RendaFamiliar
                    )
                    VALUES ("; // Parêntese de abertura para os VALUES
                SQL += "" + this.Id + ","; // ID numérico geralmente não leva aspas
                SQL += "'" + this.Nome + "',";
                SQL += "'" + this.NomeMae + "',"; // Corrigido para corresponder à ordem da declaração de colunas
                SQL += "'" + this.NomePai + "',"; // Corrigido para corresponder à ordem da declaração de colunas
                //SQL += "'" + Convert.ToString(this.NaoTemPai) + "',";
                SQL += Convert.ToInt32(this.NaoTemPai).ToString() + ",";
                SQL += "'" + this.Cpf + "',";
                SQL += "'" + Convert.ToString(this.Genero) + "',";
                SQL += "'" + this.Cep + "',";
                SQL += "'" + this.Logradouro + "',";
                SQL += "'" + this.Complemento + "',";
                SQL += "'" + this.Bairro + "',";
                SQL += "'" + this.Cidade + "',";
                SQL += "'" + this.Estado + "',";
                SQL += "'" + this.Telefone + "',";
                SQL += "'" + this.Profissao + "',";
                SQL += "" + Convert.ToString(this.RendaFamiliar) + ");"; // RendaFamiliar numérico sem aspas, fecha parêntese, e ; no final
                return SQL;
            }

            public string ToUpdate(string Id)
            {
                string SQL;
                SQL = @"UPDATE TB_Cliente
                        SET ";
                SQL += "Id = " + this.Id + ",";
                SQL += "Nome = '" + this.Nome + "',";
                SQL += "NomePai = '" + this.NomePai + "',";
                SQL += "NomeMae = '" + this.NomeMae + "',";
                SQL += "NaoTemPai = " + (this.NaoTemPai ? "1" : "0") + ", ";
                SQL += "Cpf = '" + this.Cpf + "',";
                SQL += "Genero = '" + Convert.ToString(this.Genero) + "',";
                SQL += "Cep = '" + this.Cep + "',";
                SQL += "Logradouro = '" + this.Logradouro + "',";
                SQL += "Complemento = '" + this.Complemento + "',";
                SQL += "Bairro = '" + this.Bairro + "',";
                SQL += "Cidade = '" + this.Cidade + "',";
                SQL += "Estado = '" + this.Estado + "',";
                SQL += "Telefone = '" + this.Telefone + "',";
                SQL += "Profissao = '" + this.Profissao + "',";
                SQL += "RendaFamiliar = '" + Convert.ToString(this.RendaFamiliar) + "'"; // Não tem vírgula no final
                SQL += " WHERE Id = '" + Id + "';"; // O 'Id' aqui provavelmente deveria ser 'this.Id' ou um parâmetro
                return SQL;
            }

            public Unit DataRowToUnit(DataRow dr)
            {
                Unit u = new Unit();
                u.Id = dr["Id"].ToString();
                u.Nome = dr["Nome"].ToString();
                u.NomePai = dr["NomePai"].ToString();
                u.NomeMae = dr["NomeMae"].ToString();
                u.NaoTemPai = Convert.ToInt32(dr["NaoTemPai"]) != 0;
                u.Cpf = dr["Cpf"].ToString();
                u.Logradouro = dr["Logradouro"].ToString();
                u.Complemento = dr["Complemento"].ToString();
                u.Bairro = dr["Bairro"].ToString();
                u.Cidade = dr["Cidade"].ToString();
                u.Estado = dr["Estado"].ToString();
                u.Telefone = dr["Telefone"].ToString();
                u.Profissao = dr["Profissao"].ToString();
                u.RendaFamiliar = Convert.ToDouble(dr["RendaFamiliar"]);
                return u;
            }
            #endregion

            public void IncluirFicharioSQLREL()
            {
                try
                {
                    string SQL;
                    SQL = this.ToInsert();
                    var db = new SQLServerClass();
                    db.SQLComando(SQL);
                    db.CloseConnection();

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao incluir!! " + ex.Message);
                }
            }

            public Unit BuscarFicharioSQLREL(string Id)
            {
                try
                {
                    string SQL = "SELECT * FROM [TB_Cliente] WHERE Id = '" + Id + "'";
                    var db = new SQLServerClass();
                    var Dt = db.SQLQuery(SQL);

                    if (Dt.Rows.Count == 0)
                    {
                        db.CloseConnection();
                        throw new Exception("Identificador não existe " + Id);
                    }
                    else
                    {
                        Unit u = this.DataRowToUnit(Dt.Rows[0]);
                        return u;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("eRRO DE BUSCA: " + ex.Message);
                }
            }

            public void AlterarFicharioSQLREL()
            {

                try
                {
                    string SQL = "SELECT * FROM [TB_Cliente] WHERE Id = '" + Id + "'";
                    var db = new SQLServerClass();
                    var Dt = db.SQLQuery(SQL);

                    if (Dt.Rows.Count == 0)
                    {
                        db.CloseConnection();
                        throw new Exception("Identificador não existe " + Id);
                    }
                    else
                    {
                        SQL = this.ToUpdate(this.Id);
                        db.SQLComando(SQL);
                        db.CloseConnection();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ERRO AO ALTERAR: " + ex.Message);
                }

            }

            public void ApagarFicharioSQLREL()
            {
                try
                {
                    string SQL = "SELECT * FROM [TB_Cliente] WHERE Id = '" + this.Id + "'";
                    var db = new SQLServerClass();
                    var Dt = db.SQLQuery(SQL);

                    if (Dt.Rows.Count == 0)
                    {
                        db.CloseConnection();
                        throw new Exception("Identificador não existe " + Id);
                    }
                    else
                    {
                        SQL = "DELETE FROM TB_cliente WHERE Id = '" + this.Id + "'";
                        db.SQLComando(SQL);
                        db.CloseConnection();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ERRO AO EXCLUIR: " + ex.Message);
                }
            }

            public List<string> ListaFicharioSQLREL()
            {
                List<string> ListaBusca = new List<string>(); // Lista de strings simples

                try
                {
                    //Verifico conexão
                    FicharioSQLServer F = new FicharioSQLServer("TB_Cliente");
                    if (F.status == true)
                    {
                        List<string> todosJson = F.BuscarTodosSQLREL();
                        return todosJson;
                    }
                    else
                    {
                        throw new Exception(F.mensagem);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ERRO AO BUSCAR TODOS sqlrel: " + ex.Message, ex);
                }
                // Nota: O gerenciamento de recursos (Dt.Dispose() e fechamento da conexão)
                // ainda depende da implementação de db.SQLQuery().
            }



            //public List<List<string>> ListaFicharioSQLREL(string conexao)
            //{
            //    List<List<string>> ListaBusca = new List<List<string>>();
            //    try
            //    {
            //        var SQL = "SELECT * FROM TB_Cliente";
            //        var db = new SQLServerClass();
            //        var Dt = db.SQLQuery(SQL);

            //        for (int i = 0; i <= Dt.Rows.Count - 1; i++)
            //        {
            //            ListaBusca.Add(new List<string> { Dt.Rows[i]["Id"].ToString(), Dt.Rows[i]["Nome"].ToString() });
            //        }

            //        return ListaBusca;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("ERRO AO BUSCAR TODOS: " + ex.Message);
            //    }
            //}

            #endregion


            public class List
            {
                public List<Unit> ListUnit { get; set; }
            }
        }
    }
}
