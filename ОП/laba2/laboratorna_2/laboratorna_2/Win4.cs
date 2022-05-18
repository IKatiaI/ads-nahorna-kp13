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
    class Win4: Window
    {
        private MainWindow mainWindow;
        private Button ToHome;

        public Win4(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            initialize();
        }

        private void initialize()
        {
            this.Title = "Win1";
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStyle = WindowStyle.None;
            this.Height = 387.5;
            this.Width = 723.864;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Grid grid = new Grid();

            ToHome = new Button();  //на головну
            ToHome.Width = 80;
            ToHome.Height = 78;
            ToHome.Content = "return";
            ToHome.VerticalAlignment = VerticalAlignment.Top;
            ToHome.HorizontalAlignment = HorizontalAlignment.Left;
            ToHome.FontSize = 16;
            ToHome.FontFamily = new FontFamily("Yu Gothic UI Light");
            ToHome.Margin = new Thickness(83, 262, 0, -58);
            ToHome.Click += onReturnBtnClick;

            //--------labels------------------------
            Label label;

            label = new Label();
            label.Content = "    Нагорна Катерина Вікторівна";
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Width = 575;
            label.Height = 64;
            label.FontSize = 36;
            label.FontFamily = new FontFamily("Yu Gothic UI Light");
            label.Margin = new Thickness(83, 81, 0, 0);
            grid.Children.Add(label);

            label = new Label();
            label.Content = "08.02.2022";
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Width = 175;
            label.Height = 64;
            label.FontSize = 36;
            label.FontFamily = new FontFamily("Yu Gothic UI Light");
            label.Margin = new Thickness(507, 276, 0, -58);
            grid.Children.Add(label);

            label = new Label();
            label.Content = "група КП-13";
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Width = 196;
            label.Height = 64;
            label.FontSize = 36;
            label.FontFamily = new FontFamily("Yu Gothic UI Light");
            label.Margin = new Thickness(246, 150, 0, 0);
            grid.Children.Add(label);

            //---------------------------------

            grid.Children.Add(ToHome);

            this.Content = grid;
        }

        private void onReturnBtnClick(object sender, RoutedEventArgs args)
        {
            this.Hide();
            mainWindow.Show();
        }
    }
}
