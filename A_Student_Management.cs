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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Server=ADNANFAROOQ\SQLEXPRESS;Database=Adbms_Project;Trusted_Connection=True;TrustServerCertificate=True;");
        public Form1()
        {
            InitializeComponent();
            ShowData();
        }

        private void ShowData()
        {
            try
            {
                con.Open();
                // Add student_id to the SELECT statement
                string query = "SELECT student_id, roll_no AS [Roll No], name AS [Name], class_id AS [Class] FROM Students";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                // Hide the ID column from the user, but keep it available for code
                dataGridView1.Columns["student_id"].Visible = false;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // Leave empty
        }
        private void label2_Click(object sender, EventArgs e)
        {
            // Leave empty
        }
        private void label3_Click(object sender, EventArgs e)
        {
            // Leave empty
        }
        private void label4_Click(object sender, EventArgs e)
        {

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
        private void label7_Click(object sender, EventArgs e)
        {
            // Leave empty
        }
        private void label8_Click(object sender, EventArgs e)
        {
            Exams_and_Results examScreen = new Exams_and_Results();
            examScreen.Show();
            this.Hide();
        }
        private void label9_Click(object sender, EventArgs e)
        {
            // Leave empty
        }

        private void label10_Click(object sender, EventArgs e)
        {
            // Leave empty
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                con.Open();
                // Using the stored procedure AddStudent from your SQL script
                SqlCommand cmd = new SqlCommand("AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", textBox2.Text + " " + textBox4.Text);
                cmd.Parameters.AddWithValue("@roll", textBox5.Text);
                cmd.Parameters.AddWithValue("@class", 1); // Assuming 1 for testing; replace with your ComboBox value

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Student Added Successfully!");

                // Clear textboxes
                textBox2.Clear();
                textBox4.Clear();
                textBox5.Clear();

                // Refresh the table to show the new record
                ShowData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding student: " + ex.Message);
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 2. Get the Unique ID from the selected row
                // Replace "student_id" with the actual name of your ID column in the DataGridView
                int studentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["student_id"].Value);

                // Confirm with the user
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();

                        // 3. Use the stored procedure 'DeleteStudent' from your script
                        SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", studentId);

                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Student deleted successfully.");

                        // 4. Refresh the table to show updated data
                        ShowData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a full row from the list to delete.");
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
    }

}
