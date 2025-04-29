namespace Login_Day2
{
    partial class RemoveScoreForm
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
            this.StudentScoreInfo_dataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.RemoveScore_btn = new System.Windows.Forms.Button();
            this.SelectCourse_comboBox = new System.Windows.Forms.ComboBox();
            this.StudentID_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StudentScoreInfo_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentScoreInfo_dataGridView
            // 
            this.StudentScoreInfo_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentScoreInfo_dataGridView.Location = new System.Drawing.Point(265, 22);
            this.StudentScoreInfo_dataGridView.Name = "StudentScoreInfo_dataGridView";
            this.StudentScoreInfo_dataGridView.Size = new System.Drawing.Size(538, 278);
            this.StudentScoreInfo_dataGridView.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Select course:";
            // 
            // RemoveScore_btn
            // 
            this.RemoveScore_btn.Location = new System.Drawing.Point(93, 160);
            this.RemoveScore_btn.Name = "RemoveScore_btn";
            this.RemoveScore_btn.Size = new System.Drawing.Size(75, 23);
            this.RemoveScore_btn.TabIndex = 14;
            this.RemoveScore_btn.Text = "Remove Score";
            this.RemoveScore_btn.UseVisualStyleBackColor = true;
            this.RemoveScore_btn.Click += new System.EventHandler(this.RemoveScore_btn_Click);
            // 
            // SelectCourse_comboBox
            // 
            this.SelectCourse_comboBox.FormattingEnabled = true;
            this.SelectCourse_comboBox.Location = new System.Drawing.Point(84, 56);
            this.SelectCourse_comboBox.Name = "SelectCourse_comboBox";
            this.SelectCourse_comboBox.Size = new System.Drawing.Size(153, 21);
            this.SelectCourse_comboBox.TabIndex = 13;
            this.SelectCourse_comboBox.SelectedIndexChanged += new System.EventHandler(this.SelectCourse_comboBox_SelectedIndexChanged);
            // 
            // StudentID_textBox
            // 
            this.StudentID_textBox.Location = new System.Drawing.Point(84, 22);
            this.StudentID_textBox.Name = "StudentID_textBox";
            this.StudentID_textBox.Size = new System.Drawing.Size(130, 20);
            this.StudentID_textBox.TabIndex = 12;
            this.StudentID_textBox.TextChanged += new System.EventHandler(this.StudentID_textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Student ID:";
            // 
            // RemoveScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 323);
            this.Controls.Add(this.StudentScoreInfo_dataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RemoveScore_btn);
            this.Controls.Add(this.SelectCourse_comboBox);
            this.Controls.Add(this.StudentID_textBox);
            this.Controls.Add(this.label1);
            this.Name = "RemoveScoreForm";
            this.Text = "RemoveScoreForm";
            this.Load += new System.EventHandler(this.RemoveScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentScoreInfo_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StudentScoreInfo_dataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RemoveScore_btn;
        private System.Windows.Forms.ComboBox SelectCourse_comboBox;
        private System.Windows.Forms.TextBox StudentID_textBox;
        private System.Windows.Forms.Label label1;
    }
}