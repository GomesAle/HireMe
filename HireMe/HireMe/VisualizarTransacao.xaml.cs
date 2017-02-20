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
    /// Interaction logic for VisualizarTransacao.xaml
    /// </summary>
    public partial class VisualizarTransacao : Window
    {
        public VisualizarTransacao()
        {
            

            InitializeComponent();

            

        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<Transaction> transacoes = new List<Transaction>();
            Transaction t1 = new Transaction(1000, "Tipo1", new Card(), 1);
            Transaction t2 = new Transaction(1020, "Tipo2", new Card(), 2);
            Transaction t3 = new Transaction(1030, "Tipo3", new Card(), 3);
            Transaction t4 = new Transaction(1040, "Tipo4", new Card(), 5);
            
            /*
            var grid = sender as DataGrid;
            grid.ItemsSource = transacoes;
            */

            this.dataGrid.ItemsSource = transacoes;
        }
    }
}
