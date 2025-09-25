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
    }
}
