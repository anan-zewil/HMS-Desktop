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

namespace ALL
{
    /// <summary>
    /// Interaction logic for CustomerHome.xaml
    /// </summary>
    public partial class CustomerHome : Window
    {
        public CustomerHome()
        {
            InitializeComponent();
        }

        private void contact_us_click(object sender, RoutedEventArgs e)
        {
            ContactUs ct = new ContactUs();
            ct.Show();
            this.Close();
        }

       /* private void profile_click(object sender, RoutedEventArgs e)
        {

        }*/

        private void join_us_Click(object sender, RoutedEventArgs e)
        {
            joinus js = new joinus();
            js.Show();
            this.Close();
        }

        private void profile_Click(object sender, RoutedEventArgs e)
        {
            Profile pf = new Profile();
            pf.Show(); this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Room1 r1 = new Room1();
            r1.Show(); this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Room2 r2 = new Room2();
            r2.Show(); this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Room3 room3 = new Room3();
            room3.Show(); this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Room4 r4 = new Room4();
            r4.Show(); this.Close();
        }


        private void Button_Click_00(object sender, RoutedEventArgs e)
        {
            Room6 r1 = new Room6();
            r1.Show(); this.Close();    
        }

        private void Room5_Click(object sender, RoutedEventArgs e)
        {
            Room5 r55 = new Room5();
            r55.Show(); this.Close();
        }

        private void Room7_Click(object sender, RoutedEventArgs e)
        {
            Room7 r77 = new Room7();
            r77.Show(); this.Close();
        }

        private void Room_Click8(object sender, RoutedEventArgs e)
        {
            Room8 r88 = new Room8();
            r88.Show(); this.Close();
        }
    }
}
