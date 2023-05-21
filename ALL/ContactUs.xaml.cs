using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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
using System.Xml.Linq;

namespace ALL
{
    /// <summary>
    /// Interaction logic for ContactUs.xaml
    /// </summary>
    public partial class ContactUs : Window
    {
        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;

        public ContactUs()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CustomerHome csh = new CustomerHome();
            csh.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || email.Text == ""  || phone.Text == "" || message.Text == "")
            {
                MessageBox.Show("Please Fill in the Blank");
            }
            else
            {
                try
                {

                    con.Open();
                    cmd = new SqlCommand("insert into contact_us (name,email,phone,message) values('" + name.Text + "','" + email.Text + "','" + phone.Text + "','" + message.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sent");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
