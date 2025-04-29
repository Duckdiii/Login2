namespace Login_Day2
{
    partial class AddCourse
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
            this.addCourse_btn = new System.Windows.Forms.Button();
            this.CourseID_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CourseName_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CoursePeriod_textBox = new System.Windows.Forms.TextBox();
            this.CourseDescription_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Semester_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // addCourse_btn
            // 
            this.addCourse_btn.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCourse_btn.Location = new System.Drawing.Point(36, 230);
            this.addCourse_btn.Name = "addCourse_btn";
            this.addCourse_btn.Size = new System.Drawing.Size(352, 59);
            this.addCourse_btn.TabIndex = 0;
            this.addCourse_btn.Text = "Add";
            this.addCourse_btn.UseVisualStyleBackColor = true;
            this.addCourse_btn.Click += new System.EventHandler(this.addCourse_btn_Click);
            // 
            // CourseID_textBox
            // 
            this.CourseID_textBox.Location = new System.Drawing.Point(112, 38);
            this.CourseID_textBox.Name = "CourseID_textBox";
            this.CourseID_textBox.Size = new System.Drawing.Size(164, 20);
            this.CourseID_textBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Course ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Label:";
            // 
            // CourseName_textBox
            // 
            this.CourseName_textBox.Location = new System.Drawing.Point(112, 64);
            this.CourseName_textBox.Name = "CourseName_textBox";
            this.CourseName_textBox.Size = new System.Drawing.Size(164, 20);
            this.CourseName_textBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Period:";
            // 
            // CoursePeriod_textBox
            // 
            this.CoursePeriod_textBox.Location = new System.Drawing.Point(112, 90);
            this.CoursePeriod_textBox.Name = "CoursePeriod_textBox";
            this.CoursePeriod_textBox.Size = new System.Drawing.Size(164, 20);
            this.CoursePeriod_textBox.TabIndex = 5;
            // 
            // CourseDescription_richTextBox
            // 
            this.CourseDescription_richTextBox.Location = new System.Drawing.Point(112, 128);
            this.CourseDescription_richTextBox.Name = "CourseDescription_richTextBox";
            this.CourseDescription_richTextBox.Size = new System.Drawing.Size(219, 96);
            this.CourseDescription_richTextBox.TabIndex = 7;
            this.CourseDescription_richTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Semester: ";
            // 
            // Semester_comboBox
            // 
            this.Semester_comboBox.FormattingEnabled = true;
            this.Semester_comboBox.Location = new System.Drawing.Point(361, 36);
            this.Semester_comboBox.Name = "Semester_comboBox";
            this.Semester_comboBox.Size = new System.Drawing.Size(65, 21);
            this.Semester_comboBox.TabIndex = 10;
            // 
            // AddCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 328);
            this.Controls.Add(this.Semester_comboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CourseDescription_richTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CoursePeriod_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CourseName_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CourseID_textBox);
            this.Controls.Add(this.addCourse_btn);
            this.Name = "AddCourse";
            this.Text = "AddCourse_23110009_NguyenDucDuy";
            this.Load += new System.EventHandler(this.AddCourse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addCourse_btn;
        private System.Windows.Forms.TextBox CourseID_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CourseName_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CoursePeriod_textBox;
        private System.Windows.Forms.RichTextBox CourseDescription_richTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Semester_comboBox;
    }
}