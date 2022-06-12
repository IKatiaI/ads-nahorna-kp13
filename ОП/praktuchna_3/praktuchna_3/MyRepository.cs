using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace praktuchna_3
{
    public class MyRepository
    {
        private string connectionString;
        public MyRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public User getUser(string login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    string SQLQuery = $"SELECT * FROM MainTable WHERE Login = '{login}';";
                    SqlCommand command = new SqlCommand(SQLQuery, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    connection.Close();
                    User user = new User(table.Rows[0][0].ToString(), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), table.Rows[0][3].ToString(), Convert.ToBoolean(table.Rows[0][4]), Convert.ToBoolean(table.Rows[0][5]));
                    return user;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"User with login '{login}' not found");
                    connection.Close();
                    return null;
                }
            }
            throw new Exception("Connection to database can't be opened");
        }

        public bool updatePassword(string login, string password)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    string SQLQuery = $"UPDATE MainTable SET Password = '{password}' WHERE Login = '{login}';";
                    SqlCommand command = new SqlCommand(SQLQuery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Can't update password for user with login '{login}'");
                    connection.Close();
                    return false;
                }
            }
            throw new Exception("Connection to database can't be opened");
        }

        public bool insert(User user)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    string SQLQuery = "INSERT INTO MainTable (Name, Surname, Login, Password, Status, Restriction) " +
                        $"VALUES ('{user.Name}', '{user.Surname}', '{user.Login}', '{user.Password}', '{user.Status}', '{user.Restriction}');";
                    SqlCommand command = new SqlCommand(SQLQuery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Can't insert new user");
                    connection.Close();
                    return false;
                }
            }
            throw new Exception("Connection to database can't be opened");
        }

        public bool update(User user)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    string SQLQuery = $"UPDATE MainTable SET " +
                        $"Name = '{user.Name}', " +
                        $"Surname = '{user.Surname}', " +
                        $"Password = '{user.Password}', " +
                        $"Status = '{user.Status}', " +
                        $"Restriction = '{user.Restriction}' " +
                        $"WHERE Login = '{user.Login}';";
                    SqlCommand command = new SqlCommand(SQLQuery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Can't update user");
                    connection.Close();
                    return false;
                }
            }
            throw new Exception("Connection to database can't be opened");
        }

        public DataTable getAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    string SQLQuery = $"SELECT * FROM MainTable;";
                    SqlCommand command = new SqlCommand(SQLQuery, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    connection.Close();
                    return table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"User data not found");
                    connection.Close();
                    return null;
                }
            }
            throw new Exception("Connection to database can't be opened");
        }
    }
}
