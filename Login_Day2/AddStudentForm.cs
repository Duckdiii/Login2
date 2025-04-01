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
            int id = Convert.ToInt32(StudentID_textBox.Text.Trim());
            string fname = FirstName_textBox.Text.Trim();
            string lname = LastName_textBox.Text.Trim();
            DateTime bdate = BirthDate_dateTimePicker.Value;
            string phone = Phone_textBox.Text.Trim();
            string adrs = Address_richTextBox.Text.Trim();
            string gender = "Male";

            if (Female_radioButton.Checked)
            {
                gender = "Female";
            }

            if (student.studentExists(id))
            {
                MessageBox.Show("Sinh viên vớ.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MemoryStream pic = new MemoryStream();
            int born_year = BirthDate_dateTimePicker.Value.Year;
            int this_year = DateTime.Now.Year;

            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                StudentPicture_pictureBox.Image.Save(pic, StudentPicture_pictureBox.Image.RawFormat);
                if (student.insertStudent(id, fname, lname, bdate, gender, phone, adrs, pic))
                {
                    MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void ListFoundStudent(string partialStudentId)
        {
            db.openConnection();

            // Sử dụng LIKE với ký tự % ở cả hai đầu để tìm các mã chứa chuỗi nhập vào
            SqlCommand cmd = new SqlCommand("SELECT Id, fname, lname FROM std WHERE Id LIKE @partialId", db.getConnection);
            cmd.Parameters.Add("@partialId", SqlDbType.NVarChar).Value = "%" + partialStudentId + "%";

            try
            {
                // Tạo SqlDataAdapter để đổ dữ liệu vào DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Thêm cột ảo FullInfo kết hợp các thông tin cần hiển thị
                dt.Columns.Add("FullInfo", typeof(string), "Id + ' - ' + lname + ' ' + fname");

                // Hiển thị kết quả trong ListBox
                if (dt.Rows.Count > 0)
                {
                    ListFoundStudents_listBox.DataSource = dt;
                    ListFoundStudents_listBox.DisplayMember = "FullInfo"; // Hiển thị thông tin đã kết hợp
                    ListFoundStudents_listBox.ValueMember = "Id"; // Giá trị thực khi chọn
                }
                else
                {
                    ListFoundStudents_listBox.DataSource = null;
                    MessageBox.Show("Không tìm thấy sinh viên nào phù hợp");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                db.closeConnection();
            }
        }

        bool verif()
        {
            if ((FirstName_textBox.Text.Trim() == "")
                || (LastName_textBox.Text.Trim() == "")
                || (Address_richTextBox.Text.Trim() == "")
                || (Phone_textBox.Text.Trim() == "")
                || (StudentPicture_pictureBox.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UploadImage_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
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
            // Lấy thông tin từ các cột
            string studentID = worksheet.Cells[currentRow, 1].Text.Trim();
            string fName = worksheet.Cells[currentRow, 2].Text.Trim();
            string lName = worksheet.Cells[currentRow, 3].Text.Trim();
            string birthday = worksheet.Cells[currentRow, 4].Text.Trim();
            string sex = worksheet.Cells[currentRow, 5].Text.Trim();
            string email = worksheet.Cells[currentRow, 6].Text.Trim();
            string origin = worksheet.Cells[currentRow, 7].Text.Trim();
            string phone = worksheet.Cells[currentRow, 8].Text.Trim();

            // Hiển thị thông tin lên form
            StudentID_textBox.Text = studentID;
            FirstName_textBox.Text = fName;
            LastName_textBox.Text = lName;
            BirthDate_dateTimePicker.Value = DateTime.ParseExact(birthday, "dd/MM/yyyy", null);
            Male_radioButton.Checked = (sex == "Nam");
            Female_radioButton.Checked = (sex == "Nữ");
            Phone_textBox.Text = phone;
            Address_richTextBox.Text = email;

            // Tăng chỉ số dòng để chuẩn bị cho lần nhấn nút "Next" tiếp theo
            currentRow++;
        }

        private void btnNextStd_btn_Click(object sender, EventArgs e)
        {
            if (worksheet != null && currentRow <= worksheet.Dimension.Rows)
            {
                LoadStudentData(); // Đọc dữ liệu từ dòng tiếp theo
            }
            else
            {
                MessageBox.Show("Đã hết dữ liệu.");
            }
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên khi form đóng
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không phải số
                MessageBox.Show("Chỉ được nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StudentID_textBox.BackColor = Color.Red;

            }
        }

        private void StudentID_textBox_TextChanged(object sender, EventArgs e)
        {
            isManualSelection = false; // Đánh dấu không phải chọn thủ công
            ListFoundStudents_listBox.Visible = !string.IsNullOrEmpty(StudentID_textBox.Text);
            ListFoundStudent(StudentID_textBox.Text);
        }

        private void FirstName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không phải số
                MessageBox.Show("Chỉ được nhập chữ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FirstName_textBox.BackColor = Color.Red;
            }
        }

        private void LastName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không phải số
                MessageBox.Show("Chỉ được nhập chữ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LastName_textBox.BackColor = Color.Red;
            }
        }

        private void Phone_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Phone_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không phải số
                MessageBox.Show("Chỉ được nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Phone_textBox.BackColor = Color.Red;
            }
        }

        private void Address_richTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckIsIDExitst_btn_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            if (student.studentExists(Convert.ToInt32(StudentID_textBox.Text.Trim())))
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

        }

        private void StudentID_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListFoundStudents_listBox.Visible = false;
                e.SuppressKeyPress = true; // Ngăn tiếng "bíp"
            }
        }

        private void ListFoundStudents_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListFoundStudents_listBox.SelectedItem != null && isManualSelection)
            {
                ListFoundStudents_listBox.Visible = false;
                DataRowView selectedRow = (DataRowView)ListFoundStudents_listBox.SelectedItem;
                string selectedId = selectedRow["Id"].ToString();
                StudentID_textBox.Text = selectedId;
            }
        }

        private void StudentID_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            isManualSelection = true;
            ListFoundStudents_listBox_SelectedIndexChanged(sender, e);
            isManualSelection = false;
        }
    }
}