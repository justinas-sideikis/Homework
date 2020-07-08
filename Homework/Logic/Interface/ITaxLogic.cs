using Homework.ViewModels;
using System;
using System.Threading.Tasks;

namespace Homework.Logic.Interface
{
    public interface ITaxesLogic
    {
        Task<double?> GetTaxByManicipalityAndDate(string manicipalityName, DateTime date);
    }
}
