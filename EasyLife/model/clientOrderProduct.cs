using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.model
{
    class clientOrderProduct
    {
        public static string conString = env.connectionString;
        public static void insert(int clientId, int productId,string paid,string color,string note)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = $"insert into client_orders_product(client_id,product_id,paid,color,note) values ({clientId},{productId},'{paid}',N'{color}',N'{note}') ";
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
                string query = $"delete from client_orders_product where client_id = {id} ";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }
    }
}
