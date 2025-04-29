namespace Login_Day2
{
    partial class AddScoreForm
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
            this.SelectCourse_comboBox = new System.Windows.Forms.ComboBox();
            this.AddScore_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.StudentScore_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Description_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StudentScoreInfo_dataGridView = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentFname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentLname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.StudentScoreInfo_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID:";
            // 
            // SelectCourse_comboBox
            // 
            this.SelectCourse_comboBox.FormattingEnabled = true;
            this.SelectCourse_comboBox.Location = new System.Drawing.Point(110, 53);
            this.SelectCourse_comboBox.Name = "SelectCourse_comboBox";
            this.SelectCourse_comboBox.Size = new System.Drawing.Size(153, 21);
            this.SelectCourse_comboBox.TabIndex = 2;
            this.SelectCourse_comboBox.SelectedIndexChanged += new System.EventHandler(this.SelectCourse_comboBox_SelectedIndexChanged);
            // 
            // AddScore_btn
            // 
            this.AddScore_btn.Location = new System.Drawing.Point(110, 274);
            this.AddScore_btn.Name = "AddScore_btn";
            this.AddScore_btn.Size = new System.Drawing.Size(75, 23);
            this.AddScore_btn.TabIndex = 3;
            this.AddScore_btn.Text = "Add Score";
            this.AddScore_btn.UseVisualStyleBackColor = true;
            this.AddScore_btn.Click += new System.EventHandler(this.AddScore_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select course:";
            // 
            // StudentScore_textBox
            // 
            this.StudentScore_textBox.Location = new System.Drawing.Point(110, 89);
            this.StudentScore_textBox.Name = "StudentScore_textBox";
            this.StudentScore_textBox.Size = new System.Drawing.Size(130, 20);
            this.StudentScore_textBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Score:";
            // 
            // Description_richTextBox
            // 
            this.Description_richTextBox.Location = new System.Drawing.Point(110, 129);
            this.Description_richTextBox.Name = "Description_richTextBox";
            this.Description_richTextBox.Size = new System.Drawing.Size(153, 139);
            this.Description_richTextBox.TabIndex = 8;
            this.Description_richTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Description:";
            // 
            // StudentScoreInfo_dataGridView
            // 
            this.StudentScoreInfo_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentScoreInfo_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.StudentFname,
            this.StudentLname,
            this.Subject,
            this.StudentScore});
            this.StudentScoreInfo_dataGridView.Location = new System.Drawing.Point(291, 19);
            this.StudentScoreInfo_dataGridView.Name = "StudentScoreInfo_dataGridView";
            this.StudentScoreInfo_dataGridView.Size = new System.Drawing.Size(659, 278);
            this.StudentScoreInfo_dataGridView.TabIndex = 10;
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "Student Id";
            this.StudentID.Name = "StudentID";
            // 
            // StudentFname
            // 
            this.StudentFname.HeaderText = "First Name";
            this.StudentFname.Name = "StudentFname";
            // 
            // StudentLname
            // 
            this.StudentLname.HeaderText = "LastName";
            this.StudentLname.Name = "StudentLname";
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.Width = 200;
            // 
            // StudentScore
            // 
            this.StudentScore.HeaderText = "Score";
            this.StudentScore.Name = "StudentScore";
            // 
            // StudentID_comboBox
            // 
            this.StudentID_comboBox.FormattingEnabled = true;
            this.StudentID_comboBox.Location = new System.Drawing.Point(110, 19);
            this.StudentID_comboBox.Name = "StudentID_comboBox";
            this.StudentID_comboBox.Size = new System.Drawing.Size(119, 21);
            this.StudentID_comboBox.TabIndex = 11;
            this.StudentID_comboBox.SelectedIndexChanged += new System.EventHandler(this.StudentID_comboBox_SelectedIndexChanged);
            this.StudentID_comboBox.TextChanged += new System.EventHandler(this.StudentID_comboBox_TextChanged);
            this.StudentID_comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StudentID_comboBox_KeyPress);
            // 
            // AddScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 309);
            this.Controls.Add(this.StudentID_comboBox);
            this.Controls.Add(this.StudentScoreInfo_dataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Description_richTextBox);
            this.Controls.Add(this.StudentScore_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddScore_btn);
            this.Controls.Add(this.SelectCourse_comboBox);
            this.Controls.Add(this.label1);
            this.Name = "AddScoreForm";
            this.Text = "AddScoreForm";
            this.Load += new System.EventHandler(this.AddScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentScoreInfo_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SelectCourse_comboBox;
        private System.Windows.Forms.Button AddScore_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StudentScore_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox Description_richTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView StudentScoreInfo_dataGridView;
        private System.Windows.Forms.ComboBox StudentID_comboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentFname;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentLname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentScore;
    }
}