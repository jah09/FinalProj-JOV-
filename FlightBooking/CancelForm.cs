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
    public partial class CancelForm : Form
    {

        string MyConnection2 = "server=localhost;database=airlines;uid=root;pwd=;";

        public CancelForm()
        {
            InitializeComponent();
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.ToString("M/dd/yyyy");
            try
            {
                //Display query  
                // string Query = "select FlightBookID FROM flightbook  WHERE FlightSchedule >= '" + date + "'";
                string Query = "SELECT flightbook.FlightBookID FROM flightbook LEFT OUTER JOIN flightcancel ON flightbook.FlightBookID = flightcancel.FlightBookID WHERE flightcancel.FlightBookID IS NULL";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                foreach (DataRow row in dTable.Rows)
                {
                    comboBox1.Items.Add(row["FlightBookID"].ToString());
                }
                MyConn2.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("There is an error: " + e.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "insert into flightcancel(FlightBookID,Reason) values('" + comboBox1.Text.ToString() + "','" + reasonTxtBox.Text.ToString() + "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Cancel Successfuly");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog(); // 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Display query  
                string Query = "select *  from flightbook WHERE FlightBookID ='" + comboBox1.Text.ToString() + "'";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                foreach (DataRow row in dTable.Rows)
                {
                    flightSchedTxtBox.Text = row["FlightSchedule"].ToString();
                    flightSeatTxtBox.Text = row["FlightSeat"].ToString();
                    flightDistTxtBox.Text = row["FlightDestinationFrom"].ToString() + " - " + row["FlightDestinationTo"].ToString();
                }
                MyConn2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error: " + ex.Message);
            }
        }
    }
}
