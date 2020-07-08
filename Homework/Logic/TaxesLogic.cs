using Homework.Database.Repositories.Interfaces;
using Homework.Exceptions;
using Homework.Logic.Interface;
using Homework.Models;
using System;
using System.Threading.Tasks;

namespace Homework.Logic
{
    public class TaxesLogic : ITaxesLogic
    {
        private readonly ITaxesRepository _taxesRepository;
        private readonly IManicipalityRepository _manicipalityRepository;

        public TaxesLogic(ITaxesRepository taxesRepository, IManicipalityRepository manicipalityRepository)
        {
            _taxesRepository = taxesRepository;
            _manicipalityRepository = manicipalityRepository;
        }

        public async Task<double?> GetTaxByManicipalityAndDate(string manicipalityName, DateTime date)
        {
            var manicipality = await _manicipalityRepository.GetManicipalityByName(manicipalityName);

            if (manicipality == null)
            {
                throw new EntityNotFoundException<Manicipality>();
            }

            var tax = await _taxesRepository.GetTax(manicipality.Id, date);

            if (tax == null)
            {
                return null;
            }

            return tax.Rate;
        }

    }
}
