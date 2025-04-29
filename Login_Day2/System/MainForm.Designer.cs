namespace Login_Day2
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.sTUDENTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStudentFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOURSEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCourse_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remove_CourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCourse_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCourses_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.print_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sCOREToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avgScoreByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aVGResultByScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decentralizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTUDENTToolStripMenuItem,
            this.cOURSEToolStripMenuItem,
            this.sCOREToolStripMenuItem,
            this.resultToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(378, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip2";
            // 
            // sTUDENTToolStripMenuItem
            // 
            this.sTUDENTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewStudentToolStripMenuItem,
            this.studentListToolStripMenuItem,
            this.staticToolStripMenuItem,
            this.editRemoveToolStripMenuItem,
            this.manageStudentFormToolStripMenuItem,
            this.printToolStripMenuItem});
            this.sTUDENTToolStripMenuItem.Name = "sTUDENTToolStripMenuItem";
            this.sTUDENTToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.sTUDENTToolStripMenuItem.Text = "STUDENT";
            // 
            // addNewStudentToolStripMenuItem
            // 
            this.addNewStudentToolStripMenuItem.Name = "addNewStudentToolStripMenuItem";
            this.addNewStudentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addNewStudentToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.addNewStudentToolStripMenuItem.Text = "Add New Student";
            this.addNewStudentToolStripMenuItem.Click += new System.EventHandler(this.addNewStudentToolStripMenuItem_Click);
            // 
            // studentListToolStripMenuItem
            // 
            this.studentListToolStripMenuItem.Name = "studentListToolStripMenuItem";
            this.studentListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.studentListToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.studentListToolStripMenuItem.Text = "Student List";
            this.studentListToolStripMenuItem.Click += new System.EventHandler(this.studentListToolStripMenuItem_Click);
            // 
            // staticToolStripMenuItem
            // 
            this.staticToolStripMenuItem.Name = "staticToolStripMenuItem";
            this.staticToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.staticToolStripMenuItem.Text = "Statics";
            this.staticToolStripMenuItem.Click += new System.EventHandler(this.staticToolStripMenuItem_Click);
            // 
            // editRemoveToolStripMenuItem
            // 
            this.editRemoveToolStripMenuItem.Name = "editRemoveToolStripMenuItem";
            this.editRemoveToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.editRemoveToolStripMenuItem.Text = "Edit/ Remove";
            this.editRemoveToolStripMenuItem.Click += new System.EventHandler(this.editRemoveToolStripMenuItem_Click);
            // 
            // manageStudentFormToolStripMenuItem
            // 
            this.manageStudentFormToolStripMenuItem.Name = "manageStudentFormToolStripMenuItem";
            this.manageStudentFormToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.manageStudentFormToolStripMenuItem.Text = "Manage Student Form";
            this.manageStudentFormToolStripMenuItem.Click += new System.EventHandler(this.manageStudentFormToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // cOURSEToolStripMenuItem
            // 
            this.cOURSEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCourse_ToolStripMenuItem,
            this.remove_CourseToolStripMenuItem,
            this.editCourse_ToolStripMenuItem,
            this.manageCourses_ToolStripMenuItem,
            this.print_ToolStripMenuItem});
            this.cOURSEToolStripMenuItem.Name = "cOURSEToolStripMenuItem";
            this.cOURSEToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.cOURSEToolStripMenuItem.Text = "COURSE";
            // 
            // addCourse_ToolStripMenuItem
            // 
            this.addCourse_ToolStripMenuItem.Name = "addCourse_ToolStripMenuItem";
            this.addCourse_ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addCourse_ToolStripMenuItem.Text = "Add Course";
            this.addCourse_ToolStripMenuItem.Click += new System.EventHandler(this.addCourse_ToolStripMenuItem_Click);
            // 
            // remove_CourseToolStripMenuItem
            // 
            this.remove_CourseToolStripMenuItem.Name = "remove_CourseToolStripMenuItem";
            this.remove_CourseToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.remove_CourseToolStripMenuItem.Text = "Remove Course";
            this.remove_CourseToolStripMenuItem.Click += new System.EventHandler(this.remove_CourseToolStripMenuItem_Click);
            // 
            // editCourse_ToolStripMenuItem
            // 
            this.editCourse_ToolStripMenuItem.Name = "editCourse_ToolStripMenuItem";
            this.editCourse_ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.editCourse_ToolStripMenuItem.Text = "Edit Course";
            this.editCourse_ToolStripMenuItem.Click += new System.EventHandler(this.editCourse_ToolStripMenuItem_Click);
            // 
            // manageCourses_ToolStripMenuItem
            // 
            this.manageCourses_ToolStripMenuItem.Name = "manageCourses_ToolStripMenuItem";
            this.manageCourses_ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.manageCourses_ToolStripMenuItem.Text = "Manage Courses";
            this.manageCourses_ToolStripMenuItem.Click += new System.EventHandler(this.manageCourses_ToolStripMenuItem_Click);
            // 
            // print_ToolStripMenuItem
            // 
            this.print_ToolStripMenuItem.Name = "print_ToolStripMenuItem";
            this.print_ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.print_ToolStripMenuItem.Text = "Print";
            this.print_ToolStripMenuItem.Click += new System.EventHandler(this.print_ToolStripMenuItem_Click);
            // 
            // sCOREToolStripMenuItem
            // 
            this.sCOREToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addScoreToolStripMenuItem,
            this.removeScoreToolStripMenuItem,
            this.manageScoreToolStripMenuItem,
            this.avgScoreByToolStripMenuItem,
            this.printResultToolStripMenuItem});
            this.sCOREToolStripMenuItem.Name = "sCOREToolStripMenuItem";
            this.sCOREToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.sCOREToolStripMenuItem.Text = "SCORE";
            // 
            // addScoreToolStripMenuItem
            // 
            this.addScoreToolStripMenuItem.Name = "addScoreToolStripMenuItem";
            this.addScoreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addScoreToolStripMenuItem.Text = "Add Score";
            this.addScoreToolStripMenuItem.Click += new System.EventHandler(this.addScoreToolStripMenuItem_Click);
            // 
            // removeScoreToolStripMenuItem
            // 
            this.removeScoreToolStripMenuItem.Name = "removeScoreToolStripMenuItem";
            this.removeScoreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeScoreToolStripMenuItem.Text = "Remove Score";
            this.removeScoreToolStripMenuItem.Click += new System.EventHandler(this.removeScoreToolStripMenuItem_Click);
            // 
            // manageScoreToolStripMenuItem
            // 
            this.manageScoreToolStripMenuItem.Name = "manageScoreToolStripMenuItem";
            this.manageScoreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manageScoreToolStripMenuItem.Text = "Manage Score";
            this.manageScoreToolStripMenuItem.Click += new System.EventHandler(this.manageScoreToolStripMenuItem_Click);
            // 
            // avgScoreByToolStripMenuItem
            // 
            this.avgScoreByToolStripMenuItem.Name = "avgScoreByToolStripMenuItem";
            this.avgScoreByToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.avgScoreByToolStripMenuItem.Text = "Avg Score by ";
            this.avgScoreByToolStripMenuItem.Click += new System.EventHandler(this.avgScoreByToolStripMenuItem_Click);
            // 
            // printResultToolStripMenuItem
            // 
            this.printResultToolStripMenuItem.Name = "printResultToolStripMenuItem";
            this.printResultToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.printResultToolStripMenuItem.Text = "Print Result";
            this.printResultToolStripMenuItem.Click += new System.EventHandler(this.printResultToolStripMenuItem_Click);
            // 
            // resultToolStripMenuItem
            // 
            this.resultToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aVGResultByScoreToolStripMenuItem,
            this.statisticResultToolStripMenuItem});
            this.resultToolStripMenuItem.Name = "resultToolStripMenuItem";
            this.resultToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.resultToolStripMenuItem.Text = "Result";
            // 
            // aVGResultByScoreToolStripMenuItem
            // 
            this.aVGResultByScoreToolStripMenuItem.Name = "aVGResultByScoreToolStripMenuItem";
            this.aVGResultByScoreToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.aVGResultByScoreToolStripMenuItem.Text = "AVG Result By Score";
            this.aVGResultByScoreToolStripMenuItem.Click += new System.EventHandler(this.aVGResultByScoreToolStripMenuItem_Click);
            // 
            // statisticResultToolStripMenuItem
            // 
            this.statisticResultToolStripMenuItem.Name = "statisticResultToolStripMenuItem";
            this.statisticResultToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.statisticResultToolStripMenuItem.Text = "Statics Result";
            this.statisticResultToolStripMenuItem.Click += new System.EventHandler(this.statisticResultToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decentralizationToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // decentralizationToolStripMenuItem
            // 
            this.decentralizationToolStripMenuItem.Name = "decentralizationToolStripMenuItem";
            this.decentralizationToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.decentralizationToolStripMenuItem.Text = "Decentralization";
            this.decentralizationToolStripMenuItem.Click += new System.EventHandler(this.decentralizationToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 349);
            this.Controls.Add(this.menuStrip);
            this.Name = "MainForm";
            this.Text = "MainForm_23110009_NguyenDucDuy";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem sTUDENTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageStudentFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOURSEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sCOREToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCourse_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remove_CourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCourse_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCourses_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem print_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avgScoreByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decentralizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aVGResultByScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticResultToolStripMenuItem;
    }
}