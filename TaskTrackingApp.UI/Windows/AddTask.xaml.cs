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
    /// Логика взаимодействия для AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ManagerDto> managers = new ManagerRepository().GetAllManagers();
            List<StaffDto> staffs = new StaffRepository().GetAllStaff();
            periodExecution.SelectedDate = DateTime.Now;
            nameManager.ItemsSource = managers;
            nameStaff.ItemsSource = staffs;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerDto manager = (ManagerDto)nameManager.SelectedItem;
            StaffDto staff = (StaffDto)nameStaff.SelectedItem;
            TaskDto task = new TaskDto();
            task.Name = nameTask.Text;
            task.Description = descriptionTask.Text;
            task.IdManager = manager.Id;
            task.IdStaff = staff.Id;
            task.AssignmentDate = DateTime.Now;
            task.PeriodExecution = (DateTime)periodExecution.SelectedDate;
            int t = new TaskRepository().AddTask(task);
            this.Close();
        }

        
    }
}
