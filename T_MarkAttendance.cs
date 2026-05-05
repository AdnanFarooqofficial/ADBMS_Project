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
    public partial class T_MarkAttendance : Form
    {
        SqlConnection con = new SqlConnection(@"Server=ADNANFAROOQ\SQLEXPRESS;Database=Adbms_Project;Trusted_Connection=True;TrustServerCertificate=True;");

        public T_MarkAttendance()
        {
            InitializeComponent();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
        public void LoadStudents_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int successCount = 0;
            int failCount = 0;
            try
            {
                con.Open();

                DateTime selectedDate = dateTimePicker1.Value.Date;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Skip empty new row
                    if (row.IsNewRow) continue;

                    if (row.Cells[0].Value != null)
                    {
                        int studentId = Convert.ToInt32(row.Cells[0].Value);

                        // If no status selected then Absent
                        string status = "Present";

                        if (row.Cells[1].Value != null)
                            status = row.Cells[1].Value.ToString();

                        try 
                        {
                            // Check duplicate first
                            string checkQuery = @"SELECT COUNT(*) 
                                      FROM Attendance 
                                      WHERE student_id=@sid AND date=@date";

                            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                            checkCmd.Parameters.AddWithValue("@sid", studentId);
                            checkCmd.Parameters.AddWithValue("@date", selectedDate);

                            int count = (int)checkCmd.ExecuteScalar();

                            if (count == 0)
                            {
                                // Insert attendance
                                string insertQuery = @"INSERT INTO Attendance(student_id,date,status)
                                           VALUES(@sid,@date,@status)";

                                SqlCommand cmd = new SqlCommand(insertQuery, con);
                                cmd.Parameters.AddWithValue("@sid", studentId);
                                cmd.Parameters.AddWithValue("@date", selectedDate);
                                cmd.Parameters.AddWithValue("@status", status);

                                cmd.ExecuteNonQuery();
                                successCount++;
                            }
                            else
                            {
                                failCount++;
                            }
                        }
                        catch
                        {
                            failCount++;
                        }
                    }
                }

                con.Close();

                MessageBox.Show( "attendance saved \n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
          
        

        private void label4_Click(object sender, EventArgs e)
        {
            T_Dashboard t_Dashboard = new T_Dashboard();
            t_Dashboard.Show();
            this.Hide();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query = @"SELECT S.student_id, S.name
                         FROM Students S
                         JOIN Classes C ON S.class_id = C.class_id
                         WHERE C.class_name = @ClassName";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ClassName", comboBox3.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.Rows.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    dataGridView1.Rows.Add(
                        dr["student_id"].ToString(),
                        dr["name"].ToString(),
                        "Absent"
                    );
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        private void T_MarkAttendance_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn col =
                (DataGridViewComboBoxColumn)dataGridView1.Columns["StatusColumn"];

            col.Items.Add("Present");
            col.Items.Add("Absent");
        }
    }
}
