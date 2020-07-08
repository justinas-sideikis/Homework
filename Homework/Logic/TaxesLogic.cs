using Homework.Database.Repositories.Interfaces;
using Homework.Exceptions;
using Homework.Logic.Interface;
using Homework.Models;
using Homework.Models.Enums;
using Homework.ViewModels;
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

        public async Task<bool> AddTax(TaxAddRequestModel requestModel)
        {
            var manicipality = await _manicipalityRepository.GetManicipalityByName(requestModel.Manicipality);

            if (manicipality == null)
            {
                var manicipalityToCreate = new Manicipality {
                    Name = requestModel.Manicipality
                };

                manicipality = _manicipalityRepository.AddManicipality(manicipalityToCreate);

                if (manicipality.Id == Guid.Empty)
                {
                    return false;
                }
            }

            var taxToCreate = new Tax
            {
                ManicipalityId = manicipality.Id,
                Period = requestModel.Period,
                Start = requestModel.Start,
                End = requestModel.End,
                Rate = requestModel.Rate
            };

            var tax = _taxesRepository.AddTax(taxToCreate);

            return tax.Id != Guid.Empty;
        }

        public async Task<double?> GetTaxByManicipalityAndDate(TaxGetRequestModel requestModel)
        {
            var manicipality = await _manicipalityRepository.GetManicipalityByName(requestModel.Manicipality);

            if (manicipality == null)
            {
                throw new EntityNotFoundException<Manicipality>();
            }

            var tax = await _taxesRepository.GetTax(manicipality.Id, requestModel.Date);

            if (tax == null)
            {
                return null;
            }

            return tax.Rate;
        }

    }
}
