namespace Login_Day2
{
    partial class ForgetPassword
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
            this.email_textBox = new System.Windows.Forms.TextBox();
            this.SendCode_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.codelabel = new System.Windows.Forms.Label();
            this.Code_textbox = new System.Windows.Forms.TextBox();
            this.Verify_btn = new System.Windows.Forms.Button();
            this.Back_lb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forget Password";
            // 
            // email_textBox
            // 
            this.email_textBox.Location = new System.Drawing.Point(127, 97);
            this.email_textBox.Name = "email_textBox";
            this.email_textBox.Size = new System.Drawing.Size(178, 20);
            this.email_textBox.TabIndex = 1;
            // 
            // SendCode_btn
            // 
            this.SendCode_btn.Location = new System.Drawing.Point(345, 97);
            this.SendCode_btn.Name = "SendCode_btn";
            this.SendCode_btn.Size = new System.Drawing.Size(75, 23);
            this.SendCode_btn.TabIndex = 2;
            this.SendCode_btn.Text = "Send Code";
            this.SendCode_btn.UseVisualStyleBackColor = true;
            this.SendCode_btn.Click += new System.EventHandler(this.SendCode_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email:";
            // 
            // codelabel
            // 
            this.codelabel.AutoSize = true;
            this.codelabel.Location = new System.Drawing.Point(86, 142);
            this.codelabel.Name = "codelabel";
            this.codelabel.Size = new System.Drawing.Size(35, 13);
            this.codelabel.TabIndex = 5;
            this.codelabel.Text = "Code:";
            // 
            // Code_textbox
            // 
            this.Code_textbox.Location = new System.Drawing.Point(127, 139);
            this.Code_textbox.Name = "Code_textbox";
            this.Code_textbox.Size = new System.Drawing.Size(178, 20);
            this.Code_textbox.TabIndex = 4;
            // 
            // Verify_btn
            // 
            this.Verify_btn.Location = new System.Drawing.Point(182, 189);
            this.Verify_btn.Name = "Verify_btn";
            this.Verify_btn.Size = new System.Drawing.Size(75, 23);
            this.Verify_btn.TabIndex = 6;
            this.Verify_btn.Text = "Verify code";
            this.Verify_btn.UseVisualStyleBackColor = true;
            this.Verify_btn.Click += new System.EventHandler(this.Verify_btn_Click);
            // 
            // Back_lb
            // 
            this.Back_lb.AutoSize = true;
            this.Back_lb.Location = new System.Drawing.Point(12, 9);
            this.Back_lb.Name = "Back_lb";
            this.Back_lb.Size = new System.Drawing.Size(32, 13);
            this.Back_lb.TabIndex = 7;
            this.Back_lb.Text = "Back";
            this.Back_lb.Click += new System.EventHandler(this.Back_lb_Click);
            // 
            // ForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 262);
            this.Controls.Add(this.Back_lb);
            this.Controls.Add(this.Verify_btn);
            this.Controls.Add(this.codelabel);
            this.Controls.Add(this.Code_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SendCode_btn);
            this.Controls.Add(this.email_textBox);
            this.Controls.Add(this.label1);
            this.Name = "ForgetPassword";
            this.Text = "ForgetPassword";
            this.Load += new System.EventHandler(this.ForgetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox email_textBox;
        private System.Windows.Forms.Button SendCode_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label codelabel;
        private System.Windows.Forms.TextBox Code_textbox;
        private System.Windows.Forms.Button Verify_btn;
        private System.Windows.Forms.Label Back_lb;
    }
}