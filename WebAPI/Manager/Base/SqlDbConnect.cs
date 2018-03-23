using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Base
{
    public class SqlDbConnect
    {
        private SqlConnection _con;
        public SqlCommand Cmd;
        private SqlDataAdapter _da;
        private DataTable _dt;
        private DataSet _ds;

        public static string connString = ConfigurationManager.ConnectionStrings["WebAPICWA"].ConnectionString;

        public SqlDbConnect()
        {
            _con = new SqlConnection(connString);
            _con.Open();
        }

        public void SqlQuery(string queryText)
        {
            Cmd = new SqlCommand(queryText, _con);
        }

        public DataTable QueryEx()
        {
            _da = new SqlDataAdapter(Cmd);
            _dt = new DataTable();
            _da.Fill(_dt);
            return _dt;
        }

        public DataSet QueryExReport()
        {
            _da = new SqlDataAdapter(Cmd);
            _ds = new DataSet();
            _da.Fill(_ds);
            return _ds;
        }

        public void NonQueryEx()
        {
            Cmd.ExecuteNonQuery();
        }
    }
}
