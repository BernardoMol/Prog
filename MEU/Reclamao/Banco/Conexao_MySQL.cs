using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient; // permite a conexão com o mysql

namespace Reclamao.Banco
{
    public class Conexao_MySQL
    {
        // private string connectionString = "mysql://root:fZsXuTGhNhkmhaJXgGIEkfdzefXQAycW@metro.proxy.rlwy.net:45511/railway";
        private readonly string connectionString = "SERVER=metro.proxy.rlwy.net;PORT=45511;DATABASE=railway;UID=root;PASSWORD=fZsXuTGhNhkmhaJXgGIEkfdzefXQAycW;";
        public MySqlConnection Conectar()
        {
            return new MySqlConnection(connectionString);
        }
    }
}

// // CONSTUINDO A CONEXÃO DE FORMA "DINAMICA"
// namespace Reclamao.Banco
// {
//     internal class Conexao_MySQL
//     {
//         // private string connectionString = "mysql://root:fZsXuTGhNhkmhaJXgGIEkfdzefXQAycW@metro.proxy.rlwy.net:45511/railway";
//         private readonly string server = "metro.proxy.rlwy.net";
//         private readonly string port = "45511";
//         private readonly string database = "railway";
//         private readonly string uid = "root";
//         private readonly string password = "fZsXuTGhNhkmhaJXgGIEkfdzefXQAycW";
//         private string connectionString;

//         public Conexao_MySQL()
//         {
//             connectionString = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={MySqlHelper.EscapeString(password)};";
//         }

//         public MySqlConnection Conectar()
//         {
//             return new MySqlConnection(connectionString);
//         }
//     }
// }

