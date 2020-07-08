using Homework.Database.Repositories.Interfaces;
using Homework.Exceptions;
using Homework.Logic.Interface;
using Homework.Models;
using Homework.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Homework.Logic
{
    public class ManicipalityLogic : IManicipalityLogic
    {
        private readonly ITaxesRepository _taxesRepository;
        private readonly IManicipalityRepository _manicipalityRepository;

        public ManicipalityLogic(ITaxesRepository taxesRepository, IManicipalityRepository manicipalityRepository)
        {
            _taxesRepository = taxesRepository;
            _manicipalityRepository = manicipalityRepository;
        }

        public async Task AddTaxesFromFile(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {

                if (reader.Peek() < 0)
                {
                    throw new FileReaderException();
                }

                try
                {
                    var manicipalityName = await reader.ReadLineAsync();
                    var manicipality = await _manicipalityRepository.GetManicipalityByName(manicipalityName);

                    if (manicipality == null)
                    {
                        var manicipalityToCreate = new Manicipality
                        {
                            Name = manicipalityName
                        };

                        manicipality = _manicipalityRepository.AddManicipality(manicipalityToCreate);

                        if (manicipality.Id == Guid.Empty)
                        {
                            throw new Exception();
                        }
                    }

                    while (reader.Peek() >= 0)
                    {
                        var line = await reader.ReadLineAsync();

                        var data = line.Split(',');

                        var taxToCreate = new Tax
                        {
                            ManicipalityId = manicipality.Id,
                            Period = Enum.Parse<TaxPeriod>(data[0]),
                            Rate = double.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture),
                            Start = DateTime.Parse(data[2]),
                            End = DateTime.Parse(data[3])
                        };

                        _taxesRepository.AddTax(taxToCreate);
                    }
                }
                catch
                {
                    throw new FileReaderException();
                }
            }
        }
    }
}
