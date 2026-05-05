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
    public partial class S_Results : Form
    {
        SqlConnection con = new SqlConnection(@"Server=ADNANFAROOQ\SQLEXPRESS;Database=Adbms_Project;Trusted_Connection=True;TrustServerCertificate=True;");

        public S_Results()
        {
            InitializeComponent();
            ShowStudentResults();
        }
        private void ShowStudentResults(string studentRoll = "R001")
        {
            try
            {
                con.Open();
                // This query joins Results and Students but filters for only ONE roll number
                string query = @"SELECT R.exam_title AS [Exam], R.subject_name AS [Subject], 
                         R.total_marks AS [Total], R.obtained_marks AS [Obtained], 
                         R.grade AS [Grade]
                         FROM Results R
                         JOIN Students S ON R.student_id = S.student_id
                         WHERE S.roll_no = @roll";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@roll", studentRoll);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                // Populate the Result Sheet shown in image_1073e1.png
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading results: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void S_Results_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            S_Dashboard DashBoardScreen = new S_Dashboard();
            DashBoardScreen.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            S_Timetable TimeTableScreen = new S_Timetable();
            TimeTableScreen.Show();
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
