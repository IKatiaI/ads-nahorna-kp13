using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace laboratorna_2
{
    enum Speciality
    {
        SPEC_123, SPEC_113, SPEC_121
    }
    enum Kyrs
    {
        KYRS_1, KYRS_2, KYRS_3, KYRS_4
    }
    class Record
    {
        private string PIP;
        private string book;
        private Speciality spec;
        private Kyrs kyrs;
        public Record(string PIP, string book, Speciality spec, Kyrs kyrs)
        {
            this.PIP = PIP.Trim();
            this.book = book.Trim();
            this.spec = spec;
            this.kyrs = kyrs;
        }

        public string getPIP() => PIP;
        public string getBook() => book;
        public Speciality getSpec() => spec;
        public Kyrs getKyrs() => kyrs;

    }

    class Base
    {
        private List<Record> records = new List<Record>();
        public void load(string path)
        {
            records.Clear();
            System.IO.StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] lines = line.Trim().Split(';');
                if (lines.Length != 4)
                {
                    continue;
                }
                try
                {
                    string PIB = lines[0].Trim();
                    string book = lines[1].Trim();
                    Speciality spec = getSpecByCode(lines[2]);
                    Kyrs kyrs = getKyrsByCode(lines[3]);
                    records.Add(new Record(PIB, book, spec, kyrs));
                }
                catch (Exception)
                {

                }
            }
            reader.Close();
        }

        public void save(string path)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(path);
            foreach (Record record in records)
            {
                try
                {
                    string specCode = getSpecCode(record.getSpec());
                    string kyrsCode = getKyrsCode(record.getKyrs());
                    string line = $"{record.getPIP()};{record.getBook()};{specCode};{kyrsCode}";
                    writer.WriteLine(line);
                }
                catch (Exception)
                {

                }
            }
            writer.Close();
        }

        public void add(Record record)
        {
            records.Add(record);
        }

        public bool deleteByBook(string book)
        {
            string key = book.Trim();
            foreach (Record record in records)
            {
                if (String.Equals(record.getBook(), key))
                {
                    records.Remove(record);
                    return true;
                }
            }
            return false;
        }

        private Speciality getSpecByCode(string code)
        {
            switch (code)
            {
                case "113":
                    return Speciality.SPEC_113;
                case "121":
                    return Speciality.SPEC_121;
                case "123":
                    return Speciality.SPEC_123;
                default:
                    throw new Exception("Invalid Speciality Code");
            }
        }

        private string getSpecCode(Speciality spec)
        {
            switch (spec)
            {
                case Speciality.SPEC_113:
                    return "113";
                case Speciality.SPEC_121:
                    return "121";
                case Speciality.SPEC_123:
                    return "123";
                default:
                    throw new Exception("Invalid Speciality");
            }
        }

        private Kyrs getKyrsByCode(string code)
        {
            switch (code)
            {
                case "1":
                    return Kyrs.KYRS_1;
                case "2":
                    return Kyrs.KYRS_2;
                case "3":
                    return Kyrs.KYRS_3;
                case "4":
                    return Kyrs.KYRS_4;
                default:
                    throw new Exception("Invalid Kyrs Code");
            }
        }

        private string getKyrsCode(Kyrs kyrs)
        {
            switch (kyrs)
            {
                case Kyrs.KYRS_1:
                    return "1";
                case Kyrs.KYRS_2:
                    return "2";
                case Kyrs.KYRS_3:
                    return "3";
                case Kyrs.KYRS_4:
                    return "4";
                default:
                    throw new Exception("Invalid Kyrs");
            }
        }
    }
    class Win1 : Window
    {
        string baseFilePath = "";
        Base theBase = new Base();
        private MainWindow mainWindow;
        private Button ToHome;
        private Button Add_Student;
        private Button Del_Student;
        private TextBox PIP_Text;
        private TextBox Book_Text;
        private TextBox Del_Book_Text;
        private ComboBox Spec;
        private ComboBox Kyrs;
        public Win1(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            initialize();
        }

        private void initialize()
        {
            this.Title = "Win1";
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStyle = WindowStyle.None;
            this.Height = 387.797;
            this.Width = 723.864;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Grid grid = new Grid();

            //-----------buttons---------------------

            ToHome = new Button();  //на головну
            ToHome.Width = 80;
            ToHome.Height = 78;
            ToHome.Content = "return";
            ToHome.VerticalAlignment = VerticalAlignment.Top;
            ToHome.HorizontalAlignment = HorizontalAlignment.Left;
            ToHome.FontSize = 16;
            ToHome.FontFamily = new FontFamily("Yu Gothic UI Light");
            ToHome.Margin = new Thickness(630, 10, 0, 0);
            ToHome.Click += onReturnBtnClick;

            Add_Student = new Button();  //додати студента
            Add_Student.Width = 106;
            Add_Student.Height = 35;
            Add_Student.Content = "Додати";
            Add_Student.VerticalAlignment = VerticalAlignment.Top;
            Add_Student.HorizontalAlignment = HorizontalAlignment.Left;
            Add_Student.FontSize = 16;
            Add_Student.FontFamily = new FontFamily("Yu Gothic UI Light");
            Add_Student.Margin = new Thickness(215, 282, 0, 0);
            

            Del_Student = new Button();  //видалити студента
            Del_Student.Width = 106;
            Del_Student.Height = 35;
            Del_Student.Content = "Видалити";
            Del_Student.VerticalAlignment = VerticalAlignment.Top;
            Del_Student.HorizontalAlignment = HorizontalAlignment.Left;
            Del_Student.FontSize = 16;
            Del_Student.FontFamily = new FontFamily("Yu Gothic UI Light");
            Del_Student.Margin = new Thickness(551, 282, 0, 0);
            

            //--------labels------------------------
            Label label;
            
            label = new Label();
            label.Content = "Додати студента";
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Width = 130;
            label.Height = 38;
            label.FontSize = 16; 
            label.FontFamily = new FontFamily("Yu Gothic UI Light");
            label.Margin = new Thickness(77, 21, 0, 0);
            grid.Children.Add(label);

            label = new Label();
            label.Content = "Видалити студента";
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Width = 148;
            label.Height = 38;
            label.FontSize = 16;
            label.FontFamily = new FontFamily("Yu Gothic UI Light");
            label.Margin = new Thickness(509, 161, 0, 0);
            grid.Children.Add(label);

            label = new Label();
            label.Content = "ПІП:";
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Width = 45;
            label.Height = 38;
            label.FontSize = 16;
            label.FontFamily = new FontFamily("Yu Gothic UI Light");
            label.Margin = new Thickness(10, 62, 0, 0);
            grid.Children.Add(label);

            label = new Label();
            label.Content = "№ зал.кн.:";
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Width = 88;
            label.Height = 38;
            label.FontSize = 16;
            label.FontFamily = new FontFamily("Yu Gothic UI Light");
            label.Margin = new Thickness(385, 211, 0, 0);
            grid.Children.Add(label);

            label = new Label();
            label.Content = "№ зал.кн.:";
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Width = 88;
            label.Height = 38;
            label.FontSize = 16;
            label.FontFamily = new FontFamily("Yu Gothic UI Light");
            label.Margin = new Thickness(10, 113, 0, 0);
            grid.Children.Add(label);

            label = new Label();
            label.Content = "Спеціальність:";
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Width = 110;
            label.Height = 38;
            label.FontSize = 16;
            label.FontFamily = new FontFamily("Yu Gothic UI Light");
            label.Margin = new Thickness(10, 177, 0, 0);
            grid.Children.Add(label);

            label = new Label();
            label.Content = "Курс:";
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Width = 45;
            label.Height = 38;
            label.FontSize = 16;
            label.FontFamily = new FontFamily("Yu Gothic UI Light");
            label.Margin = new Thickness(10, 222, 0, 0);
            grid.Children.Add(label);

            //-----------------------------------------
            //------------textboxes--------------------

            PIP_Text = new TextBox();
            PIP_Text.Width = 273;
            PIP_Text.Height = 25;
            PIP_Text.FontSize = 16;
            PIP_Text.FontFamily = new FontFamily("Yu Gothic UI Light");
            PIP_Text.VerticalAlignment = VerticalAlignment.Top;
            PIP_Text.HorizontalAlignment = HorizontalAlignment.Left;
            PIP_Text.Margin = new Thickness(60, 66, 0, 0);
            grid.Children.Add(PIP_Text);

            Book_Text = new TextBox();
            Book_Text.Width = 230;
            Book_Text.Height = 25;
            Book_Text.FontSize = 16;
            Book_Text.FontFamily = new FontFamily("Yu Gothic UI Light");
            Book_Text.VerticalAlignment = VerticalAlignment.Top;
            Book_Text.HorizontalAlignment = HorizontalAlignment.Left;
            Book_Text.Margin = new Thickness(103, 117, 0, 0);
            grid.Children.Add(Book_Text);

            Del_Book_Text = new TextBox();
            Del_Book_Text.Width = 230;
            Del_Book_Text.Height = 25;
            Del_Book_Text.FontSize = 16;
            Del_Book_Text.FontFamily = new FontFamily("Yu Gothic UI Light");
            Del_Book_Text.VerticalAlignment = VerticalAlignment.Top;
            Del_Book_Text.HorizontalAlignment = HorizontalAlignment.Left;
            Del_Book_Text.Margin = new Thickness(478, 215, 0, 0);
            grid.Children.Add(Del_Book_Text);
            
            //-----------------------------------------
            //-------------ComboBoxes------------------

            Spec = new ComboBox();     //спеціальність
            Spec.Width = 205;
            Spec.Height = 21;
            Spec.HorizontalAlignment = HorizontalAlignment.Left;
            Spec.VerticalAlignment = VerticalAlignment.Top;
            Spec.Items.Add("113 Прикладна математика");
            Spec.Items.Add("121 Інженерія програмного забезпечення");
            Spec.Items.Add("123 Комп'ютерна інженерія");
            Spec.SelectedIndex = 0;
            Spec.Margin = new Thickness(135, 184, 0, 0);
            grid.Children.Add(Spec);


            Kyrs = new ComboBox();     //курс
            Kyrs.Width = 60;
            Kyrs.Height = 21;
            Kyrs.HorizontalAlignment = HorizontalAlignment.Left;
            Kyrs.VerticalAlignment = VerticalAlignment.Top;
            Kyrs.Items.Add("1 курс");
            Kyrs.Items.Add("2 курс");
            Kyrs.Items.Add("3 курс");
            Kyrs.Items.Add("4 курс");
            Kyrs.SelectedIndex = 0;
            Kyrs.Margin = new Thickness(60, 228, 0, 0);
            grid.Children.Add(Kyrs);

            //-----------------------------------------

            grid.Children.Add(ToHome);
            grid.Children.Add(Add_Student);
            grid.Children.Add(Del_Student);
            
            this.Content = grid;
        }

        private void onReturnBtnClick(object sender, RoutedEventArgs args)
        {
            this.Hide();
            mainWindow.Show();
        }


        private void Spec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Kyrs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Base_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                baseFilePath = openFileDialog.FileName;
                theBase.load(baseFilePath);
            }
        }

        private void Add_Record_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string PIP = PIP_Text.Text;
                string book = Book_Text.Text;
                Speciality spec = getSpecByControlIndex(Spec.SelectedIndex);
                Kyrs kyrs = getKyrsByControlIndex(Kyrs.SelectedIndex);
                Record record = new Record(PIP, book, spec, kyrs);
                theBase.add(record);
                theBase.save(baseFilePath);
            }
            catch (Exception)
            {

            }
        }

        private Speciality getSpecByControlIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return Speciality.SPEC_113;
                case 1:
                    return Speciality.SPEC_121;
                case 2:
                    return Speciality.SPEC_123;
                default:
                    throw new Exception("Invalid Speciality index");
            }
        }

        private Kyrs getKyrsByControlIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return laboratorna_2.Kyrs.KYRS_1;
                case 1:
                    return laboratorna_2.Kyrs.KYRS_2;
                case 2:
                    return laboratorna_2.Kyrs.KYRS_3;
                case 3:
                    return laboratorna_2.Kyrs.KYRS_4;
                default:
                    throw new Exception("Invalid Kyrs index");
            }
        }

        private void Del_Record_Click(object sender, RoutedEventArgs e)
        {
            string book = Del_Book_Text.Text;
            if (theBase.deleteByBook(book))
            {
                theBase.save(baseFilePath);
            }
        }

    }
}
