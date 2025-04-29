using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Day2
{
    internal class COURSE
    {
        MY_DB mydb = new MY_DB();

        public bool checkCourseName(string idCourse, string courseName)
        {
            string query = "SELECT COUNT(*) FROM Course WHERE label = @name AND Id != @id";
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            command.Parameters.AddWithValue("@name", courseName);
            command.Parameters.AddWithValue("@id", idCourse);

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            return count > 0;
        }

        public bool deleteCourse(string courseId)
        {
            SqlTransaction transaction = null;
            try
            {
                mydb.openConnection();
                transaction = mydb.getConnection.BeginTransaction();

                // Xóa bản ghi trong bảng Score
                using (SqlCommand cmdDelScores = new SqlCommand("DELETE FROM Score WHERE CourseID = @id", mydb.getConnection))
                {
                    cmdDelScores.Transaction = transaction;
                    cmdDelScores.Parameters.AddWithValue("@id", courseId);
                    cmdDelScores.ExecuteNonQuery();
                }

                // Xóa bản ghi trong bảng StudentCourses
                using (SqlCommand cmdDelStudentCourses = new SqlCommand("DELETE FROM StudentCourses WHERE CourseID = @id", mydb.getConnection))
                {
                    cmdDelStudentCourses.Transaction = transaction;
                    cmdDelStudentCourses.Parameters.AddWithValue("@id", courseId);
                    cmdDelStudentCourses.ExecuteNonQuery();
                }

                // Xóa môn học
                using (SqlCommand command = new SqlCommand("DELETE FROM Course WHERE Id = @id", mydb.getConnection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@id", courseId);
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

        public void getAllCourses(ref DataTable resultTable)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            resultTable = new DataTable();

            adapter.Fill(resultTable);
        }

        public void getCourseById(string courseId, ref DataTable resultTable)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE Id = @id", mydb.getConnection);
            command.Parameters.AddWithValue("@id", courseId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            resultTable = new DataTable();

            adapter.Fill(resultTable);
        }

        public bool insertCourse(string id, string name, string period, string description, int semester)
        {
            SqlCommand command = new SqlCommand(
                "INSERT INTO Course (Id, label, semester, period, description) VALUES (@id, @name,@semester, @period, @desc)",
                mydb.getConnection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@period", period);
            command.Parameters.AddWithValue("@desc", description);
            command.Parameters.AddWithValue("@semester", semester);


            mydb.openConnection();
            int result = command.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0;
        }

        public int totalCourses()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Course", mydb.getConnection);

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            return count;
        }

        public bool updateCourse(string courseId,string name, int period, string description)
        {
            SqlCommand command = new SqlCommand(
                "UPDATE Course SET label = @name, period = @period, description = @desc WHERE Id = @id",
                mydb.getConnection);

            command.Parameters.AddWithValue("@id", courseId);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@period", period);
            command.Parameters.AddWithValue("@desc", description);

            mydb.openConnection();
            int result = command.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0;
        }
        public string FindCourseID(string courseInfo)
        {
            // Tách chuỗi "label - period" để lấy label
            string[] parts = courseInfo.Split(new[] { " - " }, StringSplitOptions.None);
            if (parts.Length < 1)
            {
                return "";
            }
            string courseLabel = parts[0];

            string idCourse = "";
            SqlCommand command = new SqlCommand("SELECT Id FROM Course WHERE label = @label", mydb.getConnection);
            command.Parameters.AddWithValue("@label", courseLabel);

            mydb.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                idCourse = reader["Id"].ToString();
            }
            reader.Close();
            mydb.closeConnection();

            return idCourse;
        }
       
        public string FindCourseLabel(string courseId)
        {
            SqlCommand cmd = new SqlCommand("SELECT label FROM Course WHERE Id = @id", mydb.getConnection);
            cmd.Parameters.AddWithValue("@id", courseId);
            mydb.openConnection();
            object result = cmd.ExecuteScalar();
            mydb.closeConnection();
            return result?.ToString() ?? "Unknown";
        }
        public bool IsStudentEnrolled(int studentId, string courseId)
        {
            SqlCommand command = new SqlCommand(
                "SELECT COUNT(*) FROM StudentCourses WHERE StudentID = @sid AND CourseID = @cid",
                mydb.getConnection);

            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentId;
            command.Parameters.Add("@cid", SqlDbType.NVarChar).Value = courseId;

            try
            {
                mydb.openConnection();
                int count = (int)command.ExecuteScalar();
                return count > 0; // Trả về true nếu sinh viên đã đăng ký môn học
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra đăng ký môn học: " + ex.Message);
            }
            finally
            {
                mydb.closeConnection();
            }
        }
    }
}
