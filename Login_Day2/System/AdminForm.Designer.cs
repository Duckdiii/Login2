namespace Login_Day2
{
    partial class AdminForm
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
            this.ListRegister_dataGridView = new System.Windows.Forms.DataGridView();
            this.Approve_btn = new System.Windows.Forms.Button();
            this.Reject_btn = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reload_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Pending_radioButton = new System.Windows.Forms.RadioButton();
            this.Approved_radioButton = new System.Windows.Forms.RadioButton();
            this.All_radioButton = new System.Windows.Forms.RadioButton();
            this.rejected_radioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ListRegister_dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListRegister_dataGridView
            // 
            this.ListRegister_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListRegister_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.email,
            this.username,
            this.status});
            this.ListRegister_dataGridView.Location = new System.Drawing.Point(24, 12);
            this.ListRegister_dataGridView.Name = "ListRegister_dataGridView";
            this.ListRegister_dataGridView.Size = new System.Drawing.Size(446, 310);
            this.ListRegister_dataGridView.TabIndex = 0;
            this.ListRegister_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListRegister_dataGridView_CellContentClick);
            this.ListRegister_dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ListRegister_dataGridView_CellFormatting);
            // 
            // Approve_btn
            // 
            this.Approve_btn.Location = new System.Drawing.Point(476, 299);
            this.Approve_btn.Name = "Approve_btn";
            this.Approve_btn.Size = new System.Drawing.Size(75, 23);
            this.Approve_btn.TabIndex = 1;
            this.Approve_btn.Text = "Approve";
            this.Approve_btn.UseVisualStyleBackColor = true;
            this.Approve_btn.Click += new System.EventHandler(this.Approve_btn_Click);
            // 
            // Reject_btn
            // 
            this.Reject_btn.Location = new System.Drawing.Point(559, 299);
            this.Reject_btn.Name = "Reject_btn";
            this.Reject_btn.Size = new System.Drawing.Size(75, 23);
            this.Reject_btn.TabIndex = 2;
            this.Reject_btn.Text = "Reject";
            this.Reject_btn.UseVisualStyleBackColor = true;
            this.Reject_btn.Click += new System.EventHandler(this.Reject_btn_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            // 
            // username
            // 
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // reload_btn
            // 
            this.reload_btn.Location = new System.Drawing.Point(395, 328);
            this.reload_btn.Name = "reload_btn";
            this.reload_btn.Size = new System.Drawing.Size(75, 23);
            this.reload_btn.TabIndex = 3;
            this.reload_btn.Text = "Reload";
            this.reload_btn.UseVisualStyleBackColor = true;
            this.reload_btn.Click += new System.EventHandler(this.reload_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rejected_radioButton);
            this.groupBox1.Controls.Add(this.All_radioButton);
            this.groupBox1.Controls.Add(this.Approved_radioButton);
            this.groupBox1.Controls.Add(this.Pending_radioButton);
            this.groupBox1.Location = new System.Drawing.Point(486, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find user";
            // 
            // Pending_radioButton
            // 
            this.Pending_radioButton.AutoSize = true;
            this.Pending_radioButton.Location = new System.Drawing.Point(6, 19);
            this.Pending_radioButton.Name = "Pending_radioButton";
            this.Pending_radioButton.Size = new System.Drawing.Size(64, 17);
            this.Pending_radioButton.TabIndex = 0;
            this.Pending_radioButton.TabStop = true;
            this.Pending_radioButton.Text = "Pending";
            this.Pending_radioButton.UseVisualStyleBackColor = true;
            this.Pending_radioButton.CheckedChanged += new System.EventHandler(this.Pending_radioButton_CheckedChanged);
            // 
            // Approved_radioButton
            // 
            this.Approved_radioButton.AutoSize = true;
            this.Approved_radioButton.Location = new System.Drawing.Point(6, 42);
            this.Approved_radioButton.Name = "Approved_radioButton";
            this.Approved_radioButton.Size = new System.Drawing.Size(71, 17);
            this.Approved_radioButton.TabIndex = 1;
            this.Approved_radioButton.TabStop = true;
            this.Approved_radioButton.Text = "Approved";
            this.Approved_radioButton.UseVisualStyleBackColor = true;
            this.Approved_radioButton.CheckedChanged += new System.EventHandler(this.Approved_radioButton_CheckedChanged);
            // 
            // All_radioButton
            // 
            this.All_radioButton.AutoSize = true;
            this.All_radioButton.Location = new System.Drawing.Point(6, 88);
            this.All_radioButton.Name = "All_radioButton";
            this.All_radioButton.Size = new System.Drawing.Size(36, 17);
            this.All_radioButton.TabIndex = 2;
            this.All_radioButton.TabStop = true;
            this.All_radioButton.Text = "All";
            this.All_radioButton.UseVisualStyleBackColor = true;
            this.All_radioButton.CheckedChanged += new System.EventHandler(this.All_radioButton_CheckedChanged);
            // 
            // rejected_radioButton
            // 
            this.rejected_radioButton.AutoSize = true;
            this.rejected_radioButton.Location = new System.Drawing.Point(6, 65);
            this.rejected_radioButton.Name = "rejected_radioButton";
            this.rejected_radioButton.Size = new System.Drawing.Size(68, 17);
            this.rejected_radioButton.TabIndex = 3;
            this.rejected_radioButton.TabStop = true;
            this.rejected_radioButton.Text = "Rejected";
            this.rejected_radioButton.UseVisualStyleBackColor = true;
            this.rejected_radioButton.CheckedChanged += new System.EventHandler(this.rejected_radioButton_CheckedChanged);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 358);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reload_btn);
            this.Controls.Add(this.Reject_btn);
            this.Controls.Add(this.Approve_btn);
            this.Controls.Add(this.ListRegister_dataGridView);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListRegister_dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ListRegister_dataGridView;
        private System.Windows.Forms.Button Approve_btn;
        private System.Windows.Forms.Button Reject_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button reload_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Approved_radioButton;
        private System.Windows.Forms.RadioButton Pending_radioButton;
        private System.Windows.Forms.RadioButton All_radioButton;
        private System.Windows.Forms.RadioButton rejected_radioButton;
    }
}