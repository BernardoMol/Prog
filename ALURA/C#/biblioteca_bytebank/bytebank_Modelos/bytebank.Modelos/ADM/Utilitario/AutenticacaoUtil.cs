using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_Modelos.bytebank.Modelos.ADM.Utilitario
{
    public class AutenticacaoUtil
    {
        public bool ValidarSenha(string senhaVerdadeira, string senhaInserida)
        {
            // return senhaVerdadeira == senhaInserida;
             return senhaVerdadeira.Equals(senhaInserida);
        }
    }
}