using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shell;

namespace ALL
{
    /// <summary>
    /// Interaction logic for ContactUsEmp.xaml
    /// </summary>
    public partial class ContactUsEmp : Window
    {
        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;

        public ContactUsEmp()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            LoadGrid();
        }
        public void LoadGrid()
        {
            con.Open();

            string query = "SELECT * FROM contact_us ";
            cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            emplist.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeHome employeeHome = new EmployeeHome();
            employeeHome.Show();
            this.Close();
        }
    }
}
