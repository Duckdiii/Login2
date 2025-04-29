namespace Login_Day2
{
    partial class EditUserDataForm
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
            this.Fname_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Lname_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Username_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.User_pictureBox = new System.Windows.Forms.PictureBox();
            this.Submit_btn = new System.Windows.Forms.Button();
            this.User_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.User_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID:";
            // 
            // Fname_textBox
            // 
            this.Fname_textBox.Location = new System.Drawing.Point(279, 39);
            this.Fname_textBox.Name = "Fname_textBox";
            this.Fname_textBox.Size = new System.Drawing.Size(137, 20);
            this.Fname_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "First name:";
            // 
            // Lname_textBox
            // 
            this.Lname_textBox.Location = new System.Drawing.Point(279, 79);
            this.Lname_textBox.Name = "Lname_textBox";
            this.Lname_textBox.Size = new System.Drawing.Size(137, 20);
            this.Lname_textBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 82);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last name:";
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(279, 164);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.Size = new System.Drawing.Size(137, 20);
            this.Password_textBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 167);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // Username_textBox
            // 
            this.Username_textBox.Location = new System.Drawing.Point(279, 124);
            this.Username_textBox.Name = "Username_textBox";
            this.Username_textBox.Size = new System.Drawing.Size(137, 20);
            this.Username_textBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Username:";
            // 
            // User_pictureBox
            // 
            this.User_pictureBox.Location = new System.Drawing.Point(12, 12);
            this.User_pictureBox.Name = "User_pictureBox";
            this.User_pictureBox.Size = new System.Drawing.Size(177, 159);
            this.User_pictureBox.TabIndex = 10;
            this.User_pictureBox.TabStop = false;
            // 
            // Submit_btn
            // 
            this.Submit_btn.Location = new System.Drawing.Point(434, 12);
            this.Submit_btn.Name = "Submit_btn";
            this.Submit_btn.Size = new System.Drawing.Size(59, 171);
            this.Submit_btn.TabIndex = 11;
            this.Submit_btn.Text = "Submit";
            this.Submit_btn.UseVisualStyleBackColor = true;
            this.Submit_btn.Click += new System.EventHandler(this.Submit_btn_Click);
            // 
            // User_comboBox
            // 
            this.User_comboBox.FormattingEnabled = true;
            this.User_comboBox.Location = new System.Drawing.Point(279, 9);
            this.User_comboBox.Name = "User_comboBox";
            this.User_comboBox.Size = new System.Drawing.Size(121, 21);
            this.User_comboBox.TabIndex = 12;
            this.User_comboBox.SelectedIndexChanged += new System.EventHandler(this.User_comboBox_SelectedIndexChanged);
            this.User_comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.User_comboBox_KeyPress);
            this.User_comboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.User_comboBox_KeyUp);
            // 
            // EditUserDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 209);
            this.Controls.Add(this.User_comboBox);
            this.Controls.Add(this.Submit_btn);
            this.Controls.Add(this.User_pictureBox);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Username_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Lname_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Fname_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditUserDataForm";
            this.Text = "EditUserDataForm";
            this.Load += new System.EventHandler(this.EditUserDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.User_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Fname_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Lname_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Username_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox User_pictureBox;
        private System.Windows.Forms.Button Submit_btn;
        private System.Windows.Forms.ComboBox User_comboBox;
    }
}