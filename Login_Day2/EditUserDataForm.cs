using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Day2
{
    public partial class EditUserDataForm : Form
    {
        MY_DB db = new MY_DB();
        User user = new User();
        public EditUserDataForm()
        {
            InitializeComponent();
        }

        private void Submit_btn_Click(object sender, EventArgs e)
        {

        }

        private void EditUserDataForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadStudentIDs(string filter = "")
        {
            try
            {
                db.openConnection();
                string query = "SELECT Id FROM User";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += " WHERE Id LIKE @partialId";
                }

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                if (!string.IsNullOrEmpty(filter))
                {
                    cmd.Parameters.AddWithValue("@partialId", "%" + filter + "%");
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Lưu danh sách hiện tại
                List<string> currentItems = new List<string>();
                foreach (var item in User_comboBox.Items)
                {
                    currentItems.Add(item.ToString());
                }

                // Cập nhật Items chỉ khi cần
                if (dt.Rows.Count > 0 || string.IsNullOrEmpty(filter))
                {
                    User_comboBox.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        User_comboBox.Items.Add(row["Id"].ToString());
                    }
                }

                // Mở danh sách thả xuống nếu có dữ liệu
                User_comboBox.DroppedDown = !string.IsNullOrEmpty(filter) && dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void User_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                User_comboBox.BackColor = Color.IndianRed;
            }
            else
            {
                User_comboBox.BackColor = SystemColors.Window;
            }
        }

        private void User_comboBox_KeyUp(object sender, KeyEventArgs e)
        {
            // Lưu vị trí con trỏ và văn bản hiện tại
            int selectionStart = User_comboBox.SelectionStart;
            string currentText = User_comboBox.Text;

            // Tải danh sách mã số, ngoại trừ phím điều hướng
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Enter)
            {
                LoadStudentIDs(currentText);

                // Khôi phục văn bản và con trỏ
                User_comboBox.Text = currentText;
                User_comboBox.SelectionStart = selectionStart;
            }
        }

        private void User_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(User_comboBox.Text != null)
            {
                string fname = "";
                string lname = "";
                string username = "";
                string password = "";
                PictureBox pic = null;
                user.FindUser(Convert.ToInt32(User_comboBox.Text), ref fname, ref lname, ref username, ref password,ref pic);
                Fname_textBox.Text = fname;
                Lname_textBox.Text = lname;
                Username_textBox.Text = username;
                Password_textBox.Text = password;
                User_pictureBox = pic;
            }
        }
    }
}
