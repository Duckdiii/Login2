using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Login_Day2
{
    internal class STUDENT
    {
        MY_DB mydb = new MY_DB();

        // function to insert a new student
        public bool insertStudent(int Id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            fname = fname.Trim();
            lname = lname.Trim();
            phone = phone.Trim();
            address = address.Trim();
            SqlCommand command = new SqlCommand("INSERT INTO std (id, fname, lname, bdate, gender, phone, address, picture) " +
                "VALUES (@id, @fn, @ln, @bdt, @gdr, @phn, @adrs, @pic)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateStudent(int Id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            fname = fname.Trim();
            lname = lname.Trim();
            phone = phone.Trim();
            address = address.Trim();

            SqlCommand command = new SqlCommand(
                "UPDATE std SET fname = @fn, lname = @ln, bdate = @bdt, gender = @gdr, phone = @phn, address = @adrs, picture = @pic WHERE id = @id",
                mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;

            // Kiểm tra picture có dữ liệu không
            if (picture != null && picture.Length > 0)
            {
                command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            }
            else
            {
                command.Parameters.Add("@pic", SqlDbType.Image).Value = DBNull.Value; // Nếu không có hình ảnh, lưu giá trị NULL
            }

            try
            {
                mydb.openConnection();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected == 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sinh viên vào cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                mydb.closeConnection();
            }
        }
        public bool deleteStudent(int id)
        {
            SqlTransaction transaction = null;
            try
            {
                mydb.openConnection();
                transaction = mydb.getConnection.BeginTransaction();

                // Xóa bản ghi trong bảng Score
                using (SqlCommand cmdDelScores = new SqlCommand("DELETE FROM Score WHERE StudentID = @id", mydb.getConnection))
                {
                    cmdDelScores.Transaction = transaction;
                    cmdDelScores.Parameters.AddWithValue("@id", id);
                    cmdDelScores.ExecuteNonQuery();
                }

                // Xóa bản ghi trong bảng StudentCourses
                using (SqlCommand cmdDelStudentCourses = new SqlCommand("DELETE FROM StudentCourses WHERE StudentID = @id", mydb.getConnection))
                {
                    cmdDelStudentCourses.Transaction = transaction;
                    cmdDelStudentCourses.Parameters.AddWithValue("@id", id);
                    cmdDelStudentCourses.ExecuteNonQuery();
                }

                // Xóa sinh viên
                using (SqlCommand command = new SqlCommand("DELETE FROM std WHERE Id = @id", mydb.getConnection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@id", id);
                    int result = command.ExecuteNonQuery();

                    transaction.Commit();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                transaction?.Rollback();
                return false;
            }
            finally
            {
                mydb.closeConnection();
            }
        }
        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool studentExists(int id)
        {
            STUDENT student = new STUDENT();

            SqlCommand command = new SqlCommand("SELECT * FROM std WHERE id = @id");
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            DataTable table = student.getStudents(command);
            return table.Rows.Count > 0;
        }
        public DataRow FindSingleStudent(int StudentID)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE id = @id", mydb.getConnection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = StudentID;

                mydb.openConnection();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                mydb.closeConnection();

                // Kiểm tra nếu tìm thấy sinh viên
                if (table.Rows.Count > 0)
                {
                    return table.Rows[0]; // Trả về hàng đầu tiên (thông tin sinh viên)
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với ID này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                mydb.closeConnection();
            }
        }
        public DataTable getStudentsWithCourse(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            // Thêm cột Courses nếu chưa có
            if (!table.Columns.Contains("Courses"))
            {
                table.Columns.Add("Courses", typeof(string));
            }

            foreach (DataRow row in table.Rows)
            {
                int studentId = Convert.ToInt32(row["id"]);
                string courses = GetStudentCourses(studentId);
                row["Courses"] = courses;
            }

            return table;
        }

        private string GetStudentCourses(int studentId)
        {
            List<string> courseList = new List<string>();

            try
            {
                DataTable dt = new DataTable();

                SqlCommand cmd = new SqlCommand(
                    @"SELECT c.label FROM Course c INNER JOIN StudentCourses sc ON c.Id = sc.CourseID WHERE sc.StudentID = @studentId",
                   mydb.getConnection);

                cmd.Parameters.AddWithValue("@studentId", studentId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string courseName = dt.Rows[i]["label"].ToString();
                    courseList.Add(courseName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Join(", ", courseList);
        }

    }
}
