using Application.Interface;
using Core.Entities;
using Core.Request;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDropDownRepository _DropDownRepository;

        public EmployeeController(IUnitOfWork unitOfWork, IDropDownRepository dropDownRepository)
        {
            this.unitOfWork = unitOfWork;
            _DropDownRepository = dropDownRepository;
        }


        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            var upcoming_birthdays = await unitOfWork.EmployeeRepository.UpcomingBirthdays();
            var employees = await unitOfWork.EmployeeRepository.GetAllAsync();
            ViewBag.upcoming_birthdays = upcoming_birthdays;
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(id);
            return View(employee);
        }

        // GET: EmployeeController/Create
        public async Task<ActionResult> Create()
        {
            var contry = await _DropDownRepository.GetAllCountries();
            ViewBag.country = contry.Select(c => new SelectListItem
            {
                Value = c.CountryId.ToString(),
                Text = c.CountryName
            }).ToList();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await unitOfWork.EmployeeRepository.AddAsync(request);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(id);
            var contry = await _DropDownRepository.GetAllCountries();
            var state = await _DropDownRepository.GetStatesByCountry(employee.CountryId);

            ViewBag.country = contry.Select(c => new SelectListItem
            {
                Value = c.CountryId.ToString(),
                Text = c.CountryName
            }).ToList();
            ViewBag.state = state.Select(c => new SelectListItem
            {
                Value = c.StateId.ToString(),
                Text = c.StateName
            }).ToList();

            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Employee request)
        {
            try
            {
                await unitOfWork.EmployeeRepository.UpdateAsync(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await unitOfWork.EmployeeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction();
            }
            catch
            {
                return View();
            }
        }
    }
}
