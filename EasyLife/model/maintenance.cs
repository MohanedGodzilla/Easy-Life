using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.model
{
    class maintenance
    {
        public static string conString = env.connectionString;
        public static DataTable establishConnection()
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id,name,phone,note FROM maintenance", cn))
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

        public static void insert(string name, string phone, string note)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                //string query = $"insert into component(name,count,note,image) values (N'{name.ToString()}',{count},N'{note.ToString()}',{arr}) ";
                string query = $"insert into maintenance(name,phone,note) values (N'{name.ToString()}','{phone.ToString()}',N'{note.ToString()}') ";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public static void update(int id, string name, string phone, string note)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = $"UPDATE maintenance SET name = N'{name}',phone= '{phone.ToString()}',note= N'{note}' WHERE id={id}";
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
                string query = $"delete from maintenance where id = {id} ";
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
                string query = "delete from maintenance";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DBCC CHECKIDENT (maintenance, RESEED, 0)";
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }
    }
}
