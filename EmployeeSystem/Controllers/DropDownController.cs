using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeSystem.Controllers
{
    public class DropDownController : Controller
    {
        private readonly IDropDownRepository _DropDownRepository;

        public DropDownController(IDropDownRepository dropDownRepository)
        {
            _DropDownRepository = dropDownRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GetContryByState(int CountryId)
        {
            var State = await _DropDownRepository.GetStatesByCountry(CountryId);
            return Json(State);
        }
    }
}
