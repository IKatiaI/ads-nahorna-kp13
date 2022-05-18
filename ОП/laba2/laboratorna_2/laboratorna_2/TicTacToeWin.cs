using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace laboratorna_2
{
    enum CheckResult
    {
        USER_WON, COMPUTER_WON, NOBODY_WON, GAME_CONTINUE
    }
    class TicTacToeWin: Window
    {
        private MainWindow mainWindow;
        private Button ToHome;
        private Button Restart;
        private Button Cell_0_0;
        private Button Cell_0_1;
        private Button Cell_0_2;
        private Button Cell_0_3;
        private Button Cell_0_4;
        private Button Cell_1_0;
        private Button Cell_1_1;
        private Button Cell_1_2;
        private Button Cell_1_3;
        private Button Cell_1_4;
        private Button Cell_2_0;
        private Button Cell_2_1;
        private Button Cell_2_2;
        private Button Cell_2_3;
        private Button Cell_2_4;
        private Button Cell_3_0;
        private Button Cell_3_1;
        private Button Cell_3_2;
        private Button Cell_3_3;
        private Button Cell_3_4;
        private Button Cell_4_0;
        private Button Cell_4_1;
        private Button Cell_4_2;
        private Button Cell_4_3;
        private Button Cell_4_4;

        private Button[,] Buttons;
        int[,] Board = new int[5, 5];

        private const int ROWS = 7;
        private const int COLUMNS = 7;
        private const int BUTTON_WIDTH = 80;
        private const int BUTTON_HEIGHT = 80;

        public TicTacToeWin(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            initialize();
        }

        private void initialize()
        {
            this.Title = "Win1";
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStyle = WindowStyle.None;
            this.Height = 607.788;
            this.Width = 577.045;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Grid grid = new Grid();
            GridLengthConverter gridLengthConvertor = new GridLengthConverter();
            // grid.ShowGridLines = true;
            RowDefinition[] rowDefs = new RowDefinition[ROWS];
            ColumnDefinition[] colDefs = new ColumnDefinition[COLUMNS];
            for (int i = 0; i < ROWS; i++)
            {
                rowDefs[i] = new RowDefinition();
                grid.RowDefinitions.Add(rowDefs[i]);
            }
            for (int i = 0; i < COLUMNS; i++)
            {
                colDefs[i] = new ColumnDefinition();
                grid.ColumnDefinitions.Add(colDefs[i]);
            }

            //-----------buttons---------------------

            ToHome = new Button();  //на головну
            ToHome.Width = 80;
            ToHome.Height = 80;
            ToHome.Content = "return";
            ToHome.VerticalAlignment = VerticalAlignment.Top;
            ToHome.HorizontalAlignment = HorizontalAlignment.Left;
            ToHome.FontSize = 16;
            ToHome.FontFamily = new FontFamily("Yu Gothic UI Light");
            ToHome.Click += onReturnBtnClick;
            Grid.SetRow(ToHome, 0);
            Grid.SetColumn(ToHome, 0);
            grid.Children.Add(ToHome);

            //------------------------------

            Restart = new Button();  //перезапустити гру
            Restart.Width = 133;
            Restart.Height = 34;
            Restart.Content = "RESTART";
            Restart.VerticalAlignment = VerticalAlignment.Top;
            Restart.HorizontalAlignment = HorizontalAlignment.Left;
            Restart.FontSize = 16;
            Restart.FontFamily = new FontFamily("Yu Gothic UI Light");
            Restart.Click += Restart_Click;
            Grid.SetRow(Restart, 6);
            Grid.SetColumn(Restart, 3);
            Grid.SetColumnSpan(Restart, 3);
            grid.Children.Add(Restart);

            //-------------треш тут їх 25( ---------------
            Buttons = new Button[5, 5];
            for (int i=0; i< 5; i++)
            {
                for(int j=0; j<5; j++)
                {
                    Button btn = new Button();
                    btn.Name = $"Cell_{i}_{j}";
                    btn.Background = Brushes.Transparent;
                    btn.Width = 79;
                    btn.Height = 81;
                    btn.Content = "";
                    btn.FontSize = 48;
                    btn.BorderBrush = null;
                    btn.VerticalAlignment = VerticalAlignment.Top;
                    btn.HorizontalAlignment = HorizontalAlignment.Left;
                    btn.Click += Button_Click;
                    Grid.SetRow(btn, i + 1);
                    Grid.SetColumn(btn, j + 1);
                    grid.Children.Add(btn);
                    Buttons[i, j] = btn;
                }
            }

            //-----------border---------------------
            Border border;

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.VerticalAlignment = VerticalAlignment.Top;
            border.HorizontalAlignment = HorizontalAlignment.Right;
            border.Width = 1;
            border.Height = 428;
            Grid.SetRow(border, 1);
            Grid.SetColumn(border, 1);
            Grid.SetRowSpan(border, 5);
            grid.Children.Add(border);
            //--------------------------

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.VerticalAlignment = VerticalAlignment.Top;
            border.HorizontalAlignment = HorizontalAlignment.Right;
            border.Width = 1;
            border.Height = 428;
            Grid.SetRow(border, 1);
            Grid.SetColumn(border, 2);
            Grid.SetRowSpan(border, 5);
            grid.Children.Add(border);
            //--------------------------

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.VerticalAlignment = VerticalAlignment.Top;
            border.HorizontalAlignment = HorizontalAlignment.Right;
            border.Width = 1;
            border.Height = 428;
            Grid.SetRow(border, 1);
            Grid.SetColumn(border, 3);
            Grid.SetRowSpan(border, 5);
            grid.Children.Add(border);
            //--------------------------

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.VerticalAlignment = VerticalAlignment.Top;
            border.HorizontalAlignment = HorizontalAlignment.Right;
            border.Width = 1;
            border.Height = 428;
            Grid.SetRow(border, 1);
            Grid.SetColumn(border, 4);
            Grid.SetRowSpan(border, 5);
            grid.Children.Add(border);
            //--------------------------

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.VerticalAlignment = VerticalAlignment.Bottom;
            border.HorizontalAlignment = HorizontalAlignment.Left;
            border.Width = 428;
            border.Height = 1;
            Grid.SetRow(border, 1);
            Grid.SetColumn(border, 1);
            Grid.SetColumnSpan(border, 5);
            grid.Children.Add(border);
            //--------------------------

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.VerticalAlignment = VerticalAlignment.Bottom;
            border.HorizontalAlignment = HorizontalAlignment.Left;
            border.Width = 428;
            border.Height = 1;
            Grid.SetRow(border, 2);
            Grid.SetColumn(border, 1);
            Grid.SetColumnSpan(border, 5);
            grid.Children.Add(border);
            //--------------------------

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.VerticalAlignment = VerticalAlignment.Bottom;
            border.HorizontalAlignment = HorizontalAlignment.Left;
            border.Width = 428;
            border.Height = 1;
            Grid.SetRow(border, 3);
            Grid.SetColumn(border, 1);
            Grid.SetColumnSpan(border, 5);
            grid.Children.Add(border);
            //--------------------------

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.VerticalAlignment = VerticalAlignment.Bottom;
            border.HorizontalAlignment = HorizontalAlignment.Left;
            border.Width = 428;
            border.Height = 1;
            Grid.SetRow(border, 4);
            Grid.SetColumn(border, 1);
            Grid.SetColumnSpan(border, 5);
            grid.Children.Add(border);

            //-----------------------------------------------------

            this.Content = grid;
        }
        private void onReturnBtnClick(object sender, RoutedEventArgs args)
        {
            this.Hide();
            mainWindow.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            (int row, int column) = getPosition(btn.Name);
            if (row == -1 || column == -1)
            {
                return;
            }
            if (Board[row, column] == 0)
            {
                step(row, column, 100);

                switch (checkResult())
                {
                    case CheckResult.USER_WON:
                        endGame("You won");
                        break;
                    case CheckResult.NOBODY_WON:
                        endGame("Nobody won");
                        break;
                    default:
                        makeComputerStep();
                        switch (checkResult())
                        {
                            case CheckResult.COMPUTER_WON:
                                endGame("I won");
                                break;
                            case CheckResult.NOBODY_WON:
                                endGame("Nobody won");
                                break;
                        }
                        break;
                }
            }
        }

        private void endGame(string msg)
        {
            //Won1 mw = new Won1();
            //mw.msg.Content = msg;
            //mw.Show();
            MessageBox.Show(msg);
        }
        private bool checkIfGameFinished(int[,] Board)
        {
            int row, column;

            for (row = 0; row < 5; row++)
            {
                for (column = 0; column < 5; column++)
                {
                    if (Board[row, column] == 0) return false;
                }
            }
            return true;
        }



        private CheckResult checkResult()
        {
            int x_value = 100;
            int o_value = -1;
            if (checkForWin(x_value))
            {
                return CheckResult.USER_WON;
            }
            if (checkForWin(o_value))
            {
                return CheckResult.COMPUTER_WON;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Board[i, j] == 0)
                    {
                        return CheckResult.GAME_CONTINUE;
                    }
                }
            }
            return CheckResult.NOBODY_WON;
        }

        private bool checkForWin(int value)
        {
            int i;
            for (i = 0; i < 5; i++)
            {
                int j;
                for (j = 0; j < 5 && Board[i, j] == value; j++) ;
                if (j == 5)
                {
                    return true;
                }
            }
            for (i = 0; i < 5; i++)
            {
                int j;
                for (j = 0; j < 5 && Board[j, i] == value; j++) ;
                if (j == 5)
                {
                    return true;
                }
            }
            for (i = 0; i < 5 && Board[i, i] == value; i++) ;
            if (i == 5)
            {
                return true;
            }
            for (i = 0; i < 5 && Board[i, 4 - i] == value; i++) ;
            if (i == 5)
            {
                return true;
            }
            return false;
        }
        private void makeComputerStep()
        {
            Random rnd = new Random();
            int p;
            p = rnd.Next(1, 8);
            if (p % 2 == 1)
            {
                if (smartProtection(-400)) return;
            }
            if (p == 3)
            {
                if (smartProtection(-300)) return;
            }
            if (smartStep(4)) return;
            if (smartStep(3)) return;
            if (smartStep(2)) return;
            if (smartStep(1)) return;
            if (smartStep(0)) return;

            int row, column, i = 0;
            row = rnd.Next(0, 5);
            column = rnd.Next(0, 5);
            do
            {
                if (Board[row, column] == 0)
                {
                    Buttons[row, column].Content = 'o';
                    Board[row, column] = -1;
                    i = -1;
                }
                else
                {
                    row = rnd.Next(0, 5);
                    column = rnd.Next(0, 5);
                }
            }
            while (i == 0);
        }
        private bool smartProtection(int value)
        {
            int i, j, s;
            for (i = 0; i < 5; i++)
            {
                for (j = 0, s = 0; j < 5; s += Board[i, j], j++) ;
                if (s == -value)
                {
                    for (j = 0; j < 5 && Board[i, j] != 0; j++) ;
                    step(i, j, -1);
                    return true;
                }
            }
            for (i = 0; i < 5; i++)
            {
                for (j = 0, s = 0; j < 5; s += Board[j, i], j++) ;
                if (s == -value)
                {
                    for (j = 0; j < 5 && Board[j, i] != 0; j++) ;
                    step(j, i, -1);
                    return true;
                }
            }
            for (i = 0, s = 0; i < 5; s += Board[i, i], i++) ;
            if (s == -value)
            {
                for (i = 0; i < 5 && Board[i, i] != 0; i++) ;
                step(i, i, -1);
                return true;
            }
            for (i = 0, s = 0; i < 5; s += Board[i, 4 - i], i++) ;
            if (s == -value)
            {
                for (i = 0; i < 5 && Board[i, 4 - i] != 0; i++) ;
                step(i, 4 - i, -1);
                return true;
            }
            return false;
        }

        private bool smartStep(int value)
        {
            int i, j, s;
            for (i = 0; i < 5; i++)
            {
                for (j = 0, s = 0; j < 5; s += Board[i, j], j++) ;
                if (s == -value)
                {
                    for (j = 0; j < 5 && Board[i, j] != 0; j++) ;
                    step(i, j, -1);
                    return true;
                }
            }
            for (i = 0; i < 5; i++)
            {
                for (j = 0, s = 0; j < 5; s += Board[j, i], j++) ;
                if (s == -value)
                {
                    for (j = 0; j < 5 && Board[j, i] != 0; j++) ;
                    step(j, i, -1);
                    return true;
                }
            }
            for (i = 0, s = 0; i < 5; s += Board[i, i], i++) ;
            if (s == -value)
            {
                for (i = 0; i < 5 && Board[i, i] != 0; i++) ;
                step(i, i, -1);
                return true;
            }
            for (i = 0, s = 0; i < 5; s += Board[i, 4 - i], i++) ;
            if (s == -value)
            {
                for (i = 0; i < 5 && Board[i, 4 - i] != 0; i++) ;
                step(i, 4 - i, -1);
                return true;
            }
            return false;
        }

        private void step(int row, int column, int value)
        {
            switch (value)
            {
                case 100:
                    Board[row, column] = 100;
                    Buttons[row, column].Content = "x";
                    break;
                case -1:
                    Board[row, column] = -1;
                    Buttons[row, column].Content = "o";
                    break;
            }
        }

        private (int row, int column) getPosition(string name)
        {
            switch (name)
            {
                case "Cell_0_0": return (0, 0);
                case "Cell_0_1": return (0, 1);
                case "Cell_0_2": return (0, 2);
                case "Cell_0_3": return (0, 3);
                case "Cell_0_4": return (0, 4);
                case "Cell_1_0": return (1, 0);
                case "Cell_1_1": return (1, 1);
                case "Cell_1_2": return (1, 2);
                case "Cell_1_3": return (1, 3);
                case "Cell_1_4": return (1, 4);
                case "Cell_2_0": return (2, 0);
                case "Cell_2_1": return (2, 1);
                case "Cell_2_2": return (2, 2);
                case "Cell_2_3": return (2, 3);
                case "Cell_2_4": return (2, 4);
                case "Cell_3_0": return (3, 0);
                case "Cell_3_1": return (3, 1);
                case "Cell_3_2": return (3, 2);
                case "Cell_3_3": return (3, 3);
                case "Cell_3_4": return (3, 4);
                case "Cell_4_0": return (4, 0);
                case "Cell_4_1": return (4, 1);
                case "Cell_4_2": return (4, 2);
                case "Cell_4_3": return (4, 3);
                case "Cell_4_4": return (4, 4);
            }
            return (-1, -1);
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Board[i, j] = 0;
                    Buttons[i, j].Content = ' ';
                }
            }
        }
    }
}
