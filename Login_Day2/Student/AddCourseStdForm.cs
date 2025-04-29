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
    public partial class AddCourseStdForm : Form
    {
        MY_DB db = new MY_DB();

        public AddCourseStdForm()
        {
            InitializeComponent();
            LoadSemesters();
            LoadAvailableCourses();
        }

        private void AddCourseStdForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadSemesters()
        {
            Semester_comboBox.Items.AddRange(new string[] { "1", "2", "3"});
            Semester_comboBox.SelectedIndex = 0; 
        }

        private void LoadAvailableCourses()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT Id, label FROM Course Where semester = @semester", db.getConnection);
                command.Parameters.AddWithValue("@semester", Convert.ToInt32(Semester_comboBox.Text));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable courseTable = new DataTable();
                adapter.Fill(courseTable);

                AvailableCourse_listBox.DisplayMember = "label"; // Hiển thị tên môn học
                AvailableCourse_listBox.ValueMember = "Id"; // Giá trị là Id của môn học
                AvailableCourse_listBox.DataSource = courseTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message, "Error");
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (AvailableCourse_listBox.SelectedItem != null)
            {
                // Lấy môn học được chọn từ AvailableCourse_listBox
                DataRowView selectedCourse = (DataRowView)AvailableCourse_listBox.SelectedItem;
                string courseId = selectedCourse["Id"].ToString();
                string courseName = selectedCourse["label"].ToString();

                // Kiểm tra xem môn học đã có trong SelectedCourse_listBox chưa
                bool alreadySelected = false;
                foreach (DataRowView item in SelectedCourse_listBox.Items)
                {
                    if (item["Id"].ToString() == courseId)
                    {
                        alreadySelected = true;
                        break;
                    }
                }

                if (!alreadySelected)
                {
                    // Thêm môn học vào SelectedCourse_listBox
                    DataTable selectedCourses = (DataTable)SelectedCourse_listBox.DataSource;
                    if (selectedCourses == null)
                    {
                        selectedCourses = new DataTable();
                        selectedCourses.Columns.Add("Id", typeof(string));
                        selectedCourses.Columns.Add("label", typeof(string));
                    }

                    selectedCourses.Rows.Add(courseId, courseName);
                    SelectedCourse_listBox.DisplayMember = "label";
                    SelectedCourse_listBox.ValueMember = "Id";
                    SelectedCourse_listBox.DataSource = selectedCourses;
                }
                else
                {
                    MessageBox.Show("This course is already selected!", "Warning");
                }
            }
            else
            {
                MessageBox.Show("Please select a course to add!", "Warning");
            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string studentId = StudentID_textBox.Text.Trim();
                string semester = Semester_comboBox.SelectedItem?.ToString();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(studentId))
                {
                    MessageBox.Show("Please enter a Student ID!", "Error");
                    return;
                }
                if (string.IsNullOrEmpty(semester))
                {
                    MessageBox.Show("Please select a semester!", "Error");
                    return;
                }
                if (SelectedCourse_listBox.Items.Count == 0)
                {
                    MessageBox.Show("Please select at least one course!", "Error");
                    return;
                }

                // Mở kết nối cơ sở dữ liệu
                db.openConnection();

                // Lấy họ tên sinh viên từ bảng Student (giả định bạn có bảng Student)
                string stdFullName = "";
                SqlCommand getStudentCmd = new SqlCommand("SELECT fname + ' ' + lname AS FullName FROM std WHERE Id = @sid", db.getConnection);
                getStudentCmd.Parameters.AddWithValue("@sid", studentId);
                SqlDataReader reader = getStudentCmd.ExecuteReader();
                if (reader.Read())
                {
                    stdFullName = reader["FullName"].ToString();
                }
                reader.Close();

                if (string.IsNullOrEmpty(stdFullName))
                {
                    MessageBox.Show("Student ID not found!", "Error");
                    return;
                }

                // Lưu từng môn học đã chọn vào bảng StudentCourses
                foreach (DataRowView item in SelectedCourse_listBox.Items)
                {
                    string courseId = item["Id"].ToString();
                    string courseName = item["label"].ToString();

                    SqlCommand command = new SqlCommand("INSERT INTO StudentCourses (StudentID, CourseID, StdFullName, CourseName, Period) " +
                                                        "VALUES (@sid, @cid, @sname, @cname, @period)", db.getConnection);
                    command.Parameters.AddWithValue("@sid", studentId);
                    command.Parameters.AddWithValue("@cid", courseId);
                    command.Parameters.AddWithValue("@sname", stdFullName);
                    command.Parameters.AddWithValue("@cname", courseName);
                    command.Parameters.AddWithValue("@period", Convert.ToInt32(semester));

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Courses saved successfully!", "Success");
                this.Close(); // Đóng form sau khi lưu thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving courses: " + ex.Message, "Error");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void Semester_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Semester_comboBox_TextChanged(object sender, EventArgs e)
        {
            LoadAvailableCourses();
        }
    }
}
