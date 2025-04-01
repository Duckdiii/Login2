using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Login_Day2
{
    public partial class NewUserForm : Form
    {
        MY_DB mydb = new MY_DB();
        Random random = new Random();
        private Timer timerSendCode; // Khai báo timer
        int time = 60;
        string randomCode;
        public static string to;

        public NewUserForm()
        {
            InitializeComponent();
            InitializeTimer(); // Khởi tạo timer trong constructor
        }
        private void InitializeTimer()
        {
            timerSendCode = new Timer();
            timerSendCode.Interval = 1000; // 1 giây
            timerSendCode.Tick += timerSendCode_Tick;
        }
        private void Submit_btn_Click(object sender, EventArgs e)
        {
            MY_DB myDB = new MY_DB();
            int id = random.Next(1, 101);
            SqlCommand cmd = new SqlCommand("Insert into Log_in (Id, username, password, email) values(@id, @us, @pass, @email)", myDB.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Char).Value = Convert.ToString(id);

            cmd.Parameters.Add("@us", SqlDbType.Char).Value =Username_textBox.Text;
            cmd.Parameters.Add("@pass", SqlDbType.Char).Value = EncryptPassword(Password_textBox.Text);
            cmd.Parameters.Add("@email", SqlDbType.NChar).Value = email_textBox.Text;

            if (checkInfor())
            {
                if (checkCode() == false)
                {
                    return;
                }
                if (Password_textBox.Text != CheckPassword_textBox.Text)
                {
                    MessageBox.Show("Password authentication is wrong, please check again", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CheckPassword_textBox.Text = "";
                    return;
                }
                myDB.openConnection();
                if (checkUserExist(Username_textBox.Text.ToString().Trim()) == false)
                {
                    MessageBox.Show("This username has already existed", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account successfully created", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Username_textBox.Text = "";
                    Password_textBox.Text = "";
                    CheckPassword_textBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Registration error", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                myDB.closeConnection();
            }
            else
            {
                MessageBox.Show("Please do not leave information blank", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private bool IsUsernameExists(string username)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM log_in WHERE username = @un", mydb.getConnection);
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;

            mydb.getConnection.Open();
            int count = (int)command.ExecuteScalar();
            mydb.getConnection.Close();

            return count > 0;
        }

        private void ShowPass_btn_Click(object sender, EventArgs e)
        {
            if (Password_textBox.PasswordChar == '*')
            {
                Password_textBox.PasswordChar = '\0';
                CheckPassword_textBox.PasswordChar = '\0';
                ShowPass_btn.Text = "Hide";
            }
            else
            {
                Password_textBox.PasswordChar = '*';
                CheckPassword_textBox.PasswordChar = '*';
                ShowPass_btn.Text = "Show";
            }
        }

        private void NewUserForm_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendCode_btn_Click(object sender, EventArgs e)
        {
            if (email_textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your email address", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (existEmail() == true)
            {
                MessageBox.Show("Email already used, please enter another email", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = email_textBox.Text.Trim();
            from = "nguyenducduy25605@gmail.com"; // Thay bằng email của bạn
            pass = "xhthwegrwdadunqx";    // Thay bằng mật khẩu ứng dụng
            messageBody = "Code: " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Account creation code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code send successfully", "Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                time = 60;
                SendCode_btn.Enabled = false;
                timerSendCode.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkCode()
        {
            if (Code_textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your code", "Forget Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (randomCode ==Code_textBox.Text.ToString())
            {
                to = email_textBox.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Wrong code");
                return false;
            }
        }

        private void timerSendCode_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                SendCode_btn.Enabled = false;
                labelNotice.Text = "Resend code in " + time + " seconds";
                time--;
            }
            else
            {
                timerSendCode.Stop(); // Dừng timer
                labelNotice.Text = "";
                time = 60;
                SendCode_btn.Enabled = true;
            }
        }

        private bool checkUserExist(string usn)
        {
            MY_DB db = new MY_DB();
            db.openConnection();
            SqlCommand cmd = new SqlCommand("Select * from Log_in where username = @username", db.getConnection);
            cmd.Parameters.Add("@username", SqlDbType.NChar).Value = usn;
            var result = cmd.ExecuteReader();
            if (result.HasRows)
            {
                db.closeConnection();
                return false;
            }
            db.closeConnection();
            return true;
        }

        private bool checkInfor()
        {
            if (Username_textBox.Text.Trim() == "" ||
                Password_textBox.Text.Trim() == "" ||
                CheckPassword_textBox.Text.Trim() == "" ||
                Code_textBox.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private void buttonAddCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool existEmail()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Log_in where email = @email", mydb.getConnection);
                cmd.Parameters.Add("@email", SqlDbType.NChar).Value = email_textBox.Text.Trim();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                adapter.Fill(tb);
                if (tb.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ForgetPass_lb_Click(object sender, EventArgs e)
        {
            ResetPassword resetPass = new ResetPassword();
            resetPass.Show();
        }
    }
}