using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SFS_ASP_1.Controllers
{
    public class Conexion
    {
        public static DataSet Ejecutar_ds(string cmd)
        {
            string Cadecone = ConfigurationManager.AppSettings["CadeCone"].ToString();
            SqlConnection con = new SqlConnection(Cadecone);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd, con);
            da.Fill(ds);
            con.Close();
            return ds;

        }

        public static DataTable Ejecutar_dt(string cmd)
        {
            DataTable dt;
            string Cadecone = ConfigurationManager.AppSettings["CadeCone"].ToString();
            SqlConnection con = new SqlConnection(Cadecone);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd, con);
            da.Fill(ds);
            con.Close();
            dt = ds.Tables[0];
            return dt;

        }

        public static void EjecutarQuery(string cmd)
        {
            
            string Cadecone = ConfigurationManager.AppSettings["CadeCone"].ToString();
            SqlConnection con = new SqlConnection(Cadecone);
            SqlCommand command = new SqlCommand(cmd, con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
