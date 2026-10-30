using System;
using System.Data;
using System.Data.SqlClient;

namespace Bai5_3.DAL
{
    public class DatabaseHelper
    {
        // Chuỗi kết nối đến CSDL CafePOSDB
        public static string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CafePOSDB;Integrated Security=True;TrustServerCertificate=True";

        // Mô hình ngắt kết nối: Lấy dữ liệu bằng SqlDataAdapter + DataTable
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Thực thi Insert / Update / Delete đơn lẻ
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}