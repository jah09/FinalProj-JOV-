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
    public partial class LoginForm : Form
    {
        string MyConnection2 = "server=localhost;database=airlines;uid=root;pwd=;";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            Log_in.Username = txtbx_username.Text;
            Log_in.Password = txtbx_password.Text;

            string count = "";

            try
            {
                // string Query = "select username,password from flightuser where = '" + Log_in.Username + "','" + Log_in.Password + "','";
                string Query = "SELECT COUNT(*) AS login FROM flightuser WHERE username = '" + txtbx_username.Text.ToString() + "' AND password = '" + txtbx_password.Text.ToString() + "'";
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
                    count = row["login"].ToString();
                }

                if(count.Equals("1"))
                {
                    this.Hide();
                    Form1 f2 = new Form1();
                    f2.ShowDialog(); // 
                    this.Close();
                } else
                {
                    MessageBox.Show("Invalid Password!");
                }

                MyConn2.Close();
                // this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There is an error: " + ex.Message);
            }
        }
    }
}
