using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ConnectToSQLServer
{
    public partial class MainWindow : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //MessageBox.Show(connectionString);
            GetTaskOne();
            GetTaskTwo();
            GetTaskThree();
            GetTaskFour();
            GetTaskFive();
            GetTaskSix();
            GetTaskSeven();
            GetTaskEight();
            
        }

        private void GetAndDhowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
        }

        private void GetTaskOne()
        {
            string sqlQ = @"SELECT TOP 1
	c.Number AS [#],
	c.FirstName AS [Ім'я],
	c.LastName AS [Фамілія],
	c.Patronymic AS [По-батькові],
	c.Adress AS [Адресса],
	v.date  AS [дата останнього відвідування],
	prev.Name AS [Попередній діагноз],
	main.Name AS [Основний діагноз]
FROM
	Card c
	INNER JOIN Visit v ON c.ID = v.CardID
	INNER JOIN Disease prev ON prev.ID = v.prediagnosis
	INNER JOIN Disease main ON main.ID = v.diagnosis
WHERE
	c.Number = '003'
ORDER BY
	v.date DESC";
            try
            {
                GetAndDhowData(sqlQ, Task_one_DG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GetTaskTwo()
        {
            string sqlQ = @"
SELECT DISTINCT
	d.FirstName + ' ' + SUBSTRING(d.LastName,1,1)+ '. ' + SUBSTRING(d.Patronymic, 1, 1) + '.' AS [Доктор],
	c.FirstName + ' ' + SUBSTRING(c.LastName,1,1)+ '. ' + SUBSTRING(c.Patronymic, 1, 1) + '.' AS [Пацієнт]
FROM 
	Visit v 
	INNER JOIN Card c ON c.ID = v.CardID
	INNER JOIN Doctor d ON d.ID = v.DoctorID ";
            try
            {
                GetAndDhowData(sqlQ, Task_two_DG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GetTaskThree()
        {
            string sqlQ = @"
SELECT DISTINCT
	d.FirstName + ' ' + d.LastName + ' ' + d.Patronymic AS [Доктор],
	s.room,
	s.StartTime AS [ПОЧАТОК РОБОТИ],
	s.EndTime AS [КІНЕЦЬ РОБОТИ]
FROM 
	Doctor d 
	INNER JOIN Schedule s ON d.ID = s.DoctorID
WHERE
	d.ID = 4
ORDER BY
	s.StartTime ";
            try
            {
                GetAndDhowData(sqlQ, Task_three_DG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void GetTaskFour()
        {
            string sqlQ = @"SELECT DISTINCT
	d.FirstName + ' ' + SUBSTRING(d.LastName,1,1)+ '. ' + SUBSTRING(d.Patronymic, 1, 1) + '.' AS [Доктор],
	c.FirstName + ' ' + c.LastName + ' ' + c.Patronymic AS [Пацієнт],
	s.SickUntil AS [Кінцевий термін лікарняного]
FROM 
	Visit v 
	INNER JOIN SickLeave s ON  v.SickLeaveID = s.ID
	INNER JOIN Doctor d ON  d.ID = v.DoctorID
	INNER JOIN Card c ON  v.CardID = c.ID";
            try
            {
                GetAndDhowData(sqlQ, Task_four_DG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void GetTaskFive()
        {
            string sqlQ = @"SELECT DISTINCT
	v.CreatedBy AS [Доктор],
	c.FirstName + ' ' + c.LastName + ' ' + c.Patronymic AS [Пацієнт],
	d.Name AS[Хвороба],
	v.treatment AS [Лікування],
	v.date
FROM 
	Visit v 
	INNER JOIN Card c ON c.ID = v.CardID
	INNER JOIN Disease d ON d.ID = v.prediagnosis
WHERE
	d.Name = 'covid-19'
ORDER BY
	v.date
";
            try
            {
                GetAndDhowData(sqlQ, Task_five_DG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        private void GetTaskSix()
        {
            string sqlQ = @"SELECT DISTINCT
	s.room AS [Кабінет],
	s.StartTime,
	s.EndTime,
	
	d.FirstName + ' ' + d.LastName + ' ' + d.Patronymic AS [Доктор]
FROM 
	Schedule s 
	INNER JOIN Doctor d ON d.ID = s.DoctorID
WHERE
	s.room ='205а' AND	s.StartTime <= '10.05.2022 14:00:00' AND s.EndTime >= '10.05.2022 14:00:00'";
            try
            {
                GetAndDhowData(sqlQ, Task_six_DG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }private void GetTaskSeven()
        {
            string sqlQ = @"SELECT
	COUNT(*) AS [Кількість звернень]
FROM 
	Visit v 
	INNER JOIN Card c ON c.ID = v.CardID
WHERE
	c.Number = '003' AND MONTH(v.date) = MONTH(GETDATE()) - 1 AND YEAR(v.date) = YEAR(GETDATE())";
            try
            {
                GetAndDhowData(sqlQ, Task_seven_DG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }private void GetTaskEight()
        {
            string sqlQ = @"SELECT
	d.FirstName AS Name,
	d.LastName AS Family,
	d.Category AS category,
	COUNT(DISTINCT v.CardID) AS patients
FROM 
	Visit v
	INNER JOIN Doctor d ON d.ID = v.DoctorID
WHERE
	MONTH(v.date) = MONTH(GETDATE()) - 1 AND YEAR(v.date) = YEAR(GETDATE())
GROUP BY
	d.ID,
	d.FirstName,
	d.LastName,
	d.Category
";
            try
            {
                GetAndDhowData(sqlQ, Task_eight_DG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}