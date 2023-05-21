using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        
        string user2 = globals.username;
        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlCommand cmd3;
        string pricee;
        public Payment()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            
                DateTime? startdate = Start_date.SelectedDate;
                DateTime? enddate = End_date.SelectedDate;

            
            
            if (startdate == null || enddate == null || cardnumber.Text == "" || security_code.Password == "" || exp_date.Text == "")
            {
                MessageBox.Show("Please Fill in all the Blanks");
            }
            else
            {
                con.Open();


                string status_query = "SELECT RoomStatus,StartDate,EndDate FROM RoomsInfo WHERE RoomID = @roomid2";
                cmd3 = new SqlCommand(status_query, con);
                cmd3.Parameters.AddWithValue("@roomid2", globals.roomid);
                SqlDataReader statusreader = cmd3.ExecuteReader();
                string room_status;
                string sd;
                string ed ;
                
                    statusreader.Read();
                    room_status = statusreader["RoomStatus"].ToString();
                    sd = statusreader["StartDate"].ToString();
                    ed = statusreader["EndDate"].ToString();
                    statusreader.Close();
                 
               


                if (room_status == "reserved  ")
                {
                    MessageBox.Show("This Room is reserved from " + sd + " untill " + ed);
                }
                else
                {

                    string query = "UPDATE RoomsInfo SET RoomStatus =@reserved,UserName=@user,StartDate =@startdate,EndDate = @enddate Where RoomID = @roomid AND RoomStatus =@free";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@reserved", "reserved");
                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);
                    cmd.Parameters.AddWithValue("@roomid", globals.roomid);
                    cmd.Parameters.AddWithValue("@user", user2);
                    cmd.Parameters.AddWithValue("@free", "free");
                    cmd.ExecuteNonQuery();

                    string bill = "INSERT INTO Bill (RoomID,Useremail,fname,startdate,enddate,price) values('" + globals.roomid + "','" + globals.email + "','" + globals.username + "','" + startdate + "','" + enddate + "','" + pricee + "')";
                    cmd2 = new SqlCommand(bill, con);
                    cmd2.ExecuteNonQuery();

                    
                    Bill bill1 = new Bill();
                    bill1.Show();
                    this.Close();
                }
                con.Close();
            }
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                if (globals.roomid == 1)
                {
                    Room1 rq = new Room1();
                    rq.Show();
                    this.Close();
                }
                else if (globals.roomid == 2)
                {
                    Room2 rq = new Room2();
                    rq.Show();
                    this.Close();
                }
                else if (globals.roomid == 3)
                {
                    Room3 rq = new Room3();
                    rq.Show();
                    this.Close();
                }
                else if (globals.roomid == 4)
                {
                    Room4 rq = new Room4();
                    rq.Show();
                    this.Close();
                }
                else if (globals.roomid == 5)
                {
                    Room5 rq = new Room5();
                    rq.Show();
                    this.Close();
                }
                else if (globals.roomid == 6)
                {
                    Room6 rq = new Room6();
                    rq.Show();
                    this.Close();
                }
                else if (globals.roomid == 7)
                {
                    Room7 rq = new Room7();
                    rq.Show();
                    this.Close();
                }
                else if (globals.roomid == 8)
                {
                    Room8 rq = new Room8();
                    rq.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No roomid in globals");
                }

            
        }

        

        private void fname_Loaded(object sender, RoutedEventArgs e)
        {
            fname.Content = user2;
           
        }

        private void lname_Loaded(object sender, RoutedEventArgs e)
        {
            lname.Content = globals.lastname;
        }

        private void price_loaded(object sender, RoutedEventArgs e)
        {
           con.Open();
           string query = "SELECT price FROM RoomsInfo WHERE RoomID=@username";
           cmd = new SqlCommand(query,con);
           cmd.Parameters.AddWithValue("@username", globals.roomid);
           SqlDataReader reader = cmd.ExecuteReader();
           if (reader.Read())
           {
                pricee = reader["price"].ToString(); 
           }
           con.Close();

            price.Content = pricee;
        }


    }
}
