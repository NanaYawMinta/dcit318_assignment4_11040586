using System.Configuration;
using System.Data.SqlClient;

namespace MedicalApp
{
    internal static class Db
    {
        public static SqlConnection GetConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings["MedicalDB"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}
