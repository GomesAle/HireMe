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
    /// Interaction logic for TelaLogin.xaml
    /// </summary>
    public partial class TelaLogin : Window
    {
        Controller controller;
        public TelaLogin()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            /*
            CriarTransacao criarTransacao = new CriarTransacao();
            criarTransacao.Show();
            */

            TelaTransacoes telaTransacoes = new TelaTransacoes();
            telaTransacoes.Show();
        }
    }
}
