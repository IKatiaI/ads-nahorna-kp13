using System;
using System.Windows;

namespace Laboratorna1
{
    /// <summary>
    /// Логика взаимодействия для Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        enum Operation
        {
            EMPTY, PLUS, MINUS, DIVIDE, MULTIPLY, EQUAL, SIGN
        }

        static int MAX_LENGTH = 18;

        string input = "0";
        string sign = "";
        double result = 0;
        
        Operation currentOperation = Operation.EMPTY;
        public Calculator()
        {
            InitializeComponent();

        }

        private void inputSymbol(string symbolStr)
        {
            if (input.Length == MAX_LENGTH)
            {
                return;
            }
            if (symbolStr == ",")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == ',') return;
                }
                if (input == "0")
                {
                    input = "0,";
                }
                else
                {
                    input += ",";
                }
            }
            else
            {
                if (input == "0")
                {
                    input = "";
                }
                input += symbolStr;
            }
            refresh();
        }

        private void delSymbol()
        {
            if (input == "0")
            {
                return;
            }
            if(input.Length == 1)
            {
                clearInput();
                return;
            }
            input = input.Substring(0, input.Length - 1);
            refresh();
        }

        private void changeSign()
        {
            if (sign == "")
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
            refresh();
        }

        private void clear()
        {
            result = 0;
            input = "0";
            sign = "";
            currentOperation = Operation.EMPTY;
            refresh();
        }

        private void refresh()
        {
            LB.Content = sign + input;
        }

        private void inputOperation(Operation operation)
        {
            double current = Convert.ToDouble(sign + input);
            switch (currentOperation)
            {
                case Operation.PLUS:
                    result += current;
                    break;
                case Operation.MINUS:
                    result -= current;
                    break;
                case Operation.MULTIPLY:
                    result *= current;
                    break;
                case Operation.DIVIDE:
                    if(current == 0)
                    {
                        return;
                    }
                    result /= current;
                    break;
                case Operation.EMPTY:
                    result = current;
                    break;
            }
            switch (operation)
            {
                case Operation.EQUAL:
                    showResult();
                    currentOperation = Operation.EMPTY;
                    break;
                default:
                    clearInput();
                    currentOperation = operation;
                    break;
            }
        }

        private void showResult()
        {
            if (result < 0)
            {
                sign = "-";
                input = Convert.ToString(-result);
            }
            else
            {
                sign = "";
                input = Convert.ToString(result);
            }
            if(input.Length > MAX_LENGTH)
            {
                input = input.Substring(0, MAX_LENGTH);
            }
            refresh();
        }

        private void clearInput()
        {
            input = "0";
            sign = "";
            refresh();
        }
        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            inputSymbol("1");
        }
        private void BT2_Click(object sender, RoutedEventArgs e)
        {
          inputSymbol("2");
        }
        private void BT3_Click(object sender, RoutedEventArgs e)
        {
           inputSymbol("3");
        }
        private void BT4_Click(object sender, RoutedEventArgs e)
        {
           inputSymbol("4");
        }
        private void BT5_Click(object sender, RoutedEventArgs e)
        {
        inputSymbol("5");
        }
        private void BT6_Click(object sender, RoutedEventArgs e)
        {
           inputSymbol("6");
        }
        private void BT7_Click(object sender, RoutedEventArgs e)
        {
           inputSymbol("7");
        }
        private void BT8_Click(object sender, RoutedEventArgs e)
        {
          inputSymbol("8");
        }
        private void BT9_Click(object sender, RoutedEventArgs e)
        {
         inputSymbol("9");
        }
        private void BT0_Click(object sender, RoutedEventArgs e)
        {
           inputSymbol("0");
        }

        private void BT_Click(object sender, RoutedEventArgs e)
        {
           inputSymbol(",");
        }
        private void BT_Del_Click(object sender, RoutedEventArgs e)
        {
           delSymbol();
        }
        private void BT_C_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void BT_Divide_Click(object sender, RoutedEventArgs e)
        {
           inputOperation(Operation.DIVIDE);
        }

        private void BT_Sign_Click(object sender, RoutedEventArgs e)
        {
            changeSign();
        }

        private void BT_Multiply_Click(object sender, RoutedEventArgs e)
        {
            inputOperation(Operation.MULTIPLY);
        }

        private void BT_Minus_Click(object sender, RoutedEventArgs e)
        {
            inputOperation(Operation.MINUS);
        }

        private void BT_Plus_Click(object sender, RoutedEventArgs e)
        {
            inputOperation(Operation.PLUS);
        }

        private void BT_Equal_Click(object sender, RoutedEventArgs e)
        {
            inputOperation(Operation.EQUAL);
        }
    }
}
