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
    public partial class T_Dashboard : Form
    {
        SqlConnection con = new SqlConnection(@"Server=ADNANFAROOQ\SQLEXPRESS;Database=Adbms_Project;Trusted_Connection=True;TrustServerCertificate=True;");


        public T_Dashboard()
        {
            InitializeComponent();
            LoadTeacherProfile("T021");
            LoadTodaySchedule("T021");
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void T_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void LoadTeacherProfile(string teacherID)
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                // Match these names EXACTLY to your database columns
                string query = "SELECT name, employee_id, Subject FROM Teachers WHERE employee_id = @ID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", teacherID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Use the column names defined in the SELECT statement above
                    label20.Text = reader["name"].ToString();
                    label18.Text = reader["employee_id"].ToString();
                    label7.Text = reader["Subject"].ToString();
                  
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        private void LoadTodaySchedule(string currentTeacherID)
        {
            try
            {
                // Ensure connection is open
                if (con.State == ConnectionState.Closed) con.Open();

                // SQL query to match the columns in image_f44c7f.png
                // We use 'AS' to make the headers look professional in the GUI
                string query = @"SELECT Period, 
                               TimeInterval AS [Time], 
                               ClassName AS [Class], 
                               SubjectName AS [Subject] 
                        FROM Schedules 
                        WHERE TeacherID = @Tid";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Tid", currentTeacherID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind the data to your DataGridView
                // Replace 'dgvSchedule' with the actual name of your grid control
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule: " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            T_Mystudents t_Mystudents = new T_Mystudents();
            t_Mystudents.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            T_Addmarks t_Addmarks = new T_Addmarks();
            t_Addmarks.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            T_MarkAttendance t_MarkAttendance = new T_MarkAttendance();
            t_MarkAttendance.Show();
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
