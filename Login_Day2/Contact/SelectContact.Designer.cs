namespace Login_Day2
{
    partial class SelectContact
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
            this.SelectContact_dataGridView = new System.Windows.Forms.DataGridView();
            this.IDContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SelectContact_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectContact_dataGridView
            // 
            this.SelectContact_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectContact_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDContact,
            this.Fname,
            this.Lname,
            this.GroupID});
            this.SelectContact_dataGridView.Location = new System.Drawing.Point(12, 12);
            this.SelectContact_dataGridView.Name = "SelectContact_dataGridView";
            this.SelectContact_dataGridView.Size = new System.Drawing.Size(445, 290);
            this.SelectContact_dataGridView.TabIndex = 0;
            this.SelectContact_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectContact_dataGridView_CellClick);
            // 
            // IDContact
            // 
            this.IDContact.HeaderText = "ID Contact";
            this.IDContact.Name = "IDContact";
            // 
            // Fname
            // 
            this.Fname.HeaderText = "First Name";
            this.Fname.Name = "Fname";
            // 
            // Lname
            // 
            this.Lname.HeaderText = "Last Name";
            this.Lname.Name = "Lname";
            // 
            // GroupID
            // 
            this.GroupID.HeaderText = "Group ID";
            this.GroupID.Name = "GroupID";
            // 
            // SelectContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 314);
            this.Controls.Add(this.SelectContact_dataGridView);
            this.Name = "SelectContact";
            this.Text = "SelectContact";
            ((System.ComponentModel.ISupportInitialize)(this.SelectContact_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SelectContact_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lname;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
    }
}