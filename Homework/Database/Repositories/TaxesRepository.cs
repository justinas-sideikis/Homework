using Homework.Database.Repositories.Interfaces;
using Homework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Database.Repositories
{
    public class TaxesRepository : ITaxesRepository
    {
        private readonly HomeworkDbContext _homeworkDbContext;

        public TaxesRepository(HomeworkDbContext homeworkDbContext)
        {
            _homeworkDbContext = homeworkDbContext;
        }

        public Task<Tax> GetTax(Guid manicipalityId, DateTime date)
        {
            return _homeworkDbContext.Taxes
                .Where(t => t.ManicipalityId == manicipalityId
                        && t.Start <= date
                        && t.End >= date)
                .OrderByDescending(t => t.Period)
                .FirstOrDefaultAsync();
        }
    }
}
