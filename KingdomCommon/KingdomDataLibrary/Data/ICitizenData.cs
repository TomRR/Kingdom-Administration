using KingdomDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingdomDataLibrary.Data
{
    public interface ICitizenData
    {
        Task<List<CitizenModel>> GetCitizen();
        Task<int> CreateCitizen(CitizenModel citizen);
        Task<int> DeleteCitizen(int citizenId);
        Task<CitizenModel> GetCitizenById(int citizenId);
        Task<int> UpdateCitizenName(int citizenId, string citizenName);
    }
}