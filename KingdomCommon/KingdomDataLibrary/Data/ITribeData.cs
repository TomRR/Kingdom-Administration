using KingdomDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingdomDataLibrary.Data
{
    interface ITribeData
    {
        Task<int> CreateTribe(TribeModel tribe);
        Task<int> DeleteTribe(int tribeId);
        Task<List<TribeModel>> GetTribe();
        Task<TribeModel> GetTribeById(int tribeId);
        Task<int> UpdateTribeName(int tribeId, string tribeName);
    }
}