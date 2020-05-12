using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class TribeData : ITribeData
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
    }
}
