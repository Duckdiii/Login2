namespace Login_Day2
{
    partial class UserForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.AddContact_btn = new System.Windows.Forms.Button();
            this.EditContact_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Remove_btn = new System.Windows.Forms.Button();
            this.SelectContact_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectContactID_textBox = new System.Windows.Forms.TextBox();
            this.ShowFullList_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AddGroupName_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.GroupName_textBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.SelectEditGroup_comboBox = new System.Windows.Forms.ComboBox();
            this.EditGroupName_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.NewGroupName_textBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.SelectDelGroupName_comboBox = new System.Windows.Forms.ComboBox();
            this.RemoveGroup_btn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.User_pictureBox = new System.Windows.Forms.PictureBox();
            this.Refresh_btn = new System.Windows.Forms.Label();
            this.EditInfo_btn = new System.Windows.Forms.Label();
            this.UserName_lb = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.User_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(336, 115);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(13, 335);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contact";
            // 
            // AddContact_btn
            // 
            this.AddContact_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AddContact_btn.Location = new System.Drawing.Point(37, 135);
            this.AddContact_btn.Name = "AddContact_btn";
            this.AddContact_btn.Size = new System.Drawing.Size(75, 23);
            this.AddContact_btn.TabIndex = 2;
            this.AddContact_btn.Text = "Add";
            this.AddContact_btn.UseVisualStyleBackColor = false;
            this.AddContact_btn.Click += new System.EventHandler(this.AddContact_btn_Click);
            // 
            // EditContact_btn
            // 
            this.EditContact_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EditContact_btn.Location = new System.Drawing.Point(37, 194);
            this.EditContact_btn.Name = "EditContact_btn";
            this.EditContact_btn.Size = new System.Drawing.Size(75, 23);
            this.EditContact_btn.TabIndex = 3;
            this.EditContact_btn.Text = "Edit";
            this.EditContact_btn.UseVisualStyleBackColor = false;
            this.EditContact_btn.Click += new System.EventHandler(this.EditContact_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.Remove_btn);
            this.panel1.Controls.Add(this.SelectContact_btn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.SelectContactID_textBox);
            this.panel1.Location = new System.Drawing.Point(13, 241);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 100);
            this.panel1.TabIndex = 4;
            // 
            // Remove_btn
            // 
            this.Remove_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Remove_btn.Location = new System.Drawing.Point(15, 50);
            this.Remove_btn.Name = "Remove_btn";
            this.Remove_btn.Size = new System.Drawing.Size(289, 37);
            this.Remove_btn.TabIndex = 3;
            this.Remove_btn.Text = "Remove";
            this.Remove_btn.UseVisualStyleBackColor = false;
            this.Remove_btn.Click += new System.EventHandler(this.Remove_btn_Click);
            // 
            // SelectContact_btn
            // 
            this.SelectContact_btn.BackColor = System.Drawing.SystemColors.Control;
            this.SelectContact_btn.Location = new System.Drawing.Point(215, 1);
            this.SelectContact_btn.Name = "SelectContact_btn";
            this.SelectContact_btn.Size = new System.Drawing.Size(75, 37);
            this.SelectContact_btn.TabIndex = 2;
            this.SelectContact_btn.Text = "Select Contact";
            this.SelectContact_btn.UseVisualStyleBackColor = false;
            this.SelectContact_btn.Click += new System.EventHandler(this.SelectContact_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Contact ID:";
            // 
            // SelectContactID_textBox
            // 
            this.SelectContactID_textBox.Location = new System.Drawing.Point(109, 3);
            this.SelectContactID_textBox.Name = "SelectContactID_textBox";
            this.SelectContactID_textBox.Size = new System.Drawing.Size(100, 20);
            this.SelectContactID_textBox.TabIndex = 0;
            // 
            // ShowFullList_btn
            // 
            this.ShowFullList_btn.BackColor = System.Drawing.SystemColors.Control;
            this.ShowFullList_btn.Location = new System.Drawing.Point(28, 364);
            this.ShowFullList_btn.Name = "ShowFullList_btn";
            this.ShowFullList_btn.Size = new System.Drawing.Size(289, 37);
            this.ShowFullList_btn.TabIndex = 4;
            this.ShowFullList_btn.Text = "Show Full List";
            this.ShowFullList_btn.UseVisualStyleBackColor = false;
            this.ShowFullList_btn.Click += new System.EventHandler(this.ShowFullList_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(371, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 50);
            this.label3.TabIndex = 5;
            this.label3.Text = "Group";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RosyBrown;
            this.panel2.Controls.Add(this.AddGroupName_btn);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.GroupName_textBox);
            this.panel2.Location = new System.Drawing.Point(355, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 100);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // AddGroupName_btn
            // 
            this.AddGroupName_btn.BackColor = System.Drawing.SystemColors.Control;
            this.AddGroupName_btn.Location = new System.Drawing.Point(15, 50);
            this.AddGroupName_btn.Name = "AddGroupName_btn";
            this.AddGroupName_btn.Size = new System.Drawing.Size(289, 37);
            this.AddGroupName_btn.TabIndex = 3;
            this.AddGroupName_btn.Text = "Add";
            this.AddGroupName_btn.UseVisualStyleBackColor = false;
            this.AddGroupName_btn.Click += new System.EventHandler(this.AddGroupName_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Enter Group Name:";
            // 
            // GroupName_textBox
            // 
            this.GroupName_textBox.Location = new System.Drawing.Point(146, 6);
            this.GroupName_textBox.Name = "GroupName_textBox";
            this.GroupName_textBox.Size = new System.Drawing.Size(158, 20);
            this.GroupName_textBox.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RosyBrown;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.SelectEditGroup_comboBox);
            this.panel3.Controls.Add(this.EditGroupName_btn);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.NewGroupName_textBox);
            this.panel3.Location = new System.Drawing.Point(355, 228);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(317, 122);
            this.panel3.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Select Group:";
            // 
            // SelectEditGroup_comboBox
            // 
            this.SelectEditGroup_comboBox.FormattingEnabled = true;
            this.SelectEditGroup_comboBox.Location = new System.Drawing.Point(146, 13);
            this.SelectEditGroup_comboBox.Name = "SelectEditGroup_comboBox";
            this.SelectEditGroup_comboBox.Size = new System.Drawing.Size(158, 21);
            this.SelectEditGroup_comboBox.TabIndex = 4;
            // 
            // EditGroupName_btn
            // 
            this.EditGroupName_btn.BackColor = System.Drawing.SystemColors.Control;
            this.EditGroupName_btn.Location = new System.Drawing.Point(15, 63);
            this.EditGroupName_btn.Name = "EditGroupName_btn";
            this.EditGroupName_btn.Size = new System.Drawing.Size(289, 37);
            this.EditGroupName_btn.TabIndex = 3;
            this.EditGroupName_btn.Text = "Edit";
            this.EditGroupName_btn.UseVisualStyleBackColor = false;
            this.EditGroupName_btn.Click += new System.EventHandler(this.EditGroupName_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Enter New Name:";
            // 
            // NewGroupName_textBox
            // 
            this.NewGroupName_textBox.Location = new System.Drawing.Point(146, 37);
            this.NewGroupName_textBox.Name = "NewGroupName_textBox";
            this.NewGroupName_textBox.Size = new System.Drawing.Size(158, 20);
            this.NewGroupName_textBox.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.RosyBrown;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.SelectDelGroupName_comboBox);
            this.panel4.Controls.Add(this.RemoveGroup_btn);
            this.panel4.Location = new System.Drawing.Point(355, 356);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(317, 100);
            this.panel4.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Select Group:";
            // 
            // SelectDelGroupName_comboBox
            // 
            this.SelectDelGroupName_comboBox.FormattingEnabled = true;
            this.SelectDelGroupName_comboBox.Location = new System.Drawing.Point(146, 8);
            this.SelectDelGroupName_comboBox.Name = "SelectDelGroupName_comboBox";
            this.SelectDelGroupName_comboBox.Size = new System.Drawing.Size(158, 21);
            this.SelectDelGroupName_comboBox.TabIndex = 4;
            // 
            // RemoveGroup_btn
            // 
            this.RemoveGroup_btn.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveGroup_btn.Location = new System.Drawing.Point(15, 50);
            this.RemoveGroup_btn.Name = "RemoveGroup_btn";
            this.RemoveGroup_btn.Size = new System.Drawing.Size(289, 37);
            this.RemoveGroup_btn.TabIndex = 3;
            this.RemoveGroup_btn.Text = "Remove";
            this.RemoveGroup_btn.UseVisualStyleBackColor = false;
            this.RemoveGroup_btn.Click += new System.EventHandler(this.RemoveGroup_btn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.User_pictureBox);
            this.panel5.Controls.Add(this.Refresh_btn);
            this.panel5.Controls.Add(this.EditInfo_btn);
            this.panel5.Controls.Add(this.UserName_lb);
            this.panel5.Location = new System.Drawing.Point(2, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(679, 61);
            this.panel5.TabIndex = 7;
            // 
            // User_pictureBox
            // 
            this.User_pictureBox.Location = new System.Drawing.Point(3, 3);
            this.User_pictureBox.Name = "User_pictureBox";
            this.User_pictureBox.Size = new System.Drawing.Size(67, 50);
            this.User_pictureBox.TabIndex = 3;
            this.User_pictureBox.TabStop = false;
            // 
            // Refresh_btn
            // 
            this.Refresh_btn.AutoSize = true;
            this.Refresh_btn.Location = new System.Drawing.Point(146, 40);
            this.Refresh_btn.Name = "Refresh_btn";
            this.Refresh_btn.Size = new System.Drawing.Size(44, 13);
            this.Refresh_btn.TabIndex = 2;
            this.Refresh_btn.Text = "Refresh";
            this.Refresh_btn.Click += new System.EventHandler(this.Refresh_btn_Click);
            // 
            // EditInfo_btn
            // 
            this.EditInfo_btn.AutoSize = true;
            this.EditInfo_btn.Location = new System.Drawing.Point(76, 40);
            this.EditInfo_btn.Name = "EditInfo_btn";
            this.EditInfo_btn.Size = new System.Drawing.Size(64, 13);
            this.EditInfo_btn.TabIndex = 1;
            this.EditInfo_btn.Text = "Edit my info ";
            this.EditInfo_btn.Click += new System.EventHandler(this.EditInfo_btn_Click);
            // 
            // UserName_lb
            // 
            this.UserName_lb.AutoSize = true;
            this.UserName_lb.Location = new System.Drawing.Point(76, 9);
            this.UserName_lb.Name = "UserName_lb";
            this.UserName_lb.Size = new System.Drawing.Size(92, 13);
            this.UserName_lb.TabIndex = 0;
            this.UserName_lb.Text = "Welcome (Userer)";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(681, 460);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ShowFullList_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EditContact_btn);
            this.Controls.Add(this.AddContact_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.User_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddContact_btn;
        private System.Windows.Forms.Button EditContact_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SelectContactID_textBox;
        private System.Windows.Forms.Button SelectContact_btn;
        private System.Windows.Forms.Button Remove_btn;
        private System.Windows.Forms.Button ShowFullList_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button AddGroupName_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GroupName_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button EditGroupName_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NewGroupName_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SelectEditGroup_comboBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button RemoveGroup_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox SelectDelGroupName_comboBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label UserName_lb;
        private System.Windows.Forms.Label Refresh_btn;
        private System.Windows.Forms.Label EditInfo_btn;
        private System.Windows.Forms.PictureBox User_pictureBox;
    }
}