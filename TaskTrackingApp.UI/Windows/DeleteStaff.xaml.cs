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
    /// Логика взаимодействия для DaleteStaff.xaml
    /// </summary>
    public partial class DeleteStaff : Window
    {
        public DeleteStaff()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<StaffDto> staffs = new StaffRepository().GetAllStaff();
            comboBoxNameStaff.ItemsSource = staffs;
            

        }

        

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            StaffDto staff = (StaffDto)comboBoxNameStaff.SelectedItem;
            try
            {
                if (MessageBox.Show($"Вы действительно хотите удалить сотрудника {staff.Name}?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    new StaffRepository().DeleteStaff(staff.Id);
                }
                //new StaffRepository().DeleteStaff(staff.Id);
            }
            catch (Npgsql.PostgresException ex) when (ex.SqlState == "23503")
            {
                MessageBox.Show("Данную запись удалить невозможно так как есть связанные с ней записи.");
            }
            
            this.Close();
        }
    }
}
