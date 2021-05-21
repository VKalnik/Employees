using Employees.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Employees
{
    class EmployeeDatabase
    {
        private static string[] PHONE_PREFIX = { "906", "495", "499" }; // Префексы телефонных номеров
        private static int CHAR_BOUND_L = 65; // Номер начального символа (для генерации последовательности символов)
        private static int CHAR_BOUND_H = 90; // Номер конечного  символа (для генерации последовательности символов)

        private Random random = new Random();
        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeDatabase()
        {
            Employees = new ObservableCollection<Employee>();
            GenerateContacts(35);
        }

        private string GenerateSymbols(int amount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < amount; i++)
                stringBuilder.Append((char)(CHAR_BOUND_L + random.Next(CHAR_BOUND_H - CHAR_BOUND_L)));
            return stringBuilder.ToString();
        }

        private string GeneratePhone()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("+7").Append(PHONE_PREFIX[random.Next(3)]);
            for (int i = 0; i < 6; i++)
                stringBuilder.Append(random.Next(10));
            return stringBuilder.ToString();
        }

        private void GenerateContacts(int employeeCount)
        {
            Employees.Clear();

            string firstName = GenerateSymbols(random.Next(6) + 5);
            string lastName = GenerateSymbols(random.Next(6) + 5);
            string secondName = GenerateSymbols(random.Next(6) + 5);

            var locked = random.Next(0, 2) == 0 ? false : true;
            var departmentName = (Department)random.Next(0, 4);

            for (int i = 0; i < employeeCount; i++)
            {
                if (random.Next(2) == 0)
                {
                    firstName = GenerateSymbols(random.Next(6) + 5);
                    lastName = GenerateSymbols(random.Next(6) + 5);
                    secondName = GenerateSymbols(random.Next(6) + 5);
                    locked = random.Next(0, 2) == 0 ? false : true;
                    departmentName = (Department)random.Next(0, 4);
                }
                string phone = GeneratePhone();
                Employees.Add(new Employee(phone, firstName, lastName, secondName, locked, departmentName));
            }
        }

    }
}
