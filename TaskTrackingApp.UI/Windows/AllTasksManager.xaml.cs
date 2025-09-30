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
//using static TaskTrackingApp.UI.Windows.GetAllMergeTasks;

namespace TaskTrackingApp.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для AllTasksManager.xaml
    /// </summary>
    public partial class AllTasksManager : Window
    {
        public event EventHandler<DataEventArgs> DataChanged;
        public AllTasksManager()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ManagerDto> managers = new ManagerRepository().GetAllManagers();            
            comboBoxManager.ItemsSource = managers;            
        }

        private void ShowTaskButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerDto manager = (ManagerDto)comboBoxManager.SelectedItem;            
            List<TaskDto> tasks = new ManagerRepository().GetTasksByManagerId(manager.Id);
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
