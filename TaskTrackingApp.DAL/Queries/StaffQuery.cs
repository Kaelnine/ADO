using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingApp.DAL.Queries
{
    public class StaffQuery
    {
        public const string AddStaff =
            """
            INSERT INTO public."Staff"(
            "NameStaff", "PostStaff")
            VALUES (@name, @post)
            RETURNING "IdStaff";
            """;

        public const string UpdateStaff =
            """
            UPDATE public."Staff"
            SET "NameStaff"=@name, "PostStaff"=@post
            WHERE "IdStaff"=@id;
            """;

        public const string DeleteStaff =
            """
            DELETE FROM public."Staff"
            WHERE "IdStaff"=@id;
            """;

        public const string GetAllTasksStaff =
            """
            SELECT
            T."IdTasks", T."NameTask", T."DescriptionTask", T."IdStatus", T."IdStaff", T."AssignmentDateTask", T."PeriodExecutionTask", T."CompletionDateTask"
            FROM public."Staff" AS S
            JOIN public."Tasks" AS T ON S."IdStaff"=T."IdStaff"
            WHERE S."IdStaff"=@id;
            """;

        public const string GetAllStaff =
            """
            SELECT "IdStaff", "NameStaff", "PostStaff"
            FROM public."Staff";
            """;
    }
}
