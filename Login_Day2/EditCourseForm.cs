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
    public partial class EditCourseForm : Form
    {
        MY_DB db = new MY_DB();
        public EditCourseForm()
        {
            InitializeComponent();
        }

        private void EditCourseForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadCourses()
        {
            try
            {
                db.openConnection();
                string query = "SELECT Id, label FROM Course";
                SqlCommand command = new SqlCommand(query, db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                SelectCourse_comboBox.DataSource = dt;
                SelectCourse_comboBox.DisplayMember = "abel"; // Hiển thị tên course
                SelectCourse_comboBox.ValueMember = "Id";    // Giá trị thực là ID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khóa học: " + ex.Message);
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
                try
                {
                    db.openConnection();
                    string query = "SELECT label, period, description FROM Course WHERE Id = @CourseId";
                    SqlCommand command = new SqlCommand(query, db.getConnection);
                    command.Parameters.AddWithValue("@CourseId", SelectCourse_comboBox.SelectedValue);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        CourseName_textBox.Text = reader["abel"].ToString();
                        CoursePeriod_numericUpDown.Value= Convert.ToInt32(reader["period"]);
                        CourseDescription_richTextBox.Text = reader["description"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin khóa học: " + ex.Message);
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            if (SelectCourse_comboBox.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khóa học cần chỉnh sửa");
                return;
            }

            if (string.IsNullOrWhiteSpace(CourseName_textBox.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khóa học");
                return;
            }

            if (!int.TryParse(CoursePeriod_numericUpDown.Value.ToString(), out int period) || period <= 10)
            {
                MessageBox.Show("Thời lượng học phải là số và lớn hơn 10");
                return;
            }

            try
            {
                db.openConnection();
                string query = "UPDATE Course SET abel = @Label, period = @Period, description = @Description WHERE Id = @CourseId";
                SqlCommand command = new SqlCommand(query, db.getConnection);
                command.Parameters.AddWithValue("@Label", CourseName_textBox.Text);
                command.Parameters.AddWithValue("@Period", CoursePeriod_numericUpDown.Value.ToString());
                command.Parameters.AddWithValue("@Description", CourseDescription_richTextBox.Text);
                command.Parameters.AddWithValue("@CourseId", SelectCourse_comboBox.SelectedValue);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật khóa học thành công!");
                    LoadCourses(); // Refresh danh sách courses
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật khóa học");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khóa học: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
