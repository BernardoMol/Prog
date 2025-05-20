using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; // bilblioteca que acessa o banco
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace CursoWindowsFormsBiblioteca.Database
{
    public class LocalBDClass
    {
        public string stringConn; // endereço da conexão
        public SqlConnection connDB; // criador da conexão


        public LocalBDClass()
        {
            try
            {
                stringConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\CursoWindowsFormsBiblioteca\\Database\\Fichario.mdf;Integrated Security=True";
                connDB = new SqlConnection(stringConn); // CRIA A CONEXÃO
                connDB.Open(); // abre a conexão
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string SQLComando(string SQL) // commandos tipo criar, alterar, deletar, e talz
        {
            try
            {
                var cmd = CreateCommand(SQL); 
                var myReader = cmd.ExecuteReader(); // envio o pacote para o banco
                return "";
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public SqlCommand CreateCommand(string SQL)
        {
            var cmd = new SqlCommand(SQL, connDB); // crio o pacote comando
            cmd.CommandTimeout = 0; // não exite timeout --> tempo de RESPOSTA do banco infinito
            return cmd;
        }

        public DataTable SQLQuery(string SQL)  //retorna dados
        {
            DataTable dt = new DataTable();
            try
            {
                var cmd = CreateCommand(SQL);
                var reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CloseConnection()
        {
            connDB.Close();
        }
    }
}
