using System;
using System.Collections.Generic;
using System.IO;
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

namespace RockClient
{
    /// <summary>
    /// Interaction logic for TelaCadastro.xaml
    /// </summary>
    public partial class TelaCadastro : Window
    {
        Controller controller;

        public TelaCadastro()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void buttonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            long numero = DateTime.Now.Ticks;//Tick é um long de até 19 digitos

            DateTime dataExpiracao = DateTime.Now.AddYears(5);//Põe cinco anos de validade do cartão.

            Card cartao = new Card(this.textBoxNome.Text,
                                    numero,
                                    dataExpiracao,
                                    this.comboBoxBandeira.Text,
                                    Int32.Parse(this.textBoxSenha.Text),
                                    this.comboBoxTipo.Text,
                                    float.Parse(this.textBoxLimite.Text));

            //Enviar o cartão criado
            String cartaoJson  = JsonUtil.converterObjetoParaJson<Card>(cartao);
            String resposta = controller.enviarMensagem(cartaoJson);

            this.labelNumero.Content = "Cartão criado. O número dele é: "+numero;
        }

        
    }
}
