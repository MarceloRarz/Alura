using bytebank.Modelos.ADM.SistemaInterno;
using bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;

namespace bytebank.Modelos.ADM.Utilitario
{
    public class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }

        private AutenticadorSenha autenticador = new AutenticadorSenha();

        public bool Autenticar(string senha)
        {
            return autenticador.AutenticarSenha(this.Senha, senha);
        }
    }
}
