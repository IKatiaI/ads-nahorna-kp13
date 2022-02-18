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
using Microsoft.Win32;
using System.IO;


namespace Laboratorna1
{
    /// <summary>
    /// Логика взаимодействия для Wind1.xaml
    /// </summary>

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
            StreamReader reader = new StreamReader(path);
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
                catch(Exception)
                {

                }
            }
            reader.Close();
        }

        public void save(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            foreach(Record record in records)
            {
                try
                {
                    string specCode = getSpecCode(record.getSpec());
                    string kyrsCode = getKyrsCode(record.getKyrs());
                    string line = $"{record.getPIP()};{record.getBook()};{specCode};{kyrsCode}";
                    writer.WriteLine(line);
                }
                catch(Exception)
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
            foreach(Record record in records)
            {
                if(String.Equals(record.getBook(), key))
                {
                    records.Remove(record);
                    return true;
                }
            }
            return false;
        }

        private Speciality getSpecByCode(string code)
        {
            switch(code)
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
    public partial class Wind1 : Window
    {
        string baseFilePath = "";
        Base theBase = new Base();
        public Wind1()
        {
            InitializeComponent();
        }
        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
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
            switch(index)
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
                    return Laboratorna1.Kyrs.KYRS_1;
                case 1:
                    return Laboratorna1.Kyrs.KYRS_2;
                case 2:
                    return Laboratorna1.Kyrs.KYRS_3;
                case 3:
                    return Laboratorna1.Kyrs.KYRS_4;
                default:
                    throw new Exception("Invalid Kyrs index");
            }
        }

        private void Del_Record_Click(object sender, RoutedEventArgs e)
        {
            string book = Del_Book_Text.Text;
            if(theBase.deleteByBook(book))
            {
                theBase.save(baseFilePath);
            }
        }
    }
}
