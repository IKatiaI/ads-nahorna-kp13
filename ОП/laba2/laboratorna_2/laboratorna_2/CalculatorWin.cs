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
    class CalculatorWin: Window
    {
        private MainWindow mainWindow;
        private Button ToHome;
        private const int ROWS = 6;
        private const int COLUMNS = 4;
        private const int BUTTON_WIDTH = 45;
        private const int BUTTON_HEIGHT = 39;

        private Button equalBtn;
        private Button cancelBtn;
        private Button deleteBtn;
        private Button digit_0_Btn;
        private Button digit_1_Btn;
        private Button digit_2_Btn;
        private Button digit_3_Btn;
        private Button digit_4_Btn;
        private Button digit_5_Btn;
        private Button digit_6_Btn;
        private Button digit_7_Btn;
        private Button digit_8_Btn;
        private Button digit_9_Btn;
        private Button divideBtn;
        private Button multiplyBtn;
        private Button subBtn;
        private Button addBtn;
        private Button signBtn;
        private Button commaBtn;

        private Label LB;

        public CalculatorWin(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            initialize();
        }
        private void initialize()
        {
            this.Title = "Calculator";
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStyle = WindowStyle.None;
            this.Height = 354.127;
            this.Width = 223.657;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Grid grid = new Grid();
            GridLengthConverter gridLengthConvertor = new GridLengthConverter();
            // grid.ShowGridLines = true;
            RowDefinition[] rowDefs = new RowDefinition[ROWS];
            ColumnDefinition[] colDefs = new ColumnDefinition[COLUMNS];
            rowDefs[0] = new RowDefinition();
            rowDefs[0].Height = (GridLength)gridLengthConvertor.ConvertFrom("100");
            grid.RowDefinitions.Add(rowDefs[0]);
            for (int i = 1; i < ROWS; i++)
            {
                rowDefs[i] = new RowDefinition();
                rowDefs[i].Height = (GridLength)gridLengthConvertor.ConvertFrom("*");
                grid.RowDefinitions.Add(rowDefs[i]);
            }
            for (int i = 0; i < COLUMNS; i++)
            {
                colDefs[i] = new ColumnDefinition();
                grid.ColumnDefinitions.Add(colDefs[i]);
            }

            LB = new Label();
            LB.Height = 36;
            LB.Width = 168;
            LB.Content = "0";
            LB.VerticalContentAlignment = VerticalAlignment.Center;
            LB.HorizontalContentAlignment = HorizontalAlignment.Right;
            LB.VerticalAlignment = VerticalAlignment.Center;
            LB.HorizontalAlignment = HorizontalAlignment.Center;
            LB.Background = Brushes.LightGray;
            Grid.SetRow(LB, 0);
            Grid.SetColumn(LB, 0);
            Grid.SetColumnSpan(LB, 4);
            grid.Children.Add(LB);

            equalBtn = new Button();
            equalBtn.Width = BUTTON_WIDTH;
            equalBtn.Height = BUTTON_HEIGHT;
            equalBtn.Content = "=";
            equalBtn.BorderBrush = null;
            equalBtn.VerticalContentAlignment = VerticalAlignment.Center;
            equalBtn.HorizontalContentAlignment = HorizontalAlignment.Center;
            equalBtn.VerticalAlignment = VerticalAlignment.Center;
            equalBtn.HorizontalAlignment = HorizontalAlignment.Center;
            equalBtn.Click += BT_Equal_Click;
            Grid.SetRow(equalBtn, 1);
            Grid.SetColumn(equalBtn, 1);
            grid.Children.Add(equalBtn);

            ToHome = new Button();  //на головну
            ToHome.Width = BUTTON_WIDTH;
            ToHome.Height = BUTTON_HEIGHT;
            ToHome.Content = "home";
            ToHome.BorderBrush = null;
            ToHome.VerticalContentAlignment = VerticalAlignment.Center;
            ToHome.HorizontalContentAlignment = HorizontalAlignment.Center;
            ToHome.VerticalAlignment = VerticalAlignment.Center;
            ToHome.HorizontalAlignment = HorizontalAlignment.Center;
            ToHome.FontSize = 12;
            ToHome.FontFamily = new FontFamily("Yu Gothic UI Light");
            ToHome.Foreground = Brushes.DarkRed;
            ToHome.Click += onReturnBtnClick;
            Grid.SetRow(ToHome, 1);
            Grid.SetColumn(ToHome, 0);
            grid.Children.Add(ToHome);

            cancelBtn = new Button();
            cancelBtn.Width = BUTTON_WIDTH;
            cancelBtn.Height = BUTTON_HEIGHT;
            cancelBtn.BorderBrush = null;
            cancelBtn.Content = "c";
            cancelBtn.FontSize = 12;
            cancelBtn.FontFamily = new FontFamily("Yu Gothic UI Light");
            cancelBtn.Foreground = Brushes.DarkRed;
            cancelBtn.VerticalContentAlignment = VerticalAlignment.Center;
            cancelBtn.HorizontalContentAlignment = HorizontalAlignment.Center;
            cancelBtn.VerticalAlignment = VerticalAlignment.Center;
            cancelBtn.HorizontalAlignment = HorizontalAlignment.Center;
            cancelBtn.Click += BT_C_Click;
            Grid.SetRow(cancelBtn, 1);
            Grid.SetColumn(cancelBtn, 2);
            grid.Children.Add(cancelBtn);

            deleteBtn = new Button();
            deleteBtn.Width = BUTTON_WIDTH;
            deleteBtn.Height = BUTTON_HEIGHT;
            deleteBtn.BorderBrush = null;
            deleteBtn.Content = "del";
            deleteBtn.FontSize = 12;
            deleteBtn.FontFamily = new FontFamily("Yu Gothic UI Light");
            deleteBtn.Foreground = Brushes.DarkRed;
            deleteBtn.VerticalContentAlignment = VerticalAlignment.Center;
            deleteBtn.HorizontalContentAlignment = HorizontalAlignment.Center;
            deleteBtn.VerticalAlignment = VerticalAlignment.Center;
            deleteBtn.HorizontalAlignment = HorizontalAlignment.Center;
            deleteBtn.Click += BT_Del_Click;
            Grid.SetRow(deleteBtn, 1);
            Grid.SetColumn(deleteBtn, 3);
            grid.Children.Add(deleteBtn);

            divideBtn = new Button();
            divideBtn.Width = BUTTON_WIDTH;
            divideBtn.Height = BUTTON_HEIGHT;
            divideBtn.BorderBrush = null;
            divideBtn.Content = "÷";
            divideBtn.FontSize = 12;
            divideBtn.FontFamily = new FontFamily("Yu Gothic UI Light");
            deleteBtn.Foreground = Brushes.DarkRed;
            divideBtn.VerticalContentAlignment = VerticalAlignment.Center;
            divideBtn.HorizontalContentAlignment = HorizontalAlignment.Center;
            divideBtn.VerticalAlignment = VerticalAlignment.Center;
            divideBtn.HorizontalAlignment = HorizontalAlignment.Center;
            divideBtn.Click += BT_Divide_Click;
            Grid.SetRow(divideBtn, 2);
            Grid.SetColumn(divideBtn, 3);
            grid.Children.Add(divideBtn);

            multiplyBtn = new Button();
            multiplyBtn.Width = BUTTON_WIDTH;
            multiplyBtn.Height = BUTTON_HEIGHT;
            multiplyBtn.BorderBrush = null;
            multiplyBtn.Content = "×";
            multiplyBtn.FontSize = 12;
            multiplyBtn.FontFamily = new FontFamily("Yu Gothic UI Light");
            multiplyBtn.Foreground = Brushes.DarkRed;
            multiplyBtn.VerticalContentAlignment = VerticalAlignment.Center;
            multiplyBtn.HorizontalContentAlignment = HorizontalAlignment.Center;
            multiplyBtn.VerticalAlignment = VerticalAlignment.Center;
            multiplyBtn.HorizontalAlignment = HorizontalAlignment.Center;
            multiplyBtn.Click += BT_Multiply_Click;
            Grid.SetRow(multiplyBtn, 3);
            Grid.SetColumn(multiplyBtn, 3);
            grid.Children.Add(multiplyBtn);

            subBtn = new Button();
            subBtn.Width = BUTTON_WIDTH;
            subBtn.Height = BUTTON_HEIGHT;
            subBtn.BorderBrush = null;
            subBtn.Content = "-";
            subBtn.FontSize = 12;
            subBtn.FontFamily = new FontFamily("Yu Gothic UI Light");
            subBtn.Foreground = Brushes.DarkRed;
            subBtn.VerticalContentAlignment = VerticalAlignment.Center;
            subBtn.HorizontalContentAlignment = HorizontalAlignment.Center;
            subBtn.VerticalAlignment = VerticalAlignment.Center;
            subBtn.HorizontalAlignment = HorizontalAlignment.Center;
            subBtn.Click += BT_Minus_Click;
            Grid.SetRow(subBtn, 4);
            Grid.SetColumn(subBtn, 3);
            grid.Children.Add(subBtn);

            addBtn = new Button();
            addBtn.Width = BUTTON_WIDTH;
            addBtn.Height = BUTTON_HEIGHT;
            addBtn.BorderBrush = null;
            addBtn.Content = "+";
            addBtn.FontSize = 12;
            addBtn.FontFamily = new FontFamily("Yu Gothic UI Light");
            addBtn.Foreground = Brushes.DarkRed;
            addBtn.VerticalContentAlignment = VerticalAlignment.Center;
            addBtn.HorizontalContentAlignment = HorizontalAlignment.Center;
            addBtn.VerticalAlignment = VerticalAlignment.Center;
            addBtn.HorizontalAlignment = HorizontalAlignment.Center;
            addBtn.Click += BT_Plus_Click;
            Grid.SetRow(addBtn, 5);
            Grid.SetColumn(addBtn, 3);
            grid.Children.Add(addBtn);


            commaBtn = new Button();
            commaBtn.Width = BUTTON_WIDTH;
            commaBtn.Height = BUTTON_HEIGHT;
            commaBtn.BorderBrush = null;
            commaBtn.Content = ",";
            commaBtn.FontSize = 15;
            commaBtn.FontFamily = new FontFamily("Yu Gothic UI Light");
            commaBtn.Foreground = Brushes.DarkRed;
            commaBtn.VerticalContentAlignment = VerticalAlignment.Center;
            commaBtn.HorizontalContentAlignment = HorizontalAlignment.Center;
            commaBtn.VerticalAlignment = VerticalAlignment.Center;
            commaBtn.HorizontalAlignment = HorizontalAlignment.Center;
            commaBtn.Click += BT_Click;
            Grid.SetRow(commaBtn, 5);
            Grid.SetColumn(commaBtn, 2);
            grid.Children.Add(commaBtn);

            signBtn = new Button();
            signBtn.Width = BUTTON_WIDTH;
            signBtn.Height = BUTTON_HEIGHT;
            signBtn.BorderBrush = null;
            signBtn.Content = "+/-";
            signBtn.FontSize = 12;
            signBtn.FontFamily = new FontFamily("Yu Gothic UI Light");
            signBtn.Foreground = Brushes.DarkRed;
            signBtn.VerticalContentAlignment = VerticalAlignment.Center;
            signBtn.HorizontalContentAlignment = HorizontalAlignment.Center;
            signBtn.VerticalAlignment = VerticalAlignment.Center;
            signBtn.HorizontalAlignment = HorizontalAlignment.Center;
            signBtn.Click += BT_Sign_Click;
            Grid.SetRow(signBtn, 5);
            Grid.SetColumn(signBtn, 0);
            grid.Children.Add(signBtn);


            digit_0_Btn = new Button();
            digit_0_Btn.Width = BUTTON_WIDTH;
            digit_0_Btn.Height = BUTTON_HEIGHT;
            digit_0_Btn.Content = "0";
            digit_0_Btn.BorderBrush = null;
            digit_0_Btn.VerticalContentAlignment = VerticalAlignment.Center;
            digit_0_Btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            digit_0_Btn.VerticalAlignment = VerticalAlignment.Center;
            digit_0_Btn.HorizontalAlignment = HorizontalAlignment.Center;
            digit_0_Btn.Click += BT0_Click;
            Grid.SetRow(digit_0_Btn, 5);
            Grid.SetColumn(digit_0_Btn, 1);
            grid.Children.Add(digit_0_Btn);

            digit_1_Btn = new Button();
            digit_1_Btn.Width = BUTTON_WIDTH;
            digit_1_Btn.Height = BUTTON_HEIGHT;
            digit_1_Btn.Content = "1";
            digit_1_Btn.BorderBrush = null;
            digit_1_Btn.VerticalContentAlignment = VerticalAlignment.Center;
            digit_1_Btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            digit_1_Btn.VerticalAlignment = VerticalAlignment.Center;
            digit_1_Btn.HorizontalAlignment = HorizontalAlignment.Center;
            digit_1_Btn.Click += BT1_Click;
            Grid.SetRow(digit_1_Btn, 4);
            Grid.SetColumn(digit_1_Btn, 0);
            grid.Children.Add(digit_1_Btn);

            digit_2_Btn = new Button();
            digit_2_Btn.Width = BUTTON_WIDTH;
            digit_2_Btn.Height = BUTTON_HEIGHT;
            digit_2_Btn.Content = "2";
            digit_2_Btn.BorderBrush = null;
            digit_2_Btn.VerticalContentAlignment = VerticalAlignment.Center;
            digit_2_Btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            digit_2_Btn.VerticalAlignment = VerticalAlignment.Center;
            digit_2_Btn.HorizontalAlignment = HorizontalAlignment.Center;
            digit_2_Btn.Click += BT2_Click;
            Grid.SetRow(digit_2_Btn, 4);
            Grid.SetColumn(digit_2_Btn, 1);
            grid.Children.Add(digit_2_Btn);

            digit_3_Btn = new Button();
            digit_3_Btn.Width = BUTTON_WIDTH;
            digit_3_Btn.Height = BUTTON_HEIGHT;
            digit_3_Btn.Content = "3";
            digit_3_Btn.BorderBrush = null;
            digit_3_Btn.VerticalContentAlignment = VerticalAlignment.Center;
            digit_3_Btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            digit_3_Btn.VerticalAlignment = VerticalAlignment.Center;
            digit_3_Btn.HorizontalAlignment = HorizontalAlignment.Center;
            digit_3_Btn.Click += BT3_Click;
            Grid.SetRow(digit_3_Btn, 4);
            Grid.SetColumn(digit_3_Btn, 2);
            grid.Children.Add(digit_3_Btn);

            digit_4_Btn = new Button();
            digit_4_Btn.Width = BUTTON_WIDTH;
            digit_4_Btn.Height = BUTTON_HEIGHT;
            digit_4_Btn.Content = "4";
            digit_4_Btn.BorderBrush = null;
            digit_4_Btn.VerticalContentAlignment = VerticalAlignment.Center;
            digit_4_Btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            digit_4_Btn.VerticalAlignment = VerticalAlignment.Center;
            digit_4_Btn.HorizontalAlignment = HorizontalAlignment.Center;
            digit_4_Btn.Click += BT4_Click;
            Grid.SetRow(digit_4_Btn, 3);
            Grid.SetColumn(digit_4_Btn, 0);
            grid.Children.Add(digit_4_Btn);

            digit_5_Btn = new Button();
            digit_5_Btn.Width = BUTTON_WIDTH;
            digit_5_Btn.Height = BUTTON_HEIGHT;
            digit_5_Btn.Content = "5";
            digit_5_Btn.BorderBrush = null;
            digit_5_Btn.VerticalContentAlignment = VerticalAlignment.Center;
            digit_5_Btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            digit_5_Btn.VerticalAlignment = VerticalAlignment.Center;
            digit_5_Btn.HorizontalAlignment = HorizontalAlignment.Center;
            digit_5_Btn.Click += BT5_Click;
            Grid.SetRow(digit_5_Btn, 3);
            Grid.SetColumn(digit_5_Btn, 1);
            grid.Children.Add(digit_5_Btn);

            digit_6_Btn = new Button();
            digit_6_Btn.Width = BUTTON_WIDTH;
            digit_6_Btn.Height = BUTTON_HEIGHT;
            digit_6_Btn.Content = "6";
            digit_6_Btn.BorderBrush = null;
            digit_6_Btn.VerticalContentAlignment = VerticalAlignment.Center;
            digit_6_Btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            digit_6_Btn.VerticalAlignment = VerticalAlignment.Center;
            digit_6_Btn.HorizontalAlignment = HorizontalAlignment.Center;
            digit_6_Btn.Click += BT6_Click;
            Grid.SetRow(digit_6_Btn, 3);
            Grid.SetColumn(digit_6_Btn, 2);
            grid.Children.Add(digit_6_Btn);

            digit_7_Btn = new Button();
            digit_7_Btn.Width = BUTTON_WIDTH;
            digit_7_Btn.Height = BUTTON_HEIGHT;
            digit_7_Btn.Content = "7";
            digit_7_Btn.BorderBrush = null;
            digit_7_Btn.VerticalContentAlignment = VerticalAlignment.Center;
            digit_7_Btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            digit_7_Btn.VerticalAlignment = VerticalAlignment.Center;
            digit_7_Btn.HorizontalAlignment = HorizontalAlignment.Center;
            digit_7_Btn.Click += BT7_Click;
            Grid.SetRow(digit_7_Btn, 2);
            Grid.SetColumn(digit_7_Btn, 0);
            grid.Children.Add(digit_7_Btn);

            digit_8_Btn = new Button();
            digit_8_Btn.Width = BUTTON_WIDTH;
            digit_8_Btn.Height = BUTTON_HEIGHT;
            digit_8_Btn.Content = "8";
            digit_8_Btn.BorderBrush = null;
            digit_8_Btn.VerticalContentAlignment = VerticalAlignment.Center;
            digit_8_Btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            digit_8_Btn.VerticalAlignment = VerticalAlignment.Center;
            digit_8_Btn.HorizontalAlignment = HorizontalAlignment.Center;
            digit_8_Btn.Click += BT8_Click;
            Grid.SetRow(digit_8_Btn, 2);
            Grid.SetColumn(digit_8_Btn, 1);
            grid.Children.Add(digit_8_Btn);

            digit_9_Btn = new Button();
            digit_9_Btn.Width = BUTTON_WIDTH;
            digit_9_Btn.Height = BUTTON_HEIGHT;
            digit_9_Btn.Content = "9";
            digit_9_Btn.BorderBrush = null;
            digit_9_Btn.VerticalContentAlignment = VerticalAlignment.Center;
            digit_9_Btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            digit_9_Btn.VerticalAlignment = VerticalAlignment.Center;
            digit_9_Btn.HorizontalAlignment = HorizontalAlignment.Center;
            digit_9_Btn.Click += BT9_Click;
            Grid.SetRow(digit_9_Btn, 2);
            Grid.SetColumn(digit_9_Btn, 2);
            grid.Children.Add(digit_9_Btn);

            this.Content = grid;
        }
        private void onReturnBtnClick(object sender, RoutedEventArgs args)
        {
            this.Hide();
            mainWindow.Show();
        }
        enum Operation
        {
            EMPTY, PLUS, MINUS, DIVIDE, MULTIPLY, EQUAL, SIGN
        }

        static int MAX_LENGTH = 18;

        string input = "0";
        string sign = "";
        double result = 0;

        Operation currentOperation = Operation.EMPTY;
        
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
            if (input.Length == 1)
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
                    if (current == 0)
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
            if (input.Length > MAX_LENGTH)
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
