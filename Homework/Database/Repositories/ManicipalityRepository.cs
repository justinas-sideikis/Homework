using Homework.Database.Repositories.Interfaces;
using Homework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Homework.Database.Repositories
{
    public class ManicipalityRepository : IManicipalityRepository
    {
        private readonly HomeworkDbContext _homeworkDbContext;

        public ManicipalityRepository(HomeworkDbContext homeworkDbContext)
        {
            _homeworkDbContext = homeworkDbContext;
        }

        public Task<List<Manicipality>> GetManicipalities()
        {
            return _homeworkDbContext.Manicipalities.ToListAsync();
        }

        public Task<Manicipality> GetManicipalityByName(string name)
        {
            return _homeworkDbContext.Manicipalities.SingleOrDefaultAsync(m => m.Name == name);
        }
    }
}
