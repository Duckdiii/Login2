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
    public partial class PrintScoreForm : Form
    {
        MY_DB db = new MY_DB();
        public PrintScoreForm()
        {
            InitializeComponent();
        }

        private void PrintScoreForm_Load(object sender, EventArgs e)
        {
            LoadScores();
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

        private void Print_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn file để lưu kết quả
                string path = @"C:\Users\nguye\Desktop\SourceData\Win\Score.txt";

                // Lấy dữ liệu từ DataGridView (không cần truy vấn lại từ database)
                var studentData = new StringBuilder();

                // Tiêu đề báo cáo
                studentData.AppendLine("ID Number\tName\tDepartment");
                studentData.AppendLine("=========================================================");

                // Duyệt qua từng dòng trong DataGridView
                foreach (DataGridViewRow row in Display_dataGridView.Rows)
                {
                    // Kiểm tra nếu không phải dòng header và có dữ liệu
                    if (!row.IsNewRow)
                    {
                        // Lấy giá trị từ các cột
                        string id = row.Cells[0].Value?.ToString() ?? "N/A";
                        string name = row.Cells[1].Value?.ToString() ?? "N/A";
                        string department = row.Cells[2].Value?.ToString() ?? "N/A";

                        // Thêm vào chuỗi kết quả
                        studentData.AppendLine($"{id}\t{name}\t{department}");
                        studentData.AppendLine("---------------------------------------------------------");
                    }
                }

                // Ghi vào file
                File.WriteAllText(path, studentData.ToString());

                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FileLoadException fe) { fe.Message.ToString(); }
        }
    }
}
