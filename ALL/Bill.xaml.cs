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
namespace ALL
{
    /// <summary>
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : Window
    {

        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;

        public Bill()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            load_data();
        }

        public void load_data()
        {
            con.Open();
            string query = "SELECT BillID,RoomID,fname,price,startdate,enddate FROM Bill where Useremail=@user";
            cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@user", globals.email);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()) 
            {
                labelid.Content = reader["RoomID"].ToString();
                labelt.Content = reader["fname"].ToString();
                labelp.Content = reader["price"].ToString();
                labels.Content = reader["BillID"].ToString();
                labeld1.Content = reader["startdate"].ToString();
                labeld2.Content = reader["enddate"].ToString();

            }
            else { MessageBox.Show("No values returned"); }
            con.Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            CustomerHome h1 = new CustomerHome();
            h1.Show();
            this.Close();

        }
    }
}
