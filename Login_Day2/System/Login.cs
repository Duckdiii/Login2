using OfficeOpenXml.Drawing.Slicer.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login_Day2
{
    public partial class LoginPage : Form
    {
        private User userManager = new User();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void Login_button_Click(object sender, EventArgs e)
        {

            login_progressBar.Value = 0;
            login_progressBar.Visible = true;
            string username = UserName_textBox.Text;
            string password = Password_textBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                login_progressBar.Visible = false;
                return;
            }

            login_progressBar.Value = 30;

            string encryptedPassword = EncryptPassword(password);
            login_progressBar.Value = 50;

            string status = ValidateLogin(username, encryptedPassword);
            login_progressBar.Value = 100;
            if (Std_radioButton.Checked == true)
            {
                if (status == "Approved")
                {
                    this.DialogResult = DialogResult.OK;
                    GlobalUserID.SetGlobalID(userManager.Login(username, encryptedPassword));
                    MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else if (status == "Pending")
                {
                    MessageBox.Show("Tài khoản của bạn đang chờ duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (status == "Rejected")
                {
                    MessageBox.Show("Tài khoản của bạn đã bị từ chối!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(HumanResource_radioButton.Checked == true)
            {
                if (status == "Approved")
                {
                    GlobalUserID.SetGlobalID(userManager.Login(username, encryptedPassword));
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else if (status == "Pending")
                {
                    MessageBox.Show("Tài khoản của bạn đang chờ duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (status == "Rejected")
                {
                    MessageBox.Show("Tài khoản của bạn đã bị từ chối!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            login_progressBar.Visible = false;

        }
        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private string ValidateLogin(string username, string encryptedPassword)
        {
            MY_DB db = new MY_DB();
            SqlCommand command = new SqlCommand("SELECT Status FROM log_in WHERE username = @User AND password = @Pass", db.getConnection);
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = encryptedPassword;

            try
            {
                db.getConnection.Open();
                object result = command.ExecuteScalar();
                return result?.ToString() ?? string.Empty; // Trả về Status hoặc rỗng nếu không tìm thấy
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            finally
            {
                db.closeConnection();
            }
        }
        private void NewUser_label_Click(object sender, EventArgs e)
        {
            if (HumanResource_radioButton.Checked == true)
            {
                CreateNewAccount createNewAccount = new CreateNewAccount();
                createNewAccount.Show();
            }
            else if (Std_radioButton.Checked == true)
            {
                NewUserForm newUser = new NewUserForm();
                newUser.Show();
            }
        }

        private void ShowPass_btn_Click(object sender, EventArgs e)
        {
            if (Password_textBox.PasswordChar == '*')
            {
                // Hiện mật khẩu
                Password_textBox.PasswordChar = '\0'; // '\0' là ký tự null, tắt PasswordChar
                ShowPass_btn.Text = "Hide";
            }
            else
            {
                // Ẩn mật khẩu
                Password_textBox.PasswordChar = '*';
                ShowPass_btn.Text = "Show";
            }
        }

        private void ForgetPass_lb_Click(object sender, EventArgs e)
        {
            ForgetPassword forgetPass = new ForgetPassword();
            forgetPass.Show();
        }

        private void login_progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
