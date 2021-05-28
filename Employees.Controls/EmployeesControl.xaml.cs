﻿using Employees.Communication.EmployeesService;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;


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
