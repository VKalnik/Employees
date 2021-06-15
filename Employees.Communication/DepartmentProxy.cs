using System.ComponentModel.DataAnnotations;

namespace Employees.Communication
{
    public enum DepartmentProxy
    {
        [Display(Description = "Основной")]
        General = 0,
        [Display(Description = "Производственный")]
        Industrial = 1,
        [Display(Description = "Персонала")]
        Personal = 2,
        [Display(Description = "Финансов")]
        Financial = 3,
    }
}
