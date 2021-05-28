using Employees.Data;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Web.Services;

namespace Employees.WebService
{
    /// <summary>
    /// Сводное описание для EmployeesService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeesService : System.Web.Services.WebService
    {

        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EmployeesConnectionString"].ConnectionString;

        [WebMethod]
        public ObservableCollection<Employee> Load()
        {
            var employees = new ObservableCollection<Employee>();
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
                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }

        [WebMethod]
        public int Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                int locked = employee.Locked ? 1 : 0;
                string exp = $@"INSERT INTO Employees (Phone, LastName, FirstName, SecondName, Comment, Locked, DepartmentID)
                                VALUES ('{employee.Phone}', '{employee.LastName}', '{employee.FirstName}', '{employee.SecondName}', '{employee.Comment}', {locked}, {(int)employee.DepartmentName})";

                SqlCommand command = new SqlCommand(exp, connection);
                return command.ExecuteNonQuery();  
            }
        }

        [WebMethod]
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

        [WebMethod]
        public int Remove(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlExpression = $@"DELETE FROM Employees WHERE Phone = '{employee.Phone}'";
                var command = new SqlCommand(sqlExpression, connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
