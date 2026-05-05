namespace Adbms_project
{
    partial class T_MarkAttendance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label19 = new Label();
            dataGridView1 = new DataGridView();
            Column6 = new DataGridViewTextBoxColumn();
            Class = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewComboBoxColumn();
            button2 = new Button();
            label23 = new Label();
            label27 = new Label();
            label1 = new Label();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label7 = new Label();
            listView1 = new ListView();
            comboBox3 = new ComboBox();
            label14 = new Label();
            label12 = new Label();
            label11 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            label10 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(334, 68);
            label19.Name = "label19";
            label19.Size = new Size(32, 15);
            label19.TabIndex = 249;
            label19.Text = "Date";
            label19.Click += label19_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column6, Class, Column1 });
            dataGridView1.Location = new Point(148, 147);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(344, 278);
            dataGridView1.TabIndex = 248;
            // 
            // Column6
            // 
            Column6.Frozen = true;
            Column6.HeaderText = "Student ID";
            Column6.Name = "Column6";
            // 
            // Class
            // 
            Class.Frozen = true;
            Class.HeaderText = "Name";
            Class.Name = "Class";
            // 
            // Column1
            // 
            Column1.Frozen = true;
            Column1.HeaderText = "Status";
            Column1.Items.AddRange(new object[] { "Present", "Absent" });
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.True;
            Column1.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // button2
            // 
            button2.Location = new Point(13, 384);
            button2.Name = "button2";
            button2.Size = new Size(76, 26);
            button2.TabIndex = 244;
            button2.Text = "Logout";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = SystemColors.ControlLightLight;
            label23.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.Location = new Point(287, 228);
            label23.Name = "label23";
            label23.Size = new Size(0, 15);
            label23.TabIndex = 243;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.BackColor = SystemColors.ControlLightLight;
            label27.Location = new Point(151, 232);
            label27.Name = "label27";
            label27.Size = new Size(0, 15);
            label27.TabIndex = 242;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 54);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 241;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(151, 8);
            label9.Name = "label9";
            label9.Size = new Size(115, 19);
            label9.TabIndex = 239;
            label9.Text = "Mark Attendance";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ControlLightLight;
            label8.Location = new Point(14, 147);
            label8.Name = "label8";
            label8.Size = new Size(98, 15);
            label8.TabIndex = 238;
            label8.Text = "Mark Attendance";
            label8.Click += label8_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLightLight;
            label6.Location = new Point(14, 126);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 237;
            label6.Text = "Enter Marks";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlLightLight;
            label5.Location = new Point(14, 105);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 236;
            label5.Text = "My Students";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlLightLight;
            label4.Location = new Point(13, 83);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 235;
            label4.Text = "Dashboard";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLightLight;
            label3.ForeColor = SystemColors.ButtonShadow;
            label3.Location = new Point(13, 58);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 234;
            label3.Text = "My Portal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(13, 24);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 233;
            label2.Text = "Teacher Portal";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ControlLightLight;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(13, 8);
            label7.Name = "label7";
            label7.Size = new Size(82, 19);
            label7.TabIndex = 232;
            label7.Text = "School MS";
            // 
            // listView1
            // 
            listView1.Location = new Point(2, 1);
            listView1.Name = "listView1";
            listView1.Size = new Size(140, 424);
            listView1.TabIndex = 245;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Class 1", "Class 2", "Class 3", "Class 4", "Class 5", "Class 6", "Class 7", "Class 8", "Class 9", "Class 10" });
            comboBox3.Location = new Point(151, 97);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 228;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = SystemColors.ControlLightLight;
            label14.Location = new Point(173, 102);
            label14.Name = "label14";
            label14.Size = new Size(0, 15);
            label14.TabIndex = 219;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(162, 68);
            label12.Name = "label12";
            label12.Size = new Size(0, 15);
            label12.TabIndex = 217;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(151, 68);
            label11.Name = "label11";
            label11.Size = new Size(36, 15);
            label11.TabIndex = 251;
            label11.Text = "Class";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(334, 97);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 252;
            // 
            // button1
            // 
            button1.Location = new Point(593, 147);
            button1.Name = "button1";
            button1.Size = new Size(144, 23);
            button1.TabIndex = 253;
            button1.Text = "Submit Attendance";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(618, 11);
            label10.Name = "label10";
            label10.Size = new Size(119, 15);
            label10.TabIndex = 254;
            label10.Text = "Muhammad Hammad";
            // 
            // button3
            // 
            button3.Location = new Point(662, 94);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 255;
            button3.Text = "Load";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // T_MarkAttendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(label10);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label11);
            Controls.Add(label19);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(label23);
            Controls.Add(label27);
            Controls.Add(label1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(listView1);
            Controls.Add(comboBox3);
            Controls.Add(label14);
            Controls.Add(label12);
            Name = "T_MarkAttendance";
            Text = "T_MarkAttendance";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label19;
        private DataGridView dataGridView1;
        private Button button2;
        private Label label23;
        private Label label27;
        private Label label1;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label7;
        private ListView listView1;
        private ComboBox comboBox3;
        private Label label14;
        private Label label12;
        private Label label11;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private Label label10;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Class;
        private DataGridViewComboBoxColumn Column1;
        private Button button3;
    }
}