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
    public partial class RemoveCourseForm : Form
    {
        COURSE course = new COURSE();
        MY_DB mydb = new MY_DB();
        public RemoveCourseForm()
        {
            InitializeComponent();
        }

        private void removeCourse_btn_Click(object sender, EventArgs e)
        {
            string courseId = CourseID_textBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(courseId))
            {
                MessageBox.Show("Vui lòng nhập mã môn học hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra môn học có tồn tại không
            DataTable dt = new DataTable();
            course.getCourseById(courseId, ref dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy môn học với mã này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này? Hành động này không thể hoàn tác!",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }

            if (course.deleteCourse(courseId))
            {
                MessageBox.Show("Delete Course Successfully", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CourseID_textBox.Text = "";
            }
            else
            {
                MessageBox.Show("Không thể xóa môn học. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
