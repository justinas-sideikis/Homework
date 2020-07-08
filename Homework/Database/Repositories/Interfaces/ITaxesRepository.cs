using Homework.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Homework.Database.Repositories.Interfaces
{
    public interface ITaxesRepository
    {
        Task<Tax> GetTax(Guid manicipalityId, DateTime date);
    }
}
