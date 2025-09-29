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
    /// Логика взаимодействия для DeleteManager.xaml
    /// </summary>
    public partial class DeleteManager : Window
    {
        public DeleteManager()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ManagerDto> managers = new ManagerRepository().GetAllManagers();
            comboBoxNameManager.ItemsSource = managers;
            
            
        }

        

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerDto manager = (ManagerDto)comboBoxNameManager.SelectedItem;
            try
            {
                if (MessageBox.Show($"Вы действительно хотите удалить руководителя {manager.Name}?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {                    
                    new ManagerRepository().DeleteManager(manager.Id);
                }
                
            }
            catch (Npgsql.PostgresException ex) when (ex.SqlState == "23503")
            {
                MessageBox.Show("Данную запись удалить невозможно так как есть связанные с ней записи.");
            }
            
            this.Close();
            
        }
    }
}
