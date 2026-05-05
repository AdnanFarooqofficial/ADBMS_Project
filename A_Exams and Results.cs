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
    public partial class Exams_and_Results : Form
    {
        SqlConnection con = new SqlConnection(@"Server=ADNANFAROOQ\SQLEXPRESS;Database=Adbms_Project;Trusted_Connection=True;TrustServerCertificate=True;");

        public Exams_and_Results()
        {
            InitializeComponent();
            ShowData();

        }
        private void ShowData()
        {
            try
            {
                con.Open();
                // SQL Join to show Roll Number and Name along with marks
                string query = @"SELECT R.result_id, S.roll_no AS [Roll No], S.name AS [Student], 
                         R.exam_title AS [Exam], R.subject_name AS [Subject], 
                         R.total_marks AS [Total], R.obtained_marks AS [Obtained], 
                         R.grade AS [Grade]
                         FROM Results R
                         JOIN Students S ON R.student_id = S.student_id";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                // Hide result_id for deletion logic
                if (dataGridView1.Columns.Contains("result_id"))
                    dataGridView1.Columns["result_id"].Visible = false;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading results: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                // First, get the student_id using the Roll Number provided in the text/combo box
                string getID = "SELECT student_id FROM Students WHERE roll_no = @roll";
                SqlCommand cmdId = new SqlCommand(getID, con);
                cmdId.Parameters.AddWithValue("@roll", textBox3.Text); // Update with your actual control name
                object result = cmdId.ExecuteScalar();

                if (result != null)
                {
                    int studentId = Convert.ToInt32(result);

                    string query = @"INSERT INTO Results (exam_title, student_id, subject_name, total_marks, obtained_marks, grade) 
                             VALUES (@title, @sid, @sub, @total, @obtain, @grade)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@title", textBox6.Text);
                    cmd.Parameters.AddWithValue("@sid", studentId);
                    cmd.Parameters.AddWithValue("@sub", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@total", textBox5.Text);
                    cmd.Parameters.AddWithValue("@obtain", textBox4.Text);
                    cmd.Parameters.AddWithValue("@grade", comboBox1.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Result added successfully!");
                    ShowData(); // Refresh table
                }
                else
                {
                    MessageBox.Show("Invalid Roll Number. Student not found.");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
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

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 StudentScreen = new Form1();
            StudentScreen.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Teacher_Management teacherScreen = new Teacher_Management();
            teacherScreen.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Class_Management classScreen = new Class_Management();
            classScreen.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the result_id from the hidden column
                int resultId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["result_id"].Value);

                if (MessageBox.Show("Are you sure you want to delete this result?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM Results WHERE result_id = @id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", resultId);

                        cmd.ExecuteNonQuery();
                        con.Close();

                        ShowData(); // Refresh table
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        if (con.State == ConnectionState.Open) con.Close();
                    }
                }
            }
        }

        private void Exams_and_Results_Load(object sender, EventArgs e)
        {

        }
    }
}
