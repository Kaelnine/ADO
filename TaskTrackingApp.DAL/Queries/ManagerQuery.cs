using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingApp.DAL.Queries
{
    public class ManagerQuery
    {
        public const string AddManager =
            """
            INSERT INTO public."Managers"(
            "NameManager", "PostManager")
            VALUES (@name, @post)
            RETURNING "IdManager";
            """;

        public const string UpdateManager =
            """
            UPDATE public."Managers"
            SET "NameManager"=@name, "PostManager"=@post
            WHERE "IdManager"=@id;
            """;

        public const string DeleteManager =
            """
            DELETE FROM public."Managers"
            WHERE "IdManager"=@id;
            """;

        public const string GetAllTasksManager =
            """
            SELECT T."IdTasks", T."NameTask", T."DescriptionTask", TS."NameStatus", M."NameManager", S."NameStaff", T."AssignmentDateTask", T."PeriodExecutionTask", T."CompletionDateTask"
            FROM public."Tasks" AS T
            JOIN public."TaskStatus" AS TS ON T."OrderStatus"=TS."OrderStatus"
            JOIN public."Managers" AS M ON T."IdManager"=M."IdManager"
            JOIN public."Staff" AS S ON T."IdStaff"=S."IdStaff"
            WHERE T."IdManager"=@idManager;
            """;

        public const string GetAllManagers =
            """
            SELECT "IdManager", "NameManager", "PostManager"
            FROM public."Managers";
            """;
    }
}
