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
using System.IO;

namespace praktuchna_1
{
    enum StudyState
    {
        WAITING, PROCESS, FINISHED
    }
    /// <summary>
    /// Логика взаимодействия для StudyModeWindow.xaml
    /// </summary>
    public partial class StudyModeWindow : Window
    {
        private const string TEST_WORD = "qwerty";
        private MainWindow mainWindow;
        private InputManager manager;
        private List<double[]> results = new List<double[]>();
        private StudyState state = StudyState.WAITING;
        private int attempts;
        private int maxAttempts;
        public StudyModeWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            VerifField.Text = TEST_WORD;
            manager = new InputManager(TEST_WORD);
        }

        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.currentClosed();
        }

        private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (manager.keyUp(InputField.Text) != KeyResult.OK)
            {
                InputField.Text = manager.getTypedText();
                InputField.SelectionStart = InputField.Text.Length;
                InputField.SelectionLength = 0;
            }
            else
            {
                switch(state)
                {
                    case StudyState.WAITING:
                        state = StudyState.PROCESS;
                        attempts = 0;
                        maxAttempts = Int32.Parse(CountProtection.Text);
                        CountProtection.IsEnabled = false;
                        break;
                    case StudyState.PROCESS:
                        ManagerState managerState = manager.getState();
                        if (managerState == ManagerState.FINISHED)
                        {
                            attempts++;
                            results.Add(manager.getResult());
                            manager.cancel(TEST_WORD);
                            InputField.Text = "";
                            if (attempts == maxAttempts)
                            {
                                state = StudyState.FINISHED;
                                calculate();
                            }
                        }
                        break;
                    case StudyState.FINISHED:
                        MessageBox.Show("Results are obtained. Return to the main window");
                        break;
                }
            }
        }

        private void calculate()
        {
            StudyResultsCalculator calculator = new StudyResultsCalculator(results);
            List<double[]> calculated = calculator.process();
            StreamWriter writer = new StreamWriter("example.txt");
            foreach(double[] calculatedArray in calculated)
            {
                foreach(double c in calculatedArray)
                {
                    writer.Write($"\t{c}");
                }
                writer.WriteLine();
            }
            writer.Close();
        }
    }
}
