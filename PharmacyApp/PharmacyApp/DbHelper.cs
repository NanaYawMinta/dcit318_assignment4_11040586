using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PharmacyApp
{
    internal static class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}









