using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Day2
{
    public partial class ResultForm : Form
    {
        MY_DB db = new MY_DB();
        Score score = new Score();
        public ResultForm()
        {
            InitializeComponent();
            LoadAllStudents();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadAllStudents()
        {
            try
            {
                // Bước 1: Lấy danh sách tất cả môn học từ StudentCourses
                List<string> courseList = new List<string>();
                Dictionary<string, string> courseNameMapping = new Dictionary<string, string>(); // Lưu CourseID -> CourseName
                SqlCommand courseCmd = new SqlCommand("SELECT DISTINCT CourseID, CourseName FROM StudentCourses", db.getConnection);
                db.openConnection();
                SqlDataReader courseReader = courseCmd.ExecuteReader();
                while (courseReader.Read())
                {
                    string courseId = courseReader["CourseID"].ToString();
                    string courseName = courseReader["CourseName"].ToString();
                    courseList.Add(courseId);
                    courseNameMapping[courseId] = courseName;
                }
                courseReader.Close();

                // Bước 2: Tạo DataTable với các cột động
                DataTable studentTable = new DataTable();
                studentTable.Columns.Add("StudentID", typeof(int));
                studentTable.Columns.Add("FirstName", typeof(string));
                studentTable.Columns.Add("LastName", typeof(string));
                foreach (string courseId in courseList)
                {
                    studentTable.Columns.Add(courseId, typeof(double)); // Cột điểm cho từng môn
                }
                studentTable.Columns.Add("AverageScore", typeof(double));
                studentTable.Columns.Add("Rank", typeof(string));

                // Bước 3: Lấy danh sách sinh viên từ bảng std
                SqlCommand stdCmd = new SqlCommand("SELECT Id, fname, lname FROM std", db.getConnection);
                SqlDataAdapter stdAdapter = new SqlDataAdapter(stdCmd);
                DataTable stdTable = new DataTable();
                stdAdapter.Fill(stdTable);

                // Bước 4: Điền dữ liệu cho từng sinh viên
                foreach (DataRow row in stdTable.Rows)
                {
                    int studentId = Convert.ToInt32(row["Id"]);
                    string firstName = row["fname"].ToString();
                    string lastName = row["lname"].ToString();

                    DataRow newRow = studentTable.NewRow();
                    newRow["StudentID"] = studentId;
                    newRow["FirstName"] = firstName;
                    newRow["LastName"] = lastName;

                    // Lấy điểm của sinh viên cho từng môn
                    double totalScore = 0;
                    int scoreCount = 0;
                    foreach (string courseId in courseList)
                    {
                        SqlCommand scoreCmd = new SqlCommand(
                            "SELECT StudentScore FROM Score WHERE StudentID = @sid AND CourseID = @cid", db.getConnection);
                        scoreCmd.Parameters.AddWithValue("@sid", studentId);
                        scoreCmd.Parameters.AddWithValue("@cid", courseId);
                        object scoreResult = scoreCmd.ExecuteScalar();
                        if (scoreResult != null && scoreResult != DBNull.Value)
                        {
                            double score = Convert.ToDouble(scoreResult);
                            newRow[courseId] = score;
                            totalScore += score;
                            scoreCount++;
                        }
                        else
                        {
                            newRow[courseId] = DBNull.Value; // Không có điểm
                        }
                    }

                    // Tính điểm trung bình
                    double avgScore = scoreCount > 0 ? totalScore / scoreCount : 0;
                    newRow["AverageScore"] = avgScore;

                    // Xếp loại
                    newRow["Rank"] = GetRank(avgScore);

                    studentTable.Rows.Add(newRow);
                }

                // Bước 5: Hiển thị lên DataGridView
                DisplayResult_dataGridView.DataSource = studentTable;

                // Đặt tiêu đề cột
                DisplayResult_dataGridView.Columns["StudentID"].HeaderText = "Student ID";
                DisplayResult_dataGridView.Columns["FirstName"].HeaderText = "First Name";
                DisplayResult_dataGridView.Columns["LastName"].HeaderText = "Last Name";
                foreach (string courseId in courseList)
                {
                    DisplayResult_dataGridView.Columns[courseId].HeaderText = courseNameMapping[courseId]; // Đặt tiêu đề cột là tên môn học
                }
                DisplayResult_dataGridView.Columns["AverageScore"].HeaderText = "Average Score";
                DisplayResult_dataGridView.Columns["Rank"].HeaderText = "Rank";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Error");
            }
            finally
            {
                db.closeConnection();
            }
        }
        private string GetRank(double avgScore)
        {
            if (avgScore >= 8.5) return "Giỏi";
            if (avgScore >= 7.0) return "Khá";
            if (avgScore >= 5.0) return "Trung bình";
            return "Yếu";
        }

        private void SpecificSearch_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string studentIdText = StudentID_textBox.Text.Trim();
                string firstName = Fname_textBox.Text.Trim();
                string lastName = Lname_textBox.Text.Trim();

                if (string.IsNullOrEmpty(studentIdText) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                {
                    MessageBox.Show("Please enter at least one search criterion!", "Warning");
                    return;
                }

                // Xây dựng truy vấn tìm kiếm sinh viên
                string query = "SELECT Id, fname, lname FROM std WHERE 1=1";
                if (!string.IsNullOrEmpty(studentIdText) && int.TryParse(studentIdText, out int studentId))
                {
                    query += " AND Id = @sid";
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    query += " AND fname LIKE @fname";
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    query += " AND lname LIKE @lname";
                }

                SqlCommand command = new SqlCommand(query, db.getConnection);
                if (!string.IsNullOrEmpty(studentIdText) && int.TryParse(studentIdText, out studentId))
                {
                    command.Parameters.AddWithValue("@sid", studentId);
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    command.Parameters.AddWithValue("@fname", "%" + firstName + "%");
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    command.Parameters.AddWithValue("@lname", "%" + lastName + "%");
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable stdTable = new DataTable();
                adapter.Fill(stdTable);

                if (stdTable.Rows.Count == 0)
                {
                    MessageBox.Show("No student found!", "Information");
                    return;
                }

                // Lấy danh sách môn học để tạo cột động
                List<string> courseList = new List<string>();
                Dictionary<string, string> courseNameMapping = new Dictionary<string, string>();
                SqlCommand courseCmd = new SqlCommand("SELECT DISTINCT CourseID, CourseName FROM StudentCourses", db.getConnection);
                db.openConnection();
                SqlDataReader courseReader = courseCmd.ExecuteReader();
                while (courseReader.Read())
                {
                    string courseId = courseReader["CourseID"].ToString();
                    string courseName = courseReader["CourseName"].ToString();
                    courseList.Add(courseId);
                    courseNameMapping[courseId] = courseName;
                }
                courseReader.Close();

                // Tạo DataTable kết quả
                DataTable resultTable = new DataTable();
                resultTable.Columns.Add("StudentID", typeof(int));
                resultTable.Columns.Add("FirstName", typeof(string));
                resultTable.Columns.Add("LastName", typeof(string));
                foreach (string courseId in courseList)
                {
                    resultTable.Columns.Add(courseId, typeof(double));
                }
                resultTable.Columns.Add("AverageScore", typeof(double));
                resultTable.Columns.Add("Rank", typeof(string));

                // Điền dữ liệu cho sinh viên tìm thấy
                foreach (DataRow row in stdTable.Rows)
                {
                    int foundStudentId = Convert.ToInt32(row["Id"]);
                    string foundFirstName = row["fname"].ToString();
                    string foundLastName = row["lname"].ToString();

                    DataRow newRow = resultTable.NewRow();
                    newRow["StudentID"] = foundStudentId;
                    newRow["FirstName"] = foundFirstName;
                    newRow["LastName"] = foundLastName;

                    double totalScore = 0;
                    int scoreCount = 0;
                    foreach (string courseId in courseList)
                    {
                        SqlCommand scoreCmd = new SqlCommand(
                            "SELECT StudentScore FROM Score WHERE StudentID = @sid AND CourseID = @cid", db.getConnection);
                        scoreCmd.Parameters.AddWithValue("@sid", foundStudentId);
                        scoreCmd.Parameters.AddWithValue("@cid", courseId);
                        object scoreResult = scoreCmd.ExecuteScalar();
                        if (scoreResult != null && scoreResult != DBNull.Value)
                        {
                            double score = Convert.ToDouble(scoreResult);
                            newRow[courseId] = score;
                            totalScore += score;
                            scoreCount++;
                        }
                        else
                        {
                            newRow[courseId] = DBNull.Value;
                        }
                    }

                    double avgScore = scoreCount > 0 ? totalScore / scoreCount : 0;
                    newRow["AverageScore"] = avgScore;
                    newRow["Rank"] = GetRank(avgScore);

                    resultTable.Rows.Add(newRow);
                }

                // Hiển thị lên DataGridView
                DisplayResult_dataGridView.DataSource = resultTable;

                // Đặt tiêu đề cột
                DisplayResult_dataGridView.Columns["StudentID"].HeaderText = "Student ID";
                DisplayResult_dataGridView.Columns["FirstName"].HeaderText = "First Name";
                DisplayResult_dataGridView.Columns["LastName"].HeaderText = "Last Name";
                foreach (string courseId in courseList)
                {
                    DisplayResult_dataGridView.Columns[courseId].HeaderText = courseNameMapping[courseId];
                }
                DisplayResult_dataGridView.Columns["AverageScore"].HeaderText = "Average Score";
                DisplayResult_dataGridView.Columns["Rank"].HeaderText = "Rank";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching student: " + ex.Message, "Error");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = Search_textBox.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    MessageBox.Show("Please enter a search term!", "Warning");
                    return;
                }

                // Tìm kiếm theo ID hoặc FirstName
                string query = "SELECT Id, fname, lname FROM std WHERE Id LIKE @search OR fname LIKE @search";
                SqlCommand command = new SqlCommand(query, db.getConnection);
                command.Parameters.AddWithValue("@search", "%" + searchText + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable stdTable = new DataTable();
                adapter.Fill(stdTable);

                if (stdTable.Rows.Count == 0)
                {
                    MessageBox.Show("No students found!", "Information");
                    return;
                }

                // Lấy danh sách môn học để tạo cột động
                List<string> courseList = new List<string>();
                Dictionary<string, string> courseNameMapping = new Dictionary<string, string>();
                SqlCommand courseCmd = new SqlCommand("SELECT DISTINCT CourseID, CourseName FROM StudentCourses", db.getConnection);
                db.openConnection();
                SqlDataReader courseReader = courseCmd.ExecuteReader();
                while (courseReader.Read())
                {
                    string courseId = courseReader["CourseID"].ToString();
                    string courseName = courseReader["CourseName"].ToString();
                    courseList.Add(courseId);
                    courseNameMapping[courseId] = courseName;
                }
                courseReader.Close();

                // Tạo DataTable kết quả
                DataTable resultTable = new DataTable();
                resultTable.Columns.Add("StudentID", typeof(int));
                resultTable.Columns.Add("FirstName", typeof(string));
                resultTable.Columns.Add("LastName", typeof(string));
                foreach (string courseId in courseList)
                {
                    resultTable.Columns.Add(courseId, typeof(double));
                }
                resultTable.Columns.Add("AverageScore", typeof(double));
                resultTable.Columns.Add("Rank", typeof(string));

                // Điền dữ liệu cho sinh viên tìm thấy
                foreach (DataRow row in stdTable.Rows)
                {
                    int foundStudentId = Convert.ToInt32(row["Id"]);
                    string foundFirstName = row["fname"].ToString();
                    string foundLastName = row["lname"].ToString();

                    DataRow newRow = resultTable.NewRow();
                    newRow["StudentID"] = foundStudentId;
                    newRow["FirstName"] = foundFirstName;
                    newRow["LastName"] = foundLastName;

                    double totalScore = 0;
                    int scoreCount = 0;
                    foreach (string courseId in courseList)
                    {
                        SqlCommand scoreCmd = new SqlCommand(
                            "SELECT StudentScore FROM Score WHERE StudentID = @sid AND CourseID = @cid", db.getConnection);
                        scoreCmd.Parameters.AddWithValue("@sid", foundStudentId);
                        scoreCmd.Parameters.AddWithValue("@cid", courseId);
                        object scoreResult = scoreCmd.ExecuteScalar();
                        if (scoreResult != null && scoreResult != DBNull.Value)
                        {
                            double score = Convert.ToDouble(scoreResult);
                            newRow[courseId] = score;
                            totalScore += score;
                            scoreCount++;
                        }
                        else
                        {
                            newRow[courseId] = DBNull.Value;
                        }
                    }

                    double avgScore = scoreCount > 0 ? totalScore / scoreCount : 0;
                    newRow["AverageScore"] = avgScore;
                    newRow["Rank"] = GetRank(avgScore);

                    resultTable.Rows.Add(newRow);
                }

                // Hiển thị lên DataGridView
                DisplayResult_dataGridView.DataSource = resultTable;

                // Đặt tiêu đề cột
                DisplayResult_dataGridView.Columns["StudentID"].HeaderText = "Student ID";
                DisplayResult_dataGridView.Columns["FirstName"].HeaderText = "First Name";
                DisplayResult_dataGridView.Columns["LastName"].HeaderText = "Last Name";
                foreach (string courseId in courseList)
                {
                    DisplayResult_dataGridView.Columns[courseId].HeaderText = courseNameMapping[courseId];
                }
                DisplayResult_dataGridView.Columns["AverageScore"].HeaderText = "Average Score";
                DisplayResult_dataGridView.Columns["Rank"].HeaderText = "Rank";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching students: " + ex.Message, "Error");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Print_btn_Click(object sender, EventArgs e)
        {
            // Chọn nơi lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog.Title = "Save results to text file";
            saveFileDialog.FileName = "StudentResults.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Ghi tiêu đề cột
                        for (int i = 0; i < DisplayResult_dataGridView.Columns.Count; i++)
                        {
                            writer.Write(DisplayResult_dataGridView.Columns[i].HeaderText);
                            if (i < DisplayResult_dataGridView.Columns.Count - 1)
                                writer.Write("\t"); // phân cách bằng tab
                        }
                        writer.WriteLine();

                        // Ghi từng dòng dữ liệu
                        foreach (DataGridViewRow row in DisplayResult_dataGridView.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < DisplayResult_dataGridView.Columns.Count; i++)
                                {
                                    writer.Write(row.Cells[i].Value?.ToString());
                                    if (i < DisplayResult_dataGridView.Columns.Count - 1)
                                        writer.Write("\t");
                                }
                                writer.WriteLine();
                            }
                        }
                    }

                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
