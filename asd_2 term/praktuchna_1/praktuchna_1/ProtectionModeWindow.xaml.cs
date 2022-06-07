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
    enum TestState
    {
        WAITING, PROCESS, FINISHED
    }
    /// <summary>
    /// Логика взаимодействия для ProtectionModeWindow.xaml
    /// </summary>
    public partial class ProtectionModeWindow : Window
    {
        private const string TEST_WORD = "qwerty";
        private MainWindow mainWindow;
        private InputManager manager;
        private List<double[]> results = new List<double[]>();
        private TestState state = TestState.WAITING;
        private int attempts;
        private int maxAttempts;

        public ProtectionModeWindow(MainWindow mainWindow)
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

        private void InputField_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (manager.keyUp(InputField.Text) != KeyResult.OK)
            {
                InputField.Text = manager.getTypedText();
                InputField.SelectionStart = InputField.Text.Length;
                InputField.SelectionLength = 0;
            }
            else
            {
                switch (state)
                {
                    case TestState.WAITING:
                        state = TestState.PROCESS;
                        attempts = 0;
                        maxAttempts = Int32.Parse(CountProtection.Text);
                        CountProtection.IsEnabled = false;
                        break;
                    case TestState.PROCESS:
                        ManagerState managerState = manager.getState();
                        if (managerState == ManagerState.FINISHED)
                        {
                            attempts++;
                            results.Add(manager.getResult());
                            manager.cancel(TEST_WORD);
                            InputField.Text = "";
                            if (attempts == maxAttempts)
                            {
                                state = TestState.FINISHED;
                                calculate();
                            }
                        }
                        break;
                    case TestState.FINISHED:
                        MessageBox.Show("Results are obtained.");
                        break;
                }
            }
        }

        private void calculate()
        {
            StudyResultsCalculator calculator = new StudyResultsCalculator(results);
            List<double[]> calculated = calculator.process();
            double alfa = Double.Parse(AlphaSelector.Text);
            StreamReader reader = new StreamReader("example.txt");
            List<double[]> etalon = new List<double[]>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] words = line.Trim().Split('\t');
                double[] etalonArray = new double[words.Length];
                for(int i=0; i< words.Length; i++)
                {
                    etalonArray[i] = Double.Parse(words[i].Trim());
                }
                etalon.Add(etalonArray);
            }
            reader.Close();
            Authentificator authenticator = new Authentificator(etalon, calculated, alfa);
            int guest = authenticator.process();
            Authentificator authenticator2 = new Authentificator(etalon, etalon, alfa);
            int owner = authenticator2.process();
            int N = calculated.Count;
            double P = ((double)guest) / N;
            double P2 = (N - (double)guest) / N;
            N = etalon.Count;
            double P1 = (N - (double)owner) / N;
            StatisticsBlock.Content = P.ToString();
            P1Field.Content = P1.ToString();
            P2Field.Content = P2.ToString();
        }
    }
}
