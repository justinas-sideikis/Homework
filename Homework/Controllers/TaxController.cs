using Homework.Exceptions;
using Homework.Logic.Interface;
using Homework.Models;
using Homework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Homework.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TaxController : Controller
    {
        private readonly ITaxesLogic _taxesLogic;

        public TaxController(ITaxesLogic taxesLogic)
        {
            _taxesLogic = taxesLogic;
        }

        [HttpPost]
        public async Task<IActionResult> GetTax(TaxGetRequestModel requestModel)
        {
            try
            {
                var result = await _taxesLogic.GetTaxByManicipalityAndDate(requestModel.Manicipality, requestModel.Date);

                return Ok(result);
            }
            catch(EntityNotFoundException<Manicipality>)
            {
                return BadRequest("error.manicipalityNotFound");
            }
            catch
            {
                return BadRequest("error.unknown");
            }
        }
    }
}
