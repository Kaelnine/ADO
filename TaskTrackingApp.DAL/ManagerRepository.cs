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
    public class ManagerRepository
    {
        public int AddManager(ManagerDto manager)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(ManagerQuery.AddManager, connection);
                command.Parameters.Add(new NpgsqlParameter("@name", manager.Name));
                command.Parameters.Add(new NpgsqlParameter("@post", manager.Post));
                int id = (int)command.ExecuteScalar();
                return id;
            }
        }

        public List<TaskDto> GetTasksByManagerId(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(ManagerQuery.GetAllTasksManager, connection);
                command.Parameters.Add(new NpgsqlParameter("@idManager", id));
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

                }
                return tasks;

            }
        }

        public List<ManagerDto> GetAllManagers()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(ManagerQuery.GetAllManagers, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                List<ManagerDto> managers = new List<ManagerDto>();
                while (reader.Read())
                {
                    ManagerDto manager = new ManagerDto()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Post = reader.GetString(2)
                    };
                    managers.Add(manager);
                }
                return managers;
            }
        }

        public void DeleteManager(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(ManagerQuery.DeleteManager, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", id));
                int m = command.ExecuteNonQuery();
            }
        }

        public void UpdateManager(ManagerDto manager, string name, string post)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(ManagerQuery.UpdateManager, connection);
                if (name == "")
                {
                    command.Parameters.Add(new NpgsqlParameter("@name", manager.Name));
                }
                else
                {
                    command.Parameters.Add(new NpgsqlParameter("@name", name));
                }
                if (post == "")
                {
                    command.Parameters.Add(new NpgsqlParameter("@post", manager.Post));
                }
                else
                {
                    command.Parameters.Add(new NpgsqlParameter("@post", post));
                }
                //command.Parameters.Add(new NpgsqlParameter("@name", manager.Name));
                //command.Parameters.Add(new NpgsqlParameter("@post", manager.Post));
                command.Parameters.Add(new NpgsqlParameter("@id", manager.Id));
                int m = command.ExecuteNonQuery();
            }
        }
    }
}
