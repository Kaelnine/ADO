namespace TaskTrackingApp.DAL.Queries
{
	public class TaskQuery
	{
		public const string AddTask =
			"""
			INSERT INTO public."Tasks"(
			"NameTask", "DescriptionTask", "IdManager", "IdStaff", "AssignmentDateTask", "PeriodExecutionTask")
			VALUES (@name, @description, @idManager, @idStaff, @assignmentDate, @periodExecution)
			RETURNING "IdTasks";
			""";

		public const string GetAllTasks =
			"""
			SELECT "IdTasks", "NameTask", "DescriptionTask", "IdStatus", "IdManager", "IdStaff", "AssignmentDateTask", "PeriodExecutionTask", "CompletionDateTask"
			FROM public."Tasks";
			""";

		public const string GetAllTasksForDataGrid =
			"""
			SELECT T."IdTasks", T."NameTask", T."DescriptionTask", TS."IdStatus", TS."NameStatus", M."IdManager", M."NameManager", S."IdStaff", S."NameStaff", T."AssignmentDateTask", T."PeriodExecutionTask", T."CompletionDateTask"
			FROM public."Tasks" AS T
			JOIN public."TaskStatus" AS TS ON T."OrderStatus"=TS."OrderStatus"
			JOIN public."Managers" AS M ON T."IdManager"=M."IdManager"
			JOIN public."Staff" AS S ON T."IdStaff"=S."IdStaff";
			""";

		public const string GetAllMergeTasks =
			"""
			SELECT T."IdTasks", T."NameTask", T."DescriptionTask", TS."NameStatus", M."NameManager", S."NameStaff", T."AssignmentDateTask", T."PeriodExecutionTask", T."CompletionDateTask"
			FROM public."Tasks" AS T
			JOIN public."TaskStatus" AS TS ON T."OrderStatus"=TS."OrderStatus"
			JOIN public."Managers" AS M ON T."IdManager"=M."IdManager"
			JOIN public."Staff" AS S ON T."IdStaff"=S."IdStaff"
			WHERE T."IdManager"=@idManager AND T."IdStaff"=@idStaff;
			""";

		public const string DeleteTask =
			"""
			DELETE FROM public."Tasks"
			WHERE "IdTasks"=@id;
			""";

		public const string UpdateTask =
			"""
			UPDATE public."Tasks"
			SET "NameTask"=@name, "DescriptionTask"=@description, "OrderStatus"=@status, "IdManager"=@manager, "IdStaff"=@staff, "AssignmentDateTask"=@assignment, "PeriodExecutionTask"=@execution, "CompletionDateTask"=@complete
			WHERE "IdTasks"=@id;
			""";
	}
}
