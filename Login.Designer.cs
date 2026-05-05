namespace Adbms_project
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.ForeColor = SystemColors.WindowFrame;
            textBox1.Location = new Point(217, 193);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(323, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.ForeColor = SystemColors.WindowFrame;
            textBox2.Location = new Point(217, 256);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(323, 23);
            textBox2.TabIndex = 1;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(217, 25);
            label1.Name = "label1";
            label1.Size = new Size(323, 31);
            label1.TabIndex = 2;
            label1.Text = "School Management System";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(314, 307);
            button1.Name = "button1";
            button1.Size = new Size(120, 38);
            button1.TabIndex = 3;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(279, 70);
            label2.Name = "label2";
            label2.Size = new Size(200, 21);
            label2.TabIndex = 4;
            label2.Text = "Select your role to sign in";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 100);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 5;
            label3.Text = "Login As";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(217, 166);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 9;
            label4.Text = "Username";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(217, 229);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 10;
            label5.Text = "Password";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(217, 129);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(61, 19);
            radioButton1.TabIndex = 11;
            radioButton1.TabStop = true;
            radioButton1.Text = "Admin";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(347, 129);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(66, 19);
            radioButton2.TabIndex = 12;
            radioButton2.TabStop = true;
            radioButton2.Text = "Student";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(479, 129);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(65, 19);
            radioButton3.TabIndex = 13;
            radioButton3.TabStop = true;
            radioButton3.Text = "Teacher";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private TextBox textBox2;
    }
}
