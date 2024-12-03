using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G202CHAnSaleDDTM
{
    internal class ketnoi
    {
        private string connectstring = @"Data Source=LAPTOP-LRI6D6OE;Initial Catalog=1G202AnSaleDDTN;Integrated Security=True";
        public SqlConnection getConnect()
        {
            SqlConnection conn = new SqlConnection(connectstring); 
            conn.Open();
            return conn;
        }

        public DataTable sanpham()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from DMSPDD", getConnect());
            adapter.Fill(data);
            return data;
        }
        public int ExecutenonQuery(string query)
        {
            int data = 0;
            using (SqlConnection Ketnoi = new SqlConnection(connectstring))
            {
                Ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, Ketnoi);
                data = thucthi.ExecuteNonQuery();
                Ketnoi.Close();
            }
            return data;
        }

        public DataTable ExcuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Ketnoi = new SqlConnection(connectstring))
            {
                Ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, Ketnoi);
                SqlDataAdapter laydulieu = new SqlDataAdapter(thucthi);
                laydulieu.Fill(dt);
                Ketnoi.Close();
            }
            return dt;
        }

        internal void ExcuteNonQuery(string v)
        {
            throw new NotImplementedException();
        }

        internal static DataTable ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        internal static int ExecuteNonQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}
