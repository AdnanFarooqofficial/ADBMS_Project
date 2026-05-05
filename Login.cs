using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace Adbms_project
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(
        @"Server=ADNANFAROOQ\SQLEXPRESS;
        Database=Adbms_Project;
        Trusted_Connection=True;
        TrustServerCertificate=True;");
        string role = "";
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedRole = "";
            if (radioButton1.Checked) selectedRole = "Admin";
            else if (radioButton2.Checked) selectedRole = "Student";
            else if (radioButton3.Checked) selectedRole = "Teacher";

            if (string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please select a role before logging in.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                con.Open();

              
                string query = "SELECT COUNT(*) FROM Users WHERE username=@u AND password=@p AND role=@r";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@u", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@p", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@r", selectedRole);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show($"Welcome {textBox1.Text}! Login Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Navigation Logic based on Role
                    if (selectedRole == "Admin")
                    {
                        // Open the Student Management screen seen in image_54ab85.png
                        Form1 studentManagement = new Form1();
                        studentManagement.Show();
                        this.Hide(); // Hides the login form
                    }
                    else if (selectedRole == "Student")
                    {
                        S_Dashboard studentDashboard = new S_Dashboard();
                        studentDashboard.Show();
                        this.Hide(); // Hides the login form
                    }
                    else if (selectedRole == "Teacher")
                    {
                        T_Dashboard TeacherDashboard = new T_Dashboard();
                        TeacherDashboard.Show();
                        this.Hide(); // Hides the login form
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username, Password, or Role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Always close the connection in finally block to prevent leaks
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            role = "Admin";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            role = "Student";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            role = "Teacher";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            role = "Admin";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            role = "Student";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            role = "Teacher";
        }
    }
}
