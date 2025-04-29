namespace Login_Day2
{
    partial class AverageScoreForm
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
            this.myDBDataSet_Course_ver21 = new Login_Day2.myDBDataSet_Course_ver2();
            this.AverageScore_dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.myDBDataSet_Course_ver21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AverageScore_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // myDBDataSet_Course_ver21
            // 
            this.myDBDataSet_Course_ver21.DataSetName = "myDBDataSet_Course_ver2";
            this.myDBDataSet_Course_ver21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AverageScore_dataGridView
            // 
            this.AverageScore_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AverageScore_dataGridView.Location = new System.Drawing.Point(13, 13);
            this.AverageScore_dataGridView.Name = "AverageScore_dataGridView";
            this.AverageScore_dataGridView.Size = new System.Drawing.Size(397, 214);
            this.AverageScore_dataGridView.TabIndex = 0;
            // 
            // AverageScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 250);
            this.Controls.Add(this.AverageScore_dataGridView);
            this.Name = "AverageScoreForm";
            this.Text = "AverageScoreForm";
            this.Load += new System.EventHandler(this.AverageScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myDBDataSet_Course_ver21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AverageScore_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myDBDataSet_Course_ver2 myDBDataSet_Course_ver21;
        private System.Windows.Forms.DataGridView AverageScore_dataGridView;
    }
}