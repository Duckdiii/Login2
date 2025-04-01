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

        public bool checkCourseName(string courseName)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Course WHERE abel = @name", mydb.getConnection);
            command.Parameters.AddWithValue("@name", courseName);

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            return count > 0;
        }

        public bool deleteCourse(int courseId)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE Id = @id", mydb.getConnection);
            command.Parameters.AddWithValue("@id", courseId);

            mydb.openConnection();
            int result = command.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0;
        }

        public void getAllCourses(ref DataTable resultTable)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            resultTable = new DataTable();

            adapter.Fill(resultTable);
        }

        public void getCourseById(int courseId, ref DataTable resultTable)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE Id = @id", mydb.getConnection);
            command.Parameters.AddWithValue("@id", courseId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            resultTable = new DataTable();

            adapter.Fill(resultTable);
        }

        public bool insertCourse(string id, string name, string period, string description)
        {
            SqlCommand command = new SqlCommand(
                "INSERT INTO Course (Id, abel, period, description) VALUES (@id, @name, @period, @desc)",
                mydb.getConnection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@period", period);
            command.Parameters.AddWithValue("@desc", description);

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

        public bool updateCourse(int courseId, string name, string period, string description)
        {
            SqlCommand command = new SqlCommand(
                "UPDATE Course SET abel = @name, period = @period, description = @desc WHERE Id = @id",
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
    }
}
