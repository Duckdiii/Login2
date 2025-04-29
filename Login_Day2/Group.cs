using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Day2
{
    internal class Group
    {
        private MY_DB mydb = new MY_DB();
        public void deleteGroup(int groupId)
        {
            try
            {
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "DELETE FROM [Group] WHERE GroupId = @groupId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@groupId", groupId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("No group found with the specified GroupId.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting group: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả nhóm
        public DataTable getGroups()
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "SELECT GroupId, GroupName FROM [Group]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }
                    }
                }
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving groups: " + ex.Message);
            }
        }

        // Kiểm tra xem nhóm có tồn tại không (dựa trên GroupName)
        public bool groupExists(string groupName)
        {
            try
            {
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [Group] WHERE GroupName = @groupName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@groupName", groupName);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking group existence: " + ex.Message);
            }
        }

        // Thêm nhóm mới
        public void insertGroup(string groupName)
        {
            try
            {
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "INSERT INTO [Group] (GroupName) VALUES (@groupName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@groupName", groupName);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting group: " + ex.Message);
            }
        }

        // Cập nhật tên nhóm
        public void updateGroup(int groupId, string newGroupName)
        {
            try
            {
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "UPDATE [Group] SET GroupName = @newGroupName WHERE GroupId = @groupId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@groupId", groupId);
                        command.Parameters.AddWithValue("@newGroupName", newGroupName);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("No group found with the specified GroupId.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating group: " + ex.Message);
            }
        }
    }
}
