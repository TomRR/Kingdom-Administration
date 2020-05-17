using KingdomDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingdomDataLibrary.Data
{
    public interface IWeaponData
    {
        Task<int> CreateWeapon(WeaponModel weapon);
        Task<int> DeleteWeapon(int weaponId);
        Task<List<WeaponModel>> GetWeapon();
        Task<WeaponModel> GetWeaponById(int weaponId);
        Task<int> UpdateWeaponName(int weaponId, int magicalValue);
    }
}