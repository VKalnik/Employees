using Employees.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeDatabase database = new EmployeeDatabase();

        public ObservableCollection<Employee> EmployeeList { get; set; }
        
        public Employee SelectedEmployee { get; set; }        
        
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            EmployeeList = database.Employees;
     
        }

        private void employeesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if ( e.AddedItems.Count > 0)
            {
                employeeControl.Employee = (Employee)SelectedEmployee.Clone();
                //employeeControl.SetEmployee((Employee)e.AddedItems[0]);
            }

        }

        //private void UpdateBinding()
        //{
        //    employeesListView.ItemsSource = null;
        //    employeesListView.ItemsSource = database.Employees;
        //}

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (employeesListView.SelectedItems.Count < 1)
                return;
            if (database.Update(employeeControl.Employee) > 0)
            {
                EmployeeList[EmployeeList.IndexOf(SelectedEmployee)] = employeeControl.Employee;
                MessageBox.Show("Запись успешно обновлена", "Обновление записи", MessageBoxButton.OK, MessageBoxImage.Information);
            }

                //employeeControl.UpdateEmployee();
                //UpdateBinding();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEditor editor = new EmployeeEditor();
            if (editor.ShowDialog() == true)
            {
                if (database.Add(editor.Employee) > 0)
                {
                    MessageBox.Show("Запись успешно добавлена", "Добавление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                //database.Employees.Add(editor.Employee);
                //UpdateBinding();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            if (employeesListView.SelectedItems.Count > 0)
            {
                 if (MessageBox.Show("Вы действительно хотите удалить данные сотрудника?", "Удаление данных сотрудника.", MessageBoxButton.OKCancel, MessageBoxImage.Question)== MessageBoxResult.OK)
                {
                    if (database.Remove((Employee)employeesListView.SelectedItems[0]) > 0)
                    {
                        MessageBox.Show("Запись успешно удалена", "Удаление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    //database.Employees.Remove((Employee)employeesListView.SelectedItems[0]);
                    //UpdateBinding();
                }
            }
        }
    }
}
