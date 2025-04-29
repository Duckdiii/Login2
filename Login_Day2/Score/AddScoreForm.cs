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
    public partial class AddScoreForm : Form
    {
        Score score = new Score();
        COURSE course = new COURSE();
        MY_DB mydb = new MY_DB();
        private List<string> studentIds = new List<string>();
        public AddScoreForm()
        {
            InitializeComponent();
        }

        private void AddScoreForm_Load(object sender, EventArgs e)
        {
            StudentID_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            StudentID_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            showDataCourse();
            showDataScore();
            LoadStudentIDs();

        }
        private void LoadStudentIDs(string filter = "")
        {
            try
            {
                // Chỉ truy vấn cơ sở dữ liệu nếu danh sách chưa được nạp hoặc filter rỗng
                if (string.IsNullOrEmpty(filter) || studentIds.Count == 0)
                {
                    mydb.openConnection();
                    string query = "SELECT Id FROM std";
                    SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    studentIds.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        studentIds.Add(row["Id"].ToString());
                    }
                    mydb.closeConnection();
                }

                // Lọc cục bộ
                StudentID_comboBox.Items.Clear();
                var filteredIds = studentIds.Where(id => id.Contains(filter)).ToList();
                StudentID_comboBox.Items.AddRange(filteredIds.ToArray());

                // Mở danh sách thả xuống nếu có dữ liệu và người dùng đang nhập
                if (!string.IsNullOrEmpty(filter) && filteredIds.Count > 0)
                {
                    StudentID_comboBox.DroppedDown = true;
                }
                else
                {
                    StudentID_comboBox.DroppedDown = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void showDataScore()
        {
            DataTable dt = new DataTable();
            try
            {
                score.getAllScoresByStdID(ref dt);

                // Clear existing rows in DataGridView
                StudentScoreInfo_dataGridView.Rows.Clear();

                // Populate DataGridView with scores, including student names and course labels
                foreach (DataRow row in dt.Rows)
                {
                    int studentId = Convert.ToInt32(row["StudentID"]);
                    string courseId = row["CourseID"].ToString();
                    float studentScore = Convert.ToSingle(row["StudentScore"]);

                    // Lấy thông tin sinh viên và môn học từ DataTable
                    string firstName = row["fname"].ToString();
                    string lastName = row["lname"].ToString();
                    string courseLabel = row["CourseLabel"].ToString();

                    // Add to DataGridView
                    StudentScoreInfo_dataGridView.Rows.Add(studentId, firstName, lastName, courseLabel, studentScore);
                }

                // Nếu không có bản ghi nào, hiển thị thông báo
                if (StudentScoreInfo_dataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Không có điểm số nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void showDataCourse(string studentId = "")
        {
            SelectCourse_comboBox.Items.Clear();
            SelectCourse_comboBox.Enabled = true; // Mặc định bật


            try
            {
                // Kiểm tra xem sinh viên có tồn tại trong bảng std không
                SqlCommand cmdCheckStd = new SqlCommand("SELECT COUNT(*) FROM std WHERE Id = @id", mydb.getConnection);
                cmdCheckStd.Parameters.AddWithValue("@id", studentId);
                mydb.openConnection();
                int studentCount = (int)cmdCheckStd.ExecuteScalar();

                // Lấy các môn học mà sinh viên đã đăng ký
                DataTable dt = new DataTable();
                string query = @"
            SELECT c.Id, c.label, c.period, c.description
            FROM Course c
            INNER JOIN StudentCourses sc ON c.Id = sc.CourseID
            WHERE sc.StudentID = @studentId";

                SqlCommand command = new SqlCommand(query, mydb.getConnection);
                command.Parameters.AddWithValue("@studentId", studentId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);

                // Hiển thị danh sách môn học trong SelectCourse_comboBox
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string courseInfo = dt.Rows[i]["label"].ToString() + " - " + dt.Rows[i]["period"].ToString();
                    SelectCourse_comboBox.Items.Add(courseInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectCourse_comboBox.Items.Add("Đã xảy ra lỗi khi tải danh sách môn học.");
                SelectCourse_comboBox.SelectedIndex = 0;
                SelectCourse_comboBox.Enabled = false;
            }
            finally
            {
                mydb.closeConnection();
            }
        }
        private void AddScore_btn_Click(object sender, EventArgs e)
        {
            string StdID = StudentID_comboBox.Text;
            string Course = SelectCourse_comboBox.Text;

            // Kiểm tra điểm số
            if (!float.TryParse(StudentScore_textBox.Text, out float scoreValue))
            {
                MessageBox.Show("Vui lòng nhập điểm số hợp lệ.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (scoreValue < 0 || scoreValue > 10)
            {
                MessageBox.Show("Điểm số phải nằm trong khoảng từ 0 đến 10.", "Điểm số không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin sinh viên
            string firstName = "", lastName = "";
            SqlCommand cmdFindStd = new SqlCommand("SELECT fname, lname FROM std WHERE Id = @id", mydb.getConnection);
            cmdFindStd.Parameters.AddWithValue("@id", StdID); // Sử dụng số nguyên đã được chuyển đổi
            try
            {
                mydb.openConnection();
                SqlDataReader reader = cmdFindStd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Không tìm thấy sinh viên.", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reader.Close();
                    return;
                }
                firstName = reader["fname"].ToString();
                lastName = reader["lname"].ToString();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                mydb.closeConnection();
            }

            // Lấy mã môn học
            string courseId = course.FindCourseID(SelectCourse_comboBox.Text);
            if (string.IsNullOrEmpty(courseId))
            {
                MessageBox.Show("Môn học được chọn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra điểm số trùng lặp
            try
            {
                if (score.studentScoreExist(Convert.ToInt32(StdID), courseId))
                {
                    MessageBox.Show("Điểm số cho sinh viên và môn học này đã tồn tại.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra điểm số trùng lặp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thêm điểm số
            bool success = score.insertScore(Convert.ToInt32(StdID), courseId, scoreValue, Description_richTextBox.Text);
            if (success)
            {
                MessageBox.Show("Thêm điểm số thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Làm mới DataGridView
                showDataScore();
                // Xóa trắng các trường nhập liệu
                StudentID_comboBox.Text = "";
                StudentID_comboBox.SelectedIndex = -1;
                StudentScore_textBox.Clear();
                Description_richTextBox.Clear();
                SelectCourse_comboBox.SelectedIndex = -1;
                LoadStudentIDs(); // Làm mới danh sách ID
            }
            else
            {
                MessageBox.Show("Không thể thêm điểm số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StudentID_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số và dấu chấm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StudentScore_textBox.BackColor = Color.IndianRed;
            }
            else
            {
                StudentScore_textBox.BackColor = SystemColors.Window;
            }
        }

        private void StudentID_comboBox_KeyUp(object sender, KeyEventArgs e)
        {
            // Lưu vị trí con trỏ và văn bản hiện tại
            int selectionStart = StudentID_comboBox.SelectionStart;
            string currentText = StudentID_comboBox.Text;

            // Tải danh sách mã số, ngoại trừ phím điều hướng
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Enter)
            {
                LoadStudentIDs(currentText);

                // Khôi phục văn bản và con trỏ
                StudentID_comboBox.Text = currentText;
                StudentID_comboBox.SelectionStart = selectionStart;
            }
        }

        private void StudentID_comboBox_TextChanged(object sender, EventArgs e)
        {
            string studentId = StudentID_comboBox.Text.Trim();
            showDataCourse(studentId);
        }

        private void SelectCourse_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentID_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
