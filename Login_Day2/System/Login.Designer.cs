namespace Login_Day2
{
    partial class LoginPage
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
            this.Login_button = new System.Windows.Forms.Button();
            this.UserName_textBox = new System.Windows.Forms.TextBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.NewUser_label = new System.Windows.Forms.Label();
            this.ShowPass_btn = new System.Windows.Forms.Button();
            this.ForgetPass_lb = new System.Windows.Forms.Label();
            this.login_progressBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Std_radioButton = new System.Windows.Forms.RadioButton();
            this.HumanResource_radioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName: ";
            // 
            // Login_button
            // 
            this.Login_button.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_button.Location = new System.Drawing.Point(215, 384);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(135, 32);
            this.Login_button.TabIndex = 2;
            this.Login_button.Text = "Login";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // UserName_textBox
            // 
            this.UserName_textBox.Location = new System.Drawing.Point(141, 275);
            this.UserName_textBox.Name = "UserName_textBox";
            this.UserName_textBox.Size = new System.Drawing.Size(163, 20);
            this.UserName_textBox.TabIndex = 3;
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(141, 312);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(163, 20);
            this.Password_textBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password: ";
            // 
            // Cancel_button
            // 
            this.Cancel_button.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_button.Location = new System.Drawing.Point(39, 384);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(135, 32);
            this.Cancel_button.TabIndex = 7;
            this.Cancel_button.Text = "Cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            // 
            // NewUser_label
            // 
            this.NewUser_label.AutoSize = true;
            this.NewUser_label.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewUser_label.Location = new System.Drawing.Point(309, 348);
            this.NewUser_label.Name = "NewUser_label";
            this.NewUser_label.Size = new System.Drawing.Size(59, 16);
            this.NewUser_label.TabIndex = 8;
            this.NewUser_label.Text = "NewUser?";
            this.NewUser_label.Click += new System.EventHandler(this.NewUser_label_Click);
            // 
            // ShowPass_btn
            // 
            this.ShowPass_btn.Location = new System.Drawing.Point(321, 315);
            this.ShowPass_btn.Name = "ShowPass_btn";
            this.ShowPass_btn.Size = new System.Drawing.Size(61, 23);
            this.ShowPass_btn.TabIndex = 9;
            this.ShowPass_btn.Text = "Show";
            this.ShowPass_btn.UseVisualStyleBackColor = true;
            this.ShowPass_btn.Click += new System.EventHandler(this.ShowPass_btn_Click);
            // 
            // ForgetPass_lb
            // 
            this.ForgetPass_lb.AutoSize = true;
            this.ForgetPass_lb.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgetPass_lb.Location = new System.Drawing.Point(309, 425);
            this.ForgetPass_lb.Name = "ForgetPass_lb";
            this.ForgetPass_lb.Size = new System.Drawing.Size(69, 16);
            this.ForgetPass_lb.TabIndex = 10;
            this.ForgetPass_lb.Text = "ForgetPass?";
            this.ForgetPass_lb.Click += new System.EventHandler(this.ForgetPass_lb_Click);
            // 
            // login_progressBar
            // 
            this.login_progressBar.Location = new System.Drawing.Point(90, 159);
            this.login_progressBar.Name = "login_progressBar";
            this.login_progressBar.Size = new System.Drawing.Size(214, 23);
            this.login_progressBar.TabIndex = 11;
            this.login_progressBar.Visible = false;
            this.login_progressBar.Click += new System.EventHandler(this.login_progressBar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Login_Day2.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(112, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Std_radioButton
            // 
            this.Std_radioButton.AutoSize = true;
            this.Std_radioButton.Location = new System.Drawing.Point(63, 224);
            this.Std_radioButton.Name = "Std_radioButton";
            this.Std_radioButton.Size = new System.Drawing.Size(62, 17);
            this.Std_radioButton.TabIndex = 12;
            this.Std_radioButton.TabStop = true;
            this.Std_radioButton.Text = "Student";
            this.Std_radioButton.UseVisualStyleBackColor = true;
            // 
            // HumanResource_radioButton
            // 
            this.HumanResource_radioButton.AutoSize = true;
            this.HumanResource_radioButton.Location = new System.Drawing.Point(187, 224);
            this.HumanResource_radioButton.Name = "HumanResource_radioButton";
            this.HumanResource_radioButton.Size = new System.Drawing.Size(108, 17);
            this.HumanResource_radioButton.TabIndex = 13;
            this.HumanResource_radioButton.TabStop = true;
            this.HumanResource_radioButton.Text = "Human Resource";
            this.HumanResource_radioButton.UseVisualStyleBackColor = true;
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 450);
            this.Controls.Add(this.HumanResource_radioButton);
            this.Controls.Add(this.Std_radioButton);
            this.Controls.Add(this.login_progressBar);
            this.Controls.Add(this.ForgetPass_lb);
            this.Controls.Add(this.ShowPass_btn);
            this.Controls.Add(this.NewUser_label);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UserName_textBox);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.label1);
            this.Name = "LoginPage";
            this.Text = "LoginPage_23110009_NguyenDucDuy";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Login_button;
        private System.Windows.Forms.TextBox UserName_textBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Label NewUser_label;
        private System.Windows.Forms.Button ShowPass_btn;
        private System.Windows.Forms.Label ForgetPass_lb;
        private System.Windows.Forms.ProgressBar login_progressBar;
        private System.Windows.Forms.RadioButton Std_radioButton;
        private System.Windows.Forms.RadioButton HumanResource_radioButton;
    }
}

