using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;



namespace Login_Day2
{
    public partial class AddStudentForm : Form
    {
        private int currentRow = 2; // Bắt đầu từ dòng 2 (bỏ qua dòng tiêu đề)
        private ExcelWorksheet worksheet;
        private ExcelPackage package;
        MY_DB db = new MY_DB();
        private string filePath;

        private bool isManualSelection = false;

        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void AddStudent_btn_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            int id;
            if (!int.TryParse(StudentID_comboBox.Text.Trim(), out id))
            {
                MessageBox.Show("Mã số sinh viên phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fname = FirstName_textBox.Text.Trim();
            string lname = LastName_textBox.Text.Trim();
            DateTime bdate = BirthDate_dateTimePicker.Value;
            string phone = Phone_textBox.Text.Trim();
            string adrs = Address_richTextBox.Text.Trim();
            string gender = Male_radioButton.Checked ? "Male" : "Female";

            if (student.studentExists(id))
            {
                MessageBox.Show("Sinh viên với mã số này đã tồn tại.", "Thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MemoryStream pic = new MemoryStream();
            int born_year = BirthDate_dateTimePicker.Value.Year;
            int this_year = DateTime.Now.Year;

            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("Tuổi sinh viên phải từ 10 đến 100.", "Ngày sinh không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                try
                {
                    StudentPicture_pictureBox.Image.Save(pic, StudentPicture_pictureBox.Image.RawFormat);
                    if (student.insertStudent(id, fname, lname, bdate, gender, phone, adrs, pic))
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
            return !(string.IsNullOrWhiteSpace(FirstName_textBox.Text) ||
                     string.IsNullOrWhiteSpace(LastName_textBox.Text) ||
                     string.IsNullOrWhiteSpace(Address_richTextBox.Text) ||
                     string.IsNullOrWhiteSpace(Phone_textBox.Text) ||
                     string.IsNullOrWhiteSpace(StudentID_comboBox.Text) ||
                     StudentPicture_pictureBox.Image == null);
        }

        private void UploadImage_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Chọn ảnh(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                StudentPicture_pictureBox.Image = Image.FromFile(opf.FileName);
            }
        }

        private void Import_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                package = new ExcelPackage(new FileInfo(filePath));
                worksheet = package.Workbook.Worksheets[0];
                LoadStudentData();
            }
        }
        private void LoadStudentData()
        {
            if (worksheet == null || currentRow > worksheet.Dimension.Rows)
            {
                MessageBox.Show("Đã hết dữ liệu hoặc chưa chọn file Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string studentID = worksheet.Cells[currentRow, 1].Text.Trim();
                string fName = worksheet.Cells[currentRow, 2].Text.Trim();
                string lName = worksheet.Cells[currentRow, 3].Text.Trim();
                string birthday = worksheet.Cells[currentRow, 4].Text.Trim();
                string sex = worksheet.Cells[currentRow, 5].Text.Trim();
                string email = worksheet.Cells[currentRow, 6].Text.Trim();
                string origin = worksheet.Cells[currentRow, 7].Text.Trim();
                string phone = worksheet.Cells[currentRow, 8].Text.Trim();

                StudentID_comboBox.Text = studentID;
                FirstName_textBox.Text = fName;
                LastName_textBox.Text = lName;
                BirthDate_dateTimePicker.Value = DateTime.ParseExact(birthday, "dd/MM/yyyy", null);
                Male_radioButton.Checked = (sex == "Nam");
                Female_radioButton.Checked = (sex == "Nữ");
                Phone_textBox.Text = phone;
                Address_richTextBox.Text = origin;

                currentRow++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNextStd_btn_Click(object sender, EventArgs e)
        {
            LoadStudentData();
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (package != null)
            {
                package.Dispose();
            }
        }

        private void FirstName_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentID_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void StudentID_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FirstName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập chữ và khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FirstName_textBox.BackColor = Color.IndianRed;
            }
            else
            {
                FirstName_textBox.BackColor = SystemColors.Window;
            }
        }

        private void LastName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập chữ và khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LastName_textBox.BackColor = Color.Red;
            }
            else
            {
                LastName_textBox.BackColor = SystemColors.Window;
            }
        }

        private void Phone_textBox_TextChanged(object sender, EventArgs e)
        {
            Address_richTextBox.Text = StudentID_comboBox.Text+"@student.hcmute.edu.vn";
        }

        private void Phone_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Phone_textBox.BackColor = Color.IndianRed;
            }
            else
            {
                Phone_textBox.BackColor = SystemColors.Window;
            }
        }

        private void Address_richTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckIsIDExitst_btn_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            if (student.studentExists(Convert.ToInt32(StudentID_comboBox.Text.Trim())))
            {
                MessageBox.Show("Sinh viên với mã số này đã tồn tại.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                MessageBox.Show("Chưa có sinh viên nào gắn với mssv này.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

            LoadStudentIDs();
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
        private void StudentID_textBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ListFoundStudents_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentID_textBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void StudentID_comboBox_TextUpdate(object sender, EventArgs e)
        {
            LoadStudentIDs(StudentID_comboBox.Text);

        }

        private void StudentID_comboBox_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}