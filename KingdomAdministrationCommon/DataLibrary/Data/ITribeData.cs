using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    interface ITribeData
    {
        Task<List<TribeModel>> GetTribe();
    }
}