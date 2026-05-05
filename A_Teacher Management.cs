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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Adbms_project
{
    public partial class Teacher_Management : Form
    {
        SqlConnection con = new SqlConnection(@"Server=ADNANFAROOQ\SQLEXPRESS;Database=Adbms_Project;Trusted_Connection=True;TrustServerCertificate=True;");

        public Teacher_Management()
        {
            InitializeComponent();
            ShowData();
        }

        private void ShowData()
        {
            try
            {
                con.Open();
                // Query based on your Teachers table in the SQL script
                string query = "SELECT teacher_id, employee_id AS [ID], name AS [Name], subject AS [Subject] FROM Teachers";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView1.DataSource = dt;

                // Hide the primary key from the user but keep it for code logic
                if (dataGridView1.Columns.Contains("teacher_id"))
                    dataGridView1.Columns["teacher_id"].Visible = false;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO Teachers (name, subject, employee_id) VALUES (@name, @sub, @emp)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", textBox2.Text); // Assuming textBox2 is Name
                cmd.Parameters.AddWithValue("@sub", comboBox2.Text);  // Assuming comboBox2 is Subject
                cmd.Parameters.AddWithValue("@emp", textBox3.Text);  // Assuming textBox4 is Employee ID

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Teacher Added!");
                ShowData(); // Refresh the list
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 StudentScreen = new Form1();
            StudentScreen.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Class_Management classScreen = new Class_Management();
            classScreen.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Exams_and_Results examScreen = new Exams_and_Results();
            examScreen.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Teacher_Management teacherScreen = new Teacher_Management();
            teacherScreen.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int teacherId = Convert.ToInt32(
                    dataGridView1.SelectedRows[0].Cells["teacher_id"].Value
                );

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this teacher?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("DeleteTeacher", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@teacher_id", teacherId);

                        cmd.ExecuteNonQuery();

                        con.Close();

                        MessageBox.Show("Teacher deleted successfully");

                        ShowData(); // IMPORTANT
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Create a new instance of the Login form
            Login loginForm = new Login();

            // 2. Show the Login form
            loginForm.Show();

            // 3. Close the current management form entirely
            // Using .Close() is better than .Hide() for logging out to free up memory
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
