using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingApp.DAL.Queries
{
    public class TaskStatusQuery
    {
        public const string GetAllTaskStatus =
            """
            SELECT "IdStatus", "NameStatus", "OrderStatus"
            FROM public."TaskStatus";
            """;
    }
}
