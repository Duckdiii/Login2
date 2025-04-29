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
using Xceed.Document.NET;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login_Day2
{
    public partial class updateDeleteStudentForm : Form
    {
        MY_DB db = new MY_DB();
        STUDENT std = new STUDENT();
        public updateDeleteStudentForm()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();

        private void find_btn_Click(object sender, EventArgs e)
        {

            string inputId = StudentID_comboBox.Text.Trim();
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
                personalPicture_pictureBox.Image = System.Drawing.Image.FromStream(picture);
            }
            else
            {
                MessageBox.Show("not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void LoadStudentIDs(string filter = "")
        {
            try
            {
                db.openConnection();
                string query = "SELECT Id FROM std";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += " WHERE Id LIKE @partialId";
                }

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                if (!string.IsNullOrEmpty(filter))
                {
                    cmd.Parameters.AddWithValue("@partialId", "%" + filter + "%");
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Lưu danh sách hiện tại
                List<string> currentItems = new List<string>();
                foreach (var item in StudentID_comboBox.Items)
                {
                    currentItems.Add(item.ToString());
                }

                // Cập nhật Items chỉ khi cần
                if (dt.Rows.Count > 0 || string.IsNullOrEmpty(filter))
                {
                    StudentID_comboBox.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        StudentID_comboBox.Items.Add(row["Id"].ToString());
                    }
                }

                // Mở danh sách thả xuống nếu có dữ liệu
                StudentID_comboBox.DroppedDown = !string.IsNullOrEmpty(filter) && dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }
        private void StudentID_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateDeleteStudentForm_Load(object sender, EventArgs e)
        {
            LoadStudentIDs();
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
            try
            {
                // Tạo OpenFileDialog để chọn hình ảnh
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh cho sinh viên";

                // Hiển thị hộp thoại và kiểm tra xem người dùng có chọn file không
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Tải hình ảnh từ file và hiển thị trong PictureBox
                    personalPicture_pictureBox.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                    personalPicture_pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Điều chỉnh hiển thị hình ảnh
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                personalPicture_pictureBox.Image = null; // Đặt lại PictureBox nếu có lỗi
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string inputId = StudentID_comboBox.Text.Trim();
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
            MemoryStream picture = null;

            try

            {
                // Kiểm tra và lấy StudentID
                string inputId = StudentID_comboBox.Text.Trim();
                if (!int.TryParse(inputId, out int id))
                {
                    MessageBox.Show("Vui lòng nhập mã số sinh viên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin sinh viên
                string fname = firstName_textBox.Text.Trim();
                string lname = lastName_textBox.Text.Trim();
                DateTime bdate = dateOfBirth_dateTimePicker.Value;
                string gender = femaleUpdateForm_radioButton.Checked ? "Female" : "Male";
                string phone = Phone_textBox.Text.Trim();
                string address = email_richTextBox.Text.Trim();

                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ họ tên và số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xử lý hình ảnh
                if (personalPicture_pictureBox.Image != null)
                {
                    try
                    {
                        picture = new MemoryStream();
                        personalPicture_pictureBox.Image.Save(picture, System.Drawing.Imaging.ImageFormat.Jpeg); // Sử dụng định dạng JPEG
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ảnh cho sinh viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật thông tin sinh viên
                STUDENT student = new STUDENT();
                if (student.updateStudent(id, fname, lname, bdate, gender, phone, address, picture))
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin sinh viên. Vui lòng kiểm tra lại ID.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo MemoryStream được giải phóng
                if (picture != null)
                {
                    picture.Dispose();
                }
            }
        }
    

        private void StudentID_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

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
            string inputId = StudentID_comboBox.Text.Trim();
            int id;
            if (!int.TryParse(inputId, out id))
            {
                MessageBox.Show("Vui lòng nhập mã số sinh viên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra sinh viên có tồn tại không
            if (!student.studentExists(id))
            {
                MessageBox.Show("Không tìm thấy sinh viên với ID này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SqlTransaction transaction = null;
                try
                {
                    db.openConnection();
                    transaction = db.getConnection.BeginTransaction();

                    // Xóa bản ghi trong bảng Score (nếu có)
                    using (SqlCommand cmdDelScores = new SqlCommand("DELETE FROM Score WHERE StudentID = @id", db.getConnection))
                    {
                        cmdDelScores.Transaction = transaction;
                        cmdDelScores.Parameters.AddWithValue("@id", id);
                        cmdDelScores.ExecuteNonQuery();
                    }

                    // Xóa bản ghi trong bảng StudentCourses
                    using (SqlCommand cmdDelStudentCourses = new SqlCommand("DELETE FROM StudentCourses WHERE StudentID = @id", db.getConnection))
                    {
                        cmdDelStudentCourses.Transaction = transaction;
                        cmdDelStudentCourses.Parameters.AddWithValue("@id", id);
                        cmdDelStudentCourses.ExecuteNonQuery();
                    }

                    // Gọi phương thức deleteStudent để xóa sinh viên
                    if (student.deleteStudent(id))
                    {
                        transaction.Commit();
                        MessageBox.Show("Xóa sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Xóa trắng các trường sau khi xóa thành công
                        StudentID_comboBox.Text = "";
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
                        throw new Exception("Không thể xóa sinh viên.");
                    }
                }
                catch (SqlException ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }

        private void StudentID_comboBox_TextUpdate(object sender, EventArgs e)
        {
            LoadStudentIDs(StudentID_comboBox.Text);
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

        private void StudentID_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StudentID_comboBox.BackColor = Color.IndianRed;
            }
            else
            {
                StudentID_comboBox.BackColor = SystemColors.Window;
            }
        }

        private void AddCourse_btn_Click(object sender, EventArgs e)
        {
            AddCourseStdForm addCourseStdForm = new AddCourseStdForm();
            addCourseStdForm.Show();
        }

        private void StudentID_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow student = std.FindSingleStudent(Convert.ToInt32(StudentID_comboBox.Text));

            if (student != null)
            {
                firstName_textBox.Text = student["fname"].ToString();
                lastName_textBox.Text = student["lname"].ToString();
                dateOfBirth_dateTimePicker.Value = Convert.ToDateTime(student["bdate"]);
                string gender = student["gender"].ToString();
                if (gender == "Female")
                {
                    femaleUpdateForm_radioButton.Checked = true;
                }
                else MaleUpdateForm_radioButton.Checked = true;
                Phone_textBox.Text = student["phone"].ToString();
                email_richTextBox.Text = student["address"].ToString();
                byte[] picture = (byte[])student["picture"]; // Hình ảnh dưới dạng mảng byte
                using (MemoryStream ms = new MemoryStream(picture))
                {
                    personalPicture_pictureBox.Image = System.Drawing.Image.FromStream(ms);
                    personalPicture_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                
            }
        }
    }
}
