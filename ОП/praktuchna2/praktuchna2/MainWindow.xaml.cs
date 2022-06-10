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
using System.Windows.Threading;

namespace praktuchna2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DispatcherTimer timer;
        static int Radius = 15;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List<Ellipse>();
        static PointCollection CityPoints = new PointCollection();
        private Simulator simulator;
        private double probability = 0.2;
        
        public MainWindow()
        {
            timer = new DispatcherTimer();
            InitializeComponent();
            startSimulation();
            timer.Tick += new EventHandler(OneStep);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }
        private void InitPoints()
        {
            Random rnd = new Random();
            CityPoints.Clear();
            EllipseArray.Clear();
            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();
                p.X = rnd.Next(Radius, (int)(0.75 * MainWin.Width) - 3 * Radius);
                p.Y = rnd.Next(Radius, (int)(0.90 * MainWin.Height - 3 * Radius));
                CityPoints.Add(p);
            }
            for (int i = 0; i < PointCount; i++)
            {
                Ellipse el = new Ellipse();
                el.StrokeThickness = 1;
                el.Height = el.Width = Radius * 2;
                el.Stroke = Brushes.Black;
                el.Fill = Brushes.LightBlue;
                EllipseArray.Add(el);
            }
        }
        private void InitPolygon()
        {
            myPolygon.Stroke = Brushes.Black;
            myPolygon.StrokeThickness = 1;
        }
        private void PlotPoints()
        {
            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], CityPoints[i].X - Radius);
                Canvas.SetTop(EllipseArray[i], CityPoints[i].Y - Radius);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }

        private void PlotWay(int[] way)
        {
            PointCollection Points = new PointCollection();
            for (int i = 0; i < way.Length; i++)
            {
                Points.Add(CityPoints[way[i]]);
            }
            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }
        private void VelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
            timer.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));
        }
        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                NumElemCB.IsEnabled = true;
            }
            else
            {
                NumElemCB.IsEnabled = false;
                timer.Start();
            }
        }
        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
            PointCount = Convert.ToInt32(item.Content);
            startSimulation();
        }

        private void ProbabilityCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
            probability = Convert.ToDouble(item.Content);
            startSimulation();
        }

        private void startSimulation()
        {
            InitPoints();
            InitPolygon();
            simulator = new Simulator(CityPoints, 10, 5, probability);
        }
        private void OneStep(object sender, EventArgs e)
        {
            MyCanvas.Children.Clear();
            simulator.step();
            int[] bestWay = simulator.getBestWay();
            PlotWay(bestWay);
            PlotPoints();
            double length = simulator.getBestLength();
            Length.Content = Convert.ToString(length);
        }
        private int[] GetBestWay()
        {
            Random rnd = new Random();
            int[] way = new int[PointCount];
            for (int i = 0; i < PointCount; i++)
                way[i] = i;
            for (int s = 0; s < 2 * PointCount; s++)
            {
                int i1, i2, tmp;
                i1 = rnd.Next(PointCount);
                i2 = rnd.Next(PointCount);
                tmp = way[i1];
                way[i1] = way[i2];
                way[i2] = tmp;
            }
            return way;
        }
    }
}
