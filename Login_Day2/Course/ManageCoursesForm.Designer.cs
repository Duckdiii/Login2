namespace Login_Day2
{
    partial class ManageCoursesForm
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
            this.FirstPos_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CoursesDisplay_listBox = new System.Windows.Forms.ListBox();
            this.HoursNum_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.IDCourse_textBox = new System.Windows.Forms.TextBox();
            this.NameCourse_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CourseDescription_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LastPos_btn = new System.Windows.Forms.Button();
            this.NextPos_btn = new System.Windows.Forms.Button();
            this.PreviousPos_btn = new System.Windows.Forms.Button();
            this.AddCourse_btn = new System.Windows.Forms.Button();
            this.EditCourse_btn = new System.Windows.Forms.Button();
            this.RemoveCourse_btn = new System.Windows.Forms.Button();
            this.TotalCoursesNum_lb = new System.Windows.Forms.Label();
            this.Semester_textBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HoursNum_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstPos_btn
            // 
            this.FirstPos_btn.Location = new System.Drawing.Point(46, 233);
            this.FirstPos_btn.Name = "FirstPos_btn";
            this.FirstPos_btn.Size = new System.Drawing.Size(75, 23);
            this.FirstPos_btn.TabIndex = 0;
            this.FirstPos_btn.Text = "First";
            this.FirstPos_btn.UseVisualStyleBackColor = true;
            this.FirstPos_btn.Click += new System.EventHandler(this.FirstPos_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID: ";
            // 
            // CoursesDisplay_listBox
            // 
            this.CoursesDisplay_listBox.FormattingEnabled = true;
            this.CoursesDisplay_listBox.Location = new System.Drawing.Point(296, 16);
            this.CoursesDisplay_listBox.Name = "CoursesDisplay_listBox";
            this.CoursesDisplay_listBox.Size = new System.Drawing.Size(257, 290);
            this.CoursesDisplay_listBox.TabIndex = 3;
            this.CoursesDisplay_listBox.Click += new System.EventHandler(this.CoursesDisplay_listBox_Click);
            this.CoursesDisplay_listBox.SelectedIndexChanged += new System.EventHandler(this.CoursesDisplay_listBox_SelectedIndexChanged);
            this.CoursesDisplay_listBox.DoubleClick += new System.EventHandler(this.CoursesDisplay_listBox_DoubleClick);
            // 
            // HoursNum_numericUpDown
            // 
            this.HoursNum_numericUpDown.Location = new System.Drawing.Point(86, 71);
            this.HoursNum_numericUpDown.Name = "HoursNum_numericUpDown";
            this.HoursNum_numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.HoursNum_numericUpDown.TabIndex = 4;
            // 
            // IDCourse_textBox
            // 
            this.IDCourse_textBox.Location = new System.Drawing.Point(86, 16);
            this.IDCourse_textBox.Name = "IDCourse_textBox";
            this.IDCourse_textBox.Size = new System.Drawing.Size(126, 20);
            this.IDCourse_textBox.TabIndex = 5;
            // 
            // NameCourse_textBox
            // 
            this.NameCourse_textBox.Location = new System.Drawing.Point(86, 42);
            this.NameCourse_textBox.Name = "NameCourse_textBox";
            this.NameCourse_textBox.Size = new System.Drawing.Size(164, 20);
            this.NameCourse_textBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Course:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hours:";
            // 
            // CourseDescription_richTextBox
            // 
            this.CourseDescription_richTextBox.Location = new System.Drawing.Point(86, 131);
            this.CourseDescription_richTextBox.Name = "CourseDescription_richTextBox";
            this.CourseDescription_richTextBox.Size = new System.Drawing.Size(164, 96);
            this.CourseDescription_richTextBox.TabIndex = 9;
            this.CourseDescription_richTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Description:";
            // 
            // LastPos_btn
            // 
            this.LastPos_btn.Location = new System.Drawing.Point(161, 233);
            this.LastPos_btn.Name = "LastPos_btn";
            this.LastPos_btn.Size = new System.Drawing.Size(75, 23);
            this.LastPos_btn.TabIndex = 11;
            this.LastPos_btn.Text = "Last";
            this.LastPos_btn.UseVisualStyleBackColor = true;
            this.LastPos_btn.Click += new System.EventHandler(this.LastPos_btn_Click);
            // 
            // NextPos_btn
            // 
            this.NextPos_btn.Location = new System.Drawing.Point(161, 277);
            this.NextPos_btn.Name = "NextPos_btn";
            this.NextPos_btn.Size = new System.Drawing.Size(75, 23);
            this.NextPos_btn.TabIndex = 12;
            this.NextPos_btn.Text = "Next";
            this.NextPos_btn.UseVisualStyleBackColor = true;
            this.NextPos_btn.Click += new System.EventHandler(this.NextPos_btn_Click);
            // 
            // PreviousPos_btn
            // 
            this.PreviousPos_btn.Location = new System.Drawing.Point(46, 277);
            this.PreviousPos_btn.Name = "PreviousPos_btn";
            this.PreviousPos_btn.Size = new System.Drawing.Size(75, 23);
            this.PreviousPos_btn.TabIndex = 13;
            this.PreviousPos_btn.Text = "Previous";
            this.PreviousPos_btn.UseVisualStyleBackColor = true;
            this.PreviousPos_btn.Click += new System.EventHandler(this.PreviousPos_btn_Click);
            // 
            // AddCourse_btn
            // 
            this.AddCourse_btn.Location = new System.Drawing.Point(70, 328);
            this.AddCourse_btn.Name = "AddCourse_btn";
            this.AddCourse_btn.Size = new System.Drawing.Size(75, 23);
            this.AddCourse_btn.TabIndex = 14;
            this.AddCourse_btn.Text = "Add";
            this.AddCourse_btn.UseVisualStyleBackColor = true;
            this.AddCourse_btn.Click += new System.EventHandler(this.AddCourse_btn_Click);
            // 
            // EditCourse_btn
            // 
            this.EditCourse_btn.Location = new System.Drawing.Point(196, 328);
            this.EditCourse_btn.Name = "EditCourse_btn";
            this.EditCourse_btn.Size = new System.Drawing.Size(75, 23);
            this.EditCourse_btn.TabIndex = 15;
            this.EditCourse_btn.Text = "Edit";
            this.EditCourse_btn.UseVisualStyleBackColor = true;
            this.EditCourse_btn.Click += new System.EventHandler(this.EditCourse_btn_Click);
            // 
            // RemoveCourse_btn
            // 
            this.RemoveCourse_btn.Location = new System.Drawing.Point(308, 328);
            this.RemoveCourse_btn.Name = "RemoveCourse_btn";
            this.RemoveCourse_btn.Size = new System.Drawing.Size(75, 23);
            this.RemoveCourse_btn.TabIndex = 16;
            this.RemoveCourse_btn.Text = "Remove";
            this.RemoveCourse_btn.UseVisualStyleBackColor = true;
            this.RemoveCourse_btn.Click += new System.EventHandler(this.RemoveCourse_btn_Click);
            // 
            // TotalCoursesNum_lb
            // 
            this.TotalCoursesNum_lb.AutoSize = true;
            this.TotalCoursesNum_lb.Location = new System.Drawing.Point(475, 333);
            this.TotalCoursesNum_lb.Name = "TotalCoursesNum_lb";
            this.TotalCoursesNum_lb.Size = new System.Drawing.Size(10, 13);
            this.TotalCoursesNum_lb.TabIndex = 18;
            this.TotalCoursesNum_lb.Text = ".";
            // 
            // Semester_textBox
            // 
            this.Semester_textBox.Location = new System.Drawing.Point(86, 105);
            this.Semester_textBox.Name = "Semester_textBox";
            this.Semester_textBox.Size = new System.Drawing.Size(126, 20);
            this.Semester_textBox.TabIndex = 20;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(26, 108);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(54, 13);
            this.label.TabIndex = 19;
            this.label.Text = "Semester:";
            // 
            // ManageCoursesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 450);
            this.Controls.Add(this.Semester_textBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.TotalCoursesNum_lb);
            this.Controls.Add(this.RemoveCourse_btn);
            this.Controls.Add(this.EditCourse_btn);
            this.Controls.Add(this.AddCourse_btn);
            this.Controls.Add(this.PreviousPos_btn);
            this.Controls.Add(this.NextPos_btn);
            this.Controls.Add(this.LastPos_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CourseDescription_richTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameCourse_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IDCourse_textBox);
            this.Controls.Add(this.HoursNum_numericUpDown);
            this.Controls.Add(this.CoursesDisplay_listBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FirstPos_btn);
            this.Name = "ManageCoursesForm";
            this.Text = "ManageCoursesForm";
            this.Load += new System.EventHandler(this.ManageCoursesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HoursNum_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FirstPos_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox CoursesDisplay_listBox;
        private System.Windows.Forms.NumericUpDown HoursNum_numericUpDown;
        private System.Windows.Forms.TextBox IDCourse_textBox;
        private System.Windows.Forms.TextBox NameCourse_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox CourseDescription_richTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LastPos_btn;
        private System.Windows.Forms.Button NextPos_btn;
        private System.Windows.Forms.Button PreviousPos_btn;
        private System.Windows.Forms.Button AddCourse_btn;
        private System.Windows.Forms.Button EditCourse_btn;
        private System.Windows.Forms.Button RemoveCourse_btn;
        private System.Windows.Forms.Label TotalCoursesNum_lb;
        private System.Windows.Forms.TextBox Semester_textBox;
        private System.Windows.Forms.Label label;
    }
}