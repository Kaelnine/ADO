using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;
using TaskTrackingApp.Core;
using TaskTrackingApp.Core.Dtos;
using TaskTrackingApp.DAL.Queries;

namespace TaskTrackingApp.DAL
{
    public class TaskRepository
    {
        public int AddTask(TaskDto task)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            { 
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(TaskQuery.AddTask, connection);
                command.Parameters.Add(new NpgsqlParameter("@name", task.Name));
                command.Parameters.Add(new NpgsqlParameter("@description", task.Description));
                command.Parameters.Add(new NpgsqlParameter("@idManager", task.IdManager));
                command.Parameters.Add(new NpgsqlParameter("@idStaff", task.IdStaff));
                command.Parameters.Add(new NpgsqlParameter("@assignmentDate", task.AssignmentDate));
                command.Parameters.Add(new NpgsqlParameter("@periodExecution", task.PeriodExecution));  
                //command.Parameters.Add(new NpgsqlParameter("@completionDate", task.CompletionDate));
                int id = (int)command.ExecuteScalar();
                return id;
            }
        }

        public List<TaskDto> GetAllTasks()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(TaskQuery.GetAllTasksForDataGrid, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                List<TaskDto> tasks = new List<TaskDto>();
                //MessageBox.Show("");
                while (reader.Read())
                {
                    
                    TaskDto task = new TaskDto()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        OrderStatus = reader.GetString(3),
                        //IdStatus = reader.GetInt32(3),
                        NameManager = reader.GetString(4),
                        //IdManager = reader.GetInt32(4),
                        NameStaff = reader.GetString(5),
                        //IdStaff = reader.GetInt32(5),
                        AssignmentDate = reader.GetDateTime(6),
                        PeriodExecution = reader.GetDateTime(7),
                        CompletionDate = reader.GetDateTime(8),
                        
                    };
                    
                    tasks.Add(task);
                    //MessageBox.Show("");
                }
                return tasks;
            }
        }
    }
}
