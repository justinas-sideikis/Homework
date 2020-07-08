using Homework.Exceptions;
using Homework.Logic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Homework.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ManicipalityController : Controller
    {
        private readonly IManicipalityLogic _manicipalityLogic;

        public ManicipalityController(IManicipalityLogic manicipalityLogic)
        {
            _manicipalityLogic = manicipalityLogic;
        }

        [HttpPost]
        public async Task<IActionResult> UploadTaxes(IFormFile file)
        {
            try
            {
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);

                if (fileExt != "csv")
                {
                    return BadRequest("error.unsuportedFileFormat");
                }

                await _manicipalityLogic.AddTaxesFromFile(file);

                return Ok();
            }
            catch (FileReaderException)
            {
                return BadRequest($"error.fileFormatInvalid");
            }
            catch
            {
                return StatusCode(400, "error.unknown");
            }
        }
    }
}
