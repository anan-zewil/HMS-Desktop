using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using static System.Net.Mime.MediaTypeNames;

namespace ALL
{
    /// <summary>
    /// Interaction logic for AddNewEmp.xaml
    /// </summary>
    public partial class AddNewEmp : Window
    {
        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        string username3 = globals.username;

        public AddNewEmp()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            LoadGrid();
        }
        public void LoadGrid()
        {
            con.Open();

            string query = "SELECT * FROM joined ";
            cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            emplist.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("INSERT INTO employee(fname,age,phone,email,passwordd,nationalid,gender) SELECT fname,age,phone,email,passwordd,nationalid,gender FROM joined  WHERE fname='" + username.Text + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully added");

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AddNewRoom addNewRoom = new AddNewRoom();
            addNewRoom.Show();
            this.Close();
        }

        private void logout_click(object sender, RoutedEventArgs e)
        {
           MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}