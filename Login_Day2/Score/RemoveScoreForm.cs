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
    public partial class RemoveScoreForm : Form
    {
        MY_DB mydb = new MY_DB();
        Score score = new Score();
        public RemoveScoreForm()
        {
            InitializeComponent();
        }

        private void StudentID_textBox_TextChanged(object sender, EventArgs e)
        {
            UpdateCourseComboBox(StudentID_textBox.Text);
            //FilterScores();
        }

        private void RemoveScore_btn_Click(object sender, EventArgs e)
        {

            // Lấy StudentID và CourseID từ hàng được chọn
            int studentId = Convert.ToInt32(StudentScoreInfo_dataGridView.Rows[0].Cells["StudentID"].Value);
            string courseId = StudentScoreInfo_dataGridView.Rows[0].Cells["CourseID"].Value.ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm của môn học này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool success = score.deleteScore(studentId, courseId);
                if (success)
                {
                    MessageBox.Show("Xóa điểm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FilterScores(); // Làm mới dữ liệu sau khi xóa
                }
                else
                {
                    MessageBox.Show("Không thể xóa điểm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void RemoveScoreForm_Load(object sender, EventArgs e)
        {
            // Điền dữ liệu vào SelectCourse_comboBox
            SqlCommand command = new SqlCommand("SELECT Id, label FROM Course", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            try
            {
                mydb.openConnection();
                adapter.Fill(table);

                SelectCourse_comboBox.DataSource = table;
                SelectCourse_comboBox.DisplayMember = "label"; // Hiển thị tên khóa học
                SelectCourse_comboBox.ValueMember = "Id"; // Giá trị là ID của khóa học
                SelectCourse_comboBox.SelectedIndex = -1; // Không chọn mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mydb.closeConnection();
            }

            // Load dữ liệu điểm vào DataGridView
            LoadScoreData();
            LoadAllCourses();
            //FilterScores();

        }

        private void SelectCourse_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (SelectCourse_comboBox.SelectedIndex != -1)
            //{
                //FilterScores();
            //}
        }
        private void LoadAllCourses()
        {
            try
            {
                mydb.openConnection();
                string query = "SELECT Id, label FROM Course";
                SqlDataAdapter adapter = new SqlDataAdapter(query, mydb.getConnection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    SelectCourse_comboBox.Items.Add("Không có môn học nào trong hệ thống.");
                    SelectCourse_comboBox.SelectedIndex = 0;
                    SelectCourse_comboBox.Enabled = false;
                    return;
                }

                SelectCourse_comboBox.DataSource = table;
                SelectCourse_comboBox.DisplayMember = "label";
                SelectCourse_comboBox.ValueMember = "Id";
                SelectCourse_comboBox.SelectedIndex = -1; // Không chọn mặc định
                SelectCourse_comboBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectCourse_comboBox.Items.Add("Đã xảy ra lỗi khi tải danh sách môn học.");
                SelectCourse_comboBox.SelectedIndex = 0;
                SelectCourse_comboBox.Enabled = false;
            }
            finally
            {
                mydb.closeConnection();
            }
        }
        private void FilterScores()
        {
            // Khởi tạo truy vấn cơ bản
            string query = @"
                SELECT Score.StudentID, std.fname, std.lname, Course.label AS Subject, Score.StudentScore, Score.CourseID 
                FROM Score 
                INNER JOIN std ON Score.StudentID = std.Id 
                INNER JOIN Course ON Score.CourseID = Course.Id 
                WHERE 1=1";

            SqlCommand command = new SqlCommand(query, mydb.getConnection);

            // Kiểm tra và thêm điều kiện cho StudentID
            bool hasStudentId = int.TryParse(StudentID_textBox.Text.Trim(), out int studentId);
            if (hasStudentId)
            {
                query += " AND Score.StudentID = @sid";
                command.Parameters.Add("@sid", SqlDbType.Int).Value = studentId;
            }

            // Kiểm tra và thêm điều kiện cho CourseID
            string courseId = SelectCourse_comboBox.SelectedValue?.ToString();
            bool hasCourseId = !string.IsNullOrEmpty(courseId);
            if (hasCourseId)
            {
                query += " AND Score.CourseID = @cid";
                command.Parameters.Add("@cid", SqlDbType.NVarChar).Value = courseId;
            }

            // Cập nhật truy vấn với các điều kiện đã thêm
            command.CommandText = query;

            // Thực hiện truy vấn và hiển thị dữ liệu
            try
            {
                mydb.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                StudentScoreInfo_dataGridView.DataSource = table;

                // Đảm bảo cột CourseID không hiển thị trong DataGridView (nếu không cần thiết)
                if (StudentScoreInfo_dataGridView.Columns["CourseID"] != null)
                {
                    StudentScoreInfo_dataGridView.Columns["CourseID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc điểm số: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StudentScoreInfo_dataGridView.DataSource = null;
            }
            finally
            {
                mydb.closeConnection();
            }
        }
        private void LoadScoreData()
        {
            SqlCommand command = new SqlCommand(
                "SELECT Score.StudentID, std.fname, std.lname, Course.label AS Subject, Score.StudentScore, Score.CourseID " +
                "FROM Score " +
                "INNER JOIN Std ON Score.StudentID = std.Id " +
                "INNER JOIN Course ON Score.CourseID = Course.Id", mydb.getConnection);

            try
            {
                mydb.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                StudentScoreInfo_dataGridView.DataSource = table;

                // Đảm bảo cột CourseID không hiển thị trong DataGridView (nếu không cần thiết)
                if (StudentScoreInfo_dataGridView.Columns["CourseID"] != null)
                {
                    StudentScoreInfo_dataGridView.Columns["CourseID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StudentScoreInfo_dataGridView.DataSource = null;
            }
            finally
            {
                mydb.closeConnection();
            }
        }
        private void UpdateCourseComboBox(string studentIdText)
        {
            SelectCourse_comboBox.DataSource = null;
            SelectCourse_comboBox.Items.Clear();
            SelectCourse_comboBox.Enabled = false;

            // Kiểm tra StudentID có hợp lệ không
            if (!int.TryParse(studentIdText.Trim(), out int studentId))
            {
                SelectCourse_comboBox.Items.Add("Vui lòng nhập mã sinh viên hợp lệ.");
                SelectCourse_comboBox.SelectedIndex = 0;
                return;
            }

            // Kiểm tra sinh viên có tồn tại không
            SqlCommand cmdCheckStd = new SqlCommand("SELECT COUNT(*) FROM std WHERE Id = @id", mydb.getConnection);
            cmdCheckStd.Parameters.Add("@id", SqlDbType.Int).Value = studentId;

            try
            {
                mydb.openConnection();
                int studentCount = (int)cmdCheckStd.ExecuteScalar();
                if (studentCount == 0)
                {
                    SelectCourse_comboBox.Items.Add("Sinh viên không tồn tại.");
                    SelectCourse_comboBox.SelectedIndex = 0;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                mydb.closeConnection();
            }

            // Lấy danh sách môn học mà sinh viên đã đăng ký từ bảng StudentCourses
            string query = @"
                SELECT DISTINCT c.Id, c.label 
                FROM Course c
                INNER JOIN StudentCourses sc ON c.Id = sc.CourseID
                WHERE sc.StudentID = @studentId";

            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            command.Parameters.Add("@studentId", SqlDbType.Int).Value = studentId;

            try
            {
                mydb.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    SelectCourse_comboBox.Items.Add("Sinh viên chưa đăng ký môn học nào.");
                    SelectCourse_comboBox.SelectedIndex = 0;
                    return;
                }

                SelectCourse_comboBox.DataSource = table;
                SelectCourse_comboBox.DisplayMember = "label";
                SelectCourse_comboBox.ValueMember = "Id";
                SelectCourse_comboBox.SelectedIndex = -1;
                SelectCourse_comboBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectCourse_comboBox.Items.Add("Đã xảy ra lỗi khi tải danh sách môn học.");
                SelectCourse_comboBox.SelectedIndex = 0;
            }
            finally
            {
                mydb.closeConnection();
            }
        }
    }
}
