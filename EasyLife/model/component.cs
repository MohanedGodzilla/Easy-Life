using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.model
{
    class component
    {
        public static string conString = env.connectionString;
        public static DataTable establishConnection() {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id,name,count,image,note FROM component", cn))
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

        public static void insert(string name, int count, string note,Image img) {
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                //string query = $"insert into component(name,count,note,image) values (N'{name.ToString()}',{count},N'{note.ToString()}',{arr}) ";
                string query = $"insert into component(name,count,note,image) values (N'{name.ToString()}',{count},N'{note.ToString()}',@photo) ";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@photo", arr);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public static void update(int id,string name, int count, string note, Image img) {
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = $"UPDATE component SET name = N'{name}',count={count},note= N'{note}',image=@photo WHERE id={id}";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@photo", arr);
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
                string query = $"delete from component where id = {id} " ;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public static void deleteAll() {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "delete from component";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DBCC CHECKIDENT (component, RESEED, 0)";
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }
    }
}
