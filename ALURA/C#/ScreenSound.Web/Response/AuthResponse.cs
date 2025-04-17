using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ScreenSound.Web.Response
{
    public class AuthResponse
    {
        public bool Sucesso { get; set; }
        public string[] Erros { get; set; }
    }
}