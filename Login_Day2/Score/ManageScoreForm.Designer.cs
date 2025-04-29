namespace Login_Day2
{
    partial class ManageScoreForm
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
            this.AddScore_btn = new System.Windows.Forms.Button();
            this.StudentID_comboBox = new System.Windows.Forms.ComboBox();
            this.Display_dataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Score_textBox = new System.Windows.Forms.TextBox();
            this.Description_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RemoveScore_btn = new System.Windows.Forms.Button();
            this.AverageScore_btn = new System.Windows.Forms.Button();
            this.ShowStudent_btn = new System.Windows.Forms.Button();
            this.ShowScore_btn = new System.Windows.Forms.Button();
            this.SelectCourse_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Display_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID:";
            // 
            // AddScore_btn
            // 
            this.AddScore_btn.Location = new System.Drawing.Point(15, 207);
            this.AddScore_btn.Name = "AddScore_btn";
            this.AddScore_btn.Size = new System.Drawing.Size(75, 23);
            this.AddScore_btn.TabIndex = 1;
            this.AddScore_btn.Text = "Add";
            this.AddScore_btn.UseVisualStyleBackColor = true;
            this.AddScore_btn.Click += new System.EventHandler(this.AddScore_btn_Click);
            // 
            // StudentID_comboBox
            // 
            this.StudentID_comboBox.FormattingEnabled = true;
            this.StudentID_comboBox.Location = new System.Drawing.Point(92, 25);
            this.StudentID_comboBox.Name = "StudentID_comboBox";
            this.StudentID_comboBox.Size = new System.Drawing.Size(149, 21);
            this.StudentID_comboBox.TabIndex = 3;
            this.StudentID_comboBox.SelectedIndexChanged += new System.EventHandler(this.StudentID_comboBox_SelectedIndexChanged);
            this.StudentID_comboBox.TextChanged += new System.EventHandler(this.StudentID_comboBox_TextChanged);
            // 
            // Display_dataGridView
            // 
            this.Display_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Display_dataGridView.Location = new System.Drawing.Point(287, 51);
            this.Display_dataGridView.Name = "Display_dataGridView";
            this.Display_dataGridView.Size = new System.Drawing.Size(490, 232);
            this.Display_dataGridView.TabIndex = 4;
            this.Display_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Display_dataGridView_CellClick);
            this.Display_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Display_dataGridView_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Course:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Score:";
            // 
            // Score_textBox
            // 
            this.Score_textBox.Location = new System.Drawing.Point(92, 78);
            this.Score_textBox.Name = "Score_textBox";
            this.Score_textBox.Size = new System.Drawing.Size(149, 20);
            this.Score_textBox.TabIndex = 6;
            this.Score_textBox.WordWrap = false;
            // 
            // Description_richTextBox
            // 
            this.Description_richTextBox.Location = new System.Drawing.Point(92, 105);
            this.Description_richTextBox.Name = "Description_richTextBox";
            this.Description_richTextBox.Size = new System.Drawing.Size(149, 96);
            this.Description_richTextBox.TabIndex = 8;
            this.Description_richTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Description:";
            // 
            // RemoveScore_btn
            // 
            this.RemoveScore_btn.Location = new System.Drawing.Point(156, 207);
            this.RemoveScore_btn.Name = "RemoveScore_btn";
            this.RemoveScore_btn.Size = new System.Drawing.Size(75, 23);
            this.RemoveScore_btn.TabIndex = 10;
            this.RemoveScore_btn.Text = "Remove";
            this.RemoveScore_btn.UseVisualStyleBackColor = true;
            this.RemoveScore_btn.Click += new System.EventHandler(this.RemoveScore_btn_Click);
            // 
            // AverageScore_btn
            // 
            this.AverageScore_btn.Location = new System.Drawing.Point(15, 236);
            this.AverageScore_btn.Name = "AverageScore_btn";
            this.AverageScore_btn.Size = new System.Drawing.Size(161, 23);
            this.AverageScore_btn.TabIndex = 11;
            this.AverageScore_btn.Text = "Average Score by Course";
            this.AverageScore_btn.UseVisualStyleBackColor = true;
            this.AverageScore_btn.Click += new System.EventHandler(this.AverageScore_btn_Click);
            // 
            // ShowStudent_btn
            // 
            this.ShowStudent_btn.Location = new System.Drawing.Point(287, 22);
            this.ShowStudent_btn.Name = "ShowStudent_btn";
            this.ShowStudent_btn.Size = new System.Drawing.Size(225, 23);
            this.ShowStudent_btn.TabIndex = 12;
            this.ShowStudent_btn.Text = "Show Student";
            this.ShowStudent_btn.UseVisualStyleBackColor = true;
            this.ShowStudent_btn.Click += new System.EventHandler(this.ShowStudent_btn_Click);
            // 
            // ShowScore_btn
            // 
            this.ShowScore_btn.Location = new System.Drawing.Point(545, 22);
            this.ShowScore_btn.Name = "ShowScore_btn";
            this.ShowScore_btn.Size = new System.Drawing.Size(232, 23);
            this.ShowScore_btn.TabIndex = 13;
            this.ShowScore_btn.Text = "Show Score";
            this.ShowScore_btn.UseVisualStyleBackColor = true;
            this.ShowScore_btn.Click += new System.EventHandler(this.ShowScore_btn_Click);
            // 
            // SelectCourse_comboBox
            // 
            this.SelectCourse_comboBox.FormattingEnabled = true;
            this.SelectCourse_comboBox.Location = new System.Drawing.Point(92, 51);
            this.SelectCourse_comboBox.Name = "SelectCourse_comboBox";
            this.SelectCourse_comboBox.Size = new System.Drawing.Size(149, 21);
            this.SelectCourse_comboBox.TabIndex = 14;
            // 
            // ManageScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 295);
            this.Controls.Add(this.SelectCourse_comboBox);
            this.Controls.Add(this.ShowScore_btn);
            this.Controls.Add(this.ShowStudent_btn);
            this.Controls.Add(this.AverageScore_btn);
            this.Controls.Add(this.RemoveScore_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Description_richTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Score_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Display_dataGridView);
            this.Controls.Add(this.StudentID_comboBox);
            this.Controls.Add(this.AddScore_btn);
            this.Controls.Add(this.label1);
            this.Name = "ManageScoreForm";
            this.Text = "ManageScoreForm";
            this.Load += new System.EventHandler(this.ManageScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Display_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddScore_btn;
        private System.Windows.Forms.ComboBox StudentID_comboBox;
        private System.Windows.Forms.DataGridView Display_dataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Score_textBox;
        private System.Windows.Forms.RichTextBox Description_richTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RemoveScore_btn;
        private System.Windows.Forms.Button AverageScore_btn;
        private System.Windows.Forms.Button ShowStudent_btn;
        private System.Windows.Forms.Button ShowScore_btn;
        private System.Windows.Forms.ComboBox SelectCourse_comboBox;
    }
}