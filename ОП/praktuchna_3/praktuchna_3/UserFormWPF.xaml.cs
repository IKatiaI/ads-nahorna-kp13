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

namespace praktuchna_3
{
    /// <summary>
    /// Логика взаимодействия для UserFormWPF.xaml
    /// </summary>
    /// 
    enum UserState
    {
        AUTHORISED, UNKNOWN
    }

    public partial class UserFormWPF : Window
    {
        private MainWindow mainWindow;
        private MyRepository repository;
        private User user;
        private UserState state;
        private int loginCount;
        public UserFormWPF(MainWindow mainWindow, MyRepository repository)
        {
            this.mainWindow = mainWindow;
            this.repository = repository;

            InitializeComponent();
            user = null;
            setState(UserState.UNKNOWN);      
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            mainWindow.Show();
        }
        private void setState(UserState newState)
        {
            if (newState == state)
            {
                return;
            }
            state = newState;
            switch (state)
            {
                case UserState.AUTHORISED:
                    setControlsOnAuthorized();
                    break;
                case UserState.UNKNOWN:
                    setControlsOnUnknown();
                    break;
            }
        }
        private void setControlsOnAuthorized()
        {
            if (user == null)
            {
                return;
                setState(UserState.UNKNOWN);
            }

            login_tb.IsEnabled = false;
            password_tb.IsEnabled = false;
            authorize_bt.IsEnabled = false;

            close_window_bt.IsEnabled = true;
            exit_bt.IsEnabled = true;
            user_Name_Reg_tb.IsEnabled = true;
            user_Surname_Reg_tb.IsEnabled = true;
            user_login_Reg_tb.IsEnabled = true;
            Password_Reg_tb.IsEnabled = true;
            Password_Repeat_Reg_tb.IsEnabled = true;
            register_bt.IsEnabled = true;

            user_Name_Update_tb.IsEnabled = true;
            user_Surname_Update_tb.IsEnabled = true;
            Password_Update_tb.IsEnabled = true;
            Password_Repeat_Update_tb.IsEnabled = true;
            change_password_bt.IsEnabled = true;

            user_Name_Update_tb.Text = user.Name;
            user_Surname_Update_tb.Text = user.Surname;

            Clear();
        }

        private void Clear()
        {
            user_Name_Reg_tb.Clear();
            user_Surname_Reg_tb.Clear();
            user_login_Reg_tb.Clear();
            Password_Reg_tb.Clear();
            Password_Repeat_Reg_tb.Clear();
            Password_Update_tb.Clear();
            Password_Repeat_Update_tb.Clear();
            password_tb.Clear();
            Password_Update_tb.Clear();
            Password_Repeat_Update_tb.Clear();
        }
        private void setControlsOnUnknown()
        {
            loginCount = 0;

            login_tb.IsEnabled = true;
            password_tb.IsEnabled = true;
            authorize_bt.IsEnabled = true;
            close_window_bt.IsEnabled = true;

            user_Name_Reg_tb.IsEnabled = true;
            user_Surname_Reg_tb.IsEnabled = true;
            user_login_Reg_tb.IsEnabled = true;
            Password_Reg_tb.IsEnabled = true;
            Password_Repeat_Reg_tb.IsEnabled = true;
            register_bt.IsEnabled = true;

            user_Name_Update_tb.IsEnabled = false;
            user_Surname_Update_tb.IsEnabled = false;
            Password_Update_tb.IsEnabled = false;
            Password_Repeat_Update_tb.IsEnabled = false;
            change_password_bt.IsEnabled = false;
            exit_bt.IsEnabled = false;

            Clear();
            user_Name_Update_tb.Clear();
            user_Surname_Update_tb.Clear();
        }

        private void authorize_bt_Click(object sender, RoutedEventArgs e)
        {           
            if (state == UserState.UNKNOWN)
            {
                loginCount++;
                string login = login_tb.Text;
                string password = password_tb.Password;
                User candidate = repository.getUser(login);
                if (password == candidate.Password)
                {
                    if (candidate.Status)
                    {
                        user = candidate;
                        setState(UserState.AUTHORISED);
                    }
                    else
                    {
                        MessageBox.Show("This user can't login. Ask administrator for the reason.");
                    }
                }
                else
                {
                    if (loginCount == 3)
                    {
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        MessageBox.Show($"Wrong login or password. You have {3 - loginCount} attempts");
                    }
                }
            }           
        }

        private void exit_bt_Click(object sender, RoutedEventArgs e)
        {
            if (state == UserState.AUTHORISED)
            {
                user = null;
                setState(UserState.UNKNOWN);
            }
        }

        private void register_bt_Click(object sender, RoutedEventArgs e)
        {
            string name = user_Name_Reg_tb.Text.Trim();
            string surname = user_Surname_Reg_tb.Text.Trim();
            string login = user_login_Reg_tb.Text.Trim();
            string password = Password_Reg_tb.Password;
            string repeatPassword = Password_Repeat_Reg_tb.Password;

            if (name == "")
            {
                MessageBox.Show("Name is empty.");
                return;
            }
            if (surname == "")
            {
                MessageBox.Show("Surname is empty.");
                return;
            }
            if (login == "")
            {
                MessageBox.Show("Login is empty.");
                return;
            }
            if (!mainWindow.RestrictionFunc(password))
            {
                MessageBox.Show("Password is incorrect.");
                return;
            }
            if (password != repeatPassword)
            {
                MessageBox.Show("Password is not equal to repeated password");
                return;
            }

            User candidate = new User(name, surname, login, password, true, true);
            if(repository.insert(candidate))
            {
                user_Name_Reg_tb.Clear();
                user_Surname_Reg_tb.Clear();
                user_login_Reg_tb.Clear();
                Password_Reg_tb.Clear();
                Password_Repeat_Reg_tb.Clear();
                MessageBox.Show($"New user '{login}' is registrated.");
            }
        }

        private void update_user_data_bt_Click(object sender, RoutedEventArgs e)
        {
            if (state == UserState.AUTHORISED && user != null)
            {
                string name = user_Name_Update_tb.Text.Trim();
                string surname = user_Surname_Update_tb.Text.Trim();
                string password = Password_Update_tb.Password;
                string repeatPassword = Password_Repeat_Update_tb.Password;
                User candidate;
                if (name == "")
                {
                    MessageBox.Show("Name is empty.");
                    return;
                }
                if (surname == "")
                {
                    MessageBox.Show("Surname is empty.");
                    return;
                }
                if (password != "")
                {
                    if (user.Restriction && !mainWindow.RestrictionFunc(password))
                    {
                        MessageBox.Show("Password is incorrect.");
                        return;
                    }
                    if (password != repeatPassword)
                    {
                        MessageBox.Show("Password is not equal to repeated password");
                        return;
                    }
                    candidate = new User(name, surname, user.Login, password, user.Status, user.Restriction);
                }
                else
                {
                    candidate = new User(name, surname, user.Login, user.Password, user.Status, user.Restriction);
                }
                if (repository.update(candidate))
                {
                    user = candidate;
                    MessageBox.Show($"User '{user.Login}' is updated.");
                }
            }
        }
    }
}
