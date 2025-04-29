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

namespace Login_Day2
{
    public partial class CoursesStdList : Form
    {
        private string courseId;
        private string courseName;
        private int semester;

        MY_DB db = new MY_DB();
        public CoursesStdList()
        {
            InitializeComponent();
        }
        public CoursesStdList(string courseId, string courseName, int semester)
        {
            InitializeComponent();
            this.courseId = courseId;
            this.courseName = courseName;
            this.semester = semester;

            LoadCourseDetails();
            LoadStudents();
        }
        private void CoursesStdList_Load(object sender, EventArgs e)
        {

        }
        private void LoadCourseDetails()
        {
            CourseName_textBox.Text = courseName;
            Semester_lb.Text = "Semester: " + semester;
        }

        // Load danh sách sinh viên đăng ký môn học
        private void LoadStudents()
        {
            try
            {
                // Truy vấn danh sách sinh viên từ bảng StudentCourses và std
                SqlCommand command = new SqlCommand(
                    "SELECT s.Id, s.fname, s.lname, s.bdate, s.gender, s.phone, s.address, s.picture " +
                    "FROM std s " +
                    "JOIN StudentCourses sc ON s.Id = sc.StudentID " +
                    "WHERE sc.CourseID = @cid AND sc.Period = @period", db.getConnection);
                command.Parameters.AddWithValue("@cid", courseId);
                command.Parameters.AddWithValue("@period", semester);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable studentTable = new DataTable();
                adapter.Fill(studentTable);

                // Hiển thị danh sách sinh viên trong DataGridView
                DisplayCourseStd_dataGridView.DataSource = studentTable;

                // Đặt tiêu đề cột cho dễ đọc
                DisplayCourseStd_dataGridView.Columns["Id"].HeaderText = "Student ID";
                DisplayCourseStd_dataGridView.Columns["fname"].HeaderText = "First Name";
                DisplayCourseStd_dataGridView.Columns["lname"].HeaderText = "Last Name";
                DisplayCourseStd_dataGridView.Columns["bdate"].HeaderText = "Date of Birth";
                DisplayCourseStd_dataGridView.Columns["gender"].HeaderText = "Gender";
                DisplayCourseStd_dataGridView.Columns["phone"].HeaderText = "Phone";
                DisplayCourseStd_dataGridView.Columns["address"].HeaderText = "Address";
                DisplayCourseStd_dataGridView.Columns["picture"].HeaderText = "Picture";

                // Hiển thị hình ảnh nếu có
                if (DisplayCourseStd_dataGridView.Columns["picture"] != null)
                {
                    DisplayCourseStd_dataGridView.Columns["picture"].Visible = true;
                    ((DataGridViewImageColumn)DisplayCourseStd_dataGridView.Columns["picture"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Error");
            }
        }

        private void DisplayCourseStd_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
