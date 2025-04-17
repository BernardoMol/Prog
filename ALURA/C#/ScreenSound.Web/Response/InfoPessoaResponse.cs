using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenSound.Web.Response
{
    public class InfoPessoaResponse
    {
        public string? Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}