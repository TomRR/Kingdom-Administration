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
    public class CitizenData : ICitizenData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public CitizenData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<CitizenModel>> GetCitizen()
        {
            return _dataAccess.LoadData<CitizenModel, dynamic>("dbo.spCitizen_All",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }

        public async Task<int> CreateCitizen(CitizenModel citizen)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Name", citizen.Name);
            p.Add("Age", citizen.Age);
            p.Add("HairLength", citizen.HairLength);
            p.Add("LeaderSince", citizen.LeaderSince);
            p.Add("Tax", citizen.Tax);
            p.Add("TribeId", citizen.TribeId);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spCitizen_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateCitizenName(int citizenId, string citizenName)
        {
            return _dataAccess.SaveData("dbo.spCitizen_UpdateName",
                                        new
                                        {
                                            Id = citizenId,
                                            CitizenName = citizenName
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteCitizen(int citizenId)
        {
            return _dataAccess.SaveData("dbo.spCitizen_Delete",
                                        new
                                        {
                                            Id = citizenId
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public async Task<CitizenModel> GetCitizenById(int citizenId)
        {
            var recs = await _dataAccess.LoadData<CitizenModel, dynamic>("dbo.spCitizen_GetById",
                                                                       new
                                                                       {
                                                                           Id = citizenId
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
    }
}
