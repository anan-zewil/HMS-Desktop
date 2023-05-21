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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Reflection;

namespace ALL
{
    /// <summary>
    /// Interaction logic for SignUpxaml.xaml
    /// </summary>
    public partial class SignUpxaml : Window
    {
        string gender;
        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmd2;
        SHA1 sha1 = new SHA1CryptoServiceProvider();


        public SignUpxaml()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (fname.Text == "" || nationalid.Text == "" || email.Text == "" || password.Password == "" || phone.Text == ""||lname.Text=="")
            {
                MessageBox.Show("Please Fill in the Blank");
            }
            else
            {

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password.Password);
                byte[] hashBytes = sha1.ComputeHash(passwordBytes);
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "");
                



            try
            {
                con.Open();
                string query = "SELECT email FROM customers WHERE email=@useremail";
                cmd2 = new SqlCommand(query, con);
                cmd2.Parameters.AddWithValue("@useremail",email.Text);
                SqlDataReader reader = cmd2.ExecuteReader();
                    if (reader.Read()) { MessageBox.Show("Username  already exists"); }
                   
                    else
                    {
                        reader.Close();

                        string user_type = "customer";

                        cmd = new SqlCommand("insert into customers (firstname,lastname,nationalid,phone_number,email,passwordd,gender) values('" + fname.Text + "','" + lname.Text + "','" + nationalid.Text + "','" + phone.Text + "','" + email.Text + "','" + hashedPassword + "','" + gender + "')", con);
                        cmd.ExecuteNonQuery();
                        

                        Login mw = new Login();
                        mw.Show();
                        this.Close();
                    }
                    con.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gender = (sender as RadioButton).Content.ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show(); this.Close();
        }
    }
}
