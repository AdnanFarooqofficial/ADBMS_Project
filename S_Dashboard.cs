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
    public partial class S_Dashboard : Form
    {
        public S_Dashboard()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void S_Dashboard_Load(object sender, EventArgs e)
        {

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
