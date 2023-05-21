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
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Reflection;
using System.Xml.Linq;
using System.Windows.Navigation;
using System.Collections;
using System.Reflection.PortableExecutable;

namespace ALL
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string type;
        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SHA1 sha1 = new SHA1CryptoServiceProvider();

      


        public Login()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            type = (sender as RadioButton).Content.ToString(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Password == "")
            {
                MessageBox.Show("Please fill in the Blank");
            }
            else
            {
                try
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password.Password);
                    byte[] hashBytes = sha1.ComputeHash(passwordBytes);
                    string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "");
                    if (type == "Employee")
                    {
                        string query = "SELECT * FROM employee WHERE email = @email AND passwordd = @password";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@email", username.Text);
                        cmd.Parameters.AddWithValue("password", password.Password);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            EmployeeHome employee = new EmployeeHome();
                            employee.Show();
                            this.Close();
                        }
                        else { MessageBox.Show("Invalid emp login"); }
                    }
                    else if(type == "Customer")
                    {
                        string query = "SELECT email, passwordd,firstname,lastname  FROM customers WHERE email = @email AND passwordd = @password";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@email", username.Text);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string user = reader["firstname"].ToString();
                            string lastname = reader["lastname"].ToString();
                            globals.username = user;
                            globals.email = username.Text;
                            globals.lastname = lastname;
                            
                            CustomerHome customerHome = new CustomerHome();
                            customerHome.Show();
                            this.Close();
                        }
                        

                        else { MessageBox.Show("Invalid customer login"); }
                    }
                    else if (type == null)
                    {
                        string query2 = "SELECT email, passwordd  FROM admin WHERE email = @email AND passwordd = @password";
                        cmd = new SqlCommand(query2, con);
                        cmd.Parameters.AddWithValue("@email", username.Text);
                        cmd.Parameters.AddWithValue("@password", password.Password);
                        con.Open();
                        SqlDataReader reader2 = cmd.ExecuteReader();
                        if (reader2.Read())
                        {
                            AddNewRoom addNewRoom = new AddNewRoom();
                            addNewRoom.Show();
                            this.Close();
                        }
                        else { MessageBox.Show("Invalid UserName or Password"); }
                    }
                    con.Close();
                    
                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
