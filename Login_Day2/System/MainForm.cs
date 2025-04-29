using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Day2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStdF = new AddStudentForm();
            addStdF.Show(this);
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listStudentForm listStdForm = new listStudentForm();
            listStdForm.Show(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateDeleteStudentForm upDelStd = new updateDeleteStudentForm();
            upDelStd.Show(this);
        }

        private void staticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistic state = new Statistic();
            state.Show(this);
        }

        private void manageStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentForm mStdForm = new ManageStudentForm();
            mStdForm.Show(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterStudentsForm PrintStdForm = new PrinterStudentsForm();
            PrintStdForm.Show();
        }

        private void addCourse_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourse addCourse = new AddCourse();
            addCourse.Show();
        }

        private void remove_CourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCourseForm reCourse = new RemoveCourseForm();
            reCourse.Show();
        }

        private void editCourse_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCourseForm editCourse = new EditCourseForm();
            editCourse.Show();
        }

        private void manageCourses_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCoursesForm manageCoursesForm = new ManageCoursesForm();
            manageCoursesForm.Show();
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreForm addScore = new AddScoreForm();
            addScore.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void decentralizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
        }

        private void print_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintCourseForm printCourseForm = new PrintCourseForm();
            printCourseForm.Show();
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScoreForm removeScoreForm = new RemoveScoreForm();
            removeScoreForm.Show();
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScoreForm manageScoreForm = new ManageScoreForm();
            manageScoreForm.Show();
        }

        private void avgScoreByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AverageScoreForm averageScoreForm = new AverageScoreForm();
            averageScoreForm.Show();
        }

        private void aVGResultByScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultForm resultForm = new ResultForm();
            resultForm.Show();
        }

        private void statisticResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staticresult staticresult = new Staticresult();
            staticresult.Show();
        }

        private void printResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintScoreForm printScoreForm = new PrintScoreForm();
            printScoreForm.Show();
        }
    }
}
