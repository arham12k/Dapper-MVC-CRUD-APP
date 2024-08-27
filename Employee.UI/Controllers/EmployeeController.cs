using EmployeeDapper.Data.Models;
using EmployeeDapper.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDapper.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(employee);
                bool addEmployeeResult = await _employeeRepo.AddAsync(employee);
                if (addEmployeeResult)
                    TempData["msg"] = "Successfully added";
                else
                    TempData["msg"] = "Could not added";
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added";
            }
            return RedirectToAction(nameof(DisplayAll));
        }




        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeRepo.GetByIdAsync(id);
            //if (person == null)
            //    return NotFound();
            return View(employee);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employee= await _employeeRepo.GetByIdAsync(id);
            //if (person == null)
            //    return NotFound();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(employee);
                var updateResult = await _employeeRepo.UpdateAsync(employee);
                if (updateResult)
                    TempData["msg"] = "Updated succesfully";
                else
                    TempData["msg"] = "Could not updated";

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not updated";
            }
            /*return RedirectToAction(nameof(DisplayAll));*/
            return View(employee);
        }





        public async Task<IActionResult> DisplayAll()
        {
            var employees = await _employeeRepo.GetAllAsync();
            return View(employees);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var deleteResult = await _employeeRepo.DeleteAsync(id);
            return RedirectToAction(nameof(DisplayAll));
        }
    }
}
