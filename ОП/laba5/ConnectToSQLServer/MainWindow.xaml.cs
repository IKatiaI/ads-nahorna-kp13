using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ConnectToSQLServer
{

	public class Record
    {
		public int ID = 0;
		public int DepartmentID;
		public string Number;
		public string FirstName;
		public string LastName;
		public string Patronymic;
		public string Adress;
		public string Gender;
		public DateTime Birthday;
		public string InsurancePolicy;
		public DateTime CreatedAt;

		public void loadFromTable(DataRowView selected)
        {
			if (selected != null)
			{
				object[] items = selected.Row.ItemArray;

				ID = Convert.ToInt32(items[0]);
				DepartmentID = Convert.ToInt32(items[1]);
				Number = Convert.ToString(items[2]);
				FirstName = Convert.ToString(items[3]);
				LastName = Convert.ToString(items[4]);
				Patronymic = Convert.ToString(items[5]);
				Adress = Convert.ToString(items[6]);
				Gender = Convert.ToString(items[7]);
				Birthday = Convert.ToDateTime(items[8]);
				InsurancePolicy = Convert.ToString(items[9]);
				CreatedAt = Convert.ToDateTime(items[10]);
			}
            else
            {
				ID = 0;
				DepartmentID = 0;
				Number = "";
				FirstName = "";
				LastName = "";
				Patronymic = "";
				Adress = "";
				Gender = "";
				Birthday = DateTime.Now;
				InsurancePolicy = "";
				CreatedAt = DateTime.Now;
			}
		}
	}
    public partial class MainWindow : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;

		Record record = new Record();

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			//MessageBox.Show(connectionString);
			try
			{
				showData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
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

		private void ExecuteQuery(string SQLQuery)
        {
			connection = new SqlConnection(connectionString);
			connection.Open();
			command = new SqlCommand(SQLQuery, connection);
			command.ExecuteNonQuery();
			connection.Close();
		}

        private void INSERT_Click(object sender, RoutedEventArgs e)
        {
			string firstName = this.FirstName.Text.Trim();
			string lastName = this.LastName.Text.Trim();
			string number = this.Number.Text.Trim();
			string patronymic = this.Patronymic.Text.Trim();
			string departmentID = this.DepartmentID.Text.Trim();
			string adress = this.Adress.Text.Trim();
			string gender = this.Gender.Text.Trim();
			string birthday = this.Birthday.Text.Trim();
			string insurancePolicy = this.InsurancePolicy.Text.Trim();
			string createdAt = this.CreatedAt.Text.Trim();



			string sqlQ = $@"INSERT INTO Card
	(
		DepartmentID,
		Number,
		FirstName,
		LastName,
		Patronymic,
		Adress,
		Gender,
		Birthday,
		InsurancePolicy,
		CreatedAt
	)
	Values
	(
		{departmentID},
		'{number}',
		'{firstName}',
		'{lastName}',
		'{patronymic}',
		'{adress}',
		'{gender}',
		'{birthday}',
		'{insurancePolicy}',
		'{createdAt}'
	);
";
			try
			{
				ExecuteQuery(sqlQ);
				showData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void UPDATE_Click(object sender, RoutedEventArgs e)
		{
			if (record.ID == 0)
            {
				MessageBox.Show("Жоден рядок не вибраний");
				return;
            }

			string firstName = this.FirstName.Text.Trim();
			string lastName = this.LastName.Text.Trim();
			string number = this.Number.Text.Trim();
			string patronymic = this.Patronymic.Text.Trim();
			string departmentID = this.DepartmentID.Text.Trim();
			string adress = this.Adress.Text.Trim();
			string gender = this.Gender.Text.Trim();
			string birthday = this.Birthday.Text.Trim();
			string insurancePolicy = this.InsurancePolicy.Text.Trim();
			string createdAt = this.CreatedAt.Text.Trim();

			string sqlQ = $@"
		UPDATE
			Card
		SET
			DepartmentID = {departmentID},
			Number = '{number}',
			FirstName = '{firstName}',
			LastName = '{lastName}',
			Patronymic = '{patronymic}',
			Adress = '{adress}',
			Gender = '{gender}',
			Birthday = '{birthday}',
			InsurancePolicy = '{insurancePolicy}',
			CreatedAt = '{createdAt}'
		WHERE  ID = '{record.ID}';";
			try
			{
				ExecuteQuery(sqlQ);
				showData();
				record = new Record();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void DELETE_Click(object sender, RoutedEventArgs e)
		{
			if (record.ID == 0)
			{
				MessageBox.Show("Жоден рядок не вибраний");
				return;
			}
			string sqlQ = $"DELETE Card WHERE  ID = '{record.ID}';";
			try
			{
				ExecuteQuery(sqlQ);
				showData();
				record = new Record();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void showData()
		{
			string sqlSelect = "SELECT * FROM Card;";
			GetAndDhowData(sqlSelect, CardDG);
		}

        private void CardDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			try
			{
				DataGrid grid = (DataGrid)sender;
				DataRowView selected = (DataRowView)grid.SelectedItem;
				record.loadFromTable(selected);
				loadFromRecord();
			}
            catch (Exception ex)
            {
				MessageBox.Show(ex.Message);
				record = new Record();
            }
		}

		private void loadFromRecord()
        {
			if (record.ID != 0)
			{
				FirstName.Text = record.FirstName;
				LastName.Text = record.LastName;
				Number.Text = record.Number;
				Patronymic.Text = record.Patronymic;
				DepartmentID.Text = record.DepartmentID.ToString();
				Adress.Text = record.Adress;
				Gender.Text = record.Gender;
				Birthday.Text = record.Birthday.ToString();
				InsurancePolicy.Text = record.InsurancePolicy;
				CreatedAt.Text = record.CreatedAt.ToString();
			}
			else
            {
				FirstName.Text = "";
				LastName.Text = "";
				Number.Text = "";
				Patronymic.Text = "";
				DepartmentID.Text = "";
				Adress.Text = "";
				Gender.Text = "";
				Birthday.Text = "";
				InsurancePolicy.Text = "";
				CreatedAt.Text = "";
			}
		}
    }


}