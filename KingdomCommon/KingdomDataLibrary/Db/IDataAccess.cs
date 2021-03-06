﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingdomDataLibrary.Db
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
    }
}
