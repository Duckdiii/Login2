namespace Login_Day2
{
    partial class AddCourseStdForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.StudentID_textBox = new System.Windows.Forms.TextBox();
            this.Add_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Semester_comboBox = new System.Windows.Forms.ComboBox();
            this.AvailableCourse_listBox = new System.Windows.Forms.ListBox();
            this.SelectedCourse_listBox = new System.Windows.Forms.ListBox();
            this.Save_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID:";
            // 
            // StudentID_textBox
            // 
            this.StudentID_textBox.Location = new System.Drawing.Point(80, 20);
            this.StudentID_textBox.Name = "StudentID_textBox";
            this.StudentID_textBox.Size = new System.Drawing.Size(126, 20);
            this.StudentID_textBox.TabIndex = 1;
            // 
            // Add_btn
            // 
            this.Add_btn.Location = new System.Drawing.Point(51, 262);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(116, 50);
            this.Add_btn.TabIndex = 3;
            this.Add_btn.Text = "Add";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Semester:";
            // 
            // Semester_comboBox
            // 
            this.Semester_comboBox.FormattingEnabled = true;
            this.Semester_comboBox.Location = new System.Drawing.Point(304, 26);
            this.Semester_comboBox.Name = "Semester_comboBox";
            this.Semester_comboBox.Size = new System.Drawing.Size(121, 21);
            this.Semester_comboBox.TabIndex = 5;
            this.Semester_comboBox.SelectedIndexChanged += new System.EventHandler(this.Semester_comboBox_SelectedIndexChanged);
            this.Semester_comboBox.TextChanged += new System.EventHandler(this.Semester_comboBox_TextChanged);
            // 
            // AvailableCourse_listBox
            // 
            this.AvailableCourse_listBox.FormattingEnabled = true;
            this.AvailableCourse_listBox.Location = new System.Drawing.Point(16, 74);
            this.AvailableCourse_listBox.Name = "AvailableCourse_listBox";
            this.AvailableCourse_listBox.Size = new System.Drawing.Size(185, 160);
            this.AvailableCourse_listBox.TabIndex = 6;
            // 
            // SelectedCourse_listBox
            // 
            this.SelectedCourse_listBox.FormattingEnabled = true;
            this.SelectedCourse_listBox.Location = new System.Drawing.Point(251, 74);
            this.SelectedCourse_listBox.Name = "SelectedCourse_listBox";
            this.SelectedCourse_listBox.Size = new System.Drawing.Size(185, 160);
            this.SelectedCourse_listBox.TabIndex = 7;
            // 
            // Save_btn
            // 
            this.Save_btn.Location = new System.Drawing.Point(272, 262);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(116, 50);
            this.Save_btn.TabIndex = 8;
            this.Save_btn.Text = "Save";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Available Course:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Selected Course:";
            // 
            // AddCourseStdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 324);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.SelectedCourse_listBox);
            this.Controls.Add(this.AvailableCourse_listBox);
            this.Controls.Add(this.Semester_comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.StudentID_textBox);
            this.Controls.Add(this.label1);
            this.Name = "AddCourseStdForm";
            this.Text = "AddCourseStdForm";
            this.Load += new System.EventHandler(this.AddCourseStdForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StudentID_textBox;
        private System.Windows.Forms.Button Add_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Semester_comboBox;
        private System.Windows.Forms.ListBox AvailableCourse_listBox;
        private System.Windows.Forms.ListBox SelectedCourse_listBox;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}