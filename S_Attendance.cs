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
    public partial class S_Attendance : Form
    {
        SqlConnection con = new SqlConnection(@"Server=ADNANFAROOQ\SQLEXPRESS;Database=Adbms_Project;Trusted_Connection=True;TrustServerCertificate=True;");

        public S_Attendance()
        {
            InitializeComponent();
            LoadMyAttendance("R001");
        }

        private void LoadMyAttendance(string rollNo)
        {
            try
            {
                con.Open();
                // Join Attendance with Students to filter by Roll Number
                string query = @"SELECT A.date AS [Date], A.status AS [Status]
                         FROM Attendance A
                         JOIN Students S ON A.student_id = S.student_id
                         WHERE S.roll_no = @roll
                         ORDER BY A.date DESC";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@roll", rollNo);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                // Ensure your DataGridView name matches (likely dataGridView1)
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void S_Attendance_Load(object sender, EventArgs e)
        {
            UpdateAttendanceCount();
        }

        private void UpdateAttendanceCount()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Attendance", con);
                int total = (int)cmd.ExecuteScalar();
                label19.Text = total.ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Attendance WHERE Status='Absent'", con);

                int totalPresent = (int)cmd.ExecuteScalar();

                label15.Text = totalPresent.ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Attendance WHERE Status='Present'", con);

                int totalPresent = (int)cmd.ExecuteScalar();

                label14.Text = totalPresent.ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void label6_Click(object sender, EventArgs e)
        {
            S_Timetable TimeTableScreen = new S_Timetable();
            TimeTableScreen.Show();
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

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        private void label15_Click(object sender, EventArgs e)
        {
            
        }

        private void label19_Click(object sender, EventArgs e)
        {
            
        }
    }
}
