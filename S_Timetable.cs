using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adbms_project
{
    public partial class S_Timetable : Form
    {
        SqlConnection con = new SqlConnection(@"Server=ADNANFAROOQ\SQLEXPRESS;Database=Adbms_Project;Trusted_Connection=True;TrustServerCertificate=True;");

        public S_Timetable()
        {
            InitializeComponent();
            LoadTimetable();
        }
        private void LoadTimetable() // Defaulting to R001 as requested
        {
            try
            {
                con.Open();
                // Select all columns to fill the grid shown in image_0ea23f.png
                string query = @"SELECT start_time AS [Time], monday AS [MON], tuesday AS [TUE], 
                         wednesday AS [WED], thursday AS [THU], friday AS [FRI] 
                         FROM Timetable";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("The Timetable table is empty. Please add data in SQL.");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void S_Timetable_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            S_Dashboard DashBoardScreen = new S_Dashboard();
            DashBoardScreen.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            S_Results ResultScreen = new S_Results();
            ResultScreen.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            S_Attendance AttendanceScreen = new S_Attendance();
            AttendanceScreen.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Create a new instance of the Login form
            Login loginForm = new Login();

            // 2. Show the Login form
            loginForm.Show();

            // 3. Close the current management form entirely
            // Using .Close() is better than .Hide() for logging out to free up memory
            this.Close();
        }
    }
}
