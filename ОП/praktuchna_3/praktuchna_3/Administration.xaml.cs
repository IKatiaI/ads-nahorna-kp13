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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace praktuchna_3
{
    /// <summary>
    /// Логика взаимодействия для Administration.xaml
    /// </summary>
    enum AdminState
    {
        AUTHORISED, FIRST_ENTER, UNKNOWN
    }
    public partial class Administration : Window
    {
        private const string ADMIN_LOGIN = "ADMIN";

        private MainWindow mainWindow;
        private MyRepository repository;
        private User admin;
        private User user;
        private int index;
        private int maxIndex;
        DataTable dataTable;
        private AdminState state;
        private int loginCount;
        public Administration(MainWindow mainWindow, MyRepository repository)
        {
            this.mainWindow = mainWindow;
            this.repository = repository;
            InitializeComponent();
            admin = repository.getUser(ADMIN_LOGIN);
            if (admin == null)
            {
                Close();
                mainWindow.Show();
            }
            if (admin.Password == "")
            {
                MessageBox.Show("Set password for ADMIN");
                setState(AdminState.FIRST_ENTER);
            }
            else
            {
                setState(AdminState.UNKNOWN);
            }
        }

        private void Button_ReturnToMainWindow(object sender, RoutedEventArgs e)
        {
            Close();
            mainWindow.Show();
        }

        private void Button_Authorize(object sender, RoutedEventArgs e)
        {
            if (state == AdminState.UNKNOWN)
            {
                loginCount++;
                if (authorise_password_tb.Password == admin.Password)
                {
                    setState(AdminState.AUTHORISED);
                }
                else
                {
                    if (loginCount < 3)
                    {
                        MessageBox.Show($"Password is wrong. You have {3 - loginCount} attempts");
                    }
                    else
                    {
                        Application.Current.Shutdown();
                    }
                }
            }
        }

        private void Button_ChangePassword(object sender, RoutedEventArgs e)
        {
            string currentPassword = current_password_tb.Password;
            string newPassword = new_password_tb.Password;
            string repeatPassword = repeat_password_tb.Password;
            switch (state)
            {
                case AdminState.FIRST_ENTER:
                    if (newPassword == repeatPassword)
                    {
                        if (repository.updatePassword(ADMIN_LOGIN, newPassword))
                        {
                            admin = repository.getUser(ADMIN_LOGIN);
                            setState(AdminState.AUTHORISED);
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("New password and repeat password are different");
                    }
                    break;
                case AdminState.AUTHORISED:
                    if (currentPassword == admin.Password && newPassword == repeatPassword)
                    {
                        if (repository.updatePassword(ADMIN_LOGIN, newPassword))
                        {
                            admin = repository.getUser(ADMIN_LOGIN);
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Current password is not equal to password of admin or " +
                            "new password and repeat password are different");
                    }
                    break;
            }
        }
        private void Clear()
        {
            current_password_tb.Clear();
            new_password_tb.Clear();
            repeat_password_tb.Clear();
        }

        private void setState(AdminState newState)
        {
            if (newState == state)
            {
                return;
            }
            state = newState;
            switch(state)
            {
                case AdminState.FIRST_ENTER:
                    setControlsOnFirstEnter();
                    break;
                case AdminState.AUTHORISED:
                    setControlsOnAuthorized();
                    break;
                case AdminState.UNKNOWN:
                    setControlsOnUnknown();
                    break;
            }
        }

        private void setControlsOnFirstEnter()
        {
            new_password_tb.IsEnabled = true;
            repeat_password_tb.IsEnabled = true;
            change_password_bt.IsEnabled = true;
            close_window_bt.IsEnabled = true;

            authorise_password_tb.IsEnabled = false;
            authorize_bt.IsEnabled = false;
            users_grid.IsEnabled = false;
            current_password_tb.IsEnabled = false;
            prev_user_bt.IsEnabled = false;
            next_user_bt.IsEnabled = false;
            new_user_login_tb.IsEnabled = false;
            user_status_cb.IsEnabled = false;
            user_restriction_cb.IsEnabled = false;
            exit_bt.IsEnabled = false;
            user_restriction_bt.IsEnabled = false;
            user_state_bt.IsEnabled = false;
            add_new_user_bt.IsEnabled = false;

        }
        private void setControlsOnAuthorized()
        {
            new_password_tb.IsEnabled = true;
            repeat_password_tb.IsEnabled = true;
            change_password_bt.IsEnabled = true;
            close_window_bt.IsEnabled = true;
            authorise_password_tb.IsEnabled = true;
            authorize_bt.IsEnabled = false;
            users_grid.IsEnabled = true;
            current_password_tb.IsEnabled = true;
            prev_user_bt.IsEnabled = true;
            next_user_bt.IsEnabled = true;
            new_user_login_tb.IsEnabled = true;
            user_status_cb.IsEnabled = true;
            user_restriction_cb.IsEnabled = true;
            exit_bt.IsEnabled = true;
            user_restriction_bt.IsEnabled = true;
            user_state_bt.IsEnabled = true;
            add_new_user_bt.IsEnabled = true;

            loadData();
        }

        private void loadData()
        {
            dataTable = repository.getAll();
            users_grid.ItemsSource = dataTable.DefaultView;
            index = 0;
            maxIndex = dataTable.Rows.Count - 1;
            loadUser();
        }

        private void loadUser()
        {
            user = new User(dataTable.Rows[index][0].ToString(),
                            dataTable.Rows[index][1].ToString(),
                            dataTable.Rows[index][2].ToString(),
                            dataTable.Rows[index][3].ToString(),
                            Convert.ToBoolean(dataTable.Rows[index][4]),
                            Convert.ToBoolean(dataTable.Rows[index][5]));
            user_name_lb.Content = user.Name;
            user_surname_lb.Content = user.Surname;
            user_login_lb.Content = user.Login;
            user_status_lb.Content = user.Status;
            user_restriction_lb.Content = user.Restriction;
            user_status_cb.IsChecked = user.Status;
            user_restriction_cb.IsChecked = user.Restriction;
        }
        private void setControlsOnUnknown()
        {
            loginCount = 0;

            close_window_bt.IsEnabled = true;
            new_password_tb.IsEnabled = false;
            repeat_password_tb.IsEnabled = false;
            change_password_bt.IsEnabled = false;
            authorise_password_tb.IsEnabled = true;
            authorize_bt.IsEnabled = true;
            users_grid.IsEnabled = false;
            current_password_tb.IsEnabled = false;
            prev_user_bt.IsEnabled = false;
            next_user_bt.IsEnabled = false;
            new_user_login_tb.IsEnabled = false;
            user_status_cb.IsEnabled = false;
            user_restriction_cb.IsEnabled = false;
            exit_bt.IsEnabled = false;
            user_restriction_bt.IsEnabled = false;
            user_state_bt.IsEnabled = false;
            add_new_user_bt.IsEnabled = false;
        }

        private void exit_bt_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void prev_user_bt_Click(object sender, RoutedEventArgs e)
        {
            if(state == AdminState.AUTHORISED && index > 0)
            {
                index--;
                loadUser();
            }
        }

        private void next_user_bt_Click(object sender, RoutedEventArgs e)
        {
            if (state == AdminState.AUTHORISED && index < maxIndex)
            {
                index++;
                loadUser();
            }
        }

        private void user_status_bt_Click(object sender, RoutedEventArgs e)
        {
            if (state == AdminState.AUTHORISED)
            {
                user.Status = user_status_cb.IsChecked.GetValueOrDefault(false);
                repository.update(user);
                loadData();
            }
        }

        private void user_restriction_bt_Click(object sender, RoutedEventArgs e)
        {
            if (state == AdminState.AUTHORISED)
            {
                user.Restriction = user_restriction_cb.IsChecked.GetValueOrDefault(false);
                repository.update(user);
                loadData();
            }
        }

        private void add_new_user_bt_Click(object sender, RoutedEventArgs e)
        {
            if (state == AdminState.AUTHORISED)
            {
                string newLogin = new_user_login_tb.Text;
                if(newLogin != "")
                {
                    User candidate = new User("", "", newLogin, "", true, true);
                    if(repository.insert(candidate))
                    {
                        loadData();
                    }
                }
                else
                {
                    MessageBox.Show("Login of user cabn't be empty");
                }
            }
        }
    }
}