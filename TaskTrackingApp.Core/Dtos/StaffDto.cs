using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingApp.Core.Dtos
{
    public class StaffDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public List<TaskDto> Tasks { get; set; } = new List<TaskDto>();
    }
}
