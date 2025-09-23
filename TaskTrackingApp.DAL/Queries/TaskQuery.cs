using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingApp.DAL.Queries
{
    public class TaskQuery
    {
        public const string AddTask =
            """
            INSERT INTO public."Tasks"(
            "NameTask", "DescriptionTask", "IdManager", "IdStaff", "AssignmentDateTask", "PeriodExecutionTask")
            VALUES (@name, @description, @idManager, @idStaff, @assignmentDate, @periodExecution);
            """;
    }
}
