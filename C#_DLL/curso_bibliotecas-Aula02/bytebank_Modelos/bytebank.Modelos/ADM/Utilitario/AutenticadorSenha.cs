using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_Modelos.bytebank.Modelos.ADM.Utilitario
{
    internal class AutenticadorSenha
    {
        public bool AutenticarSenha(string senhaVerdadeira, string tentativaDeSenha)
        {
            //  return string.Equals(senha, tentativaDeSenha);
            return senhaVerdadeira.Equals(tentativaDeSenha);
        }
    }
}
