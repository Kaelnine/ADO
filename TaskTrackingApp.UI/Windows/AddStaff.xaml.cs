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
    /// Логика взаимодействия для AddStaff.xaml
    /// </summary>
    public partial class AddStaff : Window
    {
        public AddStaff()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            StaffDto staff = new StaffDto();
            staff.Name = nameTextBox.Text;
            staff.Post = postTextBox.Text;
            int s = new StaffRepository().AddStaff(staff);
            this.Close();
        }
    }
}
