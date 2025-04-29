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
using System.Windows.Forms.DataVisualization.Charting;

namespace Login_Day2
{
    public partial class Staticresult : Form
    {
        MY_DB db = new MY_DB();
        public Staticresult()
        {
            InitializeComponent();
            LoadStatisticsByCourses();
            LoadStatisticsByResult();
        }

        private void StaticsByResult_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void Staticresult_Load(object sender, EventArgs e)
        {

        }
        private void LoadStatisticsByCourses()
        {
            try
            {
                // Bước 1: Lấy danh sách môn học và điểm trung bình
                SqlCommand command = new SqlCommand(
                    "SELECT sc.CourseID, sc.CourseName, AVG(s.StudentScore) AS AvgScore " +
                    "FROM StudentCourses sc " +
                    "LEFT JOIN Score s ON sc.StudentID = s.StudentID AND sc.CourseID = s.CourseID " +
                    "GROUP BY sc.CourseID, sc.CourseName", db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable courseTable = new DataTable();
                adapter.Fill(courseTable);

                // Bước 2: Hiển thị danh sách môn học và điểm trung bình
                courseListBox.Items.Clear();
                foreach (DataRow row in courseTable.Rows)
                {
                    string courseName = row["CourseName"].ToString();
                    double avgScore = row["AvgScore"] != DBNull.Value ? Convert.ToDouble(row["AvgScore"]) : 0;
                    courseListBox.Items.Add($"{courseName}: {avgScore:F2}");
                }

                // Bước 3: Vẽ biểu đồ cho điểm trung bình của các môn
                StaticsByCourse_chart.Series.Clear();
                Series series = new Series("Series1")
                {
                    ChartType = SeriesChartType.Column
                };

                foreach (DataRow row in courseTable.Rows)
                {
                    string courseName = row["CourseName"].ToString();
                    double avgScore = row["AvgScore"] != DBNull.Value ? Convert.ToDouble(row["AvgScore"]) : 0;
                    series.Points.AddXY(courseName, avgScore);
                }

                StaticsByCourse_chart.Series.Add(series);
                StaticsByCourse_chart.ChartAreas[0].AxisX.Title = "Courses";
                StaticsByCourse_chart.ChartAreas[0].AxisY.Title = "Average Score";
                StaticsByCourse_chart.ChartAreas[0].AxisY.Maximum = 10;
                StaticsByCourse_chart.ChartAreas[0].AxisY.Minimum = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics by courses: " + ex.Message, "Error");
            }
        }
        private void LoadStatisticsByResult()
        {
            try
            {
                // Bước 1: Tính điểm trung bình của từng sinh viên
                SqlCommand command = new SqlCommand(
                    "SELECT s.Id, AVG(sc.StudentScore) AS AvgScore " +
                    "FROM std s " +
                    "LEFT JOIN Score sc ON s.Id = sc.StudentID " +
                    "GROUP BY s.Id", db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable studentTable = new DataTable();
                adapter.Fill(studentTable);

                // Bước 2: Đếm số lượng sinh viên theo xếp loại
                int totalStudents = studentTable.Rows.Count;
                int passCount = 0, failCount = 0;
                int excellentCount = 0, goodCount = 0, averageCount = 0, failRankCount = 0;

                foreach (DataRow row in studentTable.Rows)
                {
                    double avgScore = row["AvgScore"] != DBNull.Value ? Convert.ToDouble(row["AvgScore"]) : 0;

                    // Tính tỉ lệ đậu/rớt
                    if (avgScore >= 5.0)
                        passCount++;
                    else
                        failCount++;

                    // Đếm số lượng sinh viên theo xếp loại
                    if (avgScore >= 8.5)
                        excellentCount++;
                    else if (avgScore >= 7.0)
                        goodCount++;
                    else if (avgScore >= 5.0)
                        averageCount++;
                    else
                        failRankCount++;
                }

                // Bước 3: Hiển thị tỉ lệ đậu/rớt
                double passRate = totalStudents > 0 ? (passCount * 100.0 / totalStudents) : 0;
                double failRate = totalStudents > 0 ? (failCount * 100.0 / totalStudents) : 0;
                Pass_lb.Text = $"Pass: {passRate:F2}%";
                Fail_lb.Text = $"Fail: {failRate:F2}%";

                // Bước 4: Vẽ biểu đồ xếp loại
                resultChart.Series.Clear();
                Series series = new Series("Series1")
                {
                    ChartType = SeriesChartType.Column
                };

                series.Points.AddXY("Giỏi", excellentCount);
                series.Points.AddXY("Khá", goodCount);
                series.Points.AddXY("Trung bình", averageCount);
                series.Points.AddXY("Rớt", failRankCount);

                resultChart.Series.Add(series);
                resultChart.ChartAreas[0].AxisX.Title = "Rank";
                resultChart.ChartAreas[0].AxisY.Title = "Number of Students";
                resultChart.ChartAreas[0].AxisY.Maximum = Math.Max(totalStudents, 1);
                resultChart.ChartAreas[0].AxisY.Minimum = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics by result: " + ex.Message, "Error");
            }
        }
    }
}
