using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Employees.Data
{
    /// <summary>
    /// Рабочий
    /// </summary>
    public class Employee : INotifyPropertyChanged, ICloneable
    {

        #region NotifyPropertyChange Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string phone;
        private string firstName;
        private string lastName;
        private string secondName;
        private string comment;
        private bool locked;
        private Department departmentName;

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone 
        {
            get { return phone; }
            set
            {
                phone = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string SecondName
        {
            get { return secondName; }
            set
            {
                secondName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Блокировка
        /// </summary>
        public bool Locked
        {
            get { return locked; }
            set
            {
                locked = value;
                NotifyPropertyChanged();
            }
        }
        /// <summary>
        /// Категория
        /// </summary>
        public Department DepartmentName
        {
            get { return departmentName; }
            set
            {
                departmentName = value;
                NotifyPropertyChanged();
            }
        }

        public string FIO
        {
            get { return $"{LastName} {FirstName} {SecondName}"; }
        }

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

        public override string ToString()
        {
            return $"{Phone} - {LastName} {FirstName} {LastName}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
