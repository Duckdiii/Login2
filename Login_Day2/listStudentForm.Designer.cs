namespace Login_Day2
{
    partial class listStudentForm
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
            this.dataGridView_StudentList = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.stdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDBDataSet_Student = new Login_Day2.myDBDataSet_Student();
            this.stdTableAdapter = new Login_Day2.myDBDataSet_StudentTableAdapters.stdTableAdapter();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.export_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.check_btn = new System.Windows.Forms.Button();
            this.all_radioButton = new System.Windows.Forms.RadioButton();
            this.female_radioButton = new System.Windows.Forms.RadioButton();
            this.male_radioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Yes_radioButton = new System.Windows.Forms.RadioButton();
            this.No_radioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstSelection_Birthday_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SecondSelection_Birthday_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.search_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_StudentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDBDataSet_Student)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_StudentList
            // 
            this.dataGridView_StudentList.AutoGenerateColumns = false;
            this.dataGridView_StudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_StudentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fnameDataGridViewTextBoxColumn,
            this.lnameDataGridViewTextBoxColumn,
            this.bdateDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.pictureDataGridViewImageColumn});
            this.dataGridView_StudentList.DataSource = this.stdBindingSource;
            this.dataGridView_StudentList.Location = new System.Drawing.Point(12, 90);
            this.dataGridView_StudentList.Name = "dataGridView_StudentList";
            this.dataGridView_StudentList.Size = new System.Drawing.Size(847, 288);
            this.dataGridView_StudentList.TabIndex = 0;
            this.dataGridView_StudentList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_StudentList_CellContentClick);
            this.dataGridView_StudentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_StudentList_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Student ID";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 101;
            // 
            // fnameDataGridViewTextBoxColumn
            // 
            this.fnameDataGridViewTextBoxColumn.DataPropertyName = "fname";
            this.fnameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.fnameDataGridViewTextBoxColumn.Name = "fnameDataGridViewTextBoxColumn";
            // 
            // lnameDataGridViewTextBoxColumn
            // 
            this.lnameDataGridViewTextBoxColumn.DataPropertyName = "lname";
            this.lnameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lnameDataGridViewTextBoxColumn.Name = "lnameDataGridViewTextBoxColumn";
            this.lnameDataGridViewTextBoxColumn.Width = 101;
            // 
            // bdateDataGridViewTextBoxColumn
            // 
            this.bdateDataGridViewTextBoxColumn.DataPropertyName = "bdate";
            this.bdateDataGridViewTextBoxColumn.HeaderText = "Day of Birth";
            this.bdateDataGridViewTextBoxColumn.Name = "bdateDataGridViewTextBoxColumn";
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "Gender";
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            this.genderDataGridViewTextBoxColumn.Width = 101;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone Number";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.Width = 101;
            // 
            // pictureDataGridViewImageColumn
            // 
            this.pictureDataGridViewImageColumn.DataPropertyName = "picture";
            this.pictureDataGridViewImageColumn.HeaderText = "Picture";
            this.pictureDataGridViewImageColumn.Name = "pictureDataGridViewImageColumn";
            // 
            // stdBindingSource
            // 
            this.stdBindingSource.DataMember = "std";
            this.stdBindingSource.DataSource = this.myDBDataSet_Student;
            // 
            // myDBDataSet_Student
            // 
            this.myDBDataSet_Student.DataSetName = "myDBDataSet_Student";
            this.myDBDataSet_Student.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stdTableAdapter
            // 
            this.stdTableAdapter.ClearBeforeFill = true;
            // 
            // refresh_btn
            // 
            this.refresh_btn.Location = new System.Drawing.Point(353, 384);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(75, 23);
            this.refresh_btn.TabIndex = 1;
            this.refresh_btn.Text = "Refesh";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // export_btn
            // 
            this.export_btn.Location = new System.Drawing.Point(13, 383);
            this.export_btn.Name = "export_btn";
            this.export_btn.Size = new System.Drawing.Size(75, 23);
            this.export_btn.TabIndex = 2;
            this.export_btn.Text = "Export";
            this.export_btn.UseVisualStyleBackColor = true;
            this.export_btn.Click += new System.EventHandler(this.export_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.male_radioButton);
            this.panel1.Controls.Add(this.female_radioButton);
            this.panel1.Controls.Add(this.all_radioButton);
            this.panel1.Controls.Add(this.check_btn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 80);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.search_btn);
            this.panel2.Controls.Add(this.SecondSelection_Birthday_dateTimePicker);
            this.panel2.Controls.Add(this.FirstSelection_Birthday_dateTimePicker);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.No_radioButton);
            this.panel2.Controls.Add(this.Yes_radioButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(249, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(405, 74);
            this.panel2.TabIndex = 0;
            // 
            // check_btn
            // 
            this.check_btn.Location = new System.Drawing.Point(692, 24);
            this.check_btn.Name = "check_btn";
            this.check_btn.Size = new System.Drawing.Size(75, 23);
            this.check_btn.TabIndex = 1;
            this.check_btn.Text = "Check";
            this.check_btn.UseVisualStyleBackColor = true;
            this.check_btn.Click += new System.EventHandler(this.check_btn_Click);
            // 
            // all_radioButton
            // 
            this.all_radioButton.AutoSize = true;
            this.all_radioButton.Location = new System.Drawing.Point(21, 30);
            this.all_radioButton.Name = "all_radioButton";
            this.all_radioButton.Size = new System.Drawing.Size(36, 17);
            this.all_radioButton.TabIndex = 3;
            this.all_radioButton.TabStop = true;
            this.all_radioButton.Text = "All";
            this.all_radioButton.UseVisualStyleBackColor = true;
            // 
            // female_radioButton
            // 
            this.female_radioButton.AutoSize = true;
            this.female_radioButton.Location = new System.Drawing.Point(73, 30);
            this.female_radioButton.Name = "female_radioButton";
            this.female_radioButton.Size = new System.Drawing.Size(59, 17);
            this.female_radioButton.TabIndex = 4;
            this.female_radioButton.TabStop = true;
            this.female_radioButton.Text = "Female";
            this.female_radioButton.UseVisualStyleBackColor = true;
            // 
            // male_radioButton
            // 
            this.male_radioButton.AutoSize = true;
            this.male_radioButton.Location = new System.Drawing.Point(154, 30);
            this.male_radioButton.Name = "male_radioButton";
            this.male_radioButton.Size = new System.Drawing.Size(48, 17);
            this.male_radioButton.TabIndex = 5;
            this.male_radioButton.TabStop = true;
            this.male_radioButton.Text = "Male";
            this.male_radioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Use data range:";
            // 
            // Yes_radioButton
            // 
            this.Yes_radioButton.AutoSize = true;
            this.Yes_radioButton.Location = new System.Drawing.Point(118, 7);
            this.Yes_radioButton.Name = "Yes_radioButton";
            this.Yes_radioButton.Size = new System.Drawing.Size(43, 17);
            this.Yes_radioButton.TabIndex = 6;
            this.Yes_radioButton.TabStop = true;
            this.Yes_radioButton.Text = "Yes";
            this.Yes_radioButton.UseVisualStyleBackColor = true;
            this.Yes_radioButton.CheckedChanged += new System.EventHandler(this.Yes_radioButton_CheckedChanged);
            // 
            // No_radioButton
            // 
            this.No_radioButton.AutoSize = true;
            this.No_radioButton.Location = new System.Drawing.Point(209, 7);
            this.No_radioButton.Name = "No_radioButton";
            this.No_radioButton.Size = new System.Drawing.Size(39, 17);
            this.No_radioButton.TabIndex = 7;
            this.No_radioButton.TabStop = true;
            this.No_radioButton.Text = "No";
            this.No_radioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Birthday between:";
            // 
            // FirstSelection_Birthday_dateTimePicker
            // 
            this.FirstSelection_Birthday_dateTimePicker.Location = new System.Drawing.Point(114, 28);
            this.FirstSelection_Birthday_dateTimePicker.Name = "FirstSelection_Birthday_dateTimePicker";
            this.FirstSelection_Birthday_dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.FirstSelection_Birthday_dateTimePicker.TabIndex = 10;
            // 
            // SecondSelection_Birthday_dateTimePicker
            // 
            this.SecondSelection_Birthday_dateTimePicker.Location = new System.Drawing.Point(114, 51);
            this.SecondSelection_Birthday_dateTimePicker.Name = "SecondSelection_Birthday_dateTimePicker";
            this.SecondSelection_Birthday_dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.SecondSelection_Birthday_dateTimePicker.TabIndex = 11;
            // 
            // search_btn
            // 
            this.search_btn.Location = new System.Drawing.Point(320, 21);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(75, 23);
            this.search_btn.TabIndex = 6;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "And";
            // 
            // listStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 419);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.export_btn);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.dataGridView_StudentList);
            this.Name = "listStudentForm";
            this.Text = "listStudentForm_23110009_NguyenDucDuy";
            this.Load += new System.EventHandler(this.listStudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_StudentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDBDataSet_Student)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_StudentList;
        private myDBDataSet_Student myDBDataSet_Student;
        private System.Windows.Forms.BindingSource stdBindingSource;
        private myDBDataSet_StudentTableAdapters.stdTableAdapter stdTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn pictureDataGridViewImageColumn;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.Button export_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button check_btn;
        private System.Windows.Forms.RadioButton all_radioButton;
        private System.Windows.Forms.RadioButton female_radioButton;
        private System.Windows.Forms.RadioButton male_radioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton No_radioButton;
        private System.Windows.Forms.RadioButton Yes_radioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.DateTimePicker SecondSelection_Birthday_dateTimePicker;
        private System.Windows.Forms.DateTimePicker FirstSelection_Birthday_dateTimePicker;
        private System.Windows.Forms.Label label3;
    }
}