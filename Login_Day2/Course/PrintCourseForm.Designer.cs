namespace Login_Day2
{
    partial class PrintCourseForm
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
            this.components = new System.ComponentModel.Container();
            this.CoursesInfo_dataGridView = new System.Windows.Forms.DataGridView();
            this.ToFile_btn = new System.Windows.Forms.Button();
            this.Print_btn = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myDBDataSet_Course_ver2 = new Login_Day2.myDBDataSet_Course_ver2();
            this.courseBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.courseTableAdapter1 = new Login_Day2.myDBDataSet_Course_ver2TableAdapters.CourseTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CoursesInfo_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDBDataSet_Course_ver2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // CoursesInfo_dataGridView
            // 
            this.CoursesInfo_dataGridView.AutoGenerateColumns = false;
            this.CoursesInfo_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoursesInfo_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.labelDataGridViewTextBoxColumn,
            this.periodDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.CoursesInfo_dataGridView.DataSource = this.courseBindingSource1;
            this.CoursesInfo_dataGridView.Location = new System.Drawing.Point(29, 26);
            this.CoursesInfo_dataGridView.Name = "CoursesInfo_dataGridView";
            this.CoursesInfo_dataGridView.Size = new System.Drawing.Size(446, 208);
            this.CoursesInfo_dataGridView.TabIndex = 0;
            this.CoursesInfo_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoursesInfo_dataGridView_CellContentClick);
            // 
            // ToFile_btn
            // 
            this.ToFile_btn.Location = new System.Drawing.Point(29, 269);
            this.ToFile_btn.Name = "ToFile_btn";
            this.ToFile_btn.Size = new System.Drawing.Size(75, 23);
            this.ToFile_btn.TabIndex = 1;
            this.ToFile_btn.Text = "To File";
            this.ToFile_btn.UseVisualStyleBackColor = true;
            this.ToFile_btn.Click += new System.EventHandler(this.ToFile_btn_Click);
            // 
            // Print_btn
            // 
            this.Print_btn.Location = new System.Drawing.Point(225, 269);
            this.Print_btn.Name = "Print_btn";
            this.Print_btn.Size = new System.Drawing.Size(75, 23);
            this.Print_btn.TabIndex = 2;
            this.Print_btn.Text = "Print";
            this.Print_btn.UseVisualStyleBackColor = true;
            this.Print_btn.Click += new System.EventHandler(this.Print_btn_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // labelDataGridViewTextBoxColumn
            // 
            this.labelDataGridViewTextBoxColumn.DataPropertyName = "label";
            this.labelDataGridViewTextBoxColumn.HeaderText = "label";
            this.labelDataGridViewTextBoxColumn.Name = "labelDataGridViewTextBoxColumn";
            // 
            // periodDataGridViewTextBoxColumn
            // 
            this.periodDataGridViewTextBoxColumn.DataPropertyName = "period";
            this.periodDataGridViewTextBoxColumn.HeaderText = "period";
            this.periodDataGridViewTextBoxColumn.Name = "periodDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // myDBDataSet_Course_ver2
            // 
            this.myDBDataSet_Course_ver2.DataSetName = "myDBDataSet_Course_ver2";
            this.myDBDataSet_Course_ver2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // courseBindingSource1
            // 
            this.courseBindingSource1.DataMember = "Course";
            this.courseBindingSource1.DataSource = this.myDBDataSet_Course_ver2;
            // 
            // courseTableAdapter1
            // 
            this.courseTableAdapter1.ClearBeforeFill = true;
            // 
            // PrintCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 423);
            this.Controls.Add(this.Print_btn);
            this.Controls.Add(this.ToFile_btn);
            this.Controls.Add(this.CoursesInfo_dataGridView);
            this.Name = "PrintCourseForm";
            this.Text = "PrintCourseForm";
            this.Load += new System.EventHandler(this.PrintCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoursesInfo_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDBDataSet_Course_ver2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CoursesInfo_dataGridView;
        private System.Windows.Forms.Button ToFile_btn;
        private System.Windows.Forms.Button Print_btn;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn labelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private myDBDataSet_Course_ver2 myDBDataSet_Course_ver2;
        private System.Windows.Forms.BindingSource courseBindingSource1;
        private myDBDataSet_Course_ver2TableAdapters.CourseTableAdapter courseTableAdapter1;
    }
}