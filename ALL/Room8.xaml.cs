﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
    /// Interaction logic for Room8.xaml
    /// </summary>
    public partial class Room8 : Window
    {
        
        string user1 = globals.username;
        string path = @"Data Source=DESKTOP-UOPQJ9I;Initial Catalog=HMS;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        public Room8()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerHome customerHome = new CustomerHome();
            customerHome.Show();
            this.Close();
        }

        private void payment_Click(object sender, RoutedEventArgs e)
        {
            globals.roomid = 8;
           /* con.Open();
            string query = "UPDATE RoomsInfo SET UserName = @username WHERE RoomID = @roomid";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", user1);
            cmd.Parameters.AddWithValue("@roomid", roomid);
            cmd.ExecuteNonQuery();
            con.Close();*/
            Payment p1 = new Payment();
            p1.Show();
            this.Close();
        }
    }
}
