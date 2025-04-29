using OfficeOpenXml.ConditionalFormatting.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Day2
{
    public partial class UserForm : Form
    {
        MY_DB mydb = new MY_DB();
        private Contact contactManager = new Contact();
        private Group groupManager = new Group();
        public UserForm()
        {
            InitializeComponent();
            LoadGroups();
        }
        private void LoadGroups()
        {
            try
            {
                DataTable groups = groupManager.getGroups();
                SelectEditGroup_comboBox.DataSource = groups;
                SelectEditGroup_comboBox.DisplayMember = "GroupName";
                SelectEditGroup_comboBox.ValueMember = "GroupId";

                SelectDelGroupName_comboBox.DataSource = groups.Copy(); // Tạo bản sao để không xung đột
                SelectDelGroupName_comboBox.DisplayMember = "GroupName";
                SelectDelGroupName_comboBox.ValueMember = "GroupId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading groups: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
        public void getImageAndUsername()
        {
            try
            {
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "SELECT pic, username FROM [dbo].[User] WHERE ID = @uid";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@uid", GlobalUserID.GetUserId()); // Lấy Id từ SessionManager

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Kiểm tra xem có dữ liệu hay không
                            {
                                // Lấy hình ảnh (cột pic)
                                if (!reader.IsDBNull(reader.GetOrdinal("pic")))
                                {
                                    byte[] pic = (byte[])reader["pic"];
                                    using (MemoryStream picture = new MemoryStream(pic))
                                    {
                                        User_pictureBox.Image = Image.FromStream(picture);
                                    }
                                }
                                else
                                {
                                    User_pictureBox.Image = null; // Nếu không có hình ảnh, đặt pictureBox về null
                                }

                                // Lấy username và hiển thị
                                string username = reader["username"].ToString();
                                UserName_lb.Text = "Welcome Back (" + username + ")";
                            }
                            else
                            {
                                // Nếu không tìm thấy người dùng
                                User_pictureBox.Image = null;
                                UserName_lb.Text = "Welcome Back (Unknown)";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Đã xảy ra lỗi khi lấy thông tin người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                User_pictureBox.Image = null;
                UserName_lb.Text = "Welcome Back (Error)";
            }
        }

        private void AddContact_btn_Click(object sender, EventArgs e)
        {
            AddContactForm addContactForm = new AddContactForm();
            addContactForm.ShowDialog();
        }

        private void EditContact_btn_Click(object sender, EventArgs e)
        {
           EditContact editContact = new EditContact();
            editContact.ShowDialog();
        }

        private void Remove_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int contactId = int.Parse(SelectContactID_textBox.Text);
                contactManager.deleteContact(contactId);
                MessageBox.Show("Contact removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SelectContactID_textBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowFullList_btn_Click(object sender, EventArgs e)
        {
            ShowFullListForm showFullListForm = new ShowFullListForm();
            showFullListForm.Show();
        }

        private void AddGroupName_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string groupName = GroupName_textBox.Text.Trim();
                if (string.IsNullOrEmpty(groupName))
                {
                    MessageBox.Show("Please enter a group name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (groupManager.groupExists(groupName))
                {
                    MessageBox.Show("Group name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                groupManager.insertGroup(groupName);
                MessageBox.Show("Group added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GroupName_textBox.Clear();
                LoadGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditGroupName_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectEditGroup_comboBox.SelectedValue == null)
                {
                    MessageBox.Show("Please select a group to edit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string newGroupName = NewGroupName_textBox.Text.Trim();
                if (string.IsNullOrEmpty(newGroupName))
                {
                    MessageBox.Show("Please enter a new group name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (groupManager.groupExists(newGroupName))
                {
                    MessageBox.Show("Group name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int groupId = (int)SelectEditGroup_comboBox.SelectedValue;
                groupManager.updateGroup(groupId, newGroupName);
                MessageBox.Show("Group updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewGroupName_textBox.Clear();
                LoadGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveGroup_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectDelGroupName_comboBox.SelectedValue == null)
                {
                    MessageBox.Show("Please select a group to remove!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int groupId = (int)SelectDelGroupName_comboBox.SelectedValue;
                groupManager.deleteGroup(groupId);
                MessageBox.Show("Group removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectContact_btn_Click(object sender, EventArgs e)
        {
            SelectContact selectContact = new SelectContact();
            selectContact.Show();
        }

        private void EditInfo_btn_Click(object sender, EventArgs e)
        {
            EditUserDataForm editUserDataForm = new EditUserDataForm();
            editUserDataForm.Show();
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            getImageAndUsername();
        }
    }
}
