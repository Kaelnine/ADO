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
            VALUES (@name, @post);
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
            SELECT
            T."IdTasks", T."NameTask", T."DescriptionTask", T."IdStatus", T."IdStaff", T."AssignmentDateTask", T."PeriodExecutionTask", T."CompletionDateTask"
            FROM public."Managers" AS M
            JOIN public."Tasks" AS T ON M."IdManager"=T."IdManager"
            WHERE M."IdManager"=@id;
            """;
    }
}
