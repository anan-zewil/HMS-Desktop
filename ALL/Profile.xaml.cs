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

namespace ALL
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {

        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        string username3 = globals.username;

        public Profile()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            LoadGrid();
        }


        
        public DataTable dt2 = new DataTable();





        public void LoadGrid()
        {
            
            con.Open();
            string query = "SELECT * FROM RoomsInfo WHERE RoomStatus = 'reserved' and UserName = @username";
             cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username3);
            DataTable dt = new DataTable();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            dt2 = dt;
            con.Close();
            ReserveState.ItemsSource = dt.DefaultView;
        }

        private void CANCEL_Click(object sender, RoutedEventArgs e)
        {
            if (search_txt.Text != "") 
            {
                

                if (dt2.Rows.Count > 0)
                {
                    DataRow[] rows = dt2.Select("RoomID = '" + search_txt.Text + "'");
                    if (rows.Length > 0)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE RoomsInfo SET RoomStatus = 'free' WHERE RoomID = " + int.Parse(search_txt.Text) + " ", con);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Canceled", "cancel", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    else {MessageBox.Show("UnKnown RoomID") ; }
            
                }
                else { MessageBox.Show("No rooms to be canceled"); }
            }
            else { MessageBox.Show("Enter RoomID"); }


            

        }

       

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }

        private void usernameProfileText_Loaded(object sender, RoutedEventArgs e)
        {
            usernameProfileText.Content = username3;
        }

        private void gmail_Loaded(object sender, RoutedEventArgs e)
        {
            gmail.Content = globals.email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerHome ch3 = new CustomerHome();
            ch3.Show();
            this.Close();
        }

        private void search_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
