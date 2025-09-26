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
            //if (addManager.DialogResult == true)
            //{
            //    MessageBox.Show("Руководитель успешно добавлен");
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            //{
            //    connection.Open();
               
            //    //taskDataGrid.ItemsSource = tasks;
            //}
            List<TaskDto> tasks = new TaskRepository().GetAllTasks();
            taskDataGrid.ItemsSource = tasks;
            //MessageBox.Show("");

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
            
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            
            List<TaskDto> tasks = new TaskRepository().GetAllTasks();
            taskDataGrid.ItemsSource = tasks;
        }

        private void GetAllMegeTasks_Click(object sender, RoutedEventArgs e)
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
            //taskDataGrid.ItemsSource = 
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            timeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            dateTextBlock.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
}