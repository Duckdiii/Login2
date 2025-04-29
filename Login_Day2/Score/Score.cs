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
    internal class Score
    {
        MY_DB mydb = new MY_DB();
        /// them diem
        public bool insertScore(int studentID, string courseID, float scoreValue, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO dbo.Score (StudentID, CourseID, StudentScore, Description) " +
                               "VALUES (@sid, @cid, @scr, @descr)", mydb.getConnection);
            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            command.Parameters.AddWithValue("@cid", courseID);
            command.Parameters.Add("@scr", SqlDbType.Float).Value = scoreValue;
            command.Parameters.AddWithValue("@descr", description);

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// ktra trung, tuong tu cac phan khac
        public bool studentScoreExist(int studentID, string courseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Score WHERE StudentID = @sid AND CourseID= @cid", mydb.getConnection);
            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            command.Parameters.AddWithValue("@cid", courseID);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if ((table.Rows.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// tinh trung binh
        public DataTable getAvgScoreByCourse()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT CourseID, AVG(StudentScore) AS AverageScore " +
                               "FROM dbo.Score " +
                               "GROUP BY CourseID";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        /// delete score bằng student_id, và course_id
        public bool deleteScore(int studentID, string courseID)
        {
            SqlCommand command = new SqlCommand(
         "UPDATE dbo.Score SET StudentScore = 0, Description = '' WHERE StudentID = @sid AND CourseID = @cid",
         mydb.getConnection);

            command.Parameters.AddWithValue("@sid", studentID);
            command.Parameters.AddWithValue("@cid", courseID);

            try
            {
                mydb.openConnection();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                mydb.closeConnection();
            }
        }
        public void getAllScores(ref DataTable resultTable)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Score", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            resultTable = new DataTable();

            adapter.Fill(resultTable);
        }
        public void getAllScoresByStdID(ref DataTable resultTable)
        {
            string query = @"
        SELECT s.StudentID, s.CourseID, s.StudentScore, s.Description,
               std.fname, std.lname, c.label AS CourseLabel
        FROM Score s
        INNER JOIN StudentCourses sc ON s.StudentID = sc.StudentID AND s.CourseID = sc.CourseID
        INNER JOIN std ON s.StudentID = std.Id
        INNER JOIN Course c ON s.CourseID = c.Id";

            try
            {
                mydb.openConnection();
                SqlCommand command = new SqlCommand(query, mydb.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                resultTable = new DataTable();
                adapter.Fill(resultTable);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách điểm: " + ex.Message);
            }
            finally
            {
                mydb.closeConnection();
            }
        }
    }
}
