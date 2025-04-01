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
    public partial class Statistic : Form
    {
        MY_DB mydb = new MY_DB();
        public Statistic()
        {
            InitializeComponent();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            int count = 0;
            int count_male = 0;
            int count_female = 0;
            mydb.openConnection();
            SqlCommand cmdSum = new SqlCommand("Select count(*) from std", mydb.getConnection);
            SqlCommand cmdSumFemale = new SqlCommand("Select count(*) from std Where gender = 'Female' ", mydb.getConnection);
            SqlCommand cmdSumMale = new SqlCommand("Select count(*) from std Where gender ='Male' ", mydb.getConnection);

            count = (int)cmdSum.ExecuteScalar();
            count_female = (int)cmdSumFemale.ExecuteScalar();
            count_male = (int)cmdSumMale.ExecuteScalar();

            SumFemale_label.Text = "Female: "+ count_female.ToString();
            SumMale_label.Text = "Male: "+ count_male.ToString();
            SumQuantity_label.Text = "ToTal: "+ count.ToString();
            mydb.closeConnection();


        }
    }
}
