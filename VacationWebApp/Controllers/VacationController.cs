using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationWebApp.DataContext;
using VacationWebApp.Models;

namespace VacationWebApp.Controllers
{
    public class VacationController : Controller
    {
        [HttpGet]
        public ActionResult CalculateAccLeaves()
        {
            var employeeDetailsModel = new EmployeeDataContext();
            ViewBag.Employees = employeeDetailsModel.GetEmployees();
            return View("WorkDay");
        }
        [HttpPost]
        public ActionResult CalculateAccLeaves(WorkDayModel model)
        {
            var employeeDetailsModel = new EmployeeDataContext();
            if (model != null && ModelState.IsValid)
            {
                var employee = employeeDetailsModel.GetEmployee(model.EmployeeId);
                if (employee != null)
                {
                    var accumlatedLeaves =employee.UpdateAccumulatedLeaves(model.WorkDays);
                    ViewBag.Message = $"Work days saved successfully! Acccumated leaves count : {accumlatedLeaves} as {employee.GetType().Name}";
                }
                else
                {
                    ViewBag.Message = "Employee Id does not exists!";
                }
            }
            else
            {
                ViewBag.Message = "Invalid Input!";
            }
            ViewBag.Employees = employeeDetailsModel.GetEmployees();
            return View("WorkDay");
        }

        [HttpGet]
        public ActionResult UpdateVacationDays()
        {
            var employeeDetailsModel = new EmployeeDataContext();
            ViewBag.Employees = employeeDetailsModel.GetEmployees();
            return View("Vacationday");
        }
        [HttpPost]   
        public ActionResult UpdateVacationDays(VacationModel model)
        {
            var employeeDetailsModel = new EmployeeDataContext();
            if (ModelState.IsValid)
            {
                var employee = employeeDetailsModel.GetEmployee(model.EmployeeId);
                if (employee != null)
                {
                    var result = employee.TakeVacation(model.VacationDays);
                    if (result)
                        ViewBag.Message = $"Vacation days updated successfully!";
                    else
                        ViewBag.Message = $"Vacation days update failed!";

                    ViewBag.Message += $"Total Availed Leaves : {employee.AvailedVacationDays}, Balance : {employee.LeaveBalances} as {employee.GetType().Name}";
                }
                else
                {
                    ViewBag.Message = "Employee Id does not exists!";
                }
            }
            else
            {
                ViewBag.Message = "Invalid Input!";
            }
            ViewBag.Employees = employeeDetailsModel.GetEmployees();
            return View("Vacationday");
        }
       
       
    }
}
