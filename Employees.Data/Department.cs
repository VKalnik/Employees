using System.ComponentModel.DataAnnotations;

namespace Employees.Data
{
    public enum Department
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
