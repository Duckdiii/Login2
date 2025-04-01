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
    }
}
