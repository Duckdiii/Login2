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
    public partial class AddCourse : Form
    {
        MY_DB db = new MY_DB();
        public AddCourse()
        {
            InitializeComponent();
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {

        }

        private void addCourse_btn_Click(object sender, EventArgs e)
        {

            try
            {
                // Lấy dữ liệu từ các control trên form
                string courseID = CourseID_textBox.Text;
                string label = CourseName_textBox.Text;
                string period = CoursePeriod_textBox.Text;
                string description = CourseDescription_richTextBox.Text;

                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrWhiteSpace(courseID) || string.IsNullOrWhiteSpace(label))
                {
                    MessageBox.Show("Vui lòng nhập Course ID và Tên khóa học", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra thời lượng học phải là số và lớn hơn 10
                if (!int.TryParse(period, out int periodValue) || periodValue <= 10)
                {
                    MessageBox.Show("Thời lượng học phải là số và lớn hơn 10", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra tên course đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM Course WHERE label = @Label";
                SqlCommand checkCommand = new SqlCommand(checkQuery, db.getConnection);
                checkCommand.Parameters.AddWithValue("@Label", label);

                db.openConnection();
                int existingCount = (int)checkCommand.ExecuteScalar();

                if (existingCount > 0)
                {
                    MessageBox.Show("Tên khóa học đã tồn tại, vui lòng chọn tên khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.closeConnection();
                    return;
                }

                // Thêm vào database
                string insertQuery = "INSERT INTO Course (Id, abel, period, description) " +
                                   "VALUES (@CourseID, @Label, @Period, @Description)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, db.getConnection);
                insertCommand.Parameters.AddWithValue("@CourseID", courseID);
                insertCommand.Parameters.AddWithValue("@Label", label);
                insertCommand.Parameters.AddWithValue("@Period", period);
                insertCommand.Parameters.AddWithValue("@Description", description);

                int result = insertCommand.ExecuteNonQuery();
                db.closeConnection();

                if (result > 0)
                {
                    MessageBox.Show("Thêm khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Xóa nội dung các textbox sau khi thêm thành công
                    CourseID_textBox.Text = "";
                    CourseName_textBox.Text = "";
                    CoursePeriod_textBox.Text = "";
                    CourseDescription_richTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Không thể thêm khóa học", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }

    }
}
