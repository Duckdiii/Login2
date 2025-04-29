namespace Login_Day2
{
    partial class AddStudentForm
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
            this.Male_radioButton = new System.Windows.Forms.RadioButton();
            this.FirstName_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LastName_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BirthDate_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.Female_radioButton = new System.Windows.Forms.RadioButton();
            this.Phone_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Address_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.UploadImage_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.AddStudent_btn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Import_btn = new System.Windows.Forms.Button();
            this.btnNextStd_btn = new System.Windows.Forms.Button();
            this.StudentPicture_pictureBox = new System.Windows.Forms.PictureBox();
            this.StudentID_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.StudentPicture_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID:";
            // 
            // Male_radioButton
            // 
            this.Male_radioButton.AutoSize = true;
            this.Male_radioButton.Location = new System.Drawing.Point(83, 163);
            this.Male_radioButton.Name = "Male_radioButton";
            this.Male_radioButton.Size = new System.Drawing.Size(48, 17);
            this.Male_radioButton.TabIndex = 2;
            this.Male_radioButton.TabStop = true;
            this.Male_radioButton.Text = "Male";
            this.Male_radioButton.UseVisualStyleBackColor = true;
            // 
            // FirstName_textBox
            // 
            this.FirstName_textBox.Location = new System.Drawing.Point(98, 71);
            this.FirstName_textBox.Name = "FirstName_textBox";
            this.FirstName_textBox.Size = new System.Drawing.Size(175, 20);
            this.FirstName_textBox.TabIndex = 5;
            this.FirstName_textBox.TextChanged += new System.EventHandler(this.FirstName_textBox_TextChanged);
            this.FirstName_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FirstName_textBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "First name:";
            // 
            // LastName_textBox
            // 
            this.LastName_textBox.Location = new System.Drawing.Point(98, 97);
            this.LastName_textBox.Name = "LastName_textBox";
            this.LastName_textBox.Size = new System.Drawing.Size(175, 20);
            this.LastName_textBox.TabIndex = 7;
            this.LastName_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LastName_textBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last name:";
            // 
            // BirthDate_dateTimePicker
            // 
            this.BirthDate_dateTimePicker.Location = new System.Drawing.Point(83, 123);
            this.BirthDate_dateTimePicker.Name = "BirthDate_dateTimePicker";
            this.BirthDate_dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.BirthDate_dateTimePicker.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "BirthDate:";
            // 
            // Female_radioButton
            // 
            this.Female_radioButton.AutoSize = true;
            this.Female_radioButton.Location = new System.Drawing.Point(188, 163);
            this.Female_radioButton.Name = "Female_radioButton";
            this.Female_radioButton.Size = new System.Drawing.Size(59, 17);
            this.Female_radioButton.TabIndex = 10;
            this.Female_radioButton.TabStop = true;
            this.Female_radioButton.Text = "Female";
            this.Female_radioButton.UseVisualStyleBackColor = true;
            // 
            // Phone_textBox
            // 
            this.Phone_textBox.Location = new System.Drawing.Point(98, 186);
            this.Phone_textBox.Name = "Phone_textBox";
            this.Phone_textBox.Size = new System.Drawing.Size(175, 20);
            this.Phone_textBox.TabIndex = 12;
            this.Phone_textBox.TextChanged += new System.EventHandler(this.Phone_textBox_TextChanged);
            this.Phone_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Phone_textBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Phone:";
            // 
            // Address_richTextBox
            // 
            this.Address_richTextBox.Location = new System.Drawing.Point(98, 212);
            this.Address_richTextBox.Name = "Address_richTextBox";
            this.Address_richTextBox.Size = new System.Drawing.Size(175, 59);
            this.Address_richTextBox.TabIndex = 13;
            this.Address_richTextBox.Text = "";
            this.Address_richTextBox.TextChanged += new System.EventHandler(this.Address_richTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Address: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Picture:";
            // 
            // UploadImage_btn
            // 
            this.UploadImage_btn.Location = new System.Drawing.Point(98, 385);
            this.UploadImage_btn.Name = "UploadImage_btn";
            this.UploadImage_btn.Size = new System.Drawing.Size(175, 23);
            this.UploadImage_btn.TabIndex = 17;
            this.UploadImage_btn.Text = "Upload Image";
            this.UploadImage_btn.UseVisualStyleBackColor = true;
            this.UploadImage_btn.Click += new System.EventHandler(this.UploadImage_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(15, 468);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(122, 61);
            this.Cancel_btn.TabIndex = 18;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            // 
            // AddStudent_btn
            // 
            this.AddStudent_btn.Location = new System.Drawing.Point(161, 468);
            this.AddStudent_btn.Name = "AddStudent_btn";
            this.AddStudent_btn.Size = new System.Drawing.Size(122, 61);
            this.AddStudent_btn.TabIndex = 19;
            this.AddStudent_btn.Text = "Add";
            this.AddStudent_btn.UseVisualStyleBackColor = true;
            this.AddStudent_btn.Click += new System.EventHandler(this.AddStudent_btn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Gender:";
            // 
            // Import_btn
            // 
            this.Import_btn.Location = new System.Drawing.Point(98, 414);
            this.Import_btn.Name = "Import_btn";
            this.Import_btn.Size = new System.Drawing.Size(75, 23);
            this.Import_btn.TabIndex = 21;
            this.Import_btn.Text = "Import";
            this.Import_btn.UseVisualStyleBackColor = true;
            this.Import_btn.Click += new System.EventHandler(this.Import_btn_Click);
            // 
            // btnNextStd_btn
            // 
            this.btnNextStd_btn.Location = new System.Drawing.Point(198, 414);
            this.btnNextStd_btn.Name = "btnNextStd_btn";
            this.btnNextStd_btn.Size = new System.Drawing.Size(75, 23);
            this.btnNextStd_btn.TabIndex = 22;
            this.btnNextStd_btn.Text = "Next";
            this.btnNextStd_btn.UseVisualStyleBackColor = true;
            this.btnNextStd_btn.Click += new System.EventHandler(this.btnNextStd_btn_Click);
            // 
            // StudentPicture_pictureBox
            // 
            this.StudentPicture_pictureBox.Location = new System.Drawing.Point(98, 280);
            this.StudentPicture_pictureBox.Name = "StudentPicture_pictureBox";
            this.StudentPicture_pictureBox.Size = new System.Drawing.Size(175, 99);
            this.StudentPicture_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StudentPicture_pictureBox.TabIndex = 16;
            this.StudentPicture_pictureBox.TabStop = false;
            // 
            // StudentID_comboBox
            // 
            this.StudentID_comboBox.FormattingEnabled = true;
            this.StudentID_comboBox.Location = new System.Drawing.Point(98, 45);
            this.StudentID_comboBox.Name = "StudentID_comboBox";
            this.StudentID_comboBox.Size = new System.Drawing.Size(121, 21);
            this.StudentID_comboBox.TabIndex = 23;
            this.StudentID_comboBox.SelectedIndexChanged += new System.EventHandler(this.StudentID_comboBox_SelectedIndexChanged);
            this.StudentID_comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StudentID_comboBox_KeyPress);
            this.StudentID_comboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StudentID_comboBox_KeyUp);
            // 
            // AddStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 541);
            this.Controls.Add(this.StudentID_comboBox);
            this.Controls.Add(this.btnNextStd_btn);
            this.Controls.Add(this.Import_btn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AddStudent_btn);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.UploadImage_btn);
            this.Controls.Add(this.StudentPicture_pictureBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Address_richTextBox);
            this.Controls.Add(this.Phone_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Female_radioButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BirthDate_dateTimePicker);
            this.Controls.Add(this.LastName_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FirstName_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Male_radioButton);
            this.Controls.Add(this.label1);
            this.Name = "AddStudentForm";
            this.Text = "AddStudentForm_23110009_NguyenDucDuy";
            this.Load += new System.EventHandler(this.AddStudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentPicture_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Male_radioButton;
        private System.Windows.Forms.TextBox FirstName_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LastName_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker BirthDate_dateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton Female_radioButton;
        private System.Windows.Forms.TextBox Phone_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox Address_richTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox StudentPicture_pictureBox;
        private System.Windows.Forms.Button UploadImage_btn;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Button AddStudent_btn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Import_btn;
        private System.Windows.Forms.Button btnNextStd_btn;
        private System.Windows.Forms.ComboBox StudentID_comboBox;
    }
}