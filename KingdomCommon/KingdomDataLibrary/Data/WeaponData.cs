using Dapper;
using KingdomDataLibrary.Db;
using KingdomDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdomDataLibrary.Data
{
    public class WeaponData : IWeaponData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public WeaponData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<WeaponModel>> GetWeapon()
        {
            return _dataAccess.LoadData<WeaponModel, dynamic>("dbo.spWeapon_All",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }

        public async Task<int> CreateWeapon(WeaponModel weapon)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Typ", weapon.Typ);
            p.Add("MagicalValue", weapon.MagicalValue);
            p.Add("CitizenId", weapon.CitizenId);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spWeapon_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateMagicalValue(int weaponId, int magicalValue)
        {
            return _dataAccess.SaveData("dbo.spWeapon_UpdateMagicalValue",
                                        new
                                        {
                                            Id = weaponId,
                                            MagicalValue = magicalValue
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteWeapon(int weaponId)
        {
            return _dataAccess.SaveData("dbo.spWeapon_Delete",
                                        new
                                        {
                                            Id = weaponId
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public async Task<WeaponModel> GetWeaponById(int weaponId)
        {
            var recs = await _dataAccess.LoadData<WeaponModel, dynamic>("dbo.spWeapon_GetById",
                                                                       new
                                                                       {
                                                                           Id = weaponId
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
    }
}
