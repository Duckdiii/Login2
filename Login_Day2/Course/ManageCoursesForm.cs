using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login_Day2
{
    public partial class ManageCoursesForm : Form
    {
        COURSE course = new COURSE();
        MY_DB db = new MY_DB();
        private int pos;
        public ManageCoursesForm()
        {
            InitializeComponent();
        }

        private void ManageCoursesForm_Load(object sender, EventArgs e)
        {
            reloadListBoxData();
        }
        void reloadListBoxData()
        {
            DataTable dt = new DataTable();
            course.getAllCourses(ref dt); 
            CoursesDisplay_listBox.DataSource = dt;
            CoursesDisplay_listBox.ValueMember = "Id";
            CoursesDisplay_listBox.DisplayMember = "label"; 
            CoursesDisplay_listBox.SelectedItem = null;

            TotalCoursesNum_lb.Text = ("TOTAL Courses: " + course.totalCourses());
        }

        void showData(int index)
        {
            DataTable dt = new DataTable();
            course.getAllCourses(ref dt);
            DataRow dr = dt.Rows[index];
            CoursesDisplay_listBox.SelectedIndex = index;
            IDCourse_textBox.Text = dr.ItemArray[0].ToString();
            NameCourse_textBox.Text = dr.ItemArray[1].ToString();
            Semester_textBox.Text = dr.ItemArray[2].ToString();
            HoursNum_numericUpDown.Value = int.Parse(dr.ItemArray[3].ToString());
            CourseDescription_richTextBox.Text = dr.ItemArray[4].ToString();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CoursesDisplay_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CoursesDisplay_listBox_Click(object sender, EventArgs e)
        {
            if (CoursesDisplay_listBox.SelectedItem == null) return; 
            DataRowView drv = (DataRowView)CoursesDisplay_listBox.SelectedItem;
            pos = CoursesDisplay_listBox.SelectedIndex;
            showData(pos);
        }

        private void AddCourse_btn_Click(object sender, EventArgs e)
        {
            string name = NameCourse_textBox.Text;
            string hrs = HoursNum_numericUpDown.Value.ToString(); 
            string descr = CourseDescription_richTextBox.Text;
            string id = IDCourse_textBox.Text; 

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please Enter A Course ID", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (name.Trim() == "")
            {
                MessageBox.Show("Add A Course Name", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (course.checkCourseName(id, name))
            {
                MessageBox.Show("This Course Name Already Exists", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (course.insertCourse(id, name, hrs, descr,Convert.ToInt16(Semester_textBox.Text)))
                {
                    MessageBox.Show("Course Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reloadListBoxData();
                }
                else
                {
                    MessageBox.Show("Course Not Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void EditCourse_btn_Click(object sender, EventArgs e)
        {
            string name = NameCourse_textBox.Text;
            int hrs = (int)HoursNum_numericUpDown.Value; 
            string descr = CourseDescription_richTextBox.Text;
            string id=IDCourse_textBox.Text;

            DataTable dt = new DataTable();
            course.getCourseById(id, ref dt);
            bool nameExists = dt.Rows.Count > 0 && dt.Rows[0]["label"].ToString() != name && course.checkCourseName(id,name);

            if (nameExists)
            {
                MessageBox.Show("This Course Name Already Exists", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (course.updateCourse(id,  name, hrs, descr))
            {
                MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reloadListBoxData();
            }
            else
            {
                MessageBox.Show("Course Not Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pos = 0;
        }

        private void RemoveCourse_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string courseID = IDCourse_textBox.Text;
                if ((MessageBox.Show("Are You Sure You Want To Delete This Course", "Remove Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (course.deleteCourse(courseID))
                    {
                        MessageBox.Show("Course Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IDCourse_textBox.Text = "";
                        NameCourse_textBox.Text = "";
                        HoursNum_numericUpDown.Value = 10;
                        CourseDescription_richTextBox.Text = "";
                        reloadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("Course Not Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter A Valid Numeric ID", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FirstPos_btn_Click(object sender, EventArgs e)
        {
            pos = 0;
            showData(pos);
        }

        private void NextPos_btn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            course.getAllCourses(ref dt);
            if (pos < (dt.Rows.Count - 1))
            {
                pos = pos + 1;
                showData(pos);
            }
        }

        private void PreviousPos_btn_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos = pos - 1;
                showData(pos);
            }
        }

        private void LastPos_btn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            course.getAllCourses(ref dt);
            pos = dt.Rows.Count - 1;
            showData(pos);
        }

        private void CoursesDisplay_listBox_DoubleClick(object sender, EventArgs e)
        {
            if (CoursesDisplay_listBox.SelectedItem != null)
            {
                DataRowView selectedCourse = (DataRowView)CoursesDisplay_listBox.SelectedItem;
                string courseId = selectedCourse["CourseID"].ToString();
                string courseName = selectedCourse["CourseName"].ToString();

                // Lấy học kỳ của môn học (Period) từ bảng StudentCourses
                int semester = 0;
                SqlCommand command = new SqlCommand("SELECT TOP 1 Period FROM StudentCourses WHERE CourseID = @cid", db.getConnection);
                command.Parameters.AddWithValue("@cid", courseId);
                db.openConnection();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    semester = reader.GetInt32(0);
                }
                reader.Close();
                db.closeConnection();

                // Mở form CoursesStdList và truyền thông tin môn học
                CoursesStdList form = new CoursesStdList(courseId, courseName, semester);
                form.ShowDialog();
            }
        }
    }
}
