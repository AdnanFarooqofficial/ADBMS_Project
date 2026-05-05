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
    public partial class T_Mystudents : Form
    {
        SqlConnection con = new SqlConnection(@"Server=ADNANFAROOQ\SQLEXPRESS;Database=Adbms_Project;Trusted_Connection=True;TrustServerCertificate=True;");

        public T_Mystudents()
        {
            InitializeComponent();
            LoadStudentGrid("Class 1");
        }
        private void LoadStudentGrid(string className)
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string query = @"
                SELECT 
                    S.roll_no AS [Roll No], 
                    S.name AS [Student Name], 
                    ISNULL(LatestAttendance.status, 'No Record') AS [Last Attendance]
                FROM Students S
                JOIN Classes C ON S.class_id = C.class_id
                OUTER APPLY (
                    SELECT TOP 1 status 
                    FROM Attendance A 
                    WHERE A.student_id = S.student_id 
                    ORDER BY A.date DESC
                ) AS LatestAttendance
                WHERE C.class_name = @ClassName";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ClassName", className);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // dataGridView1 is the grid shown in your image
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void T_Mystudents_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            T_Dashboard t_Dashboard = new T_Dashboard();
            t_Dashboard.Show();
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
