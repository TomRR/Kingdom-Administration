using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    interface IWeaponData
    {
        Task<List<WeaponModel>> GetWeapon();
    }
}