namespace Login_Day2
{
    partial class EditCourseForm
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
            this.SelectCourse_comboBox = new System.Windows.Forms.ComboBox();
            this.CourseName_textBox = new System.Windows.Forms.TextBox();
            this.CourseDescription_richTextBox = new System.Windows.Forms.RichTextBox();
            this.Edit_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CoursePeriod_numericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.CoursePeriod_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectCourse_comboBox
            // 
            this.SelectCourse_comboBox.FormattingEnabled = true;
            this.SelectCourse_comboBox.Location = new System.Drawing.Point(117, 26);
            this.SelectCourse_comboBox.Name = "SelectCourse_comboBox";
            this.SelectCourse_comboBox.Size = new System.Drawing.Size(152, 21);
            this.SelectCourse_comboBox.TabIndex = 0;
            this.SelectCourse_comboBox.SelectedIndexChanged += new System.EventHandler(this.SelectCourse_comboBox_SelectedIndexChanged);
            // 
            // CourseName_textBox
            // 
            this.CourseName_textBox.Location = new System.Drawing.Point(117, 62);
            this.CourseName_textBox.Name = "CourseName_textBox";
            this.CourseName_textBox.Size = new System.Drawing.Size(152, 20);
            this.CourseName_textBox.TabIndex = 1;
            // 
            // CourseDescription_richTextBox
            // 
            this.CourseDescription_richTextBox.Location = new System.Drawing.Point(117, 134);
            this.CourseDescription_richTextBox.Name = "CourseDescription_richTextBox";
            this.CourseDescription_richTextBox.Size = new System.Drawing.Size(207, 96);
            this.CourseDescription_richTextBox.TabIndex = 3;
            this.CourseDescription_richTextBox.Text = "";
            // 
            // Edit_btn
            // 
            this.Edit_btn.Location = new System.Drawing.Point(162, 233);
            this.Edit_btn.Name = "Edit_btn";
            this.Edit_btn.Size = new System.Drawing.Size(75, 23);
            this.Edit_btn.TabIndex = 4;
            this.Edit_btn.Text = "Edit";
            this.Edit_btn.UseVisualStyleBackColor = true;
            this.Edit_btn.Click += new System.EventHandler(this.Edit_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Course:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Label:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Period:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Description:";
            // 
            // CoursePeriod_numericUpDown
            // 
            this.CoursePeriod_numericUpDown.Location = new System.Drawing.Point(117, 97);
            this.CoursePeriod_numericUpDown.Name = "CoursePeriod_numericUpDown";
            this.CoursePeriod_numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.CoursePeriod_numericUpDown.TabIndex = 10;
            // 
            // EditCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 268);
            this.Controls.Add(this.CoursePeriod_numericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Edit_btn);
            this.Controls.Add(this.CourseDescription_richTextBox);
            this.Controls.Add(this.CourseName_textBox);
            this.Controls.Add(this.SelectCourse_comboBox);
            this.Name = "EditCourseForm";
            this.Text = "EditCourseForm_23110009_NguyenDucDuy";
            this.Load += new System.EventHandler(this.EditCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoursePeriod_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectCourse_comboBox;
        private System.Windows.Forms.TextBox CourseName_textBox;
        private System.Windows.Forms.RichTextBox CourseDescription_richTextBox;
        private System.Windows.Forms.Button Edit_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown CoursePeriod_numericUpDown;
    }
}