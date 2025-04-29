using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Day2
{
    internal class User
    {
        MY_DB db = new MY_DB();
        public int Login(string username, string password)
        {
            try
            {
                using (SqlConnection connection = db.getConnection)
                {
                    connection.Open();
                    string query = "SELECT ID FROM [dbo].[User] WHERE username = @username AND pass = @password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result); // Trả về Id nếu tìm thấy
                        }
                        return -1; // Trả về -1 nếu không tìm thấy
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đăng nhập: " + ex.Message);
                return -1;
            }
        }
        private void getUserByID(int id)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[User] where ID = @id", db.getConnection);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                GlobalUserID.SetGlobalID(reader.GetInt32(0));
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }
            public void insertUser(int id, string fname, string lname, string username, string password, byte[] pic)
        {
            db.openConnection();

            string query = "INSERT INTO [dbo].[User] (Id,fname, lname, username, pass, pic) VALUES (@id, @fname, @lname, @username, @pass, @pic)";

            SqlCommand command = new SqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@fname", fname);
            command.Parameters.AddWithValue("@lname", lname);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@pass", password);
            command.Parameters.AddWithValue("@pic", (object)pic ?? DBNull.Value);           
            command.ExecuteNonQuery();
        }

        // Update an existing user in the database
        public void updateUser(int id, string fname, string lname, string username, string password, byte[] pic)
        {
            db.openConnection();

            string query = "UPDATE [dbo].[User] SET fname = @fname, lname = @lname, username = @username, pass = @pass, pic = @pic WHERE ID = @id";

            SqlCommand command = new SqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@fname", fname);
            command.Parameters.AddWithValue("@lname", lname);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@pass", password);
            command.Parameters.AddWithValue("@pic", (object)pic ?? DBNull.Value); // Handle null image

            command.ExecuteNonQuery();
        }

        // Check if a username already exists in the database
        public bool usernameExist(string username)
        {
            db.openConnection();

            string query = "SELECT COUNT(*) FROM [dbo].[User] WHERE username = @username";

            SqlCommand command = new SqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@username", username);

            int count = (int)command.ExecuteScalar(); // Assuming MY_DB has an ExecuteScalar method for retrieving a single value
            return count > 0;
        }
        public void FindUser(int id, ref string fname, ref string lname, ref string username, ref string password, ref PictureBox pic)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[User] where ID = @id", db.getConnection);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                fname = reader["fname"].ToString();
                lname = reader["lname"].ToString();
                username = reader["username"].ToString();
                password = reader["pass"].ToString();
                if (reader["pic"] != DBNull.Value)
                {
                    byte[] picData = (byte[])reader["pic"];
                    using (MemoryStream ms = new MemoryStream(picData))
                    {
                        pic.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pic.Image = null; // Hoặc một hình ảnh mặc định
                }
            }
            else
            {
                MessageBox.Show("User not found.");
            }
            db.closeConnection();
        }
    }
}
