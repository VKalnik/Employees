using Employees.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Employees
{
    class EmployeeDatabase
    {
        public const string ConnectionString = @"Data Source=ABIGOR-PC\SQLEXPRESS;Initial Catalog=Employees;User ID=EmployeeRoot;Password=12345";
        
        
        private static string[] PHONE_PREFIX = { "906", "495", "499" }; // Префексы телефонных номеров
        private static int CHAR_BOUND_L = 65; // Номер начального символа (для генерации последовательности символов)
        private static int CHAR_BOUND_H = 90; // Номер конечного  символа (для генерации последовательности символов)

        private Random random = new Random();
        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeDatabase()
        {
            Employees = new ObservableCollection<Employee>();
            LoadFromDatabase();
            //GenerateContacts(35);
            //SyncToDatabase();
        }

        //public void SyncToDatabase()
        //{
        //    foreach (var employee in Employees)
        //    {
        //        Add(employee);
        //    }
        //}

        public int Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                int locked = employee.Locked ? 1 : 0;
                string exp = $@"INSERT INTO Employees (Phone, LastName, FirstName, SecondName, Comment, Locked, DepartmentID)
                                VALUES ('{employee.Phone}', '{employee.LastName}', '{employee.FirstName}', '{employee.SecondName}', '{employee.Comment}', {locked}, {(int)employee.DepartmentName})";
                
                SqlCommand command = new SqlCommand(exp, connection);
                int res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    Employees.Add(employee);
                }
                return res;
            }
        }

        public int Update(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var locked = employee.Locked ? 1 : 0;
                string sqlExpression = $@"UPDATE Employees
                    SET LastName = '{employee.LastName}', FirstName = '{employee.FirstName}', SecondName = '{employee.SecondName}', Comment = '{employee.Comment}', Locked = {locked}, DepartmentId = {(int)employee.DepartmentName}
                    WHERE phone = '{employee.Phone}'";
                var command = new SqlCommand(sqlExpression, connection);
                return command.ExecuteNonQuery();
            }
        }

        public int Remove(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlExpression = $@"DELETE FROM Employees WHERE Phone = '{employee.Phone}'";
                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    Employees.Remove(employee);
                }
                return res;
            }
        }

        private void LoadFromDatabase()
        {
            string sqlExpression = "SELECT * FROM Employees";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee()
                            {
                                Phone = reader.GetValue(0).ToString(),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader.GetString(2),
                                SecondName = reader["SecondName"].ToString(),
                                Comment = reader["Comment"].ToString(),
                                Locked = reader.GetBoolean(5),
                                DepartmentName = (Department)reader.GetInt32(6)
                            };
                            Employees.Add(employee);
                        }
                    }
                }
            }
        }


        /*private string GenerateSymbols(int amount)
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
        }*/

    }
}
