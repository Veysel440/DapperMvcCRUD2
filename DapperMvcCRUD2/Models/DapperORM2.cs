using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DapperMvcCRUD2.Models
{
    public class DapperORM2
    {
        private static string connectionString = @"Data Source=DESKTOP-EUFH0D7; Initial Catalog=MVCDapperDB2; Integrated Security=true;";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param2 = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                con.Execute(procedureName, param2, commandType: CommandType.StoredProcedure);
            }
        }
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param2 = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return (T)Convert.ChangeType(con.ExecuteScalar(procedureName, param2, commandType: CommandType.StoredProcedure), typeof(T)); ;
            }
        }
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param2 = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.Query<T>(procedureName, param2, commandType: CommandType.StoredProcedure);
            }
        }
    }
}