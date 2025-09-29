using Npgsql;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TaskTrackingApp.Core;
using TaskTrackingApp.Core.Dtos;
using TaskTrackingApp.DAL;
using TaskTrackingApp.UI.Windows;

namespace TaskTrackingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void AddManager_Click(object sender, RoutedEventArgs e)
        {
            AddManager addManager = new AddManager();
            addManager.ShowDialog();   

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<TaskDto> tasks = new TaskRepository().GetAllTasks();
            taskDataGrid.ItemsSource = tasks;
            

        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            AddStaff addStaff = new AddStaff();
            addStaff.ShowDialog();
        }

        private void DeleteManager_Click(object sender, RoutedEventArgs e)
        {
            DeleteManager deleteManager = new DeleteManager();
            deleteManager.ShowDialog();
        }

        private void DeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            DeleteStaff deleteStaff = new DeleteStaff();
            deleteStaff.ShowDialog();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTask addTask = new AddTask();
            addTask.ShowDialog();
        }

        private void UpdateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateTask task = new UpdateTask();
            task._task = (TaskDto)taskDataGrid.SelectedItem;
            task.ShowDialog();
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskDto task = (TaskDto)taskDataGrid.SelectedItem;
            try
            {
                if (MessageBox.Show($"Вы действительно хотите удалить задачу \"{task.Name}\"?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    new TaskRepository().DeleteTask(task.Id);
                }

            }
            catch (Npgsql.PostgresException ex) when (ex.SqlState == "23503")
            {
                MessageBox.Show("Данную запись удалить невозможно так как есть связанные с ней записи.");
            }

            
        }

        private void RefreshDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            
            List<TaskDto> tasks = new TaskRepository().GetAllTasks();
            taskDataGrid.ItemsSource = tasks;
        }

        private void GetAllMergeTasks_Click(object sender, RoutedEventArgs e)
        {
            GetAllMergeTasks getAllMergeTasks = new GetAllMergeTasks();
            getAllMergeTasks.DataChanged += GetAllMergeTasks_DataChanged;
            getAllMergeTasks.ShowDialog();
        }

        private void GetAllMergeTasks_DataChanged(object? sender, GetAllMergeTasks.DataEventArgs e)
        {
            //throw new NotImplementedException();
            List<TaskDto> tasks = e._tasks;
            taskDataGrid.ItemsSource = tasks;             
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            timeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            dateTextBlock.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void UpdateManager_Click(object sender, RoutedEventArgs e)
        {
            UpdateManager updateManager = new UpdateManager();
            updateManager.ShowDialog();
        }

        private void UpdateStaff_Click(object sender, RoutedEventArgs e)
        {
            UpdateStaff updateStaff = new UpdateStaff();
            updateStaff.ShowDialog();
        }

        
    }
}