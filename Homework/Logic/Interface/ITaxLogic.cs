using Homework.ViewModels;
using System.Threading.Tasks;

namespace Homework.Logic.Interface
{
    public interface ITaxesLogic
    {
        Task<double?> GetTaxByManicipalityAndDate(TaxGetRequestModel requestModel);
        Task<bool> AddTax(TaxAddRequestModel requestModel);
    }
}
