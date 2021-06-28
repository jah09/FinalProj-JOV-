using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightBooking
{
    public partial class Form1 : Form
    {
        string MyConnection2 = "server=localhost;database=airlines;uid=root;pwd=;";
        string seatNumber = "";

        public Form1()
        {
            InitializeComponent();

            var dateAndTime = DateTime.Now;
            var date = dateAndTime.ToString("M/dd/yyyy");

            try
            {
                //Display query  
                string Query = "select * from flightdestination";
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
                    fromComboBox.Items.Add(row["FlightDestinationTLA"].ToString());
                    toComboBox.Items.Add(row["FlightDestinationTLA"].ToString());
                }
                MyConn2.Close();

            } catch(Exception e)
            {
                MessageBox.Show("There is an error: " + e.Message);
            }

            try
            {
                //Display query  
                // string Query = "select * from flightbook WHERE FlightSchedule ='" + date + "'";
                // string Query = "select * from flightbook";
                string Query = "SELECT * FROM flightbook LEFT OUTER JOIN flightcancel ON flightbook.FlightBookID = flightcancel.FlightBookID WHERE flightcancel.FlightBookID IS NULL";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
                this.dataGridView1.Columns["FlightCancelID"].Visible = false;
                this.dataGridView1.Columns["FlightBookID1"].Visible = false;
                this.dataGridView1.Columns["Reason"].Visible = false;
                this.dataGridView1.Columns["FlightCancelDate"].Visible = false;
                MyConn2.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("There is an error: " + e.Message);
            }

            
            /*
            try
            {
                //Display query  
                string Query = "SELECT COUNT(*) AS books FROM flightbook WHERE FlightSchedule ='" + date + "'";
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
                    bookView.Text = row["books"].ToString();
                    string total = row["books"].ToString();
                    int available = 36 - Int32.Parse(total);
                    availableView.Text = available.ToString();
                }
                MyConn2.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("There is an error: " + e.Message);
            }

            viewComboBox.Items.Add("Book");
            viewComboBox.Items.Add("Destination");
            */
            

            counterBook(date);
            bookSeats(date);

        }


        private void BookBtn_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                string theDate = dateTimePicker1.Value.ToShortDateString();
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "insert into flightbook(FlightSeat,FlightSchedule,FlightDestinationFrom,FlightDestinationTo,Fare) values('" + seatNumber + "','" + theDate + "','" + fromComboBox.Text + "','" + toComboBox.Text + "','" + 50 + "');";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } */

            string theDate = dateTimePicker1.Value.ToShortDateString();
            BookObject.FlightSeat = seatNumber;
            BookObject.FlightSchedule = theDate;
            BookObject.FlightDestinationFrom = fromComboBox.Text;
            BookObject.FlightDestinationTo = toComboBox.Text;
           // BookObject.Fare = "50";

            /*ja previous( I forgot the date)*/
            BookObject.Firstname = first_name.Text;
            BookObject.Lastname = last_name.Text;

            /*ja modify 6/4/21*/
            BookObject.Fare_CashAmount = txtbx_cashamount.Text;
            BookObject.Fare_CardNum = txtbx_cardnum.Text;
            BookObject.Fare_CardAmount = txtbx_cardamount.Text;

            this.Hide();
            confirmation f2 = new confirmation();
            f2.ShowDialog(); // 
            this.Close();

        }

        private void aOneBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "A1";
        }

        private void bOneBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "B1";
        }

        private void cOneBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "C1";
        }

        private void dOneBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "D1";
        }

        private void eOneBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "E1";
        }

        private void fOneBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "F1";
        }

        private void aTwoBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "A2";
        }

        private void bTwoBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "B2";
        }

        private void cTwoBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "C2";
        }

        private void dTwoBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "D2";

        }

        private void eTwoBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "E2";
        }

        private void fTwoBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "F2";
        }

        private void aThreeBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "A3";
        }

        private void bThreeBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "B3";
        }

        private void cThreeBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "C3";
        }
        private void dThreeBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "D3";
        }

        private void fThreeBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "F3";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("aw");
        }

        private void aFourBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "A4";
        }

        private void bFourBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "B4";
        }

        private void cFourBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "C4";
        }

        private void dFourBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "D4";
        }

        private void eFourBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "E4";
        }

        private void fFourBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "F4";
        }

        private void aFiveBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "A5";
        }

        private void bFiveBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "B5";
        }

        private void cFiveBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "C5";
        }

        private void dFiveBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "D5";
        }

        private void eFiveBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "E5";
        }

        private void fFiveBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "F5";
        }

        private void aSixBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "A6";
        }

        private void bSixBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "B6";
        }

        private void cSixBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "C6";
        }

        private void dSixBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "D6";
        }

        private void eSixBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "E6";
        }

        private void fSixBtn_Click(object sender, EventArgs e)
        {
            seatNumber = "F6";
        }
        //private void dThreeBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void fThreeBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void button14_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("aw");
        //}

        //private void aFourBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void bFourBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void cFourBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void dFourBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void eFourBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void fFourBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void aFiveBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void bFiveBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void cFiveBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void dFiveBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void eFiveBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void fFiveBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void aSixBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void bSixBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void cSixBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void dSixBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void eSixBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void fSixBtn_Click(object sender, EventArgs e)
        //{

        //}

        private void viewComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Query = "";
            try
            {
                if (viewComboBox.Text.Equals("Book"))
                {
                    Query = "SELECT * FROM flightbook LEFT OUTER JOIN flightcancel ON flightbook.FlightBookID = flightcancel.FlightBookID WHERE flightcancel.FlightBookID IS NULL";
                }
                else
                {
                    Query = "select * from flightdestination";
                }
                //Display query  
               
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
                MyConn2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void fromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToShortDateString();
            bookSeats(theDate);
            counterBook(theDate);
        }

        private void bookSeats(string theDate)
        {
            try
            {
                btnBookDefault();
                //Display query  
                // string Query = "select * from flightbook WHERE FlightSchedule ='" + theDate + "'";
                string Query = "SELECT * FROM flightbook LEFT OUTER JOIN flightcancel ON flightbook.FlightBookID = flightcancel.FlightBookID WHERE flightcancel.FlightBookID IS NULL AND flightbook.FlightSchedule ='" + theDate + "'";
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
                    // fromComboBox.Items.Add(row["FlightDestinationTLA"].ToString());
                    // toComboBox.Items.Add(row["FlightDestinationTLA"].ToString());

                    string seatBook = row["FlightSeat"].ToString();

                    switch (seatBook)
                    {
                        case "A1":
                            aOneBtn.Enabled = false;
                            break;
                        case "B1":
                            bOneBtn.Enabled = false;
                            break;
                        case "C1":
                            cOneBtn.Enabled = false;
                            break;
                        case "D1":
                            dOneBtn.Enabled = false;
                            break;
                        case "E1":
                            eOneBtn.Enabled = false;
                            break;
                        case "F1":
                            fOneBtn.Enabled = false;
                            break;
                        case "A2":
                            aTwoBtn.Enabled = false;
                            break;
                        case "B2":
                            bTwoBtn.Enabled = false;
                            break;
                        case "C2":
                            cTwoBtn.Enabled = false;
                            break;
                        case "D2":
                            dTwoBtn.Enabled = false;
                            break;
                        case "E2":
                            eTwoBtn.Enabled = false;
                            break;
                        case "F2":
                            fTwoBtn.Enabled = false;
                            break;
                        case "A3":
                            aThreeBtn.Enabled = false;
                            break;
                        case "B3":
                            bThreeBtn.Enabled = false;
                            break;
                        case "C3":
                            cThreeBtn.Enabled = false;
                            break;
                        case "D3":
                            dThreeBtn.Enabled = false;
                            break;
                        case "E3":
                            fThreeBtn.Enabled = false;
                            break;
                        case "F3":
                            button14.Enabled = false;
                            break;
                        case "A4":
                            aFourBtn.Enabled = false;
                            break;
                        case "B4":
                            bFourBtn.Enabled = false;
                            break;
                        case "C4":
                            cFourBtn.Enabled = false;
                            break;
                        case "D4":
                            dFourBtn.Enabled = false;
                            break;
                        case "E4":
                            eFourBtn.Enabled = false;
                            break;
                        case "F4":
                            fFourBtn.Enabled = false;
                            break;
                        case "A5":
                            aFiveBtn.Enabled = false;
                            break;
                        case "B5":
                            bFiveBtn.Enabled = false;
                            break;
                        case "C5":
                            cFiveBtn.Enabled = false;
                            break;
                        case "D5":
                            dFiveBtn.Enabled = false;
                            break;
                        case "E5":
                            eFiveBtn.Enabled = false;
                            break;
                        case "F5":
                            fFiveBtn.Enabled = false;
                            break;
                        case "A6":
                            aSixBtn.Enabled = false;
                            break;
                        case "B6":
                            bSixBtn.Enabled = false;
                            break;
                        case "C6":
                            cSixBtn.Enabled = false;
                            break;
                        case "D6":
                            dSixBtn.Enabled = false;
                            break;
                        case "E6":
                            eSixBtn.Enabled = false;
                            break;
                        case "F6":
                            fSixBtn.Enabled = false;
                            break;
                        default:
                            
                            break;
                    }

                }
                MyConn2.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("There is an error: " + e.Message);
            }
        }

        private void btnBookDefault()
        {
            aOneBtn.Enabled = true;
            bOneBtn.Enabled = true;
            cOneBtn.Enabled = true;
            dOneBtn.Enabled = true;
            eOneBtn.Enabled = true;
            fOneBtn.Enabled = true;

            aTwoBtn.Enabled = true;
            bTwoBtn.Enabled = true;
            cTwoBtn.Enabled = true;
            dTwoBtn.Enabled = true;
            eTwoBtn.Enabled = true;
            fTwoBtn.Enabled = true;

            aThreeBtn.Enabled = true;
            bThreeBtn.Enabled = true;
            cThreeBtn.Enabled = true;
            dThreeBtn.Enabled = true;
            fThreeBtn.Enabled = true;
            button14.Enabled = true;

            aFourBtn.Enabled = true;
            bFourBtn.Enabled = true;
            cFourBtn.Enabled = true;
            dFourBtn.Enabled = true;
            eFourBtn.Enabled = true;
            fFourBtn.Enabled = true;

            aFiveBtn.Enabled = true;
            bFiveBtn.Enabled = true;
            cFiveBtn.Enabled = true;
            dFiveBtn.Enabled = true;
            eFiveBtn.Enabled = true;
            fFiveBtn.Enabled = true;

            aSixBtn.Enabled = true;
            bSixBtn.Enabled = true;
            cSixBtn.Enabled = true;
            dSixBtn.Enabled = true;
            eSixBtn.Enabled = true;
            fSixBtn.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CancelForm cancelForm = new CancelForm();
            cancelForm.ShowDialog(); // 
            this.Close();
        }

        private void availableView_Click(object sender, EventArgs e)
        {

        }

        private void bookView_Click(object sender, EventArgs e)
        {

        }

        private void counterBook(string date)
        {

            // var dateAndTime = DateTime.Now;
            // var date = dateAndTime.ToString("M/dd/yyyy");

            try
            {
                //Display query  
                // string Query = "SELECT COUNT(*) AS books FROM flightbook WHERE FlightSchedule ='" + date + "'";
                string Query = "SELECT COUNT(*) AS books FROM flightbook LEFT OUTER JOIN flightcancel ON flightbook.FlightBookID = flightcancel.FlightBookID WHERE flightcancel.FlightBookID IS NULL AND flightbook.FlightSchedule ='" + date + "'";
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
                    bookView.Text = row["books"].ToString();
                    string total = row["books"].ToString();
                    int available = 36 - Int32.Parse(total);
                    availableView.Text = available.ToString();
                }
                MyConn2.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("There is an error: " + e.Message);
            }

            viewComboBox.Items.Add("Book");
            viewComboBox.Items.Add("Destination");
        }

    }
}
