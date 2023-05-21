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
    /// Interaction logic for RemoveEmpAdmin.xaml
    /// </summary>
    public partial class RemoveEmpAdmin : Window
    {
        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        string username3 = globals.username;


        public RemoveEmpAdmin()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            LoadGrid();
        }

        public void LoadGrid()
        {
            con.Open();

            string query = "SELECT * FROM employee ";
            cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            emplist.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM employee WHERE fname='" + username.Text + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully deleted");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                LoadGrid();
            }
        }

        private void back_click(object sender, RoutedEventArgs e)
        {
            AddNewRoom addNewRoom = new AddNewRoom();
            addNewRoom.Show();
            this.Close();
        }
    }
}
