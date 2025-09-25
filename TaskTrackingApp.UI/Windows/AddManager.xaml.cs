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
    /// Логика взаимодействия для AddManager.xaml
    /// </summary>
    public partial class AddManager : Window
    {
        public AddManager()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerDto manager = new ManagerDto();
            manager.Name = nameTextBox.Text;
            manager.Post = postTextBox.Text;
            int m = new ManagerRepository().AddManager(manager);
            this.Close();
        }
    }
}
