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
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Windows.Markup;
using System.Windows.Controls.Primitives;
using System.Threading.Channels;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Window
    {

        public LogInPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Properties.Settings.Default.Remember)
            {
                this.Login.Text = Properties.Settings.Default.Login;
                this.Password.Text = Properties.Settings.Default.Password;
                this.Remember.IsChecked = Properties.Settings.Default.Remember;
            }
        }

        private void Remember_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Login = Login.Text;
            Properties.Settings.Default.Password = Password.Text;
            Properties.Settings.Default.Remember = (bool)Remember.IsChecked;
            Properties.Settings.Default.Save();
        }

        public void Log(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=MIKHAILPC1;Initial Catalog=OurMessandgerDB;Integrated Security=True;TrustServerCertificate=true;";

            string login = Login.Text;
            string password = Password.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Login = @Login AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login and password exist in the database.");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login and password do not exist in the database. Register before work!");
                        Registration registrationWindow = new Registration();
                        registrationWindow.Show();
                    }
                }
            }
        }
    }
}
