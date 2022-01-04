using DelonBoard.Entity.Models;
using DelonBoard.Persistence.Data;
using DelonBoard.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DelonBoard.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeServices;
        private readonly IHRServices _HRServices;

        public EmployeeController(IEmployeeService employeeServices, IHRServices HRServices)
        {
            _HRServices = HRServices;
            _employeeServices = employeeServices;
        }

        public IActionResult GetAll()
        {
            IEnumerable<Employee> employees = _employeeServices.GetAllAsync();
            return View(employees);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _employeeServices.CreateEmployee(obj);
                _HRServices.SendOfferLetter(obj.EmployeeID);
                return RedirectToAction("GetAll");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var employee = _employeeServices.GetByIdAsync((int)id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _employeeServices.UpdateById(obj);
                return RedirectToAction("GetAll");
            }
            return View(obj);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _employeeServices.GetByIdAsync((int)id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee obj)
        {
            _employeeServices.DeleteById(obj);
            return RedirectToAction("GetAll");
        }

        //GET - VIEW
        public IActionResult View(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _employeeServices.GetByIdAsync((int)id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //GET- SEARCH 
        public IActionResult Search(string searching)
        {
            List<Employee> Values = _employeeServices.SearchEmployee(searching);
            return View(Values);
        }
    }
}