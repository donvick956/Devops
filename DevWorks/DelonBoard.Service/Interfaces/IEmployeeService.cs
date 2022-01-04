using DelonBoard.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelonBoard.Service.Interfaces
{
    public interface IEmployeeService
    {
        string HoursOfWork { get; }
        string LineManager { get; }
        string WorkDays { get; }

        void DeleteById(Employee employee);
        void UpdateById(Employee employee);
        IEnumerable<Employee> GetAllAsync();
        Employee GetByIdAsync(int employeeId);
        void CreateEmployee(Employee employee);
        List<Employee> SearchEmployee(string keyword);
    }
}