using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Homework.Logic.Interface
{
    public interface IManicipalityLogic
    {
        Task AddTaxesFromFile(IFormFile file);
    }
}
