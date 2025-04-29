using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Day2
{
    public partial class EditCourseForm : Form
    {
        MY_DB db = new MY_DB();
        COURSE course = new COURSE();
        public EditCourseForm()
        {
            InitializeComponent();
            LoadCourses();
        }

        private void EditCourseForm_Load(object sender, EventArgs e)
        {
        }
        private void LoadCourses()
        {
            try
            {
                db.openConnection();
                string query = "SELECT Id, label FROM dbo.Course";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.getConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Thêm cột mới để kết hợp Id và label
                dt.Columns.Add("DisplayText", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    row["DisplayText"] = $"{row["Id"]} - {row["label"]}";
                }

                // Hiển thị danh sách khóa học trong ComboBox
                SelectCourse_comboBox.DataSource = dt;
                SelectCourse_comboBox.DisplayMember = "DisplayText"; // Hiển thị cả Id và label
                SelectCourse_comboBox.ValueMember = "Id";           // Giá trị vẫn là Id

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }
        private void LoadCourseDetails(string courseID)
        {
            try
            {
                db.openConnection();
                string query = "SELECT label, period, description FROM dbo.Course WHERE Id = @CourseID";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@CourseID", courseID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    CourseName_textBox.Text = reader["label"].ToString();
                    CoursePeriod_numericUpDown.Value = reader["period"] != DBNull.Value ? Convert.ToInt32(reader["period"]) : 0;
                    CourseDescription_richTextBox.Text = reader["description"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading course details: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void SelectCourse_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectCourse_comboBox.SelectedValue != null)
            {
                LoadCourseDetails(SelectCourse_comboBox.SelectedValue.ToString());
            }
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectCourse_comboBox.SelectedValue?.ToString()) ||
                 string.IsNullOrEmpty(CourseName_textBox.Text))
            {
                MessageBox.Show("Please select a course and fill in the label.");
                return;
            }
            string id = SelectCourse_comboBox.SelectedValue.ToString();
            string nameCourse = CourseName_textBox.Text;
            int period = (int)CoursePeriod_numericUpDown.Value;
            string description = CourseDescription_richTextBox.Text;
            if (course.checkCourseName(id, nameCourse))
            {
                MessageBox.Show("Course name already exists!");
            }

            else if (course.updateCourse(id, nameCourse, period, description))
            {
                MessageBox.Show("Course updated successfully!");

            }
            else MessageBox.Show("Course cannot be updated successfully!");

            // Làm mới danh sách khóa học
            LoadCourses();
        }


    }
}
