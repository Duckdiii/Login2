using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Day2
{
    public partial class CreateNewAccount : Form
    {
        private User userManager = new User();
        private byte[] userImage; // Để lưu trữ hình ảnh dưới dạng byte[]
        MY_DB db = new MY_DB();
        public CreateNewAccount()
        {
            InitializeComponent();
        }

        private void CreateNewAccount_Load(object sender, EventArgs e)
        {

        }
        private bool verifyField()
        {
            return string.IsNullOrEmpty(ID_textBox.Text) &&
                   string.IsNullOrEmpty(Fname_textBox.Text) &&
                   string.IsNullOrEmpty(Lname_textBox.Text) &&
                   string.IsNullOrEmpty(Username_textBox.Text) &&
                   string.IsNullOrEmpty(Pass_textBox.Text) &&
                    Picture_pictureBox.Image != null;
        }
        private void Upload_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Picture_pictureBox.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                    userImage = File.ReadAllBytes(openFileDialog.FileName); // Chuyển hình ảnh thành byte[]
                }
            }
        }

        private void Submit_btn_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Lấy dữ liệu từ các ô nhập liệu
                int id = Convert.ToInt32(ID_textBox.Text.Trim());
                string fname = Fname_textBox.Text.Trim();
                string lname = Lname_textBox.Text.Trim();
                string username = Username_textBox.Text.Trim();
                string password = Pass_textBox.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) ||
                    string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem username đã tồn tại chưa
                if (userManager.usernameExist(username))
                {
                    MessageBox.Show("Tên người dùng đã tồn tại! Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                userManager.insertUser(id,fname, lname, username, password, userImage);
                MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa các trường sau khi tạo thành công
                Fname_textBox.Clear();
                Lname_textBox.Clear();
                Username_textBox.Clear();
                Pass_textBox.Clear();
                Picture_pictureBox.Image = null;
                userImage = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HaveAccount_lb_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}
