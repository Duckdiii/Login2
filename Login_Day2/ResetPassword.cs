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

namespace Login_Day2
{
    public partial class ResetPassword : Form
    {
        Random random = new Random();

        public ResetPassword()
        {
            InitializeComponent();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            MY_DB myDB = new MY_DB();

            if (NewPassword_textBox.Text.Trim() == "" || VerifyPassword_textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter all fields", "Reset Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (NewPassword_textBox.Text != VerifyPassword_textBox.Text)
            {
                MessageBox.Show("Passwords do not match", "Reset Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                myDB.openConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Log_in SET password = @pass WHERE email = @email", myDB.getConnection);
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = HashPassword(NewPassword_textBox.Text);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = ForgetPassword.to; // Sử dụng email từ ForgetPassword

                int rowsAffected = cmd.ExecuteNonQuery();

                myDB.closeConnection();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password reset successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to reset password. Email not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                myDB.closeConnection();
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
