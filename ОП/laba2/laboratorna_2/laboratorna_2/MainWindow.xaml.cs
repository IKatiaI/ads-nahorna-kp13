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

namespace laboratorna_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Win1 win1;
        private TicTacToeWin ticTacToeWin;
        private Win4 win4;
        private CalculatorWin calculatorWin;
        public MainWindow()
        {
            InitializeComponent();
            win1 = new Win1(this);
            ticTacToeWin = new TicTacToeWin(this);
            calculatorWin = new CalculatorWin(this);
            win4 = new Win4(this);
        }

        private void ToWin1_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            win1.Show();
        }

        private void ToWin2_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ticTacToeWin.Show();
        }

        private void ToWin3_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            calculatorWin.Show();
        }

        private void ToWin4_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            win4.Show();
        }

        private void Gnida_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
