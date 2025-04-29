namespace Login_Day2
{
    partial class NewUserForm
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
            this.Username_textBox = new System.Windows.Forms.TextBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckPassword_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Submit_btn = new System.Windows.Forms.Button();
            this.ShowPass_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.email_textBox = new System.Windows.Forms.TextBox();
            this.Code_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SendCode_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.labelNotice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // Username_textBox
            // 
            this.Username_textBox.Location = new System.Drawing.Point(143, 176);
            this.Username_textBox.Name = "Username_textBox";
            this.Username_textBox.Size = new System.Drawing.Size(146, 20);
            this.Username_textBox.TabIndex = 1;
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(141, 212);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(148, 20);
            this.Password_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // CheckPassword_textBox
            // 
            this.CheckPassword_textBox.Location = new System.Drawing.Point(141, 249);
            this.CheckPassword_textBox.Name = "CheckPassword_textBox";
            this.CheckPassword_textBox.PasswordChar = '*';
            this.CheckPassword_textBox.Size = new System.Drawing.Size(148, 20);
            this.CheckPassword_textBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // Submit_btn
            // 
            this.Submit_btn.Location = new System.Drawing.Point(172, 298);
            this.Submit_btn.Name = "Submit_btn";
            this.Submit_btn.Size = new System.Drawing.Size(75, 23);
            this.Submit_btn.TabIndex = 6;
            this.Submit_btn.Text = "Submit";
            this.Submit_btn.UseVisualStyleBackColor = true;
            this.Submit_btn.Click += new System.EventHandler(this.Submit_btn_Click);
            // 
            // ShowPass_btn
            // 
            this.ShowPass_btn.Location = new System.Drawing.Point(315, 252);
            this.ShowPass_btn.Name = "ShowPass_btn";
            this.ShowPass_btn.Size = new System.Drawing.Size(61, 23);
            this.ShowPass_btn.TabIndex = 10;
            this.ShowPass_btn.Text = "Show";
            this.ShowPass_btn.UseVisualStyleBackColor = true;
            this.ShowPass_btn.Click += new System.EventHandler(this.ShowPass_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Email:";
            // 
            // email_textBox
            // 
            this.email_textBox.Location = new System.Drawing.Point(101, 51);
            this.email_textBox.Name = "email_textBox";
            this.email_textBox.Size = new System.Drawing.Size(255, 20);
            this.email_textBox.TabIndex = 12;
            // 
            // Code_textBox
            // 
            this.Code_textBox.Location = new System.Drawing.Point(101, 95);
            this.Code_textBox.Name = "Code_textBox";
            this.Code_textBox.Size = new System.Drawing.Size(255, 20);
            this.Code_textBox.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Code:";
            // 
            // SendCode_btn
            // 
            this.SendCode_btn.Location = new System.Drawing.Point(342, 135);
            this.SendCode_btn.Name = "SendCode_btn";
            this.SendCode_btn.Size = new System.Drawing.Size(75, 23);
            this.SendCode_btn.TabIndex = 15;
            this.SendCode_btn.Text = "Send Code";
            this.SendCode_btn.UseVisualStyleBackColor = true;
            this.SendCode_btn.Click += new System.EventHandler(this.SendCode_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(12, 361);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.Cancel_btn.TabIndex = 16;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // labelNotice
            // 
            this.labelNotice.AutoSize = true;
            this.labelNotice.Location = new System.Drawing.Point(79, 74);
            this.labelNotice.Name = "labelNotice";
            this.labelNotice.Size = new System.Drawing.Size(33, 13);
            this.labelNotice.TabIndex = 17;
            this.labelNotice.Text = "Timer";
            // 
            // NewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 396);
            this.Controls.Add(this.labelNotice);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.SendCode_btn);
            this.Controls.Add(this.Code_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.email_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ShowPass_btn);
            this.Controls.Add(this.Submit_btn);
            this.Controls.Add(this.CheckPassword_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Username_textBox);
            this.Controls.Add(this.label1);
            this.Name = "NewUserForm";
            this.Text = "NewUserForm_23110009_NguyenDucDuy";
            this.Load += new System.EventHandler(this.NewUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Username_textBox;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CheckPassword_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Submit_btn;
        private System.Windows.Forms.Button ShowPass_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox email_textBox;
        private System.Windows.Forms.TextBox Code_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SendCode_btn;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Label labelNotice;
    }
}