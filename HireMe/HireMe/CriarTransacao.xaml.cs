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
        public CriarTransacao()
        {
            InitializeComponent();
        }

        private void buttonCriarTransacao_Click(object sender, RoutedEventArgs e)
        {
            Transaction transacao = new Transaction();
        }
    }
}
