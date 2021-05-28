using Employees.Communication.EmployeesService;
using Employees.Controls;
using System.Windows;


namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для EmployeeEditor.xaml
    /// </summary>
    public partial class EmployeeEditor : Window
    {
        private EditorType editorType;

        public Employee Employee { get; set; } = new Employee();

        public EmployeeEditor()
        {
            InitializeComponent();

            editorType = EditorType.Add;
            employeesControl.Employee = Employee;
            PrepareUI();
            
        }
        public EmployeeEditor(EditorType editorType)
        {
            InitializeComponent();

            this.editorType = editorType;
            employeesControl.Employee = Employee;
            PrepareUI();
        }

        private void PrepareUI()
        {
            switch (editorType)
            {
                case EditorType.Add:
                    this.Title = $"{this.Title} [Добавление]";
                    break;
                case EditorType.Edit:
                    this.Title = $"{this.Title} [Правка]";
                    break;
            }
            employeesControl.PrepareUI(editorType);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Сохранить данные нового сотрудника?", "Добавление нового сотрудника.", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                DialogResult = true;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
