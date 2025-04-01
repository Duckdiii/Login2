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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login_Day2
{
    public partial class updateDeleteStudentForm : Form
    {
        public updateDeleteStudentForm()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();

        private void find_btn_Click(object sender, EventArgs e)
        {

            string inputId = StudentID_textBox.Text.Trim();
            int id;
            if (!int.TryParse(inputId, out id))
            {
                // Nếu không phải là số, hiển thị thông báo lỗi
                MessageBox.Show("Vui lòng nhập một mã số sinh viên hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại và không thực hiện các bước tiếp theo
            }

            SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE id = " + id);
            DataTable table = student.getStudents(command);

            if (table.Rows.Count > 0)
            {
                firstName_textBox.Text = table.Rows[0]["fname"].ToString();
                lastName_textBox.Text = table.Rows[0]["lname"].ToString();
                dateOfBirth_dateTimePicker.Value = (DateTime)table.Rows[0]["bdate"];

                if (table.Rows[0]["gender"].ToString() == "Female")
                {
                    femaleUpdateForm_radioButton.Checked = true;
                }

                Phone_textBox.Text = table.Rows[0]["phone"].ToString();
                email_richTextBox.Text = table.Rows[0]["address"].ToString();

                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                personalPicture_pictureBox.SizeMode=PictureBoxSizeMode.StretchImage;
                personalPicture_pictureBox.Image = Image.FromStream(picture);
            }
            else
            {
                MessageBox.Show("not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void StudentID_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateDeleteStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void email_richTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void uploadImage_btn_Click(object sender, EventArgs e)
        {

        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string inputId = StudentID_textBox.Text.Trim();
            int? id = null;

            if (string.IsNullOrEmpty(inputId))
            {
                // Nếu rỗng, gán id = null
                id = null;

            }
            string fname = firstName_textBox.Text.Trim();
            string lname = lastName_textBox.Text.Trim();
            listStudentForm listStudent = new listStudentForm(id, fname, lname);
            listStudent.Show();
        }

        private void Male_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            string inputId = StudentID_textBox.Text.Trim();
            int id;
            if (!int.TryParse(inputId, out id))
            {
                MessageBox.Show("Vui lòng nhập mã số sinh viên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fname = firstName_textBox.Text.Trim();
            string lname = lastName_textBox.Text.Trim();
            DateTime bdate = dateOfBirth_dateTimePicker.Value;
            string gender = femaleUpdateForm_radioButton.Checked ? "Female" : "Male";
            string phone = Phone_textBox.Text.Trim();
            string address = email_richTextBox.Text.Trim();
            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng điền đầy đủ họ tên và số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MemoryStream picture;
            if (personalPicture_pictureBox.Image != null)
            {
                picture = new MemoryStream();
                personalPicture_pictureBox.Image.Save(picture, personalPicture_pictureBox.Image.RawFormat);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ảnh cho sinh viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (student.updateStudent(id, fname, lname, bdate, gender, phone, address, picture))
            {
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể cập nhật thông tin sinh viên. Vui lòng kiểm tra lại ID.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StudentID_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không phải số
                MessageBox.Show("Chỉ được nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void firstName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không phải số
                MessageBox.Show("Chỉ được nhập chữ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lastName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không phải số
                MessageBox.Show("Chỉ được nhập chữ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Phone_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không phải số
                MessageBox.Show("Chỉ được nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            string inputId = StudentID_textBox.Text.Trim();
            int id;
            if (!int.TryParse(inputId, out id))
            {
                MessageBox.Show("Vui lòng nhập mã số sinh viên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Kiểm tra sinh viên có tồn tại không
                if (!student.studentExists(id))
                {
                    MessageBox.Show("Không tìm thấy sinh viên với ID này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thực hiện xóa
                if (student.deleteStudent(id))
                {
                    MessageBox.Show("Xóa sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa trắng các trường sau khi xóa thành công
                    StudentID_textBox.Text = "";
                    firstName_textBox.Text = "";
                    lastName_textBox.Text = "";
                    dateOfBirth_dateTimePicker.Value = DateTime.Now;
                    femaleUpdateForm_radioButton.Checked = false;
                    Phone_textBox.Text = "";
                    email_richTextBox.Text = "";
                    personalPicture_pictureBox.Image = null;
                }
                else
                {
                    MessageBox.Show("Không thể xóa sinh viên. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
