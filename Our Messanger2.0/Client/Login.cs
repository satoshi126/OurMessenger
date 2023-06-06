using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{
    public class LogIn
    {
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public bool Remember { get; set; } = true;

        public LogIn()
        {

        }
        public void Log(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=MIKHAILPC1;Initial Catalog=OurMessandgerDB;Integrated Security=True;TrustServerCertificate=true;";

            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Login = @Login AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", Login);
                    command.Parameters.AddWithValue("@Password", Password);

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
