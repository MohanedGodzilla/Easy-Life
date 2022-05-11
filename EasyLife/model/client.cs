using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.model
{
    class client
    {
        public static string conString = env.connectionString;
        public static DataTable establishConnection()
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT c.id ,c.name ,c.phone ,cp.paid ,cp.color ,p.name AS 'product name' ,cp.note FROM client_orders_product cp,client c,product p WHERE c.id= cp.client_id AND p.Id = cp.product_id", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    cn.Close();
                    return dt;
                }
            }
        }

        public static void insert(string name,string national_code,string phone,string mail) {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = $"insert into client (name,national_code,phone,mail) values (N'{name}','{national_code}','{phone}','{mail}')";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void update(int id,string name, string national_code, string phone, string mail)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = $"UPDATE client SET name = N'{name}',national_code='{national_code}',phone='{phone}',mail='{mail}' WHERE id={id}";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public static void delete(int id)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = $"delete from client where id = {id} ";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public static void deleteAll()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "delete from client";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DBCC CHECKIDENT (client, RESEED, 0)";
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public static int getTheMaxId()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT MAX(id) from client";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            int val = (int)cmd.ExecuteScalar();
            cn.Close();
            return val;
        }
    }
}
