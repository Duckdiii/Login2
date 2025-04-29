namespace Login_Day2
{
    partial class PrintScoreForm
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
            this.Display_dataGridView = new System.Windows.Forms.DataGridView();
            this.Print_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Display_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Display_dataGridView
            // 
            this.Display_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Display_dataGridView.Location = new System.Drawing.Point(12, 12);
            this.Display_dataGridView.Name = "Display_dataGridView";
            this.Display_dataGridView.Size = new System.Drawing.Size(585, 246);
            this.Display_dataGridView.TabIndex = 0;
            // 
            // Print_btn
            // 
            this.Print_btn.Location = new System.Drawing.Point(232, 268);
            this.Print_btn.Name = "Print_btn";
            this.Print_btn.Size = new System.Drawing.Size(75, 23);
            this.Print_btn.TabIndex = 1;
            this.Print_btn.Text = "Print";
            this.Print_btn.UseVisualStyleBackColor = true;
            this.Print_btn.Click += new System.EventHandler(this.Print_btn_Click);
            // 
            // PrintScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 303);
            this.Controls.Add(this.Print_btn);
            this.Controls.Add(this.Display_dataGridView);
            this.Name = "PrintScoreForm";
            this.Text = "PrintScoreForm";
            this.Load += new System.EventHandler(this.PrintScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Display_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Display_dataGridView;
        private System.Windows.Forms.Button Print_btn;
    }
}