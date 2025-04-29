using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Day2
{
    internal class Contact
    {
        private MY_DB mydb = new MY_DB();
        public void updateContact(int userId, string fname, string lname, string groupID, string phone, string email, string address, PictureBox pic, string contactID)
        {
            try
            {
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "UPDATE Contact SET fname = @fname, @lname= lname, @groupID= groupID, @phone= phone, @email=email, @address=address, @pic=pic  WHERE Id = @contactId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@fname", fname);
                        command.Parameters.AddWithValue("@lname", lname);
                        command.Parameters.AddWithValue("@groupID", groupID);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@pic", pic);
                        command.Parameters.AddWithValue("@contactID", contactID);


                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("No contact found with the specified ContactId.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating contact: " + ex.Message);
            }
        }
        public void deleteContact(int contactId)
        {
            try
            {
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "DELETE FROM Contact WHERE ContactId = @contactId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@contactId", contactId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("No contact found with the specified ContactId.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting contact: " + ex.Message);
            }
        }

        // Lấy thông tin liên hệ theo ContactId
        public DataRow GetContactByID(int contactId)
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "SELECT c.ContactId, u.username, g.GroupName " +
                                  "FROM Contact c " +
                                  "JOIN [dbo].[User] u ON c.UserId = u.ID " +
                                  "JOIN [Group] g ON c.GroupId = g.GroupId " +
                                  "WHERE c.ContactId = @contactId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@contactId", contactId);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }
                    }
                }
                return table.Rows.Count > 0 ? table.Rows[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving contact: " + ex.Message);
            }
        }

        // Thêm liên hệ mới
        public void insertContact(int contactId, string fname, string lname, string groupID, string phone, string email, string address, PictureBox pic)
        {
            try
            {
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "INSERT INTO Contact (Id, fname, lname, groupID, phone, email, address, pic, userID) VALUES (@contactId, @fname, @lname" +
                        ", @groupID, @phone, @email, @address, @pic, @groupId)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@contactId", contactId);
                        command.Parameters.AddWithValue("@fname", fname);
                        command.Parameters.AddWithValue("@lname", lname);
                        command.Parameters.AddWithValue("@groupID", groupID);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@pic", pic);
                        command.Parameters.AddWithValue("@userID", GlobalUserID.GetUserId());

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting contact: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả liên hệ
        public DataTable SelectContactList()
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection connection = mydb.getConnection)
                {
                    connection.Open();
                    string query = "SELECT c.ContactId, u.username, g.GroupName " +
                                  "FROM Contact c " +
                                  "JOIN [dbo].[User] u ON c.UserId = u.ID " +
                                  "JOIN [Group] g ON c.GroupId = g.GroupId";
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
                throw new Exception("Error retrieving contact list: " + ex.Message);
            }
        }
    }
}
