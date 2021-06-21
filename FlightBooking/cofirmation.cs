using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightBooking
{
    public partial class confirmation : Form
    {

        string MyConnection2 = "server=localhost;database=airlines;uid=root;pwd=;";
        BookObject book;

        public confirmation()
        {
            InitializeComponent();
            fromLabel.Text = BookObject.FlightDestinationFrom.ToString();
            toLabel.Text = BookObject.FlightDestinationTo.ToString();
            scheduleLabel.Text = BookObject.FlightSchedule.ToString();
          //  fareLabel.Text = BookObject.Fare.ToString();
            seatLabel.Text = BookObject.FlightSeat.ToString();

            fnLabel.Text = BookObject.Firstname.ToString() +" "+ BookObject.Lastname.ToString();
            cashamountLabel.Text = BookObject.Fare_CashAmount.ToString();
            cardnumLabel.Text = BookObject.Fare_CardNum.ToString();
            cardamountLabel.Text = BookObject.Fare_CardAmount.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form call= new Form();
            // new Form1().setVisible(true);   
            /*if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("No entries in back navigation history.");
            } */
            /* Form call = new Form();
             call.Form(); */
            this.Hide();
            Form1 f2 = new Form1();
            f2.ShowDialog(); // 
            this.Close();
        }

        private void bookButton_Click(object sender, EventArgs e)
        {
            try
            {
               
                //This is my insert query in which i am taking input from the user through windows forms  
               string Query = "insert into flightbook(FlightSeat,FlightSchedule,FlightDestinationFrom,FlightDestinationTo,Fare,Flight_Lname,Flight_Fname,Flight_CardNum,Fare_CardAmount) values('" + BookObject.FlightSeat + "','" + BookObject.FlightSchedule + "','" + BookObject.FlightDestinationFrom + "','" + BookObject.FlightDestinationTo + "','" + BookObject.Fare_CashAmount + "','" + BookObject.Firstname + "','" + BookObject.Lastname  + "','"+ BookObject.Fare_CardNum + "','"+ BookObject.Fare_CardAmount + "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Book Successfuly");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
                // this.Close();

                this.Hide();
                Form1 f2 = new Form1();
                f2.ShowDialog(); // 
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void fareLabel_Click(object sender, EventArgs e)
        {

        }

        private void confirmation_Load(object sender, EventArgs e)
        {
            fromLabel.Parent = pictureBox1;
            fromLabel.BackColor = Color.Transparent;

            toLabel.Parent = pictureBox1;
            toLabel.BackColor = Color.Transparent;

            seatLabel.Parent = pictureBox1;
            seatLabel.BackColor = Color.Transparent;

            scheduleLabel.Parent = pictureBox1;
            scheduleLabel.BackColor = Color.Transparent;

            fnLabel.Parent = pictureBox1;
            fnLabel.BackColor = Color.Transparent;

            cashamountLabel.Parent = pictureBox1;
            cashamountLabel.BackColor = Color.Transparent;

            cardnumLabel.Parent = pictureBox1;
            cardnumLabel.BackColor = Color.Transparent;

            cardamountLabel.Parent = pictureBox1;
            cardamountLabel.BackColor = Color.Transparent;

            flightsummaryLabel.Parent = pictureBox1;
            flightsummaryLabel.BackColor = Color.Transparent;
        }
    }
}
