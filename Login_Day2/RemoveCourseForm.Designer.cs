namespace Login_Day2
{
    partial class RemoveCourseForm
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
            this.CourseID_textBox = new System.Windows.Forms.TextBox();
            this.removeCourse_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course ID:";
            // 
            // CourseID_textBox
            // 
            this.CourseID_textBox.Location = new System.Drawing.Point(120, 47);
            this.CourseID_textBox.Name = "CourseID_textBox";
            this.CourseID_textBox.Size = new System.Drawing.Size(152, 20);
            this.CourseID_textBox.TabIndex = 2;
            // 
            // removeCourse_btn
            // 
            this.removeCourse_btn.Location = new System.Drawing.Point(303, 47);
            this.removeCourse_btn.Name = "removeCourse_btn";
            this.removeCourse_btn.Size = new System.Drawing.Size(108, 23);
            this.removeCourse_btn.TabIndex = 3;
            this.removeCourse_btn.Text = "Remove Course";
            this.removeCourse_btn.UseVisualStyleBackColor = true;
            // 
            // RemoveCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 159);
            this.Controls.Add(this.removeCourse_btn);
            this.Controls.Add(this.CourseID_textBox);
            this.Controls.Add(this.label1);
            this.Name = "RemoveCourseForm";
            this.Text = "RemoveCourseForm_23110009_NguyenDucDuy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CourseID_textBox;
        private System.Windows.Forms.Button removeCourse_btn;
    }
}