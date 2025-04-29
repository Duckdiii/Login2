using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;

namespace Login_Day2
{
    public partial class ManageStudentForm : Form
    {
        STUDENT student = new STUDENT();
        MY_DB db = new MY_DB();

        private string id;
        private string fname;
        private string lname;
        private DateTime bdate;
        private string phone;
        private string Gender;
        private string address;
        private MemoryStream personalPic;
        private ImageFormat imageFormat; // Biến lưu định dạng ảnh

        public ManageStudentForm()
        {
            InitializeComponent();

        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std", db.getConnection);
                LoadDataGridView(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }
        private void LoadDataGridView(SqlCommand command)
        {
            ListStudent_dataGridView.ReadOnly = true;
            ListStudent_dataGridView.RowTemplate.Height = 80;

            DataTable dataTable = getStudentsWithCourse(command);
            ListStudent_dataGridView.DataSource = dataTable;


            ListStudent_dataGridView.Columns["Courses"].Width = 200;
            TrimDataGridViewCells(ListStudent_dataGridView);
        }
        private void TrimDataGridViewCells(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value is string)
                    {
                        cell.Value = cell.Value.ToString().Trim();
                    }
                }
            }
        }
        public DataTable getStudentsWithCourse(SqlCommand command)
        {
            command.Connection = db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            MessageBox.Show($"Số hàng lấy được: {table.Rows.Count}", "Thông tin");

            if (!table.Columns.Contains("Courses"))
            {
                table.Columns.Add("Courses", typeof(string));
            }

            foreach (DataRow row in table.Rows)
            {
                int studentId = Convert.ToInt32(row["id"]);
                string courses = GetStudentCourses(studentId, command.Connection);
                row["Courses"] = courses;
            }

            return table;
        }

        private string GetStudentCourses(int studentId, SqlConnection connection)
        {
            List<string> courseList = new List<string>();

            try
            {
                // Kiểm tra trạng thái kết nối và mở nếu cần
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand(
                    @"SELECT c.label FROM Course c INNER JOIN StudentCourses sc ON c.Id = sc.CourseID WHERE sc.StudentID = @studentId",
                    connection);

                cmd.Parameters.AddWithValue("@studentId", studentId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string courseName = dt.Rows[i]["label"].ToString();
                    courseList.Add(courseName);
                }

                // Nếu không có môn học, ghi log hoặc thông báo
                if (courseList.Count == 0)
                {
                    Debug.WriteLine($"Không tìm thấy môn học cho sinh viên ID: {studentId}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách môn học cho sinh viên ID {studentId}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Join(", ", courseList);
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudentID_comboBox_KeyDown(object sender, KeyEventArgs e)
        {

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

        private void ListStudent_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= ListStudent_dataGridView.Rows.Count)
                return;

            StudentID_comboBox.Text = ListStudent_dataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
            id = StudentID_comboBox.Text;

            Fname_textBox.Text = ListStudent_dataGridView.CurrentRow.Cells[1].Value.ToString().Trim();
            fname = Fname_textBox.Text;

            Lname_textBox.Text = ListStudent_dataGridView.CurrentRow.Cells[2].Value.ToString().Trim();
            lname = Lname_textBox.Text;

            Birthday_dateTimePicker.Value = (DateTime)ListStudent_dataGridView.CurrentRow.Cells[3].Value;
            bdate = Birthday_dateTimePicker.Value;

            string gender = ListStudent_dataGridView.CurrentRow.Cells[4].Value.ToString().Trim();
            if (gender == "Female")
            {
                Female_radioButton.Checked = true;
                Gender = "Female";
            }
            else
            {
                Male_radioButton.Checked = true;
                Gender = "Male";
            }

            Phone_textBox.Text = ListStudent_dataGridView.CurrentRow.Cells[5].Value.ToString();
            phone = Phone_textBox.Text;

            Email_richTextBox.Text = ListStudent_dataGridView.CurrentRow.Cells[6].Value.ToString();
            address = Email_richTextBox.Text;

            byte[] pic = (byte[])ListStudent_dataGridView.CurrentRow.Cells[7].Value;
            imageFormat = GetImageFormat(pic);
            MemoryStream picture = new MemoryStream(pic);
            personalPic = new MemoryStream(pic);

            System.Drawing.Image originalImage = System.Drawing.Image.FromStream(picture);
            PersonalImage_pictureBox.Image = ResizeImage(originalImage, PersonalImage_pictureBox.Width, PersonalImage_pictureBox.Height);
        }
        private System.Drawing.Image ResizeImage(System.Drawing.Image img, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return resizedImage;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            int id;
            if (!int.TryParse(StudentID_comboBox.Text.Trim(), out id))
            {
                MessageBox.Show("Mã số sinh viên phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fname = Fname_textBox.Text.Trim();
            string lname = Lname_textBox.Text.Trim();
            DateTime bdate = Birthday_dateTimePicker.Value;
            string phone = Phone_textBox.Text.Trim();
            string adrs = Email_richTextBox.Text.Trim();
            string gender = Male_radioButton.Checked ? "Nam" : "Nữ";

            if (student.studentExists(id))
            {
                MessageBox.Show("Sinh viên với mã số này đã tồn tại.", "Thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MemoryStream pic = new MemoryStream();
            int born_year = Birthday_dateTimePicker.Value.Year;
            int this_year = DateTime.Now.Year;

            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("Tuổi sinh viên phải từ 10 đến 100.", "Ngày sinh không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                try
                {
                    MemoryStream picture = new MemoryStream(personalPic.ToArray());
                    if (student.insertStudent(id, fname, lname, bdate, gender, phone, adrs, picture))
                    {
                        MessageBox.Show("Đã thêm sinh viên mới.", "Thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Làm mới ComboBox
                        LoadStudentIDs();
                        StudentID_comboBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm sinh viên.", "Thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool verif()
        {
            return !(string.IsNullOrWhiteSpace(Fname_textBox.Text) ||
                     string.IsNullOrWhiteSpace(Lname_textBox.Text) ||
                     string.IsNullOrWhiteSpace(Email_richTextBox.Text) ||
                     string.IsNullOrWhiteSpace(Phone_textBox.Text) ||
                     string.IsNullOrWhiteSpace(StudentID_comboBox.Text) ||
                     PersonalImage_pictureBox.Image == null);
        }
        private ImageFormat GetImageFormat(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length < 4)
                return ImageFormat.Jpeg; // Trả về mặc định nếu không đủ byte để phân tích

            // Kiểm tra JPEG: FF D8
            if (imageBytes[0] == 0xFF && imageBytes[1] == 0xD8)
                return ImageFormat.Jpeg;

            // Kiểm tra PNG: 89 50 4E 47
            if (imageBytes[0] == 0x89 && imageBytes[1] == 0x50 && imageBytes[2] == 0x4E && imageBytes[3] == 0x47)
                return ImageFormat.Png;

            // Kiểm tra GIF: 47 49 46
            if (imageBytes[0] == 0x47 && imageBytes[1] == 0x49 && imageBytes[2] == 0x46)
                return ImageFormat.Gif;

            // Kiểm tra BMP: 42 4D
            if (imageBytes[0] == 0x42 && imageBytes[1] == 0x4D)
                return ImageFormat.Bmp;

            // Nếu không xác định được, trả về JPEG làm mặc định
            return ImageFormat.Jpeg;
        }
        private void edit_btn_Click(object sender, EventArgs e)
        {
            string inputId = StudentID_comboBox.Text.Trim();
            int id;
            if (!int.TryParse(inputId, out id))
            {
                MessageBox.Show("Vui lòng nhập mã số sinh viên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fname = Fname_textBox.Text.Trim();
            string lname = Lname_textBox.Text.Trim();
            DateTime bdate = Birthday_dateTimePicker.Value;
            string gender = Female_radioButton.Checked ? "Nữ" : "Nam";
            string phone = Phone_textBox.Text.Trim();
            string address = Email_richTextBox.Text.Trim();

            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng điền đầy đủ họ tên và số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MemoryStream picture = null;
            if (PersonalImage_pictureBox.Image != null)
            {
                try
                {
                    picture = new MemoryStream();
                    // Sử dụng imageFormat đã xác định, nếu không có thì dùng JPEG
                    PersonalImage_pictureBox.Image.Save(picture, imageFormat ?? ImageFormat.Jpeg);
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

            if (student.updateStudent(id, fname, lname, bdate, gender, phone, address, picture))
            {
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể cập nhật thông tin sinh viên. Vui lòng kiểm tra lại ID.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            string inputId = StudentID_comboBox.Text.Trim();
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
                    StudentID_comboBox.Text = "";
                    Fname_textBox.Text = "";
                    Lname_textBox.Text = "";
                    Birthday_dateTimePicker.Value = DateTime.Now;
                    Female_radioButton.Checked = false;
                    Phone_textBox.Text = "";
                    Email_richTextBox.Text = "";
                    PersonalImage_pictureBox.Image = null;
                }
                else
                {
                    MessageBox.Show("Không thể xóa sinh viên. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            StudentID_comboBox.Text = id;
            Fname_textBox.Text = fname;
            Lname_textBox.Text = lname;
            Birthday_dateTimePicker.Value = bdate;
            if (Gender == "Female") Female_radioButton.Checked = true;
            else Male_radioButton.Checked = true;
            Phone_textBox.Text = phone;
            Email_richTextBox.Text = address;
            System.Drawing.Image originalImage = System.Drawing.Image.FromStream(personalPic);

            PersonalImage_pictureBox.Image = ResizeImage(originalImage, PersonalImage_pictureBox.Width, PersonalImage_pictureBox.Height);
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std", db.getConnection);
                LoadDataGridView(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string search = search_textBox.Text;
            SqlCommand cmdSearch = new SqlCommand(
                "SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE fname = @search OR lname = @search OR address = @search",
                db.getConnection);
            cmdSearch.Parameters.AddWithValue("@search", search);
            LoadDataGridView(cmdSearch);

        }

        private void StudentID_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow Student = student.FindSingleStudent(Convert.ToInt32(StudentID_comboBox.Text));

            if (Student != null)
            {
                Fname_textBox.Text = Student["fname"].ToString();
                Lname_textBox.Text = Student["lname"].ToString();
                Birthday_dateTimePicker.Value = Convert.ToDateTime(Student["bdate"]);
                string gender = Student["gender"].ToString();
                if (gender == "Nữ")
                {
                    Female_radioButton.Checked = true;
                }
                else Male_radioButton.Checked = true;
                Phone_textBox.Text = Student["phone"].ToString();
                Email_richTextBox.Text = Student["address"].ToString();
                byte[] picture = (byte[])Student["picture"]; // Hình ảnh dưới dạng mảng byte
                using (MemoryStream ms = new MemoryStream(picture))
                {
                    PersonalImage_pictureBox.Image = System.Drawing.Image.FromStream(ms);
                    PersonalImage_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }

            }
        }

        private void UploadImange_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;*.bmp aplikacji|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";
                openFileDialog.Title = "Chọn ảnh sinh viên";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

                        // Kiểm tra kích thước tệp (tối đa 5MB)
                        if (imageBytes.Length > 5 * 1024 * 1024)
                        {
                            MessageBox.Show("Tệp ảnh quá lớn. Vui lòng chọn ảnh nhỏ hơn 5MB.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Lưu ảnh vào MemoryStream
                        personalPic = new MemoryStream(imageBytes);

                        // Xác định định dạng ảnh
                        imageFormat = GetImageFormat(imageBytes) ?? ImageFormat.Jpeg;

                        // Hiển thị ảnh
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            System.Drawing.Image originalImage = System.Drawing.Image.FromStream(ms);
                            PersonalImage_pictureBox.Image = ResizeImage(originalImage, PersonalImage_pictureBox.Width, PersonalImage_pictureBox.Height);
                            PersonalImage_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        personalPic = null; // Đặt lại nếu có lỗi
                        imageFormat = null;
                    }
                }
            }
        }
    }
}
