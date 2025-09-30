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
            SELECT T."IdTasks", T."NameTask", T."DescriptionTask", TS."NameStatus", M."NameManager", S."NameStaff", T."AssignmentDateTask", T."PeriodExecutionTask", T."CompletionDateTask"
            FROM public."Tasks" AS T
            JOIN public."TaskStatus" AS TS ON T."OrderStatus"=TS."OrderStatus"
            JOIN public."Managers" AS M ON T."IdManager"=M."IdManager"
            JOIN public."Staff" AS S ON T."IdStaff"=S."IdStaff"
            WHERE S."IdStaff"=@idStaff;
            """;

        public const string GetAllStaff =
            """
            SELECT "IdStaff", "NameStaff", "PostStaff"
            FROM public."Staff";
            """;
    }
}
