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

namespace RockClient
{
    /// <summary>
    /// Interaction logic for CriarTransacao.xaml
    /// </summary>
    public partial class CriarTransacao : Window
    {
        Controller controller;
        public CriarTransacao()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void buttonCriarTransacao_Click(object sender, RoutedEventArgs e)
        {
            Card cartao = new Card("", long.Parse(this.textBoxCartao.Text), DateTime.Now, "", 0, "", 0);

            //Buscar cartão
            string resposta = controller.enviarMensagem(JsonUtil.converterObjetoParaJson(cartao));

            cartao = JsonUtil.converterJsonParaObjeto<Card>(resposta);

            Transaction transacao = new Transaction(float.Parse(this.textBoxValor.Text), this.textBoxTipo.Text, cartao, int.Parse(this.textBoxParcelas.Text));
        }
    }
}
