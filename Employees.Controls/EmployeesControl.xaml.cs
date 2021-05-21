using Employees.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Employees.Controls
{
    /// <summary>
    /// Логика взаимодействия для EmployeesControl.xaml
    /// </summary>
    public partial class EmployeesControl : UserControl, INotifyPropertyChanged
    {
        private Employee employee;

        public Employee Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Department> DepartmentList { get; set; } = new ObservableCollection<Department>();

        public EmployeesControl()
        {
            InitializeComponent();

            this.DataContext = this;

            DepartmentList.Add(Department.General);
            DepartmentList.Add(Department.Industrial);
            DepartmentList.Add(Department.Personal);
            DepartmentList.Add(Department.Financial);
        }

        public void PrepareUI(EditorType editorType)
        {
            switch (editorType)
            {
                case EditorType.Add:
                    this.tbPhone.IsReadOnly = false;
                    this.tbPhone.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF")); /*#FFF1EFEF*/
                    break;
                case EditorType.Edit:
                    break;
            }
        }

        //public void SetEmployee(Employee employee)
        //{
        //    this.employee = employee;

        //    tbLastname.Text = employee.LastName;
        //    tbFirstname.Text = employee.FirstName;
        //    tbSecondname.Text = employee.SecondName;
        //    tbPhone.Text = employee.Phone;
        //    cbDepardment.SelectedItem = employee.DepartmentName;
        //    cbLocked.IsChecked = employee.Locked;
        //    tbComment.Text = employee.Comment;

        //}

        //public void UpdateEmployee()
        //{
        //    employee.LastName = tbLastname.Text;
        //    employee.FirstName = tbFirstname.Text;
        //    employee.SecondName = tbSecondname.Text;
        //    employee.Phone = tbPhone.Text;
        //    employee.DepartmentName = (Department)cbDepardment.SelectedItem;
        //    employee.Locked = (bool)cbLocked.IsChecked;
        //    employee.Comment = tbComment.Text;

        //}
        #region NotifyPropertyChange Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
