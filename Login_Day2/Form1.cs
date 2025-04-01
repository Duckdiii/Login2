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


            if (ValidateLogin(username, encryptedPassword))
            {
                this.DialogResult = DialogResult.OK;
                login_progressBar.Value = 100;
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }

            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        private bool ValidateLogin(string username, string encryptedPassword)
        {
            MY_DB db = new MY_DB();
            SqlCommand command = new SqlCommand("SELECT * FROM log_in WHERE username = @User AND password = @Pass", db.getConnection);
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = encryptedPassword;

            try
            {
                db.getConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                db.getConnection.Close();
            }
        }
        private void NewUser_label_Click(object sender, EventArgs e)
        {
            NewUserForm newUser = new NewUserForm();
            newUser.Show();
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
