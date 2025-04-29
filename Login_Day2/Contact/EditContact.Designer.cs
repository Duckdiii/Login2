namespace Login_Day2
{
    partial class EditContact
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
            this.Upload_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.EditContact_btn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ContactID_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Contact_pictureBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ContactAddress_richTextBox = new System.Windows.Forms.RichTextBox();
            this.ContactEmail_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ContactPhone_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ContactGroup_comboBox = new System.Windows.Forms.ComboBox();
            this.ContactLastName_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ContactFirstName_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectContact_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Contact_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Upload_btn
            // 
            this.Upload_btn.Location = new System.Drawing.Point(226, 348);
            this.Upload_btn.Name = "Upload_btn";
            this.Upload_btn.Size = new System.Drawing.Size(75, 23);
            this.Upload_btn.TabIndex = 37;
            this.Upload_btn.Text = "Upload";
            this.Upload_btn.UseVisualStyleBackColor = true;
            this.Upload_btn.Click += new System.EventHandler(this.Upload_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(241, 377);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.Cancel_btn.TabIndex = 36;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // EditContact_btn
            // 
            this.EditContact_btn.Location = new System.Drawing.Point(43, 377);
            this.EditContact_btn.Name = "EditContact_btn";
            this.EditContact_btn.Size = new System.Drawing.Size(75, 23);
            this.EditContact_btn.TabIndex = 35;
            this.EditContact_btn.Text = "Edit Contact";
            this.EditContact_btn.UseVisualStyleBackColor = true;
            this.EditContact_btn.Click += new System.EventHandler(this.AddContact_btn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Picture:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // ContactID_textBox
            // 
            this.ContactID_textBox.Location = new System.Drawing.Point(89, 9);
            this.ContactID_textBox.Name = "ContactID_textBox";
            this.ContactID_textBox.Size = new System.Drawing.Size(95, 20);
            this.ContactID_textBox.TabIndex = 33;
            this.ContactID_textBox.TextChanged += new System.EventHandler(this.ContactID_textBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "ID:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Contact_pictureBox
            // 
            this.Contact_pictureBox.Location = new System.Drawing.Point(89, 268);
            this.Contact_pictureBox.Name = "Contact_pictureBox";
            this.Contact_pictureBox.Size = new System.Drawing.Size(131, 103);
            this.Contact_pictureBox.TabIndex = 31;
            this.Contact_pictureBox.TabStop = false;
            this.Contact_pictureBox.Click += new System.EventHandler(this.Contact_pictureBox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Address:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // ContactAddress_richTextBox
            // 
            this.ContactAddress_richTextBox.Location = new System.Drawing.Point(89, 166);
            this.ContactAddress_richTextBox.Name = "ContactAddress_richTextBox";
            this.ContactAddress_richTextBox.Size = new System.Drawing.Size(271, 96);
            this.ContactAddress_richTextBox.TabIndex = 29;
            this.ContactAddress_richTextBox.Text = "";
            this.ContactAddress_richTextBox.TextChanged += new System.EventHandler(this.ContactAddress_richTextBox_TextChanged);
            // 
            // ContactEmail_textBox
            // 
            this.ContactEmail_textBox.Location = new System.Drawing.Point(89, 140);
            this.ContactEmail_textBox.Name = "ContactEmail_textBox";
            this.ContactEmail_textBox.Size = new System.Drawing.Size(271, 20);
            this.ContactEmail_textBox.TabIndex = 28;
            this.ContactEmail_textBox.TextChanged += new System.EventHandler(this.ContactEmail_textBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Emai:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ContactPhone_textBox
            // 
            this.ContactPhone_textBox.Location = new System.Drawing.Point(89, 114);
            this.ContactPhone_textBox.Name = "ContactPhone_textBox";
            this.ContactPhone_textBox.Size = new System.Drawing.Size(271, 20);
            this.ContactPhone_textBox.TabIndex = 26;
            this.ContactPhone_textBox.TextChanged += new System.EventHandler(this.ContactPhone_textBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Phone:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Group:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ContactGroup_comboBox
            // 
            this.ContactGroup_comboBox.FormattingEnabled = true;
            this.ContactGroup_comboBox.Location = new System.Drawing.Point(89, 87);
            this.ContactGroup_comboBox.Name = "ContactGroup_comboBox";
            this.ContactGroup_comboBox.Size = new System.Drawing.Size(271, 21);
            this.ContactGroup_comboBox.TabIndex = 23;
            this.ContactGroup_comboBox.SelectedIndexChanged += new System.EventHandler(this.ContactGroup_comboBox_SelectedIndexChanged);
            // 
            // ContactLastName_textBox
            // 
            this.ContactLastName_textBox.Location = new System.Drawing.Point(89, 61);
            this.ContactLastName_textBox.Name = "ContactLastName_textBox";
            this.ContactLastName_textBox.Size = new System.Drawing.Size(271, 20);
            this.ContactLastName_textBox.TabIndex = 22;
            this.ContactLastName_textBox.TextChanged += new System.EventHandler(this.ContactLastName_textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Last Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ContactFirstName_textBox
            // 
            this.ContactFirstName_textBox.Location = new System.Drawing.Point(89, 35);
            this.ContactFirstName_textBox.Name = "ContactFirstName_textBox";
            this.ContactFirstName_textBox.Size = new System.Drawing.Size(271, 20);
            this.ContactFirstName_textBox.TabIndex = 20;
            this.ContactFirstName_textBox.TextChanged += new System.EventHandler(this.ContactFirstName_textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "First Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SelectContact_btn
            // 
            this.SelectContact_btn.Location = new System.Drawing.Point(204, 7);
            this.SelectContact_btn.Name = "SelectContact_btn";
            this.SelectContact_btn.Size = new System.Drawing.Size(75, 23);
            this.SelectContact_btn.TabIndex = 38;
            this.SelectContact_btn.Text = "Select Contact";
            this.SelectContact_btn.UseVisualStyleBackColor = true;
            this.SelectContact_btn.Click += new System.EventHandler(this.SelectContact_btn_Click);
            // 
            // EditContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 450);
            this.Controls.Add(this.SelectContact_btn);
            this.Controls.Add(this.Upload_btn);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.EditContact_btn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ContactID_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Contact_pictureBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ContactAddress_richTextBox);
            this.Controls.Add(this.ContactEmail_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ContactPhone_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ContactGroup_comboBox);
            this.Controls.Add(this.ContactLastName_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ContactFirstName_textBox);
            this.Controls.Add(this.label1);
            this.Name = "EditContact";
            this.Text = "EditContact";
            ((System.ComponentModel.ISupportInitialize)(this.Contact_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Upload_btn;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Button EditContact_btn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ContactID_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox Contact_pictureBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox ContactAddress_richTextBox;
        private System.Windows.Forms.TextBox ContactEmail_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ContactPhone_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ContactGroup_comboBox;
        private System.Windows.Forms.TextBox ContactLastName_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ContactFirstName_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectContact_btn;
    }
}