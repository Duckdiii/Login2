namespace Login_Day2
{
    partial class ResultForm
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
            this.Fname_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Lname_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Search_btn = new System.Windows.Forms.Button();
            this.Search_textBox = new System.Windows.Forms.TextBox();
            this.DisplayResult_dataGridView = new System.Windows.Forms.DataGridView();
            this.Print_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.SpecificSearch_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayResult_dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID:";
            // 
            // StudentID_textBox
            // 
            this.StudentID_textBox.Location = new System.Drawing.Point(74, 19);
            this.StudentID_textBox.Name = "StudentID_textBox";
            this.StudentID_textBox.Size = new System.Drawing.Size(120, 20);
            this.StudentID_textBox.TabIndex = 1;
            // 
            // Fname_textBox
            // 
            this.Fname_textBox.Location = new System.Drawing.Point(74, 45);
            this.Fname_textBox.Name = "Fname_textBox";
            this.Fname_textBox.Size = new System.Drawing.Size(120, 20);
            this.Fname_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Name:";
            // 
            // Lname_textBox
            // 
            this.Lname_textBox.Location = new System.Drawing.Point(74, 71);
            this.Lname_textBox.Name = "Lname_textBox";
            this.Lname_textBox.Size = new System.Drawing.Size(120, 20);
            this.Lname_textBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Name:";
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(210, 9);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(75, 85);
            this.Search_btn.TabIndex = 7;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Search_textBox
            // 
            this.Search_textBox.Location = new System.Drawing.Point(22, 23);
            this.Search_textBox.Name = "Search_textBox";
            this.Search_textBox.Size = new System.Drawing.Size(172, 20);
            this.Search_textBox.TabIndex = 8;
            // 
            // DisplayResult_dataGridView
            // 
            this.DisplayResult_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DisplayResult_dataGridView.Location = new System.Drawing.Point(315, 26);
            this.DisplayResult_dataGridView.Name = "DisplayResult_dataGridView";
            this.DisplayResult_dataGridView.Size = new System.Drawing.Size(900, 236);
            this.DisplayResult_dataGridView.TabIndex = 9;
            // 
            // Print_btn
            // 
            this.Print_btn.Location = new System.Drawing.Point(234, 239);
            this.Print_btn.Name = "Print_btn";
            this.Print_btn.Size = new System.Drawing.Size(75, 23);
            this.Print_btn.TabIndex = 10;
            this.Print_btn.Text = "Print";
            this.Print_btn.UseVisualStyleBackColor = true;
            this.Print_btn.Click += new System.EventHandler(this.Print_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(12, 245);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.Cancel_btn.TabIndex = 11;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // SpecificSearch_btn
            // 
            this.SpecificSearch_btn.Location = new System.Drawing.Point(210, 19);
            this.SpecificSearch_btn.Name = "SpecificSearch_btn";
            this.SpecificSearch_btn.Size = new System.Drawing.Size(75, 72);
            this.SpecificSearch_btn.TabIndex = 12;
            this.SpecificSearch_btn.Text = "Search";
            this.SpecificSearch_btn.UseVisualStyleBackColor = true;
            this.SpecificSearch_btn.Click += new System.EventHandler(this.SpecificSearch_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SpecificSearch_btn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.StudentID_textBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Fname_textBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Lname_textBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Specific Student";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Search_btn);
            this.groupBox2.Controls.Add(this.Search_textBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search by ID, FirstName";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 280);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Print_btn);
            this.Controls.Add(this.DisplayResult_dataGridView);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayResult_dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StudentID_textBox;
        private System.Windows.Forms.TextBox Fname_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Lname_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.TextBox Search_textBox;
        private System.Windows.Forms.DataGridView DisplayResult_dataGridView;
        private System.Windows.Forms.Button Print_btn;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Button SpecificSearch_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}