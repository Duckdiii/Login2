using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login_Day2
{
    public partial class PrinterStudentsForm : Form
    {
        STUDENT STUDENT = new STUDENT();
        MY_DB db = new MY_DB();
        public PrinterStudentsForm()
        {
            InitializeComponent();
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            string sex = null;
            if (female_radioButton.Checked) sex = "Female";
            else if (male_radioButton.Checked) sex = "Male";

            bool yesOrNo = Yes_radioButton.Checked;
            DateTime? birthday1 = yesOrNo ? FirstSelection_Birthday_dateTimePicker.Value : (DateTime?)null;
            DateTime? birthday2 = yesOrNo ? SecondSelection_Birthday_dateTimePicker.Value : (DateTime?)null;

            findStudentWithConditionSex(sex, yesOrNo, birthday1, birthday2);
        }
        private void findStudentWithConditionSex(string sex, bool YesOrNo, DateTime? birthdaySelection1, DateTime? birthdateSelection2)
        {
            SqlCommand cmd;

            if (!string.IsNullOrEmpty(sex) && YesOrNo && birthdaySelection1.HasValue && birthdateSelection2.HasValue)
            {
                cmd = new SqlCommand(
                    "SELECT Id, fname, lname, bdate, gender, phone, address, picture " +
                    "FROM std " +
                    "WHERE gender = @sex AND bdate BETWEEN @birthdaySelection1 AND @birthdateSelection2",
                    db.getConnection);
                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.Parameters.AddWithValue("@birthdaySelection1", birthdaySelection1.Value);
                cmd.Parameters.AddWithValue("@birthdateSelection2", birthdateSelection2.Value);
            }
            else if (!string.IsNullOrEmpty(sex))
            {
                cmd = new SqlCommand("SELECT Id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE gender = @sex", db.getConnection);
                cmd.Parameters.AddWithValue("@sex", sex);
            }
            else
            {
                cmd = new SqlCommand("SELECT Id, fname, lname, bdate, gender, phone, address, picture FROM std", db.getConnection);
            }

            LoadDataGridView(cmd);
        }
        private void LoadDataGridView(SqlCommand command)
        {
            dataGridView_StudentList.ReadOnly = true;
            dataGridView_StudentList.RowTemplate.Height = 80;
            dataGridView_StudentList.DataSource = STUDENT.getStudentsWithCourse(command);

            DataGridViewImageColumn picCol = (DataGridViewImageColumn)dataGridView_StudentList.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView_StudentList.AllowUserToAddRows = false;

            TrimDataGridViewCells(dataGridView_StudentList);
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
        public void fillGrid(SqlCommand command)
        {
            dataGridView_StudentList.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            dataGridView_StudentList.RowTemplate.Height = 80;

            dataGridView_StudentList.DataSource = STUDENT.getStudents(command);

            picCol = (DataGridViewImageColumn)dataGridView_StudentList.Columns[7];

            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView_StudentList.AllowUserToAddRows = false;

            // Dem sinh vien
           // LabelTotalStudents.Text = ("Total Students: " + dataGridView_StudentList.Rows.Count);
        }

        private void dataGridView_StudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateDeleteStudentForm updateDelStdF = new updateDeleteStudentForm();
            updateDelStdF.StudentID_comboBox.Text = dataGridView_StudentList.CurrentRow.Cells[0].Value.ToString().Trim();
            updateDelStdF.firstName_textBox.Text = dataGridView_StudentList.CurrentRow.Cells[1].Value.ToString().Trim();
            updateDelStdF.lastName_textBox.Text = dataGridView_StudentList.CurrentRow.Cells[2].Value.ToString().Trim();
            updateDelStdF.dateOfBirth_dateTimePicker.Value = (DateTime)dataGridView_StudentList.CurrentRow.Cells[3].Value;

            string gender = dataGridView_StudentList.CurrentRow.Cells[4].Value.ToString().Trim();
            if (gender == "Female")
            {
                updateDelStdF.femaleUpdateForm_radioButton.Checked = true;
            }
            else
            {
                updateDelStdF.MaleUpdateForm_radioButton.Checked = true;
            }

            updateDelStdF.Phone_textBox.Text = dataGridView_StudentList.CurrentRow.Cells[5].Value.ToString();
            updateDelStdF.email_richTextBox.Text = dataGridView_StudentList.CurrentRow.Cells[6].Value.ToString();

            byte[] pic = (byte[])dataGridView_StudentList.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            System.Drawing.Image originalImage = System.Drawing.Image.FromStream(picture);

            updateDelStdF.personalPicture_pictureBox.Image = ResizeImage(originalImage, updateDelStdF.personalPicture_pictureBox.Width, updateDelStdF.personalPicture_pictureBox.Height);
            updateDelStdF.ShowDialog();
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
        private void PrinterStudentsForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std");
            LoadDataGridView(command);
        }

        private void SaveToTextFile_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn file để lưu kết quả
                string path = @"C:\Users\nguye\Desktop\SourceData\Win\ListStdInformation.txt";

                // Lấy dữ liệu từ DataGridView (không cần truy vấn lại từ database)
                var studentData = new StringBuilder();

                // Tiêu đề báo cáo
                studentData.AppendLine("ID Number\tName\tDepartment\tAddress");
                studentData.AppendLine("=========================================================");

                // Duyệt qua từng dòng trong DataGridView
                foreach (DataGridViewRow row in dataGridView_StudentList.Rows)
                {
                    // Kiểm tra nếu không phải dòng header và có dữ liệu
                    if (!row.IsNewRow)
                    {
                        // Lấy giá trị từ các cột
                        string id = row.Cells[0].Value?.ToString() ?? "N/A";
                        string name = row.Cells[1].Value?.ToString() ?? "N/A";
                        string department = row.Cells[2].Value?.ToString() ?? "N/A";
                        string address = row.Cells[6].Value?.ToString() ?? "N/A";

                        // Thêm vào chuỗi kết quả
                        studentData.AppendLine($"{id}\t{name}\t{department}\t{address}");
                        studentData.AppendLine("---------------------------------------------------------");
                    }
                }

                // Ghi vào file
                File.WriteAllText(path, studentData.ToString());

                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FileLoadException fe) { fe.Message.ToString(); }
        }

        private void Print_btn_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }
    }
}
