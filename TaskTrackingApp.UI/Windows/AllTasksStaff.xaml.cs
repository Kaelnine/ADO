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
    /// Логика взаимодействия для AllTasksStaff.xaml
    /// </summary>
    public partial class AllTasksStaff : Window
    {
        public event EventHandler<DataEventArgs> DataChanged;
        public AllTasksStaff()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<StaffDto> staffs = new StaffRepository().GetAllStaff();            
            comboBoxStaff.ItemsSource = staffs;
        }

        private void ShowTaskButton_Click(object sender, RoutedEventArgs e)
        {
            StaffDto staff = (StaffDto)comboBoxStaff.SelectedItem;
            List<TaskDto> tasks = new StaffRepository().GetTasksByStaffId(staff.Id);
            DataChanged?.Invoke(this, new DataEventArgs(tasks));
            this.Close();
        }

        public class DataEventArgs : EventArgs
        {
            public List<TaskDto> _tasks;
            public DataEventArgs(List<TaskDto> tasks)
            {
                _tasks = tasks;
            }
        }
    }
}
