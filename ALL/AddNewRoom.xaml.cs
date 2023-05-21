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
    /// Interaction logic for AddNewRoom.xaml
    /// </summary>
    public partial class AddNewRoom : Window
    {
        
        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;

        public AddNewRoom()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rid.Text == "" || rt.Text == "" || pr.Text == "")
            {
                MessageBox.Show("Please Fill in the Blank");
            }
            else
            {

                try
                {

                    con.Open();
                    cmd = new SqlCommand("insert into RoomsInfo (RoomID,SingleOrDouble,RoomStatus,price) values('" + rid.Text + "','" + rt.Text + "' ,'" + "free" + "', '" + pr.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Added");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }


            }


        }

        private void join_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmp addNewEmp = new AddNewEmp();
            addNewEmp.Show();
            this.Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            RemoveEmpAdmin removeEmpAdmin = new RemoveEmpAdmin();
            removeEmpAdmin.Show();
            this.Close();
        }
    }
}