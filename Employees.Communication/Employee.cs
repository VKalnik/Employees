using System;


namespace Employees.Communication.EmployeesService
{
    public partial class Employee : ICloneable
    {

        #region Constructors

        public Employee() { }

        public Employee(string phone, string firstName, string lastName, string secondName)
        {
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
        }

        public Employee(string phone, string firstName, string lastName, string secondName, bool locked, Department departmentName)
        {
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;

            Locked = locked;
            DepartmentName = departmentName;
        }


        #endregion
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
