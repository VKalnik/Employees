using Employees.Communication.EmployeesService;
using System.Collections.ObjectModel;


namespace Employees
{
    class EmployeeDatabase
    {
        EmployeesServiceSoapClient employeesServiceSoapClient = new EmployeesServiceSoapClient();

        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeDatabase()
        {
            Employees = new ObservableCollection<Employee>();
            Load();
        }

        public int Add(Employee employee)
        {
            var res = employeesServiceSoapClient.Add(employee);
            if (res > 0)
            {
                Employees.Add(employee);
            }
            return res;
        }

        public int Update(Employee employee)
        {
            return employeesServiceSoapClient.Update(employee);
        }

        public int Remove(Employee employee)
        {
            var res = employeesServiceSoapClient.Remove(employee);
            if (res > 0)
            {
                Employees.Remove(employee);
            }
            return res;
        }

        private void Load()
        {
            foreach (var employee in employeesServiceSoapClient.Load())
            {
                Employees.Add(employee);
            }
        }
    }
}
