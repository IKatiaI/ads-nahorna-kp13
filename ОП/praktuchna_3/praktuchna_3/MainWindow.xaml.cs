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

namespace praktuchna_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyRepository repository;
        public MainWindow()
        {
            repository = new MyRepository();
            InitializeComponent();
        }
        private void AdminMode_Click(object sender, RoutedEventArgs e)
        {
            Administration administration = new Administration(this, repository);
            Hide();
            administration.Show();
        }
        private void UserMode_Click(object sender, RoutedEventArgs e)
        {
            UserFormWPF userFormWPF = new UserFormWPF(this, repository);
            Hide();
            userFormWPF.Show();
        }
        private void UserMode_Copy_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void AboutDev_Click(object sender, RoutedEventArgs e)
        {
            DevWindow devWindow = new DevWindow(this);
            Hide();
            devWindow.Show();
        }

        public Boolean RestrictionFunc(String Pass)
        {
            Byte Count1, Count2, Count3;
            Byte LenPass = (Byte)Pass.Length;
            Count1 = Count2 = Count3 = 0;
            for (Byte i = 0; i < LenPass; i++)
            {
                if ((Convert.ToInt32(Pass[i]) >= 65) && (Convert.ToInt32(Pass[i]) <= 65 + 25))
                {
                    Count1++;
                }
                if ((Convert.ToInt32(Pass[i]) >= 97) && (Convert.ToInt32(Pass[i]) <= 97 + 25))
                {
                    Count2++;
                }
                if ((Pass[i] == '+') || (Pass[i] == '-') || (Pass[i] == '*') || (Pass[i] == '/'))
                {
                    Count3++;
                }
            }
            return (Count1 * Count2 * Count3 != 0);
        }
    }
}
