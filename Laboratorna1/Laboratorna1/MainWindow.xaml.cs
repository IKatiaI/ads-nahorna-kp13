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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorna1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GoWind4_Click(object sender, RoutedEventArgs e)
        {
            Wind4 mw;
            mw = new Wind4();
            Hide();
            mw.Show();
        }
        private void GoCalculator_Click(object sender, RoutedEventArgs e)
        {
            Calculator mw;
            mw = new Calculator();
            Hide();
            mw.Show();
        }
        private void GoTictactoe_Click(object sender, RoutedEventArgs e)
        {
            Tictactoe mw;
            mw = new Tictactoe();
            Hide();
            mw.Show();
        }
        private void GoWind1_Click(object sender, RoutedEventArgs e)
        {
            Wind1 mw;
            mw = new Wind1();
            Hide();
            mw.Show();
        }
    }
}
