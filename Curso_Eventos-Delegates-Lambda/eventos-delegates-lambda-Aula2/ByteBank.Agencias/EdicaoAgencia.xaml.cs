using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;

        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();

            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));
            AtualizarCamposDeTexto();
            AtualizarControles();
        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }

        private void AtualizarControles()
        {
            RoutedEventHandler dialogResultTrue = ( o, e) => DialogResult = true;            

            RoutedEventHandler dialogResultFalse = delegate (object o, RoutedEventArgs e)
            {
                DialogResult = false;
            };

            var okEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            //  txtNome.TextChanged += ContruirDelegateValidacaoCampoNulo(txtNome);
            //  txtDescricao.TextChanged += ContruirDelegateValidacaoCampoNulo(txtDescricao);
            //  txtEndereco.TextChanged += ContruirDelegateValidacaoCampoNulo(txtEndereco);
            //  txtNumero.TextChanged += ContruirDelegateValidacaoCampoNulo(txtNumero);
            //  txtTelefone.TextChanged += ContruirDelegateValidacaoCampoNulo(txtTelefone);

            txtNome.TextChanged += ValidarCampoNulo;
            txtDescricao.TextChanged += ValidarCampoNulo;
            txtEndereco.TextChanged += ValidarCampoNulo;
            txtNumero.TextChanged += ValidarCampoNulo;
            txtNumero.TextChanged += ValidarSomenteDigito;
            txtTelefone.TextChanged += ValidarCampoNulo;
        }

        private TextChangedEventHandler ContruirDelegateValidacaoCampoNulo(TextBox txt)
        {
            return (o, e) =>
            {
                var textoEstaVazio = String.IsNullOrEmpty(txt.Text);
                txt.Background = textoEstaVazio ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);

            };
        }

        private void ValidarSomenteDigito(object sender, EventArgs e)
        {
            var txt = sender as TextBox;

            //  Func<char, bool> verificarSeEhDigito = caractere => Char.IsDigit(caractere);
            //Func<char, bool> verificarSeEhDigito = Char.IsDigit;

            //var todosCaracteresSaoVazios = txt.Text.All(verificarSeEhDigito);
            var todosCaracteresSaoVazios = txt.Text.All(Char.IsDigit);

            txt.Background = todosCaracteresSaoVazios ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.OrangeRed);

        }
        private void ValidarCampoNulo(object sender, EventArgs e)
        {

            var txt = sender as TextBox;
            var textoEstaVazio = String.IsNullOrEmpty(txt.Text);

            txt.Background = textoEstaVazio ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);
        }

        private void TxtNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = String.IsNullOrEmpty(txtNome.Text);
            if (textoEstaVazio)            
                txtNome.Background = new SolidColorBrush(Colors.OrangeRed);            
            else
                txtNome.Background = new SolidColorBrush(Colors.White);



            throw new NotImplementedException();
        }

        private void btnOk_Click(object sender, EventArgs e) =>
            DialogResult = true;

        private void btnCancelar_Click(object sender, EventArgs e) =>
            DialogResult = false;

        private void Fechar(object sender, EventArgs e) =>
            Close();
    }
}
