using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskTrackingApp.Core.Dtos;
using TaskTrackingApp.DAL;

namespace TaskTrackingApp.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateTask.xaml
    /// </summary>
    public partial class UpdateTask : Window
    {
        public TaskDto _task { get; set; }
        public UpdateTask()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ManagerDto> managers = new ManagerRepository().GetAllManagers();
            nameManager.ItemsSource = managers;
            List<StaffDto> staffs = new StaffRepository().GetAllStaff();
            nameStaff.ItemsSource = staffs;
            List<TaskStatusDto> taskStatuses = new TaskStatusRepository().GetAllTaskStatus();
            statusTask.ItemsSource = taskStatuses;
            textBlockNameTask.Text = _task.Name;
            nameTask.Text = _task.Name;
            descriptionTask.Text = _task.Description;
            statusTask.SelectedItem = _task.OrderStatus;
            nameManager.SelectedItem = _task.NameManager;
            nameStaff.SelectedItem = _task.NameStaff;
            periodExecution.DisplayDate = _task.PeriodExecution;
            completionDate.DisplayDate = _task.CompletionDate;
        }

        private void UpdateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskDto task = new TaskDto();
            task.Id = _task.Id;
            task.Name = textBlockNameTask.Text;
            task.Description = descriptionTask.Text;
            task.IdStatus = statusTask.SelectedIndex;
            task.IdManager = nameManager.SelectedIndex;
            task.IdStaff = nameStaff.SelectedIndex;
            task.AssignmentDate = _task.AssignmentDate;            
            task.PeriodExecution = (DateTime)periodExecution.SelectedDate;
            task.CompletionDate = (DateTime)completionDate.SelectedDate;
            new TaskRepository().UpdateTask(task);
            this.Close();
 //           UPDATE public."Tasks"
	//SET "NameTask"='ghhggj', "DescriptionTask"='hvmvhjvh', "OrderStatus"=2, "IdManager"=1, "IdStaff"=1, "AssignmentDateTask"='2025-01-01', "PeriodExecutionTask"='2025-01-01', "CompletionDateTask"='2025-01-01'
	//WHERE "IdTasks"=1;
        }
    }
}
