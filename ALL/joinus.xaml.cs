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
using System.Windows.Markup;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace ALL
{
    /// <summary>
    /// Interaction logic for joinus.xaml
    /// </summary>
    public partial class joinus : Window
    {

        string gender;
        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SHA1 sha1 = new SHA1CryptoServiceProvider();


        public joinus()
        {
            InitializeComponent();
            con = new SqlConnection(path);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerHome cs = new CustomerHome();
            cs.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CustomerHome cs = new CustomerHome();
            cs.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (fname.Text == "" || nid.Text == "" || email.Text == "" || pasword.Password == "" || ph.Text == "" || lastjob.Text == "" )
            {
                MessageBox.Show("Please Fill in the Blank");
            }
            else
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(pasword.Password);
                byte[] hashBytes = sha1.ComputeHash(passwordBytes);
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "");
                try
                {

                    con.Open();
                    cmd = new SqlCommand("insert into joined (fname,email,nationalid,phone,gender,age,passwordd,lastjob,experience) values('" + fname.Text + "','" + email.Text + "','" + nid.Text + "','" + ph.Text + "','" + gender + "','" + ag.Text + "','" + hashedPassword + "','" + lastjob.Text + "','" + experience.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sent");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }


            }


        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gender = (sender as RadioButton).Content.ToString();
        }

        
    }
}