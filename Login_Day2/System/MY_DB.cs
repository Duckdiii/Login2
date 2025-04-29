using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Day2
{
    internal class MY_DB
    {
        // 1. Khai báo một đối tượng SqlConnection để kết nối đến CSDL
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=myDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //2. Thuộc tính getConnection để lấy đối tượng SqlConnection
        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }


        // 3. Phương thức mở kết nối
        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))
            {
                con.Open();
            }

        }


        // 4. Phương thức đóng kết nối
        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
            {
                con.Close();
            }

        }


    }
}
