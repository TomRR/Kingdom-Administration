using DataLibrary.Models;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface ICitizenData
    {
        Task<int> CreateCitizen(CitizenModel citizen);
        Task<int> DeleteCitizen(int orderId);
        Task<CitizenModel> GetCitizenById(int orderId);
        Task<int> UpdateCitizenName(int orderId, string orderName);
    }
}