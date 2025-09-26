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
    public class StaffRepository
    {
        public int AddStaff(StaffDto staff)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(StaffQuery.AddStaff, connection);
                command.Parameters.Add(new NpgsqlParameter("@name", staff.Name));
                command.Parameters.Add(new NpgsqlParameter("@post", staff.Post));
                int id = (int)command.ExecuteScalar();
                return id;
            }
        }

        public List<StaffDto> GetAllStaff()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(StaffQuery.GetAllStaff, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                List<StaffDto> staffs = new List<StaffDto>();
                while (reader.Read())
                {
                    StaffDto staff = new StaffDto()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Post = reader.GetString(2)
                    };
                    staffs.Add(staff);
                }
                return staffs;
            }
        }

        public void DeleteStaff(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(StaffQuery.DeleteStaff, connection);
                command.Parameters.Add(new NpgsqlParameter("id", id));
                int s = command.ExecuteNonQuery();
            }
        }
    }
}
