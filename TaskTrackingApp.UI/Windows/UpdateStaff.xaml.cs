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
    /// Логика взаимодействия для UpdateStaff.xaml
    /// </summary>
    public partial class UpdateStaff : Window
    {
        public UpdateStaff()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<StaffDto> staffs = new StaffRepository().GetAllStaff();
            comboBoxNameStaff.ItemsSource = staffs;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            StaffDto staff = (StaffDto)comboBoxNameStaff.SelectedItem;
            try
            {
                if (MessageBox.Show($"Вы действительно хотите изменить сотрудника {staff.Name}?", "Подтверждение изменения", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    new StaffRepository().UpdateStaff(staff, nameTextBox.Text, postTextBox.Text);
                }

            }
            catch (Npgsql.PostgresException ex) when (ex.SqlState == "23503")
            {
                MessageBox.Show("Данную запись изменить невозможно так как есть связанные с ней записи.");
            }

            this.Close();
        }
    }
}
