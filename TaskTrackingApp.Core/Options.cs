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
                return "Host=localhost;Port=5432;Username=Administrator;Password=12345678;Database=TaskTracking;";
            }
        }
    }
}
