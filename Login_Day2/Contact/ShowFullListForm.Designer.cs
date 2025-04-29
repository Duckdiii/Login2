namespace Login_Day2
{
    partial class ShowFullListForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.Display_listBox = new System.Windows.Forms.ListBox();
            this.Display_dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Display_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Show All";
            // 
            // Display_listBox
            // 
            this.Display_listBox.FormattingEnabled = true;
            this.Display_listBox.Location = new System.Drawing.Point(15, 26);
            this.Display_listBox.Name = "Display_listBox";
            this.Display_listBox.Size = new System.Drawing.Size(131, 186);
            this.Display_listBox.TabIndex = 2;
            // 
            // Display_dataGridView
            // 
            this.Display_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Display_dataGridView.Location = new System.Drawing.Point(153, 26);
            this.Display_dataGridView.Name = "Display_dataGridView";
            this.Display_dataGridView.Size = new System.Drawing.Size(599, 186);
            this.Display_dataGridView.TabIndex = 3;
            // 
            // ShowFullListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 227);
            this.Controls.Add(this.Display_dataGridView);
            this.Controls.Add(this.Display_listBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShowFullListForm";
            this.Text = "ShowFullListForm";
            this.Load += new System.EventHandler(this.ShowFullListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Display_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Display_listBox;
        private System.Windows.Forms.DataGridView Display_dataGridView;
    }
}