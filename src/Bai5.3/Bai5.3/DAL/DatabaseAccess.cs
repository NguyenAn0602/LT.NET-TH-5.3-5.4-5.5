using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Bai5._3.DAL
{
    public class DatabaseAccess
    {
        // Chuỗi kết nối CSDL MySQL trên XAMPP
        protected string connectionString = "Server=localhost;Database=CafePOSDB;Uid=root;Pwd=;Port=3306;";

        // Thực thi câu lệnh Query trả về DataTable (Mô hình ngắt kết nối)
        public DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Thực thi Insert/Update/Delete trả về số dòng bị tác động
        public int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }

        // Thực thi trả về giá trị đơn (SELECT COUNT, SELECT LAST_INSERT_ID,...)
        public object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}