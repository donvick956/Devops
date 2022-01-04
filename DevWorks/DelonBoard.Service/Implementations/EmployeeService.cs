using DelonBoard.Entity.Models;
using DelonBoard.Persistence.Data;
using DelonBoard.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelonBoard.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;

        #region Private Fields
        private string _hoursOfWork = "9:00 a.m. to 5:00 p.m.";
        private string _workDays = "Monday - Friday";
        private string _lineManager = "Hope Ndudim";
        #endregion

        #region Constructor
        public EmployeeService(ApplicationDbContext dbContext) => _dbContext = dbContext;
        #endregion

        #region Properties
        public string HoursOfWork => _hoursOfWork;
        public string WorkDays => _workDays;
        public string LineManager => _lineManager;
        #endregion

        #region Methods      
        public IEnumerable<Employee> GetAllAsync() => _dbContext.Employees.ToList();

        public void CreateEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public Employee GetByIdAsync(int employeeId) => _dbContext.Employees.Find(employeeId);

        // Implements the actual update
        public void UpdateById(Employee employee)
        {
            // Update DB with updated Employee information
            _dbContext.Employees.Update(employee);

            // Save changes to DB 
            _dbContext.SaveChanges();
        }

        public void DeleteById(Employee employee)
        {
            _dbContext.Employees.Remove(employee);

            // Save change to DB
            _dbContext.SaveChanges();
        }

        public List<Employee> SearchEmployee(string keyword)
        {
            return _dbContext.Employees.Where(x => x.LastName.Contains(keyword) || x.FirstName.Contains(keyword) || keyword == null).ToList();
        }


        //public async Task CreateEmployee(Employee employee)
        //{
        //    _dbContext.Employees.Add(employee);
        //    _dbContext.SaveChanges();
        //}

        //public async Task DeleteById(Employee employee)
        //{
        //    _dbContext.Employees.Remove(employee);

        //    // Save change to DB
        //    _dbContext.SaveChanges();
        //}

        //public async Task<IEnumerable<Employee>> GetAllAsync() => _dbContext.Employees.ToList();

        ////public Employee GetByIdAsync(int employeeId) => _dbContext.Employees.Find(employeeId);
        //public async Task<Employee> GetByIdAsync(int employeeId) => _dbContext.Employees.Find(employeeId);

        ////public List<Employee> SearchEmployee(string keyword) => _dbContext.Employees.Where(employee => employee.LastName.Contains(keyword) || employee.FirstName.Contains(keyword) || keyword == null).ToList();
        //public async Task<List<Employee>> SearchEmployee(string keyword) => _dbContext.Employees.Where(employee => employee.LastName.Contains(keyword) || employee.FirstName.Contains(keyword) || keyword == null).ToList();

        //public async Task UpdateById(Employee employee)
        //{
        //    // Update context with updated Employee information
        //    _dbContext.Employees.Update(employee);

        //    // Save changes to DB 
        //    _dbContext.SaveChanges();
        //}
        #endregion
    }
}