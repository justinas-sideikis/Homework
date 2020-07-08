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

        public Manicipality AddManicipality(Manicipality manicipalityToCreate)
        {
            _homeworkDbContext.Add(manicipalityToCreate);

            _homeworkDbContext.SaveChanges();

            return manicipalityToCreate;
        }

        public Task<Manicipality> GetManicipalityByName(string name)
        {
            return _homeworkDbContext.Manicipalities.SingleOrDefaultAsync(m => m.Name == name);
        }
    }
}
