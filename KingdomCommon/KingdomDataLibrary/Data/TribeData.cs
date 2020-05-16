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
    class TribeData : ITribeData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public TribeData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<TribeModel>> GetTribe()
        {
            return _dataAccess.LoadData<TribeModel, dynamic>("dbo.spTribe_All",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }

        public async Task<int> CreateTribe(TribeModel tribe)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Name", tribe.Name);
            p.Add("ExistSince", tribe.ExistSince);
            p.Add("LeaderId", tribe.LeaderId);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spTribe_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateTribeName(int tribeId, string tribeName)
        {
            return _dataAccess.SaveData("dbo.spTribe_UpdateName",
                                        new
                                        {
                                            Id = tribeId,
                                            CitizenName = tribeName
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteTribe(int tribeId)
        {
            return _dataAccess.SaveData("dbo.spTribe_Delete",
                                        new
                                        {
                                            Id = tribeId
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public async Task<TribeModel> GetTribeById(int tribeId)
        {
            var recs = await _dataAccess.LoadData<TribeModel, dynamic>("dbo.spTribe_GetById",
                                                                       new
                                                                       {
                                                                           Id = tribeId
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
    }
}
