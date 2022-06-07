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

namespace praktuchna_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    enum CurrentWindow
    {
        MAIN, STUDY, PROTECTION
    }
    public partial class MainWindow : Window
    {
        private CurrentWindow currentWindow = CurrentWindow.MAIN;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void currentClosed()
        {
            currentWindow = CurrentWindow.MAIN;
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void StudyModeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentWindow == CurrentWindow.MAIN)
            {
                StudyModeWindow studyModeWindow = new StudyModeWindow(this);
                studyModeWindow.Show();
                currentWindow = CurrentWindow.STUDY;
            }
        }
        private void ProtectionModeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentWindow == CurrentWindow.MAIN)
            {
                ProtectionModeWindow protectionModeWindow = new ProtectionModeWindow(this);
                protectionModeWindow.Show();
                currentWindow = CurrentWindow.PROTECTION;
            }
        }
    }
}
