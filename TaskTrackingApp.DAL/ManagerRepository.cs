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
                command.Parameters.Add(new NpgsqlParameter("@id", id));
                NpgsqlDataReader reader = command.ExecuteReader();

                //закрывашка
                List<TaskDto> tasks = new List<TaskDto>();
                return tasks;
                //
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
                command.Parameters.Add(new NpgsqlParameter("id", id));
                int m = command.ExecuteNonQuery();
            }
        }
    }
}
