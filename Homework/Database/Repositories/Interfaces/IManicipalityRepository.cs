using Homework.Models;
using System.Threading.Tasks;

namespace Homework.Database.Repositories.Interfaces
{
    public interface IManicipalityRepository
    {
        Task<Manicipality> GetManicipalityByName(string name);
        Manicipality AddManicipality(Manicipality manicipalityToCreate);
    }
}
