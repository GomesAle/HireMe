﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RockClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            TelaCadastro telaCadastro = new TelaCadastro();
            telaCadastro.Show();
        }

        private void button_Logar_Click(object sender, RoutedEventArgs e)
        {
            TelaTransacoes telaTransacoes = new TelaTransacoes();
            telaTransacoes.Show();
        }
    }
}
