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
    public partial class AdminForm : Form
    {
        private MY_DB db = new MY_DB();
        public AdminForm()
        {
            InitializeComponent();
            LoadUsers("All");
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            ListRegister_dataGridView.MultiSelect = true;
        }
        private void LoadUsers(string statusFilter)
        {
            try
            {
                ListRegister_dataGridView.Rows.Clear();

                string query = "SELECT Id, email, username, status FROM log_in";

                if (statusFilter != "All")
                {
                    query += " WHERE Status = @Status";
                }

                SqlCommand command = new SqlCommand(query, db.getConnection);
                if (statusFilter != "All")
                {
                    command.Parameters.AddWithValue("@Status", statusFilter);
                }


                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    ListRegister_dataGridView.Rows.Add(row["Id"], row["email"], row["username"], row["status"]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.getConnection.Close();
            }
        }

        private void UpdateUserStatus(List<int> userIds, string status)
        {
            if (userIds.Count == 0)
            {
                MessageBox.Show("Không có người dùng nào được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string actionText = status == "Approved" ? "duyệt" : "từ chối";
            string confirmMessage = userIds.Count > 1
                ? $"Bạn có chắc muốn {actionText} {userIds.Count} người dùng?"
                : $"Bạn có chắc muốn {actionText} người dùng này?";

            if (MessageBox.Show(confirmMessage, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                db.openConnection();
                foreach (int userId in userIds)
                {
                    SqlCommand command = new SqlCommand("UPDATE log_in SET Status = @Status WHERE Id = @Id", db.getConnection);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Id", userId);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show($"Đã {actionText} {userIds.Count} người dùng!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void Approve_btn_Click(object sender, EventArgs e)
        {
            if (ListRegister_dataGridView.SelectedRows.Count > 0)
            {
                List<int> selectedUserIds = new List<int>();
                foreach (DataGridViewRow row in ListRegister_dataGridView.SelectedRows)
                {
                    if (row.Cells["Id"].Value != null)
                    {
                        selectedUserIds.Add(Convert.ToInt32(row.Cells["Id"].Value));
                    }
                }

                UpdateUserStatus(selectedUserIds, "Approved");

                // Làm mới dựa trên radio button hiện tại
                if (Pending_radioButton.Checked) LoadUsers("Pending");
                else if (Approved_radioButton.Checked) LoadUsers("Approved");
                else if (rejected_radioButton.Checked) LoadUsers("Rejected");
                else LoadUsers("All");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Reject_btn_Click(object sender, EventArgs e)
        {
            if (ListRegister_dataGridView.SelectedRows.Count > 0)
            {
                List<int> selectedUserIds = new List<int>();
                foreach (DataGridViewRow row in ListRegister_dataGridView.SelectedRows)
                {
                    if (row.Cells["Id"].Value != null)
                    {
                        selectedUserIds.Add(Convert.ToInt32(row.Cells["Id"].Value));
                    }
                }

                UpdateUserStatus(selectedUserIds, "Rejected");

                // Làm mới dựa trên radio button hiện tại
                if (Pending_radioButton.Checked) LoadUsers("Pending");
                else if (Approved_radioButton.Checked) LoadUsers("Approved");
                else if (rejected_radioButton.Checked) LoadUsers("Rejected");
                else LoadUsers("All");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void reload_btn_Click(object sender, EventArgs e)
        {

            LoadUsers("All");
        }

        private void Pending_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Pending_radioButton.Checked)
            {
                LoadUsers("Pending");
            }
        }

        private void Approved_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Approved_radioButton.Checked)
            {
                LoadUsers("Approved");
            }
        }

        private void All_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (All_radioButton.Checked)
            {
                LoadUsers("All");
            }
        }

        private void ListRegister_dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ListRegister_dataGridView.Columns["Status"].Index && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Pending")
                {
                    e.CellStyle.ForeColor = Color.Orange;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else if (status == "Approved")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else if (status == "Rejected")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }

            }
        }

        private void rejected_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rejected_radioButton.Checked)
            {
                LoadUsers("Rejected");
            }
        }

        private void ListRegister_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
