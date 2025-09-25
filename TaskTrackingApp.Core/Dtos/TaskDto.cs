using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingApp.Core.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrderStatus { get; set; } 
        //public int IdStatus { get; set; }
        public string NameManager { get; set; }
        public int IdManager { get; set; }
        public string NameStaff { get; set; }
        public int IdStaff {  get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime PeriodExecution {  get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
