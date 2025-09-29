using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingApp.Core;
using TaskTrackingApp.Core.Dtos;
using TaskTrackingApp.DAL.Queries;

namespace TaskTrackingApp.DAL
{
    public class TaskStatusRepository
    {
        public List<TaskStatusDto> GetAllTaskStatus()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(TaskStatusQuery.GetAllTaskStatus, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                List<TaskStatusDto> taskStatuses = new List<TaskStatusDto>();
                while (reader.Read())
                {
                    TaskStatusDto taskStatus = new TaskStatusDto()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Order = reader.GetInt32(2)
                    };
                    taskStatuses.Add(taskStatus);
                }
                return taskStatuses;
            }
        }
    }
}
