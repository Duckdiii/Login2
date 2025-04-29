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
    public partial class AverageScoreForm : Form
    {
        MY_DB db = new MY_DB();
        Score score = new Score();
        public AverageScoreForm()
        {
            InitializeComponent();
            LoadAverageScores();
        }

        private void AverageScoreForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadAverageScores()
        {
            try
            {
                DataTable avgScoreTable = score.getAvgScoreByCourse();

                DataTable finalTable = new DataTable();
                finalTable.Columns.Add("CourseID", typeof(string));
                finalTable.Columns.Add("CourseName", typeof(string));
                finalTable.Columns.Add("AverageScore", typeof(double));

                db.openConnection();

                foreach (DataRow row in avgScoreTable.Rows)
                {
                    string courseId = row["CourseID"].ToString();
                    double averageScore = Convert.ToDouble(row["AverageScore"]);

                    SqlCommand command = new SqlCommand("SELECT label FROM Course WHERE Id = @cid", db.getConnection);
                    command.Parameters.AddWithValue("@cid", courseId);
                    SqlDataReader reader = command.ExecuteReader();

                    string courseName = "";
                    if (reader.Read())
                    {
                        courseName = reader["label"].ToString();
                    }
                    reader.Close();

                    finalTable.Rows.Add(courseId, courseName, averageScore);
                }

                AverageScore_dataGridView.DataSource = finalTable;

                AverageScore_dataGridView.Columns["CourseID"].HeaderText = "Course ID";
                AverageScore_dataGridView.Columns["CourseName"].HeaderText = "Course Name";
                AverageScore_dataGridView.Columns["AverageScore"].HeaderText = "Average Score";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading average scores: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
