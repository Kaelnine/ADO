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
    }
}