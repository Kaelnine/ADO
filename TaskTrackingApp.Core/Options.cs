using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingApp.Core
{
    public class Options
    {
        public static string ConnectionString
        {
            get
            {
                return "Server = localhost; Port = 5432; User Id = postgres; Password = ; Database = TaskTracking;";
            }
        }
    }
}
