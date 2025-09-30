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
            statusTask.Text = _task.OrderStatus;      
            nameManager.Text = _task.NameManager;
            nameStaff.Text = _task.NameStaff;
            string datePeriodExecution = _task.PeriodExecution.ToString("yyyy-MM-dd");
            periodExecution.SelectedDate = DateTime.Parse(datePeriodExecution);
            string dateCompletionDate = _task.CompletionDate.ToString("yyyy-MM-dd");
            completionDate.SelectedDate = DateTime.Parse(dateCompletionDate);
        }

        private void UpdateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskDto task = new TaskDto();
            task.Id = _task.Id;
            task.Name = nameTask.Text;
            task.Description = descriptionTask.Text;
            var selectedItemStatus = statusTask.SelectedItem as TaskStatusDto;
            if (selectedItemStatus != null)
            {                
                task.IdStatus = selectedItemStatus.Id;
            }            
            var selectedItemManager = nameManager.SelectedItem as ManagerDto;
            if (selectedItemManager != null)
            {
                task.IdManager = selectedItemManager.Id;
            }            
            var selectedItemStaff = nameStaff.SelectedItem as StaffDto;
            if (selectedItemStaff != null)
            {
                task.IdStaff = selectedItemStaff.Id;
            }            
            task.AssignmentDate = _task.AssignmentDate;            
            task.PeriodExecution = (DateTime)periodExecution.SelectedDate;
            task.CompletionDate = (DateTime)completionDate.SelectedDate;
            new TaskRepository().UpdateTask(task);
            
            this.Close();
 
        }

        
    }
}
