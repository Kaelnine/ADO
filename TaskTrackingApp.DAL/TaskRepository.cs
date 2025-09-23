using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using TaskTrackingApp.Core;
using TaskTrackingApp.Core.Dtos;
using TaskTrackingApp.DAL.Queries;

namespace TaskTrackingApp.DAL
{
    class TaskRepository
    {
        public int AddTask(TaskDto task)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            { 
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(TaskQuery.AddTask, connection);
                command.Parameters.Add("");

                return id;
            }
        }
    }
}
