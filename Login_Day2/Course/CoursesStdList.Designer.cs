namespace Login_Day2
{
    partial class CoursesStdList
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
            this.CourseName_textBox = new System.Windows.Forms.TextBox();
            this.DisplayCourseStd_dataGridView = new System.Windows.Forms.DataGridView();
            this.Semester_lb = new System.Windows.Forms.Label();
            this.Print_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayCourseStd_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course Name:";
            // 
            // CourseName_textBox
            // 
            this.CourseName_textBox.Location = new System.Drawing.Point(130, 27);
            this.CourseName_textBox.Name = "CourseName_textBox";
            this.CourseName_textBox.Size = new System.Drawing.Size(118, 20);
            this.CourseName_textBox.TabIndex = 1;
            // 
            // DisplayCourseStd_dataGridView
            // 
            this.DisplayCourseStd_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DisplayCourseStd_dataGridView.Location = new System.Drawing.Point(12, 65);
            this.DisplayCourseStd_dataGridView.Name = "DisplayCourseStd_dataGridView";
            this.DisplayCourseStd_dataGridView.Size = new System.Drawing.Size(408, 226);
            this.DisplayCourseStd_dataGridView.TabIndex = 2;
            this.DisplayCourseStd_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DisplayCourseStd_dataGridView_CellContentClick);
            // 
            // Semester_lb
            // 
            this.Semester_lb.AutoSize = true;
            this.Semester_lb.Location = new System.Drawing.Point(272, 30);
            this.Semester_lb.Name = "Semester_lb";
            this.Semester_lb.Size = new System.Drawing.Size(54, 13);
            this.Semester_lb.TabIndex = 3;
            this.Semester_lb.Text = "Semester:";
            // 
            // Print_btn
            // 
            this.Print_btn.Location = new System.Drawing.Point(146, 298);
            this.Print_btn.Name = "Print_btn";
            this.Print_btn.Size = new System.Drawing.Size(75, 23);
            this.Print_btn.TabIndex = 4;
            this.Print_btn.Text = "Print";
            this.Print_btn.UseVisualStyleBackColor = true;
            // 
            // CoursesStdList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 334);
            this.Controls.Add(this.Print_btn);
            this.Controls.Add(this.Semester_lb);
            this.Controls.Add(this.DisplayCourseStd_dataGridView);
            this.Controls.Add(this.CourseName_textBox);
            this.Controls.Add(this.label1);
            this.Name = "CoursesStdList";
            this.Text = "CoursesStdList";
            this.Load += new System.EventHandler(this.CoursesStdList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayCourseStd_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CourseName_textBox;
        private System.Windows.Forms.DataGridView DisplayCourseStd_dataGridView;
        private System.Windows.Forms.Label Semester_lb;
        private System.Windows.Forms.Button Print_btn;
    }
}