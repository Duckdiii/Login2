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
    public partial class ManageScoreForm : Form
    {
        MY_DB db = new MY_DB();
        public ManageScoreForm()
        {
            InitializeComponent();

        }
        private void LoadStudents()
        {
            try
            {
                db.openConnection();
                string query = "SELECT Id, fname + ' ' + lname AS FullName FROM dbo.std";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.getConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                StudentID_comboBox.DataSource = dt;
                StudentID_comboBox.DisplayMember = "FullName"; // Hiển thị tên sinh viên
                StudentID_comboBox.ValueMember = "Id"; // Giá trị là mã sinh viên
                StudentID_comboBox.SelectedIndex = -1; // Không chọn mặc định

                Display_dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }
        private void LoadScores()
        {
            try
            {
                db.openConnection();
                string query = "SELECT s.StudentID, st.fname + ' ' + st.lname AS StudentName, s.CourseID, s.StudentScore, s.Description " +
                               "FROM dbo.Score s JOIN dbo.std st ON s.StudentID = st.Id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.getConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                Display_dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading scores: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }
        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadAllCourses();
            // Ban đầu vô hiệu hóa SelectCourse_comboBox cho đến khi chọn sinh viên
            SelectCourse_comboBox.DataSource = null;
            SelectCourse_comboBox.Items.Clear();
            SelectCourse_comboBox.Items.Add("Vui lòng chọn sinh viên trước.");
            SelectCourse_comboBox.SelectedIndex = 0;
            SelectCourse_comboBox.Enabled = false;
        }

        private void AddScore_btn_Click(object sender, EventArgs e)
        {
            Score score = new Score();
            COURSE course = new COURSE();

            // Kiểm tra các trường bắt buộc
            if (StudentID_comboBox.SelectedValue == null ||
                SelectCourse_comboBox.SelectedValue == null ||
                string.IsNullOrEmpty(Score_textBox.Text))
            {
                MessageBox.Show("Please fill in all required fields (Student ID, Course, Score).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy StudentID và CourseID
            int studentId = Convert.ToInt32(StudentID_comboBox.SelectedValue);
            string courseId = SelectCourse_comboBox.SelectedValue.ToString();

            // Kiểm tra xem sinh viên đã đăng ký môn học chưa
            try
            {
                if (!course.IsStudentEnrolled(studentId, courseId))
                {
                    MessageBox.Show("Sinh viên chưa đăng ký môn học này. Vui lòng đăng ký trước khi thêm điểm.",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra điểm số hợp lệ
            if (!float.TryParse(Score_textBox.Text, out float scoreValue))
            {
                MessageBox.Show("Vui lòng nhập điểm số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (scoreValue < 0 || scoreValue > 10)
            {
                MessageBox.Show("Điểm số phải nằm trong khoảng từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thêm điểm
            try
            {
                db.openConnection();
                if (score.insertScore(studentId, courseId, scoreValue, Description_richTextBox.Text))
                {
                    MessageBox.Show("Score added successfully!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadScores(); // Làm mới dữ liệu sau khi thêm
                }
                else
                {
                    MessageBox.Show("Failed to add score.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding score: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void RemoveScore_btn_Click(object sender, EventArgs e)
        {
            RemoveScoreForm RemoveScore = new RemoveScoreForm();
            RemoveScore.Show();
        }

        private void AverageScore_btn_Click(object sender, EventArgs e)
        {
            Score score = new Score();
            DataTable dt = score.getAvgScoreByCourse();
            Display_dataGridView.DataSource = dt;

        }

        private void ShowStudent_btn_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void ShowScore_btn_Click(object sender, EventArgs e)
        {
            LoadScores();
        }

        private void Display_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem RowIndex có hợp lệ không
            if (e.RowIndex < 0 || e.RowIndex >= Display_dataGridView.Rows.Count)
            {
                return; // Thoát nếu không có dòng hợp lệ
            }

            // Lấy dòng được chọn
            DataGridViewRow row = Display_dataGridView.Rows[e.RowIndex];

            try
            {
                // Kiểm tra xem các cột cần thiết có tồn tại không
                bool hasRequiredColumns = Display_dataGridView.Columns.Contains("StudentID") &&
                                          Display_dataGridView.Columns.Contains("CourseID") &&
                                          Display_dataGridView.Columns.Contains("StudentScore") &&
                                          Display_dataGridView.Columns.Contains("Description");

                if (!hasRequiredColumns)
                {
                    MessageBox.Show("Dữ liệu hiện tại không chứa thông tin điểm số. Vui lòng hiển thị danh sách điểm trước (nút Show Score).",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy giá trị từ các cột
                string studentId = row.Cells["StudentID"].Value?.ToString();
                string courseId = row.Cells["CourseID"].Value?.ToString();
                string studentScore = row.Cells["StudentScore"].Value?.ToString();
                string description = row.Cells["Description"].Value?.ToString();

                // Điền dữ liệu vào các điều khiển
                if (!string.IsNullOrEmpty(studentId))
                {
                    StudentID_comboBox.SelectedValue = studentId; // Đặt giá trị cho ComboBox
                }
                else
                {
                    StudentID_comboBox.SelectedIndex = -1;
                }

                SelectCourse_comboBox.Text = courseId ?? string.Empty;
                Score_textBox.Text = studentScore ?? string.Empty;
                Description_richTextBox.Text = description ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ DataGridView: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Display_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void UpdateCourseComboBox(string studentIdText)
        {
            SelectCourse_comboBox.DataSource = null;
            SelectCourse_comboBox.Items.Clear();
            SelectCourse_comboBox.Enabled = false;

            // Kiểm tra StudentID có hợp lệ không
            if (!int.TryParse(studentIdText, out int studentId))
            {
                SelectCourse_comboBox.Items.Add("Vui lòng nhập mã sinh viên hợp lệ.");
                SelectCourse_comboBox.SelectedIndex = 0;
                return;
            }

            // Kiểm tra sinh viên có tồn tại không
            SqlCommand cmdCheckStd = new SqlCommand("SELECT COUNT(*) FROM std WHERE Id = @id", db.getConnection);
            cmdCheckStd.Parameters.AddWithValue("@id", studentId);

            try
            {
                db.openConnection();
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
                db.closeConnection();
            }

            // Lấy danh sách môn học mà sinh viên đã đăng ký từ bảng StudentCourses
            string query = @"
                SELECT DISTINCT c.Id, c.label 
                FROM Course c
                INNER JOIN StudentCourses sc ON c.Id = sc.CourseID
                WHERE sc.StudentID = @studentId";

            SqlCommand command = new SqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@studentId", studentId);

            try
            {
                db.openConnection();
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
                db.closeConnection();
            }
        }
        private void LoadAllCourses()
        {
            try
            {
                db.openConnection();
                string query = "SELECT Id, label FROM Course";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.getConnection);
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
                SelectCourse_comboBox.SelectedIndex = -1;
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
                db.closeConnection();
            }
        }
        private void StudentID_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudentID_comboBox.SelectedValue != null)
            {
                UpdateCourseComboBox(StudentID_comboBox.SelectedValue.ToString());
            }
        }

        private void StudentID_comboBox_TextChanged(object sender, EventArgs e)
        {
            string studentId = StudentID_comboBox.Text.Trim();
            UpdateCourseComboBox(studentId);

        }
    }
}
