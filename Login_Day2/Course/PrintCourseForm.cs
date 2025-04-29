using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Day2
{
    public partial class PrintCourseForm : Form
    {
        public PrintCourseForm()
        {
            InitializeComponent();
        }

        private void PrintCourseForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet_Course_ver2.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter1.Fill(this.myDBDataSet_Course_ver2.Course);


        }

        private void ToFile_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn file để lưu kết quả
                string path = @"C:\Users\nguye\Desktop\SourceData\Win\Course.txt";

                // Lấy dữ liệu từ DataGridView (không cần truy vấn lại từ database)
                var studentData = new StringBuilder();

                // Tiêu đề báo cáo
                studentData.AppendLine("ID Number\tName\tDepartment");
                studentData.AppendLine("=========================================================");

                // Duyệt qua từng dòng trong DataGridView
                foreach (DataGridViewRow row in CoursesInfo_dataGridView.Rows)
                {
                    // Kiểm tra nếu không phải dòng header và có dữ liệu
                    if (!row.IsNewRow)
                    {
                        // Lấy giá trị từ các cột
                        string id = row.Cells[0].Value?.ToString() ?? "N/A";
                        string name = row.Cells[1].Value?.ToString() ?? "N/A";
                        string department = row.Cells[2].Value?.ToString() ?? "N/A";

                        // Thêm vào chuỗi kết quả
                        studentData.AppendLine($"{id}\t{name}\t{department}");
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

        private void CoursesInfo_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
