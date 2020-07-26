using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }        
        
        [Route("[action]")]
        [Route("~/")] // Makes List(), the default action
        public ViewResult Index()
        {
            var model =_employeeRepository.GetAllEmployees();
            return View(model);
        }

        [Route("[action]/{id?}")]
        public ViewResult Details(int? Id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                PageTitle = "Employee Details",
                Employee = _employeeRepository.GetEmployee(Id??1)
            };

            return View(homeDetailsViewModel);
        }
    }
}
