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
    public partial class Class_Management : Form
    {
        SqlConnection con = new SqlConnection(@"Server=ADNANFAROOQ\SQLEXPRESS;Database=Adbms_Project;Trusted_Connection=True;TrustServerCertificate=True;");

        public Class_Management()
        {
            InitializeComponent();
            ShowData();
        }

        private void ShowData()
        {
            try
            {
                con.Open();
                // Fetching columns matching your SQL Classes table
                string query = "SELECT class_id, class_name AS [Class Name], section AS [Section], room_no AS [Room No] FROM Classes";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                // Hide class_id so code can use it for deletion but users don't see it
                if (dataGridView1.Columns.Contains("class_id"))
                    dataGridView1.Columns["class_id"].Visible = false;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void label8_Click(object sender, EventArgs e)
        {
            Exams_and_Results examScreen = new Exams_and_Results();
            examScreen.Show();
            this.Hide();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                // Inserting into Classes table based on your schema
                string query = "INSERT INTO Classes (class_name, section, room_no) VALUES (@name, @sec, @room)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", textBox2.Text); // Class Name
                cmd.Parameters.AddWithValue("@sec", textBox4.Text);  // Section
                cmd.Parameters.AddWithValue("@room", textBox3.Text); // Room No

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Class added successfully!");
                ShowData(); // Refresh list
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int classId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["class_id"].Value);

                try
                {
                    con.Open();
                    string query = "DELETE FROM Classes WHERE class_id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", classId);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Class deleted.");
                    ShowData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot delete: This class may have students assigned to it.");
                    if (con.State == ConnectionState.Open) con.Close();
                }
            }
            }
    }
}
