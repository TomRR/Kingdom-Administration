using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
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
        public async Task<int> CreateCitizen(CitizenModel citizen)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("CitizenName", citizen.CitizenName);
            p.Add("Age", citizen.Age);
            p.Add("HairLength", citizen.HairLength);
            p.Add("Height", citizen.Height);
            p.Add("LeaderSince", citizen.LeaderSince);
            p.Add("Tax", citizen.Tax);
            p.Add("TribeId", citizen.TribeId);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spCitizen_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateCitizenName(int orderId, string orderName)
        {
            return _dataAccess.SaveData("dbo.spCitizen_UpdateName",
                                        new
                                        {
                                            Id = orderId,
                                            OrderName = orderName
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteCitizen(int orderId)
        {
            return _dataAccess.SaveData("dbo.spCitizen_Delete",
                                        new
                                        {
                                            Id = orderId
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public async Task<CitizenModel> GetCitizenById(int orderId)
        {
            var recs = await _dataAccess.LoadData<CitizenModel, dynamic>("dbo.spCitizen_GetById",
                                                                       new
                                                                       {
                                                                           Id = orderId
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
    }
}
