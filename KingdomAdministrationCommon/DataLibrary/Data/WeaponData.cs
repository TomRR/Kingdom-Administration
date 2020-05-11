using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    class WeaponData : IWeaponData
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
    }
}
