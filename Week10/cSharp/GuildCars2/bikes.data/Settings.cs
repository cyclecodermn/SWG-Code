using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace bikes.data
{
   public class Settings
   {
       private static string _connectionString;
       public static string GetConnectionString()
       {
           if (string.IsNullOrEmpty(_connectionString))

               _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
           return _connectionString;
       }
   }
}
