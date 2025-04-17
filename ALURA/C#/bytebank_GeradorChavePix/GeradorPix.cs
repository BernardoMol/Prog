using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_GeradorChavePix
{
    public static class GeradorPix
    {
        /// <summary>
        /// Gera uma chave Pix aleatória.
        /// </summary>
        /// <returns>Chave Pix gerada.</returns>
        public static string GetChavePix()
        {
            return Guid.NewGuid().ToString();
        }

        public static List<string> GetChavesPix(int numeroDeChaves)
        {
            if (numeroDeChaves <= 0)
            {
                return null;
            }
            else
            {
                var chaves = new List<string>();
                for (int i = 0; i < numeroDeChaves; i++)
                {
                    chaves.Add(Guid.NewGuid().ToString());
                }
                return chaves;
            }

        }
    }
}