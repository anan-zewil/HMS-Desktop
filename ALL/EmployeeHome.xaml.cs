using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ALL
{
    /// <summary>
    /// Interaction logic for EmployeeHome.xaml
    /// </summary>
    public partial class EmployeeHome : Window
    {

        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;


        public EmployeeHome()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select RoomID , SingleOrDouble , price ,RoomStatus , UserName,StartDate,EndDate from RoomsInfo where RoomID=@RoomID", con);
            cmd.Parameters.AddWithValue("RoomID", Textbox1.Text);
            SqlDataReader reader1 = cmd.ExecuteReader();
            if (reader1.Read())
            {
                labelid.Content = reader1["RoomID"].ToString();
                labelt.Content = reader1["SingleOrDouble"].ToString();
                labelp.Content = reader1["price"].ToString();
                labels.Content = reader1["RoomStatus"].ToString();
                if (labels.Content != "NULL")
                {
                    labelu.Content = reader1["UserName"].ToString();
                    labeld1.Content = reader1["StartDate"].ToString();
                    labeld2.Content = reader1["EndDate"].ToString();

                }
                else
                {
                    labelu.Content = "None";
                    labeld1.Content = "Not Applicable";
                    labeld2.Content = "Not Applicable";

                }
                con.Close();



            }
            else
            {


                labelid.Content = "wrong RoomID ";
                labelt.Content = " ";
                labelp.Content = "";
                labels.Content = "";
                labelu.Content = "";
                labeld1.Content = " ";
                labeld2.Content = " ";
                MessageBox.Show("Invalid ID");
                con.Close();
            }
        }

        private void contact_click(object sender, RoutedEventArgs e)
        {
            ContactUsEmp contact = new ContactUsEmp();
            contact.Show();
            this.Close();
        }
    }
}
