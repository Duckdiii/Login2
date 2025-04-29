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
        COURSE course = new COURSE();
        public AddCourse()
        {
            InitializeComponent();
            Semester_comboBox.Items.AddRange(new string[] { "1", "2", "3" });
            Semester_comboBox.SelectedIndex = 0;
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
                int semester = Convert.ToInt32(Semester_comboBox.Text);
                if (string.IsNullOrWhiteSpace(courseID) || string.IsNullOrWhiteSpace(label))
                {
                    MessageBox.Show("Vui lòng nhập Course ID và Tên khóa học", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(period, out int periodValue) || periodValue <= 10)
                {
                    MessageBox.Show("Thời lượng học phải là số và lớn hơn 10", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                if(course.insertCourse(courseID, label, period, description, semester))
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
