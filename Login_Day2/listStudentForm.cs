using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing; // System.Drawing.Image
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Xceed.Document.NET; // Xceed.Document.NET.Image
using Xceed.Words.NET;

namespace Login_Day2
{
    public partial class listStudentForm : Form
    {
        private int? IdStd;
        private string firstNameStd;
        private string lastNameStd;
        private STUDENT student = new STUDENT();
        MY_DB db = new MY_DB();
        public listStudentForm()
        {
            InitializeComponent();
        }

        public listStudentForm(int? Id, string Fname, string Lname)
        {
            InitializeComponent();
            IdStd = Id;
            firstNameStd = Fname;
            lastNameStd = Lname;
        }

        private void listStudentForm_Load(object sender, EventArgs e)
        {
            SqlCommand command;
            if (IdStd.HasValue)
            {
                command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE id = @Id");
                command.Parameters.AddWithValue("@Id", IdStd);
            }
            else if (!string.IsNullOrEmpty(firstNameStd))
            {
                command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE fname = @FName");
                command.Parameters.AddWithValue("@FName", firstNameStd);
            }
            else if (!string.IsNullOrEmpty(lastNameStd))
            {
                command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE lname = @LName");
                command.Parameters.AddWithValue("@LName", lastNameStd);
            }
            else
            {
                command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std");
            }

            LoadDataGridView(command);
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std");
            LoadDataGridView(command);
        }

        private void LoadDataGridView(SqlCommand command)
        {
            dataGridView_StudentList.ReadOnly = true;
            dataGridView_StudentList.RowTemplate.Height = 80;
            dataGridView_StudentList.DataSource = student.getStudents(command);

            DataGridViewImageColumn picCol = (DataGridViewImageColumn)dataGridView_StudentList.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView_StudentList.AllowUserToAddRows = false;

            TrimDataGridViewCells(dataGridView_StudentList);
        }

        private void dataGridView_StudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateDeleteStudentForm updateDelStdF = new updateDeleteStudentForm();
            updateDelStdF.StudentID_textBox.Text = dataGridView_StudentList.CurrentRow.Cells[0].Value.ToString().Trim();
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

        private void export_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "StudentListExport.docx");

                // Khởi tạo ứng dụng Word
                Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word._Document oDoc = oWord.Documents.Add();
                oWord.Visible = true; // Hiển thị Word trong quá trình xử lý

                // Thêm tiêu đề
                var titlePara = oDoc.Content.Paragraphs.Add();
                titlePara.Range.Text = "Student List";
                titlePara.Range.Font.Size = 20;
                titlePara.Range.Font.Bold = 1;
                titlePara.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                titlePara.Range.InsertParagraphAfter();

                // Tạo bảng
                Microsoft.Office.Interop.Word.Table table = oDoc.Tables.Add(oDoc.Content.Paragraphs[oDoc.Content.Paragraphs.Count].Range,
                    dataGridView_StudentList.Rows.Count + 1, dataGridView_StudentList.Columns.Count);
                table.Borders.Enable = 1; // Hiển thị đường viền bảng
                table.Range.Font.Size = 11;

                // Đặt chiều cao cố định cho các hàng
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    table.Rows[i].Height = oWord.CentimetersToPoints(2.0f); // Chiều cao 2cm
                }

                // Đặt độ rộng cố định cho các cột (tăng độ rộng để hiển thị toàn bộ nội dung)
                float[] columnWidths = new float[] { 2.0f, 2.5f, 2.5f, 2.0f, 1.5f, 2.0f, 3.0f, 2.0f }; // Đơn vị: cm
                for (int i = 0; i < table.Columns.Count && i < columnWidths.Length; i++)
                {
                    table.Columns[i + 1].Width = oWord.CentimetersToPoints(columnWidths[i]);
                }

                // Điền tiêu đề cột (chỉ header được in đậm)
                for (int i = 0; i < dataGridView_StudentList.Columns.Count; i++)
                {
                    table.Cell(1, i + 1).Range.Text = dataGridView_StudentList.Columns[i].HeaderText;
                    table.Cell(1, i + 1).Range.Bold = 1; // In đậm header
                    table.Cell(1, i + 1).Range.ParagraphFormat.Alignment =
                        Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                // Điền dữ liệu vào bảng (nội dung không in đậm)
                for (int i = 0; i < dataGridView_StudentList.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_StudentList.Columns.Count; j++)
                    {
                        if (j == 7) // Cột Picture
                        {
                            object cellValue = dataGridView_StudentList.Rows[i].Cells[j].Value;
                            if (cellValue != null && cellValue is byte[] picBytes)
                            {
                                using (MemoryStream ms = new MemoryStream(picBytes))
                                {
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                                    System.Drawing.Image resizedImage = ResizeImage(image, 50, 50); // Kích thước ảnh
                                    Clipboard.SetDataObject(resizedImage);
                                    table.Cell(i + 2, j + 1).Range.Paste();
                                    table.Cell(i + 2, j + 1).Range.ParagraphFormat.Alignment =
                                        Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                }
                            }
                        }
                        else if (j == 3) // Cột Date of Birth (xóa giờ)
                        {
                            object cellValue = dataGridView_StudentList.Rows[i].Cells[j].Value;
                            if (cellValue != null && cellValue is DateTime date)
                            {
                                table.Cell(i + 2, j + 1).Range.Text = date.ToString("dd/MM/yyyy"); // Chỉ hiển thị ngày/tháng/năm
                            }
                            else
                            {
                                table.Cell(i + 2, j + 1).Range.Text = cellValue?.ToString() ?? "";
                            }
                            table.Cell(i + 2, j + 1).Range.Bold = 0; // Không in đậm
                        }
                        else
                        {
                            string cellValue = dataGridView_StudentList.Rows[i].Cells[j].Value?.ToString() ?? "";
                            table.Cell(i + 2, j + 1).Range.Text = cellValue;
                            table.Cell(i + 2, j + 1).Range.Bold = 0; // Không in đậm
                        }
                    }
                }

                // Lưu và đóng tài liệu
                oDoc.SaveAs2(filePath);
                oDoc.Close();
                oWord.Quit();

                MessageBox.Show("Dữ liệu đã được xuất sang Word thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex){
                MessageBox.Show("Đã xảy ra lỗi khi xuất file Word: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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

        private void Yes_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}