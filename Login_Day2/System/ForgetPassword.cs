using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Login_Day2
{
    public partial class ForgetPassword : Form
    {
        string randomCode;
        public static string to;

        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {

        }

        private void SendCode_btn_Click(object sender, EventArgs e)
        {
            if (email_textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your email address", "Forget Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            message.Subject = "Password reseting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code send successfully", "Code",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Verify_btn_Click(object sender, EventArgs e)
        {
            if (Code_textbox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your code", "ForgetPassword", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (randomCode == Code_textbox.Text.ToString())
            {
                to = email_textBox.Text;
                ResetPassword resetPassword = new ResetPassword();
                this.Hide();
                //resetPassword.typeAccount = 1;
                if (resetPassword.ShowDialog() == DialogResult.Cancel)
                    this.Show();
            }
            else
            {
                MessageBox.Show("Wrong code");
            }

        }

        private void Back_lb_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
